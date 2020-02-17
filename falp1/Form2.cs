using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace falp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Visible = false;
            f1.ShowDialog();
        }
        //xem diem cao
        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs;
            string name = @"E:\winforms\falp1\falp1\input.txt";//tên đường dẫn đầy đủ của 1 tập tin
            fs = new FileStream(name, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string diem = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu, ReadToEnd là đọc 
            rd.Close();
            txtdiem.Text = diem;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
