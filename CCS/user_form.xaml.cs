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
using System.Data;
using WpfPageTransitions;

namespace CCS
{
    /// <summary>
    /// Interaction logic for user_form.xaml
    /// </summary>
    public partial class user_form : Window
    {
        MainWindow parent;
        public int [] ques_id;
         int [,] career;
        int [,] interest;


        public user_form(MainWindow root)
        {
            parent = root;
            InitializeComponent();

            show_home();

        }

        private void get_questions()
        {
            if (parent.getloggedCategory().Equals("user"))
            {
                DataTable qry = parent.query("select question_id from questions order by question_id asc");
                int index = -1;
                ques_id = new int[qry.Rows.Count];
                foreach (DataRow rw in qry.Rows)
                {
                    ques_id[++index] = Int32.Parse(rw[0].ToString());
                }


                qry = parent.query("select career_id from career order by career_id asc");
                index = -1;
                career = new int[qry.Rows.Count, 2];
                foreach (DataRow rw in qry.Rows)
                {
                    int ind = ++index;
                    career[ind, 0] = Int32.Parse(rw[0].ToString());
                    career[ind, 1] = 0;
                }

            

                qry = parent.query("select interest_id from interest order by interest_id asc");
                index = -1;
                interest = new int[qry.Rows.Count, 2];
                foreach (DataRow rw in qry.Rows)
                {
                    int ind = ++index;
                    interest[ind, 0] = Int32.Parse(rw[0].ToString());
                    interest[ind, 1] = 0;
                }

                 Random rnd = new Random();
                int[] mt = ques_id.OrderBy(x => rnd.Next()).ToArray();
                ques_id = mt;


            }
        }


        public void show_home()
        {
            if (parent.getloggedCategory().Equals("user"))
            {
                user.home newPage = new user.home(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }


            if (parent.getloggedCategory().Equals("counselor"))
            {
                  counselor.home newPage = new counselor.home(parent,this);
                   transition.TransitionType = PageTransitionType.Fade;
                   transition.ShowPage(newPage);
            
            }

            if (parent.getloggedCategory().Equals("admin"))
            {
                admin.home newPage = new admin.home(parent,this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }

        }



        public void show_conversation()
        {

            if (parent.getloggedCategory().Equals("user"))
            {
                user.conversation newPage = new user.conversation(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }


            if (parent.getloggedCategory().Equals("counselor"))
            {
                counselor.conversation newPage = new counselor.conversation(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }
        }


        public void show_settings()
        {

           if (parent.getloggedCategory().Equals("user"))
            {
                user.setting  newPage= new user.setting(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }


            if (parent.getloggedCategory().Equals("counselor"))
            {
                   counselor.setting newPage = new counselor.setting(parent, this);
                  transition.TransitionType = PageTransitionType.Fade;
                  transition.ShowPage(newPage);
          
            }

            if (parent.getloggedCategory().Equals("admin"))
            {
                admin.setting newPage = new admin.setting(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }

        }


        public void show_career()
        {

            if (parent.getloggedCategory().Equals("counselor"))
            {
                counselor.career_interest newPage = new counselor.career_interest(parent, this);
                transition.TransitionType = PageTransitionType.Fade;
                transition.ShowPage(newPage);
            }


        }



        public void start_test()
        {
            get_questions();
           
            if (ques_id.Length == 0)
            {
                MessageBox.Show("No questions in the system", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (parent.getloggedCategory().Equals("user"))
                {
                    user.test newPage = new user.test(parent, this, 1800, 1);
                    transition.TransitionType = PageTransitionType.FlipAndFade;
                    transition.ShowPage(newPage);
                }
            }
        }


        public void next_question(int sec, int ques, int value, string q_category, int q_cat_id)
        {

            if (q_category.Equals("career"))
            {
                for (int cr = 0; cr < (career.Length/2); cr++)
                {
                    if (career[cr, 0] == q_cat_id)
                    { career[cr, 1] += value; break; }
                }
            }

            if (q_category.Equals("interest"))
            {
                for (int cr = 0; cr < (interest.Length/2); cr++)
                {
                    if (interest[cr, 0] == q_cat_id)
                    { interest[cr, 1] += value; break; }
                }
            }

            user.test newPage = new user.test(parent, this,sec, ques);
            transition.TransitionType = PageTransitionType.SlideAndFade;
            transition.ShowPage(newPage);
        }
        

        public void end_test(int sec, int ques, int value, string q_category, int q_cat_id)
        {
            if (q_category.Equals("career"))
            {
                for (int cr = 0; cr <( career.Length/2); cr++)
                {
                    if (career[cr, 0] == q_cat_id)
                    { career[cr, 1] += value; break; }
                }
            }

            if (q_category.Equals("interest"))
            {
                for (int cr = 0; cr < (interest.Length/2); cr++)
                {
                    if (interest[cr, 0] == q_cat_id)
                    { interest[cr, 1] += value; break; }
                }
            }

            int assess_id = 0;
            int sec_left = 1800 - sec;
            int min = sec_left / 60;
            string time = "";

            if (min < 10)
                time = "0" + min + " : ";
            else
                time = min.ToString()+" : ";

            if ((sec_left-(min*60))<10)
            {
               
                time += "0" + (sec_left - (min * 60));
            }
            else
            {
                
                time +=  (sec_left - (min * 60)).ToString();
            }

            parent.query("insert into assessment (user_id,duration,date_taken) values(" + parent.getloggedId() + ",'" + time + "',now())");
            DataTable qry = parent.query("select max(assessment_id) from assessment where user_id=" + parent.getloggedId());
            if(qry.Rows.Count>0)
            { DataRow rw = qry.Rows[0]; assess_id = Int32.Parse(rw[0].ToString()); }
         

            for (int cr = 0; cr < (career.Length/2); cr++)
            {
                parent.query("insert into result (assessment_id,user_id,career_id,percent) values(" + assess_id + "," + parent.getloggedId() + "," + career[cr, 0] + "," + career[cr, 1] + ")");
            }

            for (int cr = 0; cr < (interest.Length/2); cr++)
            {
                parent.query("insert into result (assessment_id,user_id,interest_id,percent) values(" + assess_id + "," + parent.getloggedId() + "," + interest[cr, 0] + "," + interest[cr, 1] + ")");
            }


            user.result newPage = new user.result(parent, this,assess_id);
            transition.TransitionType = PageTransitionType.SlideAndFade;
            transition.ShowPage(newPage);

        }
        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("Are you sure you want to log out?", "CCS", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                parent.signout();
                parent.Visibility = Visibility.Visible;
                e.Cancel = false;
            }
        }

     public void show_result_history(int assess_id)
        {
            user.result newPage = new user.result(parent, this, assess_id);
            transition.TransitionType = PageTransitionType.SlideAndFade;
            transition.ShowPage(newPage);
        }



    }
}
