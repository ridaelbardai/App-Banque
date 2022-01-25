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
            // TODO: cette ligne de code charge les données dans la table 'dB_CAT_RTDataSet.PRODUITS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            string strConnexion = @"Data Source=localhost;Initial Catalog=Banque;Integrated Security=True";
            this.label1.Text = Login.clt.nom;
            this.label2.Text = Login.clt.prenom;
            this.bunifuPictureBox1.Image = Image.FromFile(Login.clt.photo);
            try
            {
                IDbConnection conn = new SqlConnection(strConnexion);
                IDbCommand cmd = conn.CreateCommand();
                string req = "Select * from Client";
                cmd.CommandText = req;
                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                IDbDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                this.bunifuDataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception exp)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + exp.Message);
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
