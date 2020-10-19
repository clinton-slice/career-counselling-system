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
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Threading;

namespace CCS.admin
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        MainWindow parent;
        user_form subparent;
        DispatcherTimer timer;
        public home(MainWindow root,user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();
            timer_tick(null, null);
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();

        }

        private void timer_tick(object sender, EventArgs e)
        {
            try
            {

                if (!parent.getloggedId().Equals(""))
                {
                    DataTable qry = parent.query("select (select count(*) from user),(select count(*) from counselor)");
                    DataRow rw = qry.Rows[0];
                    user_count.Text = rw[0].ToString();
                    counselor_count.Text = rw[1].ToString();
                }
                else timer.IsEnabled = false;
            }
            catch (Exception) { }
        }

        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

           
            if (fullname.Text.Trim().Equals(""))
            { MessageBox.Show("Missing Full Name", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
            else if (password.Password.Trim().Equals(""))
            { MessageBox.Show("Missing Password", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
            else if (email.Text.Trim().Equals(""))
            { MessageBox.Show("Missing Email", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
            else if (!email.Text.Trim().Contains("@") || !email.Text.Trim().Contains("."))
            {
                MessageBox.Show("You entered an invalid email address", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                bool exist = false;
                string name = (fullname.Text.Trim());
                string pass = security.EncryptStringAES(password.Password, parent.cipher_text);
                string mail = parent.clean(email.Text.ToString());
                
                DataTable qry = parent.query("select counselor_id as id,'counselor' as cat,fullname,password from counselor where email='" + mail + "' union select user_id as id,'user' as cat, fullname,password from user where email='" + mail + "' limit 1");
                if (qry.Rows.Count != 0)
                {
                    exist = true;
                }

                if (exist)
                { MessageBox.Show("Another user is registered with that email address", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
                else
                {

                    MySqlCommand comm = new MySqlCommand("insert into counselor (email,password,fullname,date_added) values(@email,@pass,@name,now())", parent.getDbConnection());
                    comm.Parameters.Add("@email", mail);
                    comm.Parameters.Add("@pass", pass);
                    comm.Parameters.Add("@name", name);
                    comm.ExecuteNonQuery();

                    fullname.Text = "";
                    email.Text = "";
                    password.Password = "";
                   
                     MessageBox.Show("You have successfully created an account for "+name, "CCS", MessageBoxButton.OK, MessageBoxImage.Information);
         
                }
            }


        }

      

        private void user_count_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new dialog.accounts(parent, "user").Show();
        }

        private void counselor_count_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new dialog.accounts(parent, "counselor").Show();
        }

        private void label4_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = false;
            subparent.show_settings();
        }
    }
}
