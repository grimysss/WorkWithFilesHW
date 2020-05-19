using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Controls
{
	/// <summary> Контролер для видеопроигрывателя. </summary>
	public class VideoPlayerControler
	{
		#region Data

		private List<string> _listImage;
		private int _curerntImage;
		private int _countImage;

		private ProjectSettings _projectSettings;
		private LogControler _logControler;

		private VideoCapture _capture;
		private int _fps;

		private bool _pause;
		private bool _stop;
		private string _fileStart;

		#endregion

		#region Event

		/// <summary> Вызывается при  изменении картинки. </summary>
		public event EventHandler<string> ChangeImage;

		/// <summary> Вызывается при  изменении кадра. </summary>
		public event EventHandler<Mat> ChangeFrame;

		#endregion

		#region Handler

		/// <summary> Обработчик события изменения картинки на панели. </summary>
		/// <param name="path"> Путь к картинке. </param>
		private void OnChangeImage(string path)
		{
			if(ChangeImage != null)
			{
				ChangeImage.Invoke(null, path);
			}
		}

		/// <summary> Обработчик события изменения кадра. </summary>
		/// <param name="image"> Кадр. </param>
		private void OnChangeFrame(Mat image)
		{
			if(ChangeFrame != null)
			{
				ChangeFrame.Invoke(null, image);
			}
		}

		#endregion

		#region .ctor

		/// <summary> Создает контролер для видеопроигрывателя. </summary>
		public VideoPlayerControler(
			ProjectSettings projectSettings,
			LogControler logControler)
		{
			_projectSettings = projectSettings;
			_logControler = logControler;
		}

		#endregion

		#region MethodsImage

		/// <summary> Открыть одну картинку. </summary>
		/// <param name="path">Путь к картинке. </param>
		public void OpenImage(string path)
		{
			AddImageOnControl(path);
		}

		/// <summary> Открыть директорию с картинками. </summary>
		/// <param name="path"> Путь к директории. </param>
		public void OpenFolderWithImages(string path)
		{
			IEnumerable<string> _filesDirectory = null;

			if(_projectSettings.IsUnderCatalog)
			{
				_filesDirectory = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
				   .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".jpeg"));
			}
			else
			{
				_filesDirectory = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
					.Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".jpeg"));
			}


			_listImage = _filesDirectory.ToList();

			_curerntImage = 0;
			_countImage = _filesDirectory.Count();

			// Проверяем наличие файлов с нужным расширением.
			if(_countImage != 0)
			{
				AddImageOnControl(_listImage[_curerntImage]);
				_logControler.AddMessage($"{_curerntImage} {_countImage}");
				}
			else
			{
				_logControler.AddMessage("Изображений не обнаружено!");
			}

		}

		/// <summary> Добавить картинку на Контрол. </summary>
		/// <param name="path"> Путь к картинке. </param>
		private void AddImageOnControl(string path)
		{
			OnChangeImage(path);
		}

		/// <summary> Переход к следующей картинке. </summary>
		public void NextImage()
		{
			if(_listImage != null && _listImage.Count != 0)
			{
				_curerntImage++;
				if(_curerntImage == _countImage)
				{
					_curerntImage = 0;
				}
				AddImageOnControl(_listImage[_curerntImage]);
				_logControler.AddMessage($"{_curerntImage} {_countImage}");
			}
		}

		/// <summary> Переход на предыдущую картинку. </summary>
		public void PreviousImage()
		{
			if(_listImage != null && _listImage.Count != 0)
			{
				_curerntImage--;
				if(_curerntImage <= 0)
				{
					_curerntImage = _countImage -1;
				}
				AddImageOnControl(_listImage[_curerntImage]);
				_logControler.AddMessage($"{_curerntImage} {_countImage}");
			}
		}

		#endregion

		#region MethodsVideo
		/// <summary> Открыть видео. </summary>
		/// <param name="path"></param>
		public void OpenVideo(string path)
		{
			if(_capture != null) _capture.Dispose();

			_fileStart = path;
			_capture = new VideoCapture(path);
			_fps = (int)(1000 / _capture.Fps);
			using(Mat image = new Mat())
			{
				_capture.Read(image);
				if(!image.Empty())
				{
					NextFrameAddInVideoControl(image);
					_pause = false;
				}
				else
				{
					_logControler.AddMessage("Некорректное видео!");
				}

			}
		}

		/// <summary> Воспроизвести видео. </summary>
		public void PlayVideo()
		{
			if(_pause) _pause = false;
			if(_stop) _stop = false;

			while(true)
			{
				if(_capture != null)
				{
					if(_pause || _stop)
					{
						_pause = false;
						_stop = false;
						break;
					}
					using(Mat image = new Mat())
					{
						_capture.Read(image);
						if(image.Empty())
						{
							_logControler.AddMessage("Конец видео!");
							break;
						}
						NextFrameAddInVideoControl(image);
						Cv2.WaitKey(_fps);

						//Cv2.WaitKey(0);
					}
				}
				else
				{
					break;
				}
			}
		}

		/// <summary> Остановить видео. </summary>
		public void StopVideo()
		{
			if(_capture != null)
			{
			_stop = true;
			_capture.Dispose();
			OpenVideo(_fileStart);
			}
		}

		/// <summary> Пауза в видео. </summary>
		public void PauseVideo()
		{
			if(_capture != null) _pause = true;
		}

		/// <summary> Отобразить следующий кадр. </summary>
		/// <param name="image"></param>
		private void NextFrameAddInVideoControl(Mat image)
		{
			OnChangeFrame(image);
		}

		#endregion

	}
}
