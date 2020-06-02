using System;
using System.Windows.Forms;

namespace Controls
{
	/// <summary> Контрол панели с настройками. </summary>
	public partial class SettingControl : UserControl
	{
		#region Data

		private LogControler _logControler;
		private ProjectSettings _projectSettings;

		#endregion

		#region .ctor

		/// <summary> Создает контрол панели настроек. </summary>
		/// <param name="logControler"> Контролер лога. </param>
		/// <param name="projectSettings"> Контролер настроек. </param>

		public SettingControl(
			LogControler logControler,
			ProjectSettings projectSettings)
		{
			InitializeComponent();
			Dock = DockStyle.Fill;

			_logControler = logControler;
			_projectSettings = projectSettings;

			_chkDetector.Checked = _projectSettings.IsDetector;
			_chkIsUnderCatalog.Checked = _projectSettings.IsUnderCatalog;
		}

		#endregion

		#region Handler

		/// <summary> Вызывается при изменении значения чек-бокса "С подкаталогами". </summary>
		private void OnChangeUnderCatalog(object sender, EventArgs e) => _projectSettings.IsUnderCatalog = _chkIsUnderCatalog.Checked;

		/// <summary> Вызывается при изменении значения чек-бокса "Детектор". </summary>
		private void OnChangeDetector(object sender, EventArgs e) => _projectSettings.IsDetector = _chkDetector.Checked;

		/// <summary> Вызывается по нажаитю на кнопку сохранить проект. </summary>
		private void OnSaveClick(object sender, EventArgs e) => _projectSettings.SaveXMLAsync();

		#endregion

	}
}

