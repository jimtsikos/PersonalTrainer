using Application.Extensions.Enumarations;
using Autofac;

namespace Application.Registrer
{
    public class ExtensionsModule : Autofac.Module
    {
        public ExtensionsModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EnumService>().As<IEnumService>().InstancePerLifetimeScope();
        }
    }
}
