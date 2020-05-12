using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
	public partial class MainForm : Form
	{
		#region Data

		private LogControl _log;
		private SettingControl _setting;
		private VideoPlayerControl _videoPlayer;

		private LogControler _logControler;
		private VideoPlayerControler _videoPlayerControler;
		private ProjectSettings _projectSettings;

		#endregion

		#region .ctor

		/// <summary> Запуск главной формы. </summary>
		/// <param name="projectSettings"> Контролер настроек. </param>
		/// <param name="logControler"> Контролер лога. </param>
		/// <param name="videoPlayerControler"> Контролер видеопроигрывателя. </param>
		public MainForm(
			LogControler logControler,
			VideoPlayerControler videoPlayerControler,
			ProjectSettings projectSettings)
		{
			InitializeComponent();


			_logControler = logControler;
			_videoPlayerControler = videoPlayerControler;
			_projectSettings = projectSettings;

			_log = new LogControl(_logControler);
			_setting = new SettingControl(_logControler, _projectSettings);
			_videoPlayer = new VideoPlayerControl(_logControler, _videoPlayerControler, _projectSettings);

			_pnlLog.Controls.Add(_log);
			_pnlSetting.Controls.Add(_setting);
			_pnlVideoPlayer.Controls.Add(_videoPlayer);

		}

		#endregion

	}
}

