
using MiracleStone.Data.Context;
using StructureMap;
using StructureMap.Web.Pipeline;
using System;
namespace MiracleStone.DependencyInjection.Ioc
{
    public class IocInitializer
    {
        public static IContainer Container;
        public static void Initialize()
        {
            Container = new Container(x =>
            {
                x.For<IUnitOfWork>().Use(() => new MiracleStoneDbContext()).LifecycleIs<HttpContextLifecycle>();
            });
        }

        public static object GetInstance(Type pluginType)
        {
            return Container.GetInstance(pluginType);
        }
        public static TPluginType GetInstance<TPluginType>()
        {
            return Container.GetInstance<TPluginType>();
        }

        public static void HttpContextDisposeAndClearAll()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}
