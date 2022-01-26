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
using System.IO;

namespace WindowsFormsAppBanque
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.bunifuPages1.SetPage("comptes");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.bunifuPages1.SetPage("operations");

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'banqueDataSet.Compte'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            // TODO: cette ligne de code charge les données dans la table 'dB_CAT_RTDataSet.PRODUITS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            string strConnexion = @"Data Source=localhost;Initial Catalog=Banque;Integrated Security=True";
            this.label1.Text = Login.clt.nom + " " + Login.clt.prenom;

            this.bunifuPictureBox1.Image = Image.FromFile(Login.clt.photo);
            try
            {
                IDbConnection conn = new SqlConnection(strConnexion);
                IDbCommand cmd = conn.CreateCommand();
                string req = "Select num,plafond,solde from Compte where client =" + Login.clt.cin;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                IDbDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                this.bunifuDataGridView1.DataSource = ds.Tables[0];
                conn.Close();
                ///////////////////////////////////////////////////////
                SqlConnection con = new SqlConnection(strConnexion);
                con.Open();
                IDbCommand cmdbx = con.CreateCommand();
                //SqlCommand cmdcmb = new SqlCommand("Select num from Compte where client =" + Login.clt.cin, con);
                string cmbreq = "Select num from Compte where client =" + Login.clt.cin;

                cmdbx.CommandText = cmbreq;
                cmdbx.CommandType = CommandType.Text;
                DataSet dsbx = new DataSet();
                IDbDataAdapter dabx = new SqlDataAdapter();
                dabx.SelectCommand = cmd;
                dabx.Fill(dsbx);

                this.bunifuDropdown1.DataSource = dsbx.Tables[0];
                this.bunifuDropdown1.DisplayMember = "compte num";
                this.bunifuDropdown1.ValueMember = "num";
                con.Close();

            }
            catch (Exception exp)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + exp.Message);
            }
        }



        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string client = this.bunifuDropdown1.SelectedValue.ToString();
                string strConnexion = @"Data Source=localhost;Initial Catalog=Banque;Integrated Security=True";

                IDbConnection conn = new SqlConnection(strConnexion);
                IDbCommand cmd = conn.CreateCommand();
                string req = "select numero,date,montant,type from Transactions where client =" + client;
                cmd.CommandText = req;
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                IDbDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                this.bunifuDataGridView2.DataSource = ds.Tables[0];
                conn.Close();

            }
            catch (Exception exp)
            {

                Console.WriteLine("L'erreur suivante a été rencontrée :" + exp.Message);
            }
        }
    }
}
