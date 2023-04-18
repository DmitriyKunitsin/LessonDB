using System;
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
            {   string command = $"SELECT login,pass,email FROM Use WHERE login ='{textBox}'";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(command, context.myConnection);
                context.OpenConnection();
                dataReader = sQLiteCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    object login = dataReader.GetString(0);
                    object pass = dataReader.GetString(1);
                    object email = dataReader.GetString(2);
                    User user = new User(Convert.ToString(login), Convert.ToString(pass), Convert.ToString(email));
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
