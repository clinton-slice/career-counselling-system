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
using System.Data;

namespace CCS.counselor
{
    /// <summary>
    /// Interaction logic for career_interest.xaml
    /// </summary>
    public partial class career_interest : UserControl
    {
        MainWindow parent;
        user_form subparent;

        public career_interest(MainWindow root, user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();
            loggedName.Content = "Logged in: " + parent.getloggedname();


            DataTable qry = root.query("select 'Career' as cat,career_id as id, career_name as name from career union select 'Sub Career' as cat,interest_id as id, interest_name as name from interest order by name asc");
            foreach (DataRow rw in qry.Rows)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;

                if(rw["cat"].ToString().Equals("Career"))
                  panel.Name = "pan_" + rw["id"].ToString()+"_career";
                else
                    panel.Name = "pan_" + rw["id"].ToString() + "_interest";

                Label label = new Label();
                label.Content = rw["name"].ToString();
                label.Width = 230;
                panel.Children.Add(label);


                Label label2 = new Label();
                label2.Content =  "  ( " + rw["cat"].ToString() + " )";
                panel.Children.Add(label2);

             

                listBox.Items.Add(panel);
            }

            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;

        }



        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.Close();
        }


        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_home();
        }

        private void career_label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            subparent.show_career();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_conversation();
        }

        private void label3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_settings();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                 
                StackPanel stk = listBox.SelectedItem as StackPanel;
                Label lab = stk.Children[0] as Label;
               
                int cid = Int32.Parse(stk.Name.Split(new Char[] { '_' })[1]);
                DataTable qry = null;

                if(stk.Name.Split(new Char[] { '_' })[2].ToString().Equals("career"))
                {
                    qry = parent.query("select description from career where career_id=" + cid);
                }
                else
                {
                    qry = parent.query("select description from interest where interest_id=" + cid);
                }

                info.Text = "";
                if (qry.Rows.Count > 0)
                {
                    DataRow rw = qry.Rows[0];
                    info.Text = rw[0].ToString();
                }
                else
                { info.Text = "No Information about this career"; }
            }
        }
    }
}
