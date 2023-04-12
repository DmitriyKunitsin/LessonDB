using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using System.IO;
using System;
using System.Runtime.InteropServices;

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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            //ApplicationContext context = new ApplicationContext();

            //string command = "SELECT login FROM Use";
            //string command = "SELECT login,pass,email FROM Use";
            //SQLiteCommand sqlCommand = new SQLiteCommand(command, context.myConnection);
            //context.OpenConnection();
            //dataReader = sqlCommand.ExecuteReader();

            //System.Windows.Forms.ListViewItem item = null;
            //while (dataReader.Read())
            //{
            //    item = new System.Windows.Forms.ListViewItem(new string[] { Convert.ToString(dataReader["login"]),
            //        Convert.ToString(dataReader["pass"]),Convert.ToString(dataReader["email"])});

            //    listView1.Items.Add(item);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SQLiteDataReader dataReader = null;

            ApplicationContext context = new ApplicationContext();
            try
            {
                var textBox = Main_text.Text;

                string command = $"SELECT login FROM Use WHERE login ='{textBox}'";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(command, context.myConnection);
                context.OpenConnection();
                dataReader = sQLiteCommand.ExecuteReader();

                ListView item = null;

                while (dataReader.Read())
                {
                    
                    item = new ListView(new string[] { Convert.ToString(dataReader["login"]) });


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
