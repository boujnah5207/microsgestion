using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;
using System.Data.Linq;

namespace SysQ.Microgestion.Backend.Services
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
        where T : class, IPersistible
    {
        public static T GetByID(Guid id)
        {
            return (from u in DB.GetTable<T>()
                    where u.ID == id
                    select u).SingleOrDefault<T>();
        }

        public static List<T> GetAll(Func<T, object> orderExpression)
        {
            return DB.GetTable<T>()
                     .OrderBy(orderExpression)
                     .ToList();
        }

        public static void Save(T instance)
        {
            if (instance.ID == Guid.Empty)
                instance.ID = Guid.NewGuid();

            if (!instance.IsValid())
                throw new ArgumentException("La instancia que esta intentando salvar contiene datos inválidos.", "instance");

            DB.GetTable<T>().InsertOnSubmit(instance);
            
            SubmitChanges();
        }

        public static void SaveAll(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                if (!item.IsValid())
                    throw new ArgumentException("Una de las instancias que esta intentando salvar contiene datos inválidos.", "instance");

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

            if (!instance.IsValid())
                throw new ArgumentException("La instancia que esta intentando salvar contiene datos inválidos.", "instance");

            SubmitChanges();
        }

        public static void Refresh(T instance, RefreshMode mode)
        {
            DB.Refresh(mode, instance);
        }
        public static void Refresh(IEnumerable<T> instance, RefreshMode mode)
        {
            DB.Refresh(mode, instance);
        }

    }
}
