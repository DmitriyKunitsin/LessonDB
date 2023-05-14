﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace LessonDB
//{
//    public class User
//    {
//        public int ID { get; set; }
//        public string Login { get; set; }
//        public string Pass { get; set; }
//        public string Email { get; set; }
//        public override string ToString()
//        {
//            return string.Format("ID: {0}, Login: {1}, Pass: {2}, Email: {3}", ID, Login, Pass, Email);
//        }
//    }
//}
namespace LessonDB
{
    
    public class User
    {
        public int id { get; set; }
        private string login, pass, email, roleID;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }
        public User()
        {
            this.login = string.Empty;
            this.pass = string.Empty;
            this.email = string.Empty;
            this.roleID = string.Empty;
            this.id = 0;
        }
        public User(string login, string pass, string email)
        {
            this.login = login;
            this.pass = pass;
            this.email = email;
            this.roleID = string.Empty;
            this.id = 0;
        }
    }
}
