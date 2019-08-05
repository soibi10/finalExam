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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace finalexampractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Add AddWindow = null;
        update Addwindow = null;
        public MainWindow()
        {
            InitializeComponent();
           fill_listbox();
        }
        string dbConnectionString = @"data source = Personel.db3;Version=3;";
       
        void fill_listbox()
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //open connection to database
            try
            {

              
                sqliteCon.Open();
                string Query = "select * from Employee";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string EMPLOYEEID = dr.GetString(0);
                    string name = dr.GetString(1);
                    string Position = dr.GetString(2);
                    string department = dr.GetString(3);
                    string Payrate = dr.GetString(4);
                    personellist.Items.Add(EMPLOYEEID + "   " + name + "   " + Position + "   " + department+"  "+Payrate);
                    
                }
                //creeateCommand.ExecuteNonQuery();
                // MessageBox.Show("The record has been deleted successfully", "Deleted!");
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //Add window to display
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            Add AddWindow = new Add(LoadDataFromDB);
            AddWindow.ShowDialog();

        }
        //update window to display
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            update Addwindow = new update(personellist_SelectionChanged, LoadDataFromDB);
           
            Addwindow.ShowDialog();
        }

        

        private void personellist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            {

                //open connection to database
                SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

                try
                {


                    sqliteCon.Open();
                    string Query = "select * from Employee";
                    SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                    SQLiteDataReader dr = createCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string ID = dr.GetString(0);
                        string name = dr.GetString(1);
                        string Position = dr.GetString(2);
                        string department = dr.GetString(3);
                        string Payrate = dr.GetString(4);
                    }
               
                    sqliteCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

             
                }
              
                
            }
           
        }
        //to fill listbox with data from database
        public void LoadDataFromDB()
        {
            personellist.Items.Clear();
            fill_listbox();


        }

        //To delete selected Item from Database and listbox
        private void Delete_Click(object sender, RoutedEventArgs e)
        {     //open connection to database
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
         
            try
            {

               
                sqliteCon.Open();
                string Query = "Delete from employee where ID =  '" +  0 + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dr = createCommand.ExecuteReader();
                createCommand.ExecuteNonQuery();
                while (dr.Read())
                {
                    string ID = dr.GetString(0);
                    string name = dr.GetString(1);
                    string Position = dr.GetString(2);
                    string department = dr.GetString(3);
                    string Payrate = dr.GetString(4);
                }

                MessageBox.Show("The record has been deleted successfuly", "Deleted!");
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDataFromDB();
        }
    }
    }




 

    
