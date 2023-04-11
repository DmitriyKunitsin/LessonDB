using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace LessonDB
{
    internal class ApplicationContext 
    {
        public SQLiteConnection myConnection;
        
        public ApplicationContext() 
        {
            myConnection= new SQLiteConnection("Data Source=Use.sqlite3");

            if (File.Exists("./Use.sqlite3"))
            {
                SQLiteConnection.CreateFile("./User.sqlite3");
                Console.WriteLine("Data Base File Create");
            }
            else 
            {
                Console.WriteLine("The file is present");
            }
        }
        public void OpenConnection() 
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public void ClosedConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed) 
            {
                myConnection.Close();
            }

        }
        
    
    
    }
    
}
