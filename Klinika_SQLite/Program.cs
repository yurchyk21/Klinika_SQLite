using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Klinika_SQLite.Entity;

namespace Klinika_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Name = "Peter"
            };
            using (SLContext context = new SLContext())
            {
                context.Persons.Add(p);
                context.SaveChanges();
                foreach (var item in context.Persons)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
        }
        static void ADoNetSQLLite()
        {
            #region
            string conStr = ConfigurationManager.ConnectionStrings["MyConnectionSqlLite"].ToString();
            SQLiteConnection sqlLiteCon = new SQLiteConnection(conStr);
            try
            {
                sqlLiteCon.Open();
                string query = $"INSERT INTO Users(Name, Phone, Image) VALUES( 'Zozo' , '777', 'img')";
                using (SQLiteCommand Command = new SQLiteCommand(query, sqlLiteCon))
                {
                    try
                    {
                        Command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }


                //INSERT INTO "main"."Users"("Id", "Name", "Phone", "Image") VALUES(3,? 1,? 2,? 3) Parameters:
                //param 1(text): Petro param 2(integer): 782 param 3(integer): 123

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("Enter phone num");
                string phone = Console.ReadLine();
                string query = "SELECT * FROM Users as u " +
                    $"WHERE u.Phone= @phone ";
                SQLiteCommand newCommand = new
                    SQLiteCommand(query, sqlLiteCon);
                newCommand.Parameters.Add(new SQLiteParameter("@phone", phone));
                SQLiteDataReader dr = newCommand.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

        }
    }
}
