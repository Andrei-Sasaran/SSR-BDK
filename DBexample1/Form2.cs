using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DBexample1
{
    public partial class Form2 : Form
    {

        private System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();
        
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string IdUniv = textBox_IdUni.Text;
            string NumeUniv = textBox_NameUni.Text;
            string CityUniv = textBox_CityUni.Text;
            string CodeUniv = textBox_CodeUni.Text;

            try
            {

                connection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;
            AttachDbFilename = |DataDirectory|\Database1.mdf;Integrated Security=True";

                connection.Open();

                string procedure = "INSERT INTO Universitati (Id,NumeUniv,City,Code) VALUES (@Id,@Nume,@City,@Code);";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(procedure, connection);


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", int.Parse(IdUniv)));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Nume", NumeUniv));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", CityUniv));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Code", int.Parse(CodeUniv)));


                int rowsAffected = command.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                        
                    label5.Text = "Datele au fost adaugate cu succes!";
                }
                else
                {
                    label5.Text = "Nu s-au putut adauga datele!";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

