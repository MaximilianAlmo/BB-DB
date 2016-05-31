using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Bussbolag
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        string namn, 
            adress;

        int personNr, 
            reseId = 2,
            antal, 
            pris;

        MySqlConnection connection = new MySqlConnection("SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        //MySqlDataReader dr;
        DataTable dt;
        int totalPrice;

         
        private void FormMySQL_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Test");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM bussresa WHERE (avgStad LIKE '%" + textBox3.Text + "%' AND stadnamn LIKE '%" + textBox4.Text + "%');";       

            cmd = new MySqlCommand(query, connection);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            //Visar Priset för resan
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "pris";
            listBox1.ValueMember = "reseID";

            // Visar Avgångstiden
            listBox2.DataSource = dt;
            listBox2.DisplayMember = "avgangstid";
            listBox2.ValueMember = "reseID";

            // Visar Ankomsttiden
            listBox3.DataSource = dt;
            listBox3.DisplayMember = "ankomsttid";
            listBox3.ValueMember = "reseID";

            // Visar Från 
            listBox4.DataSource = dt;
            listBox4.DisplayMember = "avgStad";
            listBox4.ValueMember = "reseID";

            // Visar Till 
            listBox5.DataSource = dt;
            listBox5.DisplayMember = "stadnamn";
            listBox5.ValueMember = "reseID";

            da.Dispose();
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            namn = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            personNr = int.Parse(textBox2.Text);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            antal = int.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;";
            connection = new MySqlConnection(connectString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select bussresa(pris) where reseId ='" + reseId + "'";
            pris = (int)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            pris = pris * antal;
            //string userPicturePath = (string)cmd.ExecuteScalar();
            connection.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            adress = textBox8.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT adress from resenar WHERE personNr='" + personNr + "'";
            connection.Open();
            cmd = new MySqlCommand(query ,connection);
            adress = (string)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT into resenar(personNr, namn, adress) values ('" + personNr + "','" + namn + "','" + adress + "')";
            connection.Open();
            cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;";
            connection = new MySqlConnection(connectString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into Harbokat(personNr,reseId, antal) values('" + personNr + "' , '" + reseId + "','" + antal + "')";
            cmd.ExecuteNonQuery();
            connection.Close();

            string query = "UPDATE bussresa SET platser = platser - '" + antal + "' where reseId = '" + reseId + "'";
            connection.Open();
            cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
