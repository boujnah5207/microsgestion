using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using System.Data.Linq;

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

        public static void SubmitChanges()
        {
            try
            {
                DB.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException ex)
            {
                throw ex;
            }
        }
    }

    public class ServiceBase<T> : ServiceBase
        where T : class, IIdentificableEntity
    {
        public static T GetByID(Guid id)
        {
            return (from u in DB.GetTable<T>()
                    where u.ID == id
                    select u).SingleOrDefault<T>();
        }

        public static List<T> GetAll()
        {
            return DB.GetTable<T>().ToList();
        }

        public static void Save(T instance)
        {
            if (instance.ID == Guid.Empty)
                instance.ID = Guid.NewGuid();

            DB.GetTable<T>().InsertOnSubmit(instance);
            
            SubmitChanges();
        }

        public static void SaveAll(IEnumerable<T> collection)
        {
            DB.GetTable<T>().InsertAllOnSubmit(collection);

            SubmitChanges();
        }

        public static void Delete(T instance)
        {
            if (instance.ID == Guid.Empty)
                return;

            DB.GetTable<T>().DeleteOnSubmit(instance);

            SubmitChanges();
        }

        public static void DeleteAll(IEnumerable<T> collection)
        {
            DB.GetTable<T>().DeleteAllOnSubmit(collection);

            SubmitChanges();
        }

        public static void Update(T instance)
        {
            if (instance.ID == Guid.Empty)
                Save(instance);

            SubmitChanges();
        }

        public static void Refresh(T instance, RefreshMode mode)
        {
            DB.Refresh(mode, instance);
        }

    }
}
