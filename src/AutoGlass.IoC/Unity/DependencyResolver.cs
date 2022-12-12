using AutoGlass.Domain.Interfaces.Repositorio.Base;
using AutoGlass.Domain.Interfaces.Servicos.Produto;
using AutoGlass.Domain.Repositorio.Produto;
using AutoGlass.Infra.Persistencia;
using AutoGlass.Infra.Persistencia.AutoMapper;
using AutoGlass.Infra.Persistencia.Repositorios.Base;
using AutoGlass.Infra.Persistencia.Repositorios.Produto;
using Dominio.Servicos.Produto;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;


namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            Configuracao(container);
            Servicos(container);
            Repositorios(container);
        }

        private static void Configuracao(UnityContainer container)
        {
            //container.RegisterType<DbContext, Contexto>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());
            container.RegisterInstance(new AutoMapperConfig().Configure().CreateMapper());
        }

        private static void Servicos(UnityContainer container)
        {
            container.RegisterType<IServicoProduto, ServicoProduto>(new HierarchicalLifetimeManager());
        }

        private static void Repositorios(UnityContainer container)
        {
            container.RegisterType(typeof(IRepositorioBase<,>), typeof(RepositorioBase<,>));
            container.RegisterType<IRepositorioProduto, RepositorioProduto>(new HierarchicalLifetimeManager());
        }
    }
}
