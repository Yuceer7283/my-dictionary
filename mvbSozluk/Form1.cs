using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SqlClient;


namespace mvbSozluk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection yuceer = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vb_sozluk.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                yuceer.Open();
                OleDbCommand eklebtn = new OleDbCommand("insert into İngturkce (ingilizce,turkce) values('" + textBox1.Text + "','" + textBox2.Text + "')", yuceer);
                eklebtn.ExecuteNonQuery();
                yuceer.Close();
                MessageBox.Show("Kelime Sözlüğe Eklendi.", "Sözlük");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception bilgilendirme)
            {
                MessageBox.Show(bilgilendirme.Message, "Sözlük");
                yuceer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommandText: "SELECT * FROM İngturkce", yuceer);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                OleDbCommand komut = new OleDbCommand("select * from ingturkce where turkce like '" + textBox3.Text + "%' ", yuceer);
                OleDbDataAdapter ks = new OleDbDataAdapter(komut);
                DataTable tablo = new DataTable();
                ks.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                OleDbCommand komut = new OleDbCommand("select * from ingturkce where ingilizce like '" + textBox3.Text + "%' ", yuceer);
                OleDbDataAdapter ks = new OleDbDataAdapter(komut);
                DataTable tablo = new DataTable();
                ks.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }
    }
}
