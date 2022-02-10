using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AppBanqueLibdll;

namespace WindowsFormsAppBanque
{
    public partial class Login : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        public static Client clt;


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Banque;Integrated Security=True");
            cn.Open();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuTextBox1.Text != string.Empty || bunifuTextBox2.Text != string.Empty)
                {

                    cmd = new SqlCommand("select * from Client where login='" + bunifuTextBox1.Text + "' and password='" + bunifuTextBox2.Text + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        clt = new Client(dr.GetString(1), dr.GetString(2), dr.GetString(0), dr.GetString(3), dr.GetString(4),dr.GetString(5));
                        dr.Close();
                        this.Hide();
                        new Form4().Show();
                        
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception exp)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + exp.Message);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
