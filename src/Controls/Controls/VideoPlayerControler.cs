using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
	/// <summary> Контролер для видеопроигрывателя. </summary>
	public class VideoPlayerControler
	{
		#region Data

		private List<string> _listImage;
		private int _curerntIamge;
		private int _countImage;

		private ProjectSettings _projectSettings;
		private LogControler _logControler;

		#endregion

		#region Event

		/// <summary> Вызывается при  изменении картинки. </summary>
		public event EventHandler<string> ChangeImage;

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

		#region Methods

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

			_curerntIamge = 0;
			_countImage = _filesDirectory.Count();

			AddImageOnControl(_listImage[_curerntIamge]);
			_logControler.AddMessage($"{_curerntIamge} {_countImage}");
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
				_curerntIamge++;
				if(_curerntIamge == _countImage)
				{
					_curerntIamge = 0;
				}
				AddImageOnControl(_listImage[_curerntIamge]);
				_logControler.AddMessage($"{_curerntIamge} {_countImage}");
			}
		}

		/// <summary> Переход на предыдущую картинку. </summary>
		public void PreviousImage()
		{
			if(_listImage != null && _listImage.Count != 0)
			{
				_curerntIamge--;
				if(_curerntIamge == -1)
				{
					_curerntIamge = _countImage -1;
				}
				AddImageOnControl(_listImage[_curerntIamge]);
				_logControler.AddMessage($"{_curerntIamge} {_countImage}");
			}
		}

		#endregion
	}
}
