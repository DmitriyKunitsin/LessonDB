﻿using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace LessonDB
{
    /// <summary>
    /// Логика взаимодействия для WorksWindow.xaml
    /// </summary>
    public partial class WorksWindow : Window
    {
        public WorksWindow()
        {
            InitializeComponent();

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = new ListBoxItem();

            ApplicationContext All_List = new ApplicationContext();

            string out_List = "SELECT * FROM Use";

            SQLiteCommand command = new SQLiteCommand(out_List, All_List.myConnection);
            All_List.OpenConnection();
            var result = command.ExecuteReader();
            All_List.ClosedConnection();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBox = Main_text.Text;
            SQLiteDataReader dataReader = null;
            ApplicationContext context = new ApplicationContext();
            try
            {
                listUsers.Items.Clear();
                User user = DataBaseConnect.Data_Set_Acc_Users(textBox);
                if (user.Login != "null")
                {
                    listUsers.Items.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                    context.ClosedConnection();
                }
            }
        }
    }
}
