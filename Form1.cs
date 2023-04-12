using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;


namespace LessonDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


           //// ListBoxItem item = new ListBoxItem();

           // ApplicationContext All_List = new ApplicationContext();

           // string out_List = "SELECT * FROM Use";

           // SQLiteCommand command = new SQLiteCommand(out_List, All_List.myConnection);
           // All_List.OpenConnection();
           // var result = command.ExecuteReader();
           // All_List.ClosedConnection();
           // string ouut;
           // foreach (var item in result)
           // {
           //     ouut = listBox1.Items.Count.ToString();
              
           // }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            SQLiteDataReader dataReader = null;
            ApplicationContext context = new ApplicationContext();

            try
            {
                string command = "SELECT login,pass,email FROM Use";
                SQLiteCommand sqlCommand = new SQLiteCommand(command, context.myConnection);
                context.OpenConnection();
                dataReader = sqlCommand.ExecuteReader();

                System.Windows.Forms.ListViewItem item = null;
                while (dataReader.Read()) 
                {
                    item = new System.Windows.Forms.ListViewItem(new string[] { Convert.ToString(dataReader["login"]),
                    Convert.ToString(dataReader["pass"]),Convert.ToString(dataReader["email"])});
                   
                    listView1.Items.Add(item);
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
