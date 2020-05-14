using System.Windows.Forms;

namespace Controls
{
	/// <summary> Лог контрол для записи сообщений в лог. </summary>
	public partial class LogControl : UserControl
	{
		#region Data

		//Контролер лога.
		private LogControler _logControler;

		#endregion

		#region .ctor

		/// <summary> Создать контрол лога. </summary>
		/// <param name="log"> Лог контролер, который надо привязать к логу. </param>

		public LogControl(LogControler log)
		{
			InitializeComponent();
			Dock = DockStyle.Fill;

			_logControler = log;

			//Подписываем на событие.
			_logControler.AddMessageInLog += OnAddMessageInLog;

		}

		#endregion

		#region Methods

		/// <summary> Вызывается при добавлении текста в Лог. </summary>
		private void OnAddMessageInLog(object sender, string text)
		{
			_txtLog.AppendText(text);
		}

		#endregion
	}
}

