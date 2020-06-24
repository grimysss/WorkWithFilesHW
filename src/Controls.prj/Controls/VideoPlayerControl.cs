using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Controls
{
    /// <summary> Контрол видеопроигрывателя. </summary>
    public partial class VideoPlayerControl : UserControl
	{
		#region Data

		private LogControler _logControler;
		private VideoPlayerControler _videoPlayerControler;
		private ProjectSettings _projectSettings;
		private Detector _detector;

		#endregion

		#region .ctor

		/// <summary> Создает контрол видеопроигрывателя. </summary>
		/// <param name="logControler"> Контролер лога. </param>
		/// <param name="videoPlayerControler"> Контролер видеопроигрывателя. </param>
		/// <param name="projectSettings"> Контролер настроек. </param>

		public VideoPlayerControl(
			LogControler logControler,
			VideoPlayerControler videoPlayerControler,
			ProjectSettings projectSettings)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;

			_logControler = logControler;
			_videoPlayerControler = videoPlayerControler;
			_projectSettings = projectSettings;

			_videoPlayerControler.ChangeImage += OnChangeImage;

			_videoPlayerControler.ChangeFrame += OnChangeFrame;

			_opnFileDialog.Filter = "Image|*.png; *.jpg|Video|*.mp4; *.avi;";

			_detector = new Detector(logControler);
		}

		private void OnChangeFrame(object sender, Mat image)
		{
			using (var img = new Mat())
			{

				if (_projectSettings.IsDetector)
				{

					// В целом на моих примерах по эффективности все схожи, нужно тестировать на других видео.
					Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Cubic);
					//Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Linear);
					//Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Area);
					//Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Lanczos4);

					// Сохраняет скорость, но сильно падает качество.
					//Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Nearest);

					//_picVideo.Image = BitmapConverter.ToBitmap(img);
					//_picVideo.Image = BitmapConverter.ToBitmap(image);

					//_picVideo.ImageIpl = image;
					_picVideo.Image = _detector.Detect(img).ToBitmap();
					_picVideo.ImageIpl = img; //mb comment
					_picVideo.Refresh(); //mb comment
				}
				else
				{
					Cv2.Resize(image, img, new OpenCvSharp.Size(_picVideo.Width, _picVideo.Height), 0, 0, InterpolationFlags.Cubic);
					_picVideo.ImageIpl = img;
					_picVideo.Refresh();			
				}

				}
		}

		#endregion

		#region Handler

		/// <summary> Вызывается при необходимости изменить картинку на панели. </summary>
		private void OnChangeImage(object sender, string path)
		{
			var img = new Mat(path);
			//_picVideo.Image = Image.FromFile(path);
			if (_projectSettings.IsDetector)
			{
				_picVideo.Image = _detector.Detect(img).ToBitmap();
			}
			else
			{
				_picVideo.Image = Image.FromFile(path);
			}

		}
		/// <summary> Вызывается по нажатию на кнопку открыть файл. </summary>
		private async void OnOpenFileClickAsync(object sender, EventArgs e)
		{
			if(_opnFileDialog.ShowDialog() == DialogResult.Cancel) return;

			if(_opnFileDialog.FilterIndex == (int)FilterType.Image)
			{
				_videoPlayerControler.OpenImage(_opnFileDialog.FileName);
			}
			else if(_opnFileDialog.FilterIndex == (int)FilterType.Video)
			{
				await _videoPlayerControler.OpenVideoAsync(_opnFileDialog.FileName);
			}

		}

		/// <summary> Вызывается при нажатии открыть папку. </summary>
		private void OnOpenFolderClick(object sender, EventArgs e)
		{
			if(_opnFolderDialog.ShowDialog() == DialogResult.Cancel) return;

			_videoPlayerControler.OpenFolderWithImages(_opnFolderDialog.SelectedPath);
		}

		/// <summary> Вызывается при нажатие на кнопку следующая картинка. </summary>
		private void OnNextClick(object sender, EventArgs e) => _videoPlayerControler.NextImage();

		/// <summary> Вызывается при нажатие на кнопку предыдущая картинка. </summary>
		private void OnPreviousClick(object sender, EventArgs e) => _videoPlayerControler.PreviousImage();

		#endregion

		#region Methods

		/// <summary> Вызывается при нажатие на кнопку Start. </summary>
		private async void OnStartClickAsync(object sender, EventArgs e)
		{
			await _videoPlayerControler.PlayVideoAsync();
		}


		/// <summary> Вызывается при нажатие на кнопку Pause. </summary>
		private async void OnPauseClickAsync(object sender, EventArgs e)
		{
			await _videoPlayerControler.PauseVideoAsync();
		}

		/// <summary> Вызывается при нажатие на кнопку Stop. </summary>
		private async void OnStopClickAsync(object sender, EventArgs e)
		{
			await _videoPlayerControler.StopVideoAsync();
		}

		#endregion

	}
}
