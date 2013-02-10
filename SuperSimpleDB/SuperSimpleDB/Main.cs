using System;
using ServiceStack.OrmLite;
using ServiceStack.Common.Utils;
using System.Data;

namespace SuperSimpleDB
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var dbFactory = new OrmLiteConnectionFactory (
                "Arsenal.sqlite".MapAbsolutePath (),
                SqliteDialect.Provider);

            // Create the database, overwrite any existing data
            dbFactory.Run (d => d.CreateTable<Player> (overwrite: true));
            
            IDbConnection db = dbFactory.OpenDbConnection ();
           
            // Insert some data into the database
            db.Insert (new Player { Id = 1, Name = "SZCZESNY" });
            db.Insert (new Player { Id = 2, Name = "DIABY" });
            db.Insert (new Player { Id = 3, Name = "SAGNA" });
            db.Insert (new Player { Id = 4, Name = "MERTESACKER" });
            db.Insert (new Player { Id = 5, Name = "VERMAELEN" });
            db.Insert (new Player { Id = 6, Name = "KOSCIELNY" });
            db.Insert (new Player { Id = 7, Name = "ROSICKY" });
            db.Insert (new Player { Id = 8, Name = "ARTETA" });
            db.Insert (new Player { Id = 9, Name = "PODOLSKI" });
            db.Insert (new Player { Id = 10, Name = "WILSHERE" });
                       
            // Query the Database
            var players = db.Select<Player> (p => p.Id > 5);

            // Output the query results
            foreach (var player in players) 
            {
                Console.WriteLine (player.Name);
            }
        }
    }
}
