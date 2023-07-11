using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
              MessageBox.Show("Var olan personel yada yeni eklenen personellerle giriş yapmayı deneyin !! " +
                             "Aksi taktirde çalışmaz!!! " +
                             "(Örneğin) " +
                             "Kullanıcı Adı :'emiirrhan' " +
                             "Şifre: '123456789'");*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            if (giris(textBox1.Text, textBox2.Text) == true)
            {
               
                form2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Hatalı Giriş");
        }

        public bool giris(string kullanici_adi, string parola)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=Dizi; User Id=postgres; Password=1234;"); conn.Open();
            string sql = "SELECT parola FROM personel WHERE kullanici_adi ='" + kullanici_adi + "'";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);

            string sifre = command.ExecuteScalar().ToString();
            conn.Close();
            if (parola == sifre)
                return true;
            else
            {
                MessageBox.Show("Hatali şifre");
                Application.Exit();

                return false;



            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            if (giris(textBox1.Text, textBox2.Text) == true)
            {
                form2.Show();
            }
            else
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
