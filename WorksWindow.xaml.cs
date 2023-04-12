using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using System.IO;

namespace LessonDB
{
    //public System.Windows.Forms.ListBox.ObjectCollection Items { get; }
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
            //foreach (var item in result)
            //{
            //    ListBoxItem.(result);
            //}

        }
    }
}
