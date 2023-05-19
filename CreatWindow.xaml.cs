﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LessonDB
{
    /// <summary>
    /// Логика взаимодействия для CreatWindow.xaml
    /// </summary>
    public partial class CreatWindow : Window
    {
        public CreatWindow()
        {
            InitializeComponent();
            var user = ApplicationContext.ActualUser.Login;
            var userGr = ApplicationContext.ActualUser.Email;
            textTestName.Text = user;
            textGroup.Text = userGr;
        }
    }
}
