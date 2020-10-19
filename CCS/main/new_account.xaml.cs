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



namespace CCS.main
{
    /// <summary>
    /// Interaction logic for new_account.xaml
    /// </summary>
    public partial class new_account : UserControl
    {
        MainWindow parent;
        public new_account(MainWindow root,string _email)
        {
            parent = root;
            InitializeComponent();
            email.Content = _email;
        }



        private void button2_Click(object sender, RoutedEventArgs e)
        {
            parent.show_get_started();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           

            if (textBox.Text.Trim().Equals(""))
            { MessageBox.Show("Missing Full Name", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
            else if (passwordBox.Password.Trim().Equals(""))
            { MessageBox.Show("Missing Password", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
            else
            {
                bool exist=false;
                string name = (textBox.Text.Trim());
                string pass = security.EncryptStringAES(passwordBox.Password, parent.cipher_text);
                string mail = parent.clean(email.Content.ToString());
                string id = "";

                DataTable qry = parent.query("select counselor_id as id,'counselor' as cat,fullname,password from counselor where email='" + mail + "' union select user_id as id,'user' as cat, fullname,password from user where email='" + mail + "' limit 1");
                if (qry.Rows.Count != 0)
                {
                    exist = true;
                }

               if (exist)
                { MessageBox.Show("Another user is registered with that email address", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
                else
                {
                   
                    MySqlCommand comm = new MySqlCommand("insert into user (email,password,fullname,date_joined) values(@email,@pass,@name,now())", parent.getDbConnection());
                    comm.Parameters.Add("@email", mail);
                    comm.Parameters.Add("@pass", pass);
                    comm.Parameters.Add("@name", name);
                    comm.ExecuteNonQuery();

                    DataTable id_qry = parent.query("select user_id from user where email='" + mail + "'");
                    if (id_qry.Rows.Count > 0)
                    {
                        DataRow row = id_qry.Rows[0];
                        id = (row[0].ToString());

                        MessageBox.Show("You have successfully created your account\nYou can now fully access the system", "CCS", MessageBoxButton.OK, MessageBoxImage.Information);
                        parent.show_resume_account(id, "user", name, pass);
                    }
                }    
            }


        }













    }
}