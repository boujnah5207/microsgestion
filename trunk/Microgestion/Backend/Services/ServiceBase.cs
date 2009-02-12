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

        protected static MicrogestionDataContext DataContext
        {
            get
            {
                string connString = Microgestion.Backend.Properties.BackendSettings.Default.MicrogestionConnectionString;
                return new MicrogestionDataContext(connString);
            }
        }

        public static T GetByID<T>(Guid id)
            where T :class, IIdentificableEntity
        {
            using (MicrogestionDataContext dc = DataContext)
            {
                return (from u in dc.GetTable<T>()
                        where u.ID == id
                        select u).SingleOrDefault<T>();
            }
        }

        public static List<T> GetAll<T>()
            where T : class, IIdentificableEntity
        {
            using (MicrogestionDataContext dc = DataContext)
            {
                return dc.GetTable<T>().ToList();
            }
        }

        public static void Save<T>(T instance)
            where T :class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                instance.ID = Guid.NewGuid();

            using (MicrogestionDataContext dc = DataContext)
            {
                dc.GetTable<T>().InsertOnSubmit(instance);
                dc.SubmitChanges();
            }
        }

        public static void SaveAll<T>(IEnumerable<T> collection)
            where T : class, IIdentificableEntity
        {
            using (MicrogestionDataContext dc = DataContext)
            {
                dc.GetTable<T>().InsertAllOnSubmit(collection);
                dc.SubmitChanges();
            }
        }

        public static void Update<T>(T instance)
            where T :class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                Save(instance);

            using (MicrogestionDataContext dc = DataContext)
            {
                T original = GetByID<T>(instance.ID);

                dc.GetTable<T>().Attach(instance, original);
                dc.SubmitChanges();
            }
        }

        public static void Delete<T>(T instance)
            where T :class, IIdentificableEntity
        {
            if (instance.ID == Guid.Empty)
                return;

            using (MicrogestionDataContext dc = DataContext)
            {
                dc.GetTable<T>().Attach(instance);
                dc.GetTable<T>().DeleteOnSubmit(instance);
                dc.SubmitChanges();
            }
        }


    }
}
