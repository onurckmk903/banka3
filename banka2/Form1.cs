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

namespace banka2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        SqlConnection con=new SqlConnection("server=DESKTOP-BVGAO0O; initial catalog=Mobilbankacılık; integrated security=sspi;");
       public static string adSoyad = "";
        public static int mID;
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi=textBox1.Text;
            string kparola=textBox2.Text;
            bool sonuc = false;
            if (radioButton1.Checked) 
            { 
                    if(kAdi=="Admin" && kparola=="123")
                {
                    Yetkiliİşlemleri yi=new Yetkiliİşlemleri();
                    yi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Parola", "Hatalı giriş denemesi");
                }
 
            }
            else 
            { 
            con.Open();
                SqlCommand cmd = new SqlCommand("select * from musteriler where tcNo=@p1 and sifre = @p2 ",con );
                cmd.Parameters.AddWithValue("@p1",kAdi);
                cmd.Parameters.AddWithValue("@p2",kparola);
                
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    adSoyad = dr["adSoyad"].ToString();
                    mID = int.Parse( dr["ID"].ToString());
                    sonuc = true;
                }
                con.Close();
                if (sonuc)
                {
                    sonuc = false;
                    musteriİslemleri mi = new musteriİslemleri();
                    mi.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı/TC veya Parola","Hatalı giriş denemesi");
                }
                
            }
           textBox1.Text = "";
           textBox2.Text = "";
        }
    }
}
