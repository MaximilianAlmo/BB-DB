using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bussbolag
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        int personNr;
        string namn;        
        string adress;
=======
        private MySqlConnection connection;
>>>>>>> origin/master

        public Form1()
        {
            InitializeComponent();
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            namn = textBox1.Text;
            
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            personNr =  int.Parse(textBox2.Text); 
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            adress = textBox8.Text;
        }
        //Logga in
        private void button1_Click(object sender, EventArgs e)
        {
            string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;";
            MySqlConnection connection = new MySqlConnection(connectString);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();

            ///string userPicturePath = (string)cmd1.ExecuteScalar();
            cmd2.CommandText = "SELECT adress FROM resenar WHERE personNr ='" + personNr + "'";
             adress = (string)cmd2.ExecuteScalar();
            cmd2.ExecuteNonQuery();
            connection.Close();
=======
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;";
                 connection = new MySqlConnection(connectString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "intsert into table bussresa(reseId,pris) values('" + reseId + " , "   +pris+"'";
            Int32 userEdit = (Int32)cmd.ExecuteScalar();
            cmd.CommandText = "UPDATE profile SET picturePath=@picturePath WHERE UserName ='" + User.Identity.Name + "' AND id ='" + userEdit + "'";
>>>>>>> origin/master
        }

        //Registrera resenär
        private void button2_Click(object sender, EventArgs e)
        {
            string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af9704;UID=af9704 ;PASSWORD=Shervin05;";
            MySqlConnection connection = new MySqlConnection(connectString);
            connection.Open();
            MySqlCommand cmd1 = connection.CreateCommand();
            cmd1.CommandText = "insert into resenar(personNr, namn, adress) values ('" + personNr + "', '" + namn + "', '" + adress + "')";
            //cmd1.CommandText = "INSERT INTO " + resenar + " (" + column + ") VALUES (" + value + ")";
            cmd1.ExecuteNonQuery();
            connection.Close();
        }

       
    }
}
