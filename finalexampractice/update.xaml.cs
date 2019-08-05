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
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {
        private Action<object, SelectionChangedEventArgs> personellist_SelectionChanged;
      

        string dbConnectionString = @"data source = Personel.db3;Version=3;";
        private Action loadDataFromDB;
   

        public update(Action<object, SelectionChangedEventArgs> personellist_SelectionChanged, Action loadDataFromDB)
        {
            
            this.personellist_SelectionChanged = personellist_SelectionChanged;
            InitializeComponent();

            this.loadDataFromDB = loadDataFromDB;





            //open connection to database
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            //and bind data from listbox to update window textbox
          
            try
            {
                

                sqliteCon.Open();
                string Query = "select * from Employee";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())

               foreach (var value in  dr  )
                    {
                    string ID = dr.GetString(0);
                    string name = dr.GetString(1);
                    string Position = dr.GetString(2);
                    String department = dr.GetString(3);
                    string Payrate = dr.GetString(4);
                    tb_ID.Text = ID;
                    tb_name.Text = name;
                    tb_position.Text = Position;
                    tb_dept.Text = department;
                    tb_payrate.Text = Payrate;
                    

                }
            
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            loadDataFromDB(); 
        }

       

        //to update selected Item in Listbox
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {

                sqliteCon.Open();

                string Query = " update employee set ID = '" + this.tb_ID.Text + "', name = '"+ this.tb_name.Text + "',Position='"+this.tb_position.Text+ "',payrate='"+this.tb_payrate.Text+ "'where ID ='"  +this.tb_ID.Text+ "'";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadDataFromDB();
            this.Close();
        }
    }
    }
    