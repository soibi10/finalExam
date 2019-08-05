using System;
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
using System.Data.SQLite;

namespace finalexampractice
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add(Action loadDataFromDB)
        {
            InitializeComponent();
            this.loadDataFromDB = loadDataFromDB;

        }

      

        string dbConnectionString = @"data source = Personel.db3;Version=3;";
        private Action loadDataFromDB;

        private void add_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {

                sqliteCon.Open();

                string Query = "Insert into Employee (ID, Name, Position, Payrate) Values ('" + this.tb_id.Text + "','" + this.tb_name.Text + "','" + this.tb_position.Text + "','" + this.tb_dept.Text + "','"+this.tb_payrate+"')";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Your Record has been saved successfully", "saved!");

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            loadDataFromDB();


        }

        public void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            loadDataFromDB();

        }
    
        }
    }


