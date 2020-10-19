using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace CCS.admin
{
    /// <summary>
    /// Interaction logic for setting.xaml
    /// </summary>
    public partial class setting : UserControl
    {
        MainWindow parent;
        user_form subparent;
        string password = "";

        public setting(MainWindow root, user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();
            username.Text = parent.getloggedId();
            DataTable qry = parent.query("select password from admin where username='" + parent.getloggedId()+"'");
            if(qry.Rows.Count>0)
            {
                DataRow rw = qry.Rows[0];
                 password = rw[0].ToString();
            
            }
        }

 
        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.Close();
        }

     
        private void label4_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_settings();
        }

    
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
           
            if (p2.Password.Trim().Equals("") || p2.Password.Trim().Equals(""))
            { MessageBox.Show("Incomplete Information", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            else
            {
                if (security.DecryptStringAES(password, parent.cipher_text).Equals(p1.Password))
                {

                    string pass = security.EncryptStringAES(p2.Password, parent.cipher_text);
                    MySqlCommand comm = new MySqlCommand("update admin set password=@pass where username='" + parent.getloggedId()+"'", parent.getDbConnection());
                    comm.Parameters.Add("@pass", pass);
                    comm.ExecuteNonQuery();

                    MessageBox.Show("You have successfully changed your account password", "CCS", MessageBoxButton.OK, MessageBoxImage.Information);
                    p1.Password = p2.Password = "";
                }
                else
                {
                    MessageBox.Show("Wrong Old Password", "CCS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void change_username_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text.Trim().Equals(""))
            { MessageBox.Show("Incomplete Information", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            else
            {
                MySqlCommand comm = new MySqlCommand("update admin set username=@user where username='" + parent.getloggedId() + "'", parent.getDbConnection());
                comm.Parameters.Add("@user", username.Text.Trim());
                comm.ExecuteNonQuery();
                MessageBox.Show("You have successfully changed your account username", "CCS", MessageBoxButton.OK, MessageBoxImage.Information);
                parent.setAdminLoggedID(username.Text.Trim());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            subparent.show_home();
        }

      
    }
}
