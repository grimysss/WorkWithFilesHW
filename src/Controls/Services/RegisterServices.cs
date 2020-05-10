using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
	/// <summary> Класс для регистрации типов. </summary>
		public static class RegisterServises
	{
		/// <summary> Метод, который регистрирует наши типы. </summary>
		public static IContainer Create()
		{
			var containerBulder = new ContainerBuilder();

			containerBulder
				.RegisterModule<ModuleWinForm>();

			containerBulder
				.RegisterType<MainForm>()
				.AsSelf();

			return containerBulder.Build();

		}
	}
}
