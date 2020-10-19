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
using System.Windows.Threading;
using System.Data;

namespace CCS.user
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : UserControl
    {

        MainWindow parent;
        user_form subparent;
        int quest = 0;
        int sec_ = 0;
        DispatcherTimer timer;
        string q_category = "";
        int q_cat_id = 0;

        public test(MainWindow root, user_form subroot, int sec_left, int question)
        {
            parent = root;
            subparent = subroot;
            quest = question;
            sec_ = sec_left;
            InitializeComponent();

            question_no.Text = "Question " + quest+" of 60";

            DataTable qry = parent.query("select * from questions where question_id=" + (subparent.ques_id[(question - 1)]));
            if(qry.Rows.Count==0)
            { MessageBox.Show("An error occured", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); subparent.show_home(); }
            else
            {
                DataRow rw = qry.Rows[0];
                question_label.Text = rw["question"].ToString();

                if (!rw["career_id"].ToString().Trim().Equals(""))
                   { q_category = "career"; q_cat_id = Int32.Parse(rw["career_id"].ToString()); }
                if (!rw["interest_id"].ToString().Trim().Equals(""))
                   { q_category = "interest"; q_cat_id = Int32.Parse(rw["interest_id"].ToString()); }
 
            }

            if (quest == 60)
                button.Content = "Submit";

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }



        private void timer_tick(object sender, EventArgs e)
        {
            if ((--sec_) > 0)
            {
                int min = sec_ / 60;
                int second = sec_ - (min * 60);

                string time = "";

                if (min < 10)
                    time = "0" + min + " : ";
                else
                    time = min.ToString()+" : ";

                if (second < 10)
                    time += "0" + second;
                else
                    time += "" + second;

                textBlock.Text = time;
                if (sec_ <= 40)
                    textBlock.Foreground = Brushes.Red;
            }
            else
            {
                timer.IsEnabled = false;
                textBlock.Text = "00 : 00";
                MessageBox.Show(sec_+"You failed to complete the test within 30 minutes", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                subparent.show_home();
            }

        }


        private void button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            int value = 0;
            bool allow = true;

            if (rad1.IsChecked == false && rad2.IsChecked == false && rad3.IsChecked == false && rad4.IsChecked == false)
            {
                MessageBox.Show("You have not selected an option", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                allow = false;
            }
            else if (rad1.IsChecked == true)
            {
                if (q_category.Equals("career"))
                    value = 25;

                if (q_category.Equals("interest"))
                    value = 50;

            }

            else if (rad2.IsChecked == true)
            {
                if (q_category.Equals("career"))
                    value = 18;

                if (q_category.Equals("interest"))
                    value = 35;

            }

            else if (rad3.IsChecked == true)
            {
                if (q_category.Equals("career"))
                    value = 7;

                if (q_category.Equals("interest"))
                    value = 15;

            }
            else
                value = 0;


            if (allow)
            {
                timer.IsEnabled = false;
                if (++quest <= 60)
                {
                    
                    subparent.next_question(sec_, quest, value, q_category, q_cat_id);

                }
                else
                    subparent.end_test(sec_, quest, value, q_category, q_cat_id);
            }


        }


        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
 
            if (MessageBox.Show("Are you sure to want to end this test?\nNothing would be recorded", "CCS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { timer.IsEnabled = false; subparent.show_home(); }
        }










    }
}
