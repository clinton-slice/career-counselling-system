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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace CCS.dialog
{
    /// <summary>
    /// Interaction logic for accounts.xaml
    /// </summary>
    public partial class accounts : Window
    {
        MainWindow parent;
        string category = "";

        class AccountHolder
        {
           public string id { set; get; }
           public string fullname { set; get; }
           public string email { set; get; }
           public string date { set; get; }
        
        }


        public accounts(MainWindow root, string category_)
        {
            parent = root;
            category = category_;
            InitializeComponent();

            if (category_.Equals("user"))
            {
                textBlock.Text = "User Accounts";

                DataTable qry = parent.query("select * from user order by fullname");
                foreach(DataRow rw in qry.Rows)
                {
                    AccountHolder holder = new AccountHolder();
                    holder.id = rw["user_id"].ToString();
                    holder.fullname = rw["fullname"].ToString();
                    holder.email = rw["email"].ToString();
                    holder.date = rw["date_joined"].ToString();
                    listView.Items.Add(holder);
                }

            }


            if (category_.Equals("counselor"))
            {
                textBlock.Text = "Counselor Accounts";

                DataTable qry = parent.query("select * from counselor order by fullname");
                foreach (DataRow rw in qry.Rows)
                {
                    AccountHolder holder = new AccountHolder();
                    holder.id = rw["counselor_id"].ToString();
                    holder.fullname = rw["fullname"].ToString();
                    holder.email = rw["email"].ToString();
                    holder.date = rw["date_added"].ToString();
                    listView.Items.Add(holder);
                }
            }

 
        }


        private void delete(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            AccountHolder account = b.CommandParameter as AccountHolder;
            string id = account.id;

            if(category.Equals("user"))
            {

                if (MessageBox.Show("All Information about this user, assessment results, conversations would be deleted!\nProceed?", "CCS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataTable qry = parent.query("select conversation_id from conversation where user_id=" + id);
                    foreach (DataRow rw in qry.Rows)
                    {
                        parent.query("delete from user_message where conversation_id=" + rw[0]);
                        parent.query("delete from counselor_message where conversation_id=" + rw[0]);
                        parent.query("delete from conversation where conversation_id=" + rw[0]);
                    }

                    parent.query("delete from result where user_id=" + id);
                    parent.query("delete from assessment where user_id=" + id);
                    parent.query("delete from user where user_id=" + id);
                    listView.Items.Remove(account);
                }
            }


            if (category.Equals("counselor"))
            {

                if (MessageBox.Show("All Information about this counselor, conversations would be deleted!\nProceed?", "CCS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataTable qry = parent.query("select conversation_id from conversation where counselor_id=" + id);
                    foreach (DataRow rw in qry.Rows)
                    {
                        parent.query("delete from user_message where conversation_id=" + rw[0]);
                        parent.query("delete from counselor_message where conversation_id=" + rw[0]);
                        parent.query("update conversation set counselor_id=null where conversation_id=" + rw[0]);
                    }

                     parent.query("delete from counselor where counselor_id=" + id);
                    listView.Items.Remove(account);
                }
            }





        }



        private void reset(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            AccountHolder account = b.CommandParameter as AccountHolder;
            string id = account.id;
            string g_pass = generatePassword();
            string new_pass = security.EncryptStringAES(g_pass, parent.cipher_text);

            if (MessageBox.Show("Reset Account Password!\nProceed?", "CCS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                if(category.Equals("user"))
                {
                    MySqlCommand comm = new MySqlCommand("update user set password=@pass where user_id="+id, parent.getDbConnection());
                    comm.Parameters.Add("@pass",new_pass);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("New password is: " + g_pass, "CCS");
                }

                if (category.Equals("counselor"))
                {
                    MySqlCommand comm = new MySqlCommand("update counselor set password=@pass where counselor_id=" + id, parent.getDbConnection());
                    comm.Parameters.Add("@pass", new_pass);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("New password is: " + g_pass, "CCS");
                }

            }

        }

        public string generatePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

        }





    }
}
