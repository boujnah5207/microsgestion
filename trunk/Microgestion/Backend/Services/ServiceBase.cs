using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
{
    public class ServiceBase
    {
        protected ServiceBase() { }

        protected static MicrogestionDataContext dataContext;
        protected static MicrogestionDataContext DB
        {
            get
            {
                if (dataContext == null)
                {
                    string connString = Microgestion.Backend.Properties.BackendSettings.Default.MicrogestionConnectionString;
                    dataContext = new MicrogestionDataContext(connString);
                }
                return dataContext;
            }
        }

        public static T GetByID<T>(Guid id)
            where T : class, IIdentificableEntity
        {
            return (from u in DB.GetTable<T>()
                    where u.ID == id
                    select u).SingleOrDefault<T>();
        }

        public static List<T> GetAll<T>()
            where T : class, IIdentificableEntity
        {
            return DB.GetTable<T>().ToList();
        }

        public static void Save<T>(T instance)
            where T : class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                instance.ID = Guid.NewGuid();

            DB.GetTable<T>().InsertOnSubmit(instance);
            DB.SubmitChanges();
        }

        public static void SaveAll<T>(IEnumerable<T> collection)
            where T : class, IIdentificableEntity
        {
            DB.GetTable<T>().InsertAllOnSubmit(collection);
            DB.SubmitChanges();
        }

        public static void Update<T>(T instance)
            where T : class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                Save(instance);

            //T original = GetByID<T>(instance.ID);

            //DB.GetTable<T>().Attach(instance, original);
            DB.SubmitChanges();
        }

        public static void Delete<T>(T instance)
            where T : class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                return;

            //DB.GetTable<T>().Attach(instance);
            DB.GetTable<T>().DeleteOnSubmit(instance);
            DB.SubmitChanges();
        }

        public static void SubmitChanges()
        {
            DB.SubmitChanges();
        }
    }
}
