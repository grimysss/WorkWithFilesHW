using Autofac;
using System;
using System.Windows.Forms;

namespace Controls
{
	static class Program
	{
		/// <summary> Основная точка входа для приложения. </summary>
		[STAThread]
		static void Main()
		{
			using(var container = RegisterServises.Create())
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(container.Resolve<MainForm>());
			}
		}
	}
}