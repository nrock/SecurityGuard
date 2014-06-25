using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using FluentNHibernate;

namespace AspNet.Identity.NHibernate
{


    public class DatabaseInsaller
    {
        private static readonly object SyncObject = new object();

        private static ISessionFactory _factory;

        private static AutoPersistenceModel CreateAutomappings()
        {
            return
                AutoMap.AssemblyOf<Configuration>(new AutomappingConfiguration()).Conventions.Add(
                    new SchemaFromNamespaceTableNameConvention()).Conventions.Add(new TableIdToIdForeignKeyConvention())
                    .Conventions.Add(new IdGeneratorConvention());
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_factory == null)
            {
                lock (SyncObject)
                {
                    if (_factory == null)
                    {
                        _factory =
                            Fluently.Configure().Database(
                                MsSqlConfiguration.MsSql2008.ConnectionString(
                                    c => c.FromConnectionStringWithKey("ApplicationConnectionString")).AdoNetBatchSize(
                                        50)).Mappings(
                                            m =>
                                            {
                                                m.AutoMappings.Add(CreateAutomappings);
                                                m.HbmMappings.AddFromAssemblyOf<IdentityUser>();
                                            }).BuildSessionFactory();
                    }
                }
            }

            return _factory;
        }


    }


    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return Enumerable.Contains<Type>((IEnumerable<Type>)type.GetInterfaces(), typeof(IEntity));
        }

        public override bool ShouldMap(Member member)
        {
            if (!Enumerable.Contains<string>((IEnumerable<string>)new string[1]
      {
        "istransient"
      }, member.Name.ToLower()))
                return member.IsProperty;
            else
                return false;
        }

        public override bool IsComponent(Type type)
        {
            return type == typeof(Audit);
        }

        public override bool IsId(Member member)
        {
            if (member.IsProperty)
                return member.Name.ToLower() == "id";
            else
                return false;
        }

        public override string GetComponentColumnPrefix(Member member)
        {
            return string.Empty;
        }
    }


}
