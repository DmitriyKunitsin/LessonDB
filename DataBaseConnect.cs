using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonDB
{
    public  class DataBaseConnect
    {
        public void Data_Base_Out_User(string login, string pass)
        {
            ApplicationContext whereAccount = new ApplicationContext();

            string whereAcc = ($"SELECT login,pass FROM Use WHERE login='{login}' AND pass='{pass}'");

            SQLiteCommand command = new SQLiteCommand(whereAcc, whereAccount.myConnection);
            whereAccount.OpenConnection();
            var result = command.ExecuteReader();
            whereAccount.ClosedConnection();

           //WorksWindow next = new WorksWindow();
        }
        public void Data_Base_Input_User(string login, string pass, string email) 
        {
            //добавление логина,пароля и емейла в базу данных
            ApplicationContext Connect = new ApplicationContext();
            //Добавление таблицы в случае ее отсутствия
            string table = "CREATE TABLE IF NOT EXISTS Use (id INTEGER PRIMARY KEY, login TEXT, pass TEXT, email TEXT)";
            SQLiteCommand addTable = new SQLiteCommand(table, Connect.myConnection);
            Connect.OpenConnection();
            addTable.ExecuteNonQuery();
            string add = "INSERT INTO Use ('login', 'pass', 'email') VALUES (@login, @pass , @email)";
            SQLiteCommand myCommand = new SQLiteCommand(add, Connect.myConnection);
            Connect.OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@pass", pass);
            myCommand.Parameters.AddWithValue("@email", email);
            var resault = myCommand.ExecuteNonQuery();
            Connect.ClosedConnection();
        }
        public void Data_Base_Out_All_User(string login, string pass)
        {
            ApplicationContext whereAccount = new ApplicationContext();

            string whereAcc = ($"SELECT * FROM Use");

            SQLiteCommand command = new SQLiteCommand(whereAcc, whereAccount.myConnection);
            whereAccount.OpenConnection();
            var result = command.ExecuteReader();
            whereAccount.ClosedConnection();

            //WorksWindow next = new WorksWindow();
        }
    }
}
