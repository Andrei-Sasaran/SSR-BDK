﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;


namespace DBexample1
{
    public partial class Form1 : Form
    {
        System.Data.SqlClient.SqlConnection myCon = new System.Data.SqlClient.SqlConnection();
        DataSet dsUniv;
        DataSet dsFac;
        public Form1()
        {
            InitializeComponent();
            myCon.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;
            AttachDbFilename = |DataDirectory|\Database1.mdf;Integrated Security=True";

            myCon.Open();
            dsUniv = new DataSet();
            dsFac = new DataSet();

            System.Data.SqlClient.SqlDataAdapter daUniv = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM Universitati",myCon);
            daUniv.Fill(dsUniv, "Universitati");

            System.Data.SqlClient.SqlDataAdapter daFac = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM Facultati", myCon);
            daFac.Fill(dsFac, "Facultati");

            foreach (DataRow dr in dsUniv.Tables["Universitati"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();
                listBox_Univ.Items.Add(name);
            }
            myCon.Close();
        }

        private void listBox_Univ_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Fac.Items.Clear();
            textBox_City.Clear();
            int code = 0;
            String UnivSelected = listBox_Univ.SelectedItem.ToString();
            foreach(DataRow dr in dsUniv.Tables["Universitati"].Rows)
            {
                if (UnivSelected == dr.ItemArray.GetValue(1).ToString())
                {
                    textBox_City.Text = dr.ItemArray.GetValue(2).ToString();
                    code = Convert.ToInt16(dr.ItemArray.GetValue(3));
                    textBox_CodeUni.Text = code.ToString();
                }
            }
            foreach(DataRow dr in dsFac.Tables["Facultati"].Rows)
            {
                if(code == Convert.ToInt16(dr.ItemArray.GetValue(1)))
                {
                    String nameFac = dr.ItemArray.GetValue(2).ToString();
                    listBox_Fac.Items.Add(nameFac);
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
