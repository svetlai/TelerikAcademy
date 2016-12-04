namespace MusicSystem.Data
{
    using System;
    using System.Collections.Generic;

    using MusicSystem.Data.Contracts;
    using MusicSystem.Data.Repositories;
    using MusicSystem.Model;

    public class MusicSystemData : IMusicSystemData
    {
        private IMusicSystemDbContext db;
        private IDictionary<Type, object> repositories;

        public MusicSystemData()
            : this(new MusicSystemDbContext())
        {
        }


        public MusicSystemData(IMusicSystemDbContext db)
        {
            this.db = db;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.db));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
