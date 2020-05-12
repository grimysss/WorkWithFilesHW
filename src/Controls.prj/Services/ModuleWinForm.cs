using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
	/// <summary> Класс модуля для регистрации типов. </summary>
	public sealed class ModuleWinForm : Module
	{
		/// <summary> Загружаем нужные типы. </summary>
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder
				.RegisterType<LogControler>()
				.AsSelf()
				.SingleInstance();
			builder
				.RegisterType<ProjectSettings>()
				.AsSelf()
				.SingleInstance();
			builder
				.RegisterType<VideoPlayerControler>()
				.AsSelf()
				.SingleInstance();
		}
	}
}
