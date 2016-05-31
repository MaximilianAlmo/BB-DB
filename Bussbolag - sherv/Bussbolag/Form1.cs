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
        private MySqlConnection connection;

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
        }
    }
}
