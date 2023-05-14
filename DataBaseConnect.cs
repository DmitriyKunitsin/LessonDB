﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonDB
{
    public class DataBaseConnect
    {
        public bool Data_Base_Out_User(string login, string pass)
        {
            ApplicationContext whereAccount = new ApplicationContext();

            string whereAcc = ($"SELECT login,password FROM Users WHERE login='{login}' AND password='{pass}'");

            SQLiteCommand command = new SQLiteCommand(whereAcc, whereAccount.myConnection);
            whereAccount.OpenConnection();
            var result = command.ExecuteReader();
            var userExist = result.HasRows;
            whereAccount.ClosedConnection();
            return userExist;
            //WorksWindow next = new WorksWindow();
        }
        public void Data_Base_Input_User(string login, string pass, string email)
        {
            //добавление логина,пароля и емейла в базу данных
            ApplicationContext Connect = new ApplicationContext();
            //Добавление таблицы в случае ее отсутствия
            string table = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY, login TEXT, password TEXT, email TEXT)";
            SQLiteCommand addTable = new SQLiteCommand(table, Connect.myConnection);
            Connect.OpenConnection();
            addTable.ExecuteNonQuery();
            string add = "INSERT INTO Users ('login', 'password', 'email') VALUES (@login, @password , @email)";
            SQLiteCommand myCommand = new SQLiteCommand(add, Connect.myConnection);
            Connect.OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@password", pass);
            myCommand.Parameters.AddWithValue("@email", email);
            var resault = myCommand.ExecuteNonQuery();
            Connect.ClosedConnection();
        }
        public void Data_Base_Out_All_User(string login, string pass)
        {
            ApplicationContext whereAccount = new ApplicationContext();

            string whereAcc = ($"SELECT * FROM Users");

            SQLiteCommand command = new SQLiteCommand(whereAcc, whereAccount.myConnection);
            whereAccount.OpenConnection();
            var result = command.ExecuteReader();
            whereAccount.ClosedConnection();

            //WorksWindow next = new WorksWindow();
        }
        public static User Data_Set_Acc_Users(string textBox)
        {
            User DBUser = new User("null", "null", "null");

            SQLiteDataReader dataReader = null;

            ApplicationContext context = new ApplicationContext();

            string command = $"SELECT login,password,email FROM Users WHERE login ='{textBox}'";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(command, context.myConnection);
            context.OpenConnection();
            dataReader = sQLiteCommand.ExecuteReader();

            while (dataReader.Read())
            {
                DBUser.Login = Convert.ToString(dataReader.GetString(0));
                DBUser.Pass = Convert.ToString(dataReader.GetString(1));
                DBUser.Email = Convert.ToString(dataReader.GetString(2));

            }

            return DBUser;

        }
        public bool Data_roleID_User(string login)
        {
            SQLiteDataReader dataReader = null;
            ApplicationContext context = new ApplicationContext();
            string command = $"SELECT roleID FROM Users WHERE login = '{login}' AND roleID !=3;";
            SQLiteCommand comm = new SQLiteCommand(command, context.myConnection);
            context.OpenConnection();
            var result = comm.ExecuteReader();
            var userExist = result.HasRows;
            context.ClosedConnection();
            return userExist;


        }

        internal User FetchUser(string login)
        {
            SQLiteDataReader reader = null;
            ApplicationContext context = new ApplicationContext();
            string user = $"SELECT login,password,email,roleID FROM Users WHERE login ='{login}';";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(user, context.myConnection);
            context.OpenConnection();
            reader = sQLiteCommand.ExecuteReader();
            User userLogin = new User();
             while (reader.Read())
            {
                userLogin.Login = reader.GetString(0);
                userLogin.Pass = reader.GetString(1);
                userLogin.Email = reader.GetString(2);
                userLogin.RoleID = Convert.ToString(reader.GetInt32(3));
            }
             return userLogin;
        }
     }
}
