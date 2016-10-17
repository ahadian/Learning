using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using MongoDB.Driver;
using Selise.AppSuite.DataDefination.Core.PrimaryEntities;

namespace MongoWorker
{
    public class ConsoleRun
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        private static string HostName;
        private static int port;
        public void RunForestRun()
        {
            Console.WriteLine("Enter Host Name : ");
            HostName = Console.ReadLine();
            Console.WriteLine("Enter Port Name : ");
            try
            {
                port = int.Parse(Console.ReadLine());// I should be hanged till death for this line of code.

            }
            catch (Exception ex)
            {
                port = 27017;
            }

            _client = new MongoClient(string.Format("mongodb://{0}:{1}", HostName, port));
            var database = _client.GetDatabase("TenantRegistrations");
            var tenantCollection = database.GetCollection<Tenant>(this.GetDbName(typeof(Tenant).Name));
            var siteCollection = database.GetCollection<Site>(this.GetDbName(typeof(Site).Name));

            Console.WriteLine("Enter Tenant Name (Guid prefered) : ");
            string name = Console.ReadLine();


            var tenant = (Tenant)this.InitTenant(typeof(Tenant), name);
            tenantCollection.InsertOne(tenant);

            Console.WriteLine("Enter Site Name (Guid prefered): ");
            name = Console.ReadLine();
            var site = (Site)this.InitTenant(typeof(Site), name);
            siteCollection.InsertOne(site);

        }

        private string GetDbName(string name)
        {
            return string.Format("{0}s", name);
        }

        private object InitTenant(Type type, string id)
        {
            object instance = Activator.CreateInstance(type);
            type.GetProperty("ItemId").SetValue(instance, id, null);
            var g = type.GetProperties().Select(x => x.Name).ToList();
            int cc = 0;
            foreach (var property in g)
            {
                PropertyInfo prop = type.GetProperty(property);
                if (!prop.Name.Equals("ItemId", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter {0}", property);
                    var value = Console.ReadLine();
                    prop.SetValue(instance, this.ParseValue(value, prop), null);
                }
            }

            int u = 0;
            return instance;
        }

        private object ParseValue(string value, PropertyInfo prop)
        {
            if (".".Equals(value)) return null;
            if (prop.PropertyType.Equals(typeof(int)))
            {
                return ValueParser.ParseInt(value);
            }
            if (prop.PropertyType.Equals(typeof(int[])))
            {
                return ValueParser.ParseIntArray(value);
            }
            if (prop.PropertyType.Equals(typeof(double)))
            {
                return ValueParser.ParseDouble(value);
            }
            if (prop.PropertyType.Equals(typeof(string)))
            {
                return value;
            }
            if (prop.PropertyType.Equals(typeof(string[])))
            {
                return ValueParser.ParseStringArray(value);
            }
            if (prop.PropertyType.Equals(typeof(DateTime)))
            {
                return ValueParser.ParseDate(value);
            }
            return null;
        }
    }
}
