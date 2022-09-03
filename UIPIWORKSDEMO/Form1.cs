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

namespace UIPIWORKSDEMO
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pross()
        {
            komut = new SqlCommand("Select * From Table1", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                }

                reader = komut.ExecuteReader();
                DataTable tablo = new DataTable();
                tablo.Load(reader);
                guna2DataGridView1.DataSource = tablo;
                baglanti.Close();

            }

            catch (Exception ex)
            {
                
            }
        }

        SqlCommand komut;
        SqlConnection baglanti = new SqlConnection("Data Source = PATATES; Initial Catalog = exdatab; Integrated Security = True");
        SqlDataReader reader;
        SqlDataAdapter da;

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
            guna2Button1.Visible = false;

            pross();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Insert Into Table1 (UserName, Email, Enabled, Phone, UserRole, DisplayName) values (@username,@email,@enabled,@phone,@userrole,@displayname)", baglanti);
            komut.Parameters.AddWithValue("@email", guna2TextBox4.Text);
            komut.Parameters.AddWithValue("@phone", guna2TextBox3.Text);
            komut.Parameters.AddWithValue("@username", guna2TextBox1.Text);
            komut.Parameters.AddWithValue("@displayname", guna2TextBox2.Text);
            komut.Parameters.AddWithValue("@enabled", guna2TextBox5.Text);
            komut.Parameters.AddWithValue("@userrole", guna2TextBox6.Text);
            
            try
            {
                if(baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                }

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Successful !!!");
                pross();
            }

            catch (Exception)
            {
                MessageBox.Show("Error !!!");
            }
            
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
              if (MessageBox.Show("Are You Sure To Exit Programme ?","Exit",MessageBoxButtons.OKCancel)== DialogResult.OK)
     {
         Application.Exit();
     }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            guna2Panel1.Visible = true;
            guna2Button1.Visible = true;
            guna2DataGridView1.Size = new Size(370, 275);
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked)
            {
                guna2TextBox5.Text = "true";
            }
            else if (!guna2CheckBox2.Checked)
            {
                guna2TextBox5.Text= "false";
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                guna2TextBox6.Text = "Admin";
            }
            
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                guna2TextBox6.Text = "Guest";
            }

            else if (guna2ComboBox1.SelectedIndex ==2) 
            {
                guna2TextBox6.Text = "SuperAdmin";
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {   
            if (guna2ToggleSwitch1.Checked && guna2DataGridView1.Columns[4] == ' false ')
            {
                guna2DataGridView1.
            }
        }
    }
}
