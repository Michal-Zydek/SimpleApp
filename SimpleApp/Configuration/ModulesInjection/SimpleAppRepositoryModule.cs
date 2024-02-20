
using Autofac;
using SimpleApp.Database.Interfaces;
using SimpleApp.Database.Repositories;

namespace SimpleApp.Configuration.ModulesInjection
{
    public class SimpleAppRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().SingleInstance();
            builder.RegisterType<EmailRepository>().As<IEmailRepository>().SingleInstance();
        }
    }
}
