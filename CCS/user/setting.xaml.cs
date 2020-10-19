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

namespace CCS.user
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

            DataTable qry = parent.query("select fullname,password from user where user_id=" + parent.getloggedId());
            if(qry.Rows.Count>0)
            {
                DataRow rw = qry.Rows[0];
                name.Text = rw[0].ToString();
                password = rw[1].ToString();
                loggedName.Content = "Logged in: " + name.Text;
            }
        }

 
        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.Close();
        }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_home();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_conversation();
        }

        private void label3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_settings();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            string name_ = (name.Text.Trim());
            if (name.Text.Trim().Equals(""))
            { MessageBox.Show("Missing Full Name", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            else
            {
                MySqlCommand comm = new MySqlCommand("update user set fullname=@name where user_id="+parent.getloggedId(), parent.getDbConnection());
                comm.Parameters.Add("@name", name_);
                comm.ExecuteNonQuery();

                MessageBox.Show("You have successfully updated your account information", "CCS", MessageBoxButton.OK, MessageBoxImage.Information);
                subparent.show_settings();

            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
           
            if (p1.Password.Trim().Equals("") || p2.Password.Trim().Equals(""))
            { MessageBox.Show("Incomplete Information", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            else
            {
                if (security.DecryptStringAES(password, parent.cipher_text).Equals(p1.Password))
                {

                    string pass = security.EncryptStringAES(p2.Password, parent.cipher_text);
                    MySqlCommand comm = new MySqlCommand("update user set password=@pass where user_id=" + parent.getloggedId(), parent.getDbConnection());
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





    }
}
