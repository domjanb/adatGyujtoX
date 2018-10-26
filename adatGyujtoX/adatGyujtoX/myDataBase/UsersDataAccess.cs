using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace adatGyujtoX
{
    public class UsersDataAccess
    {
        //private SQLiteConnection database;
        private static object collisionLock = new object();
        private SQLiteConnection database;

        public ObservableCollection<Cogazon> CogUser { get; set; }

        public UsersDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Cogazon>();

            this.CogUser = new ObservableCollection<Cogazon>(database.Table<Cogazon>());

            if (!database.Table<Cogazon>().Any())
            {
                AddNewUser();
            }

        }

        private void AddNewUser()
        {
            //throw new NotImplementedException();
            /*var user0  =new Cogazon {
                uemail = "0",
                userid = 0
                };
            CogUser.Add(user0);
            CogUser.Add(new Cogazon {
                uemail = "0",
                //uname = "0",
                //upass = "0",
                userid = 0
                }                );*/
            /*this.CogUser.Add(new Cogazon
            {
                uemail = "0",
                //uname = "0",
                //upass = "0",
                userid = 0
                //usname = "0"
            });*/
            var a = "2";

        }
        public IEnumerable<Cogazon> GetCogAzonAsSern(int Sern)
        {
            lock (collisionLock)
            {
                var query = from adat in database.Table<Cogazon>() where adat.id == Sern select adat;
                return query.AsEnumerable();
            }
        }

        public Object GetCogAzonAsSernO(int Sern)
        {
            lock (collisionLock)
            {
                var query = from adat in database.Table<Cogazon>() where adat.id == Sern select adat;
                return query ;
            }
        }

        public IEnumerable<Cogazon> GetCogAzon()
        {
            lock (collisionLock)
            {
                return database.Query<Cogazon>("Select * from Cogazon").AsEnumerable();
                
            }
        }
        public int SaveCogAzon(Cogazon cogAzonAdat)
        {
            lock (collisionLock)
            {
                if (cogAzonAdat.id != 0)
                {
                    database.Update(cogAzonAdat);
                    return cogAzonAdat.id;
                }
                else
                {
                    database.Insert(cogAzonAdat);
                    return cogAzonAdat.id;
                }
            }
        }
        public int DeleteCogAzon(Cogazon cogAzonAdat)
        {
            var id = cogAzonAdat.id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Cogazon>(id);
                }

            }
            this.CogUser.Remove(cogAzonAdat);
            return id;
        }
        public void DeleteCogAzonAll()
        {
            lock (collisionLock)
            {
                database.DeleteAll<Cogazon>();
            }
                
            
            
        }
    }
}
