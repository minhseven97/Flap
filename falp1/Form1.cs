using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace falp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //playSimpleSound();
        }

        int KhoangCach2Ong = 200;

        int x_cap1, x_cap2, x_cap3;

        int y_ongtren1;
        int y_ongduoi1;

        int y_ongtren2;
        int y_ongduoi2;

        int  y_ongtren3;
        int  y_ongduoi3;

        int x_conchim, y_conchim;
        int diemso = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            //123
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Bounds = Screen.PrimaryScreen.Bounds;
           // MessageBox.Show("width + "+this.Width,"hei= "+this.Height);

            x_cap1 = this.Width +300; //cach vao 300
            y_ongtren1 = -350;
            ongtren1.Size = new Size(168, 755);
            ongtren1.Location = new Point(x_cap1, y_ongtren1);

            y_ongduoi1 = (755 + y_ongtren1) + KhoangCach2Ong;
            ongduoi1.Size = new Size(168, 755);
            ongduoi1.Location = new Point(x_cap1, y_ongduoi1);

            x_cap2 = x_cap1 + ongtren1.Width + 400; //cach o cu 250
            y_ongtren2 = -400;
            ongtren2.Size = new Size(168, 755);
            ongtren2.Location = new Point(x_cap2, y_ongtren2);

            y_ongduoi2 = (755 + y_ongtren2) + KhoangCach2Ong;
            ongduoi2.Size = new Size(168, 755);
            ongduoi2.Location = new Point(x_cap2, y_ongduoi2);

            x_cap3 = x_cap2 + ongtren2.Width + 400; //cach o cu 250
            y_ongtren3 = -350;
            ongtren3.Size = new Size(168, 755);
            ongtren3.Location = new Point(x_cap3, y_ongtren3);

            y_ongduoi3 = (755 + y_ongtren3) + KhoangCach2Ong;
            ongduoi3.Size = new Size(168, 755);
            ongduoi3.Location = new Point(x_cap3, y_ongduoi3);

            conchim.Size = new Size(100, 91);
            x_conchim = conchim.Location.X;
            y_conchim = conchim.Location.Y;

    //        label1.Location = new Point(this.Width-1200, this.Height-1300);

            timer1.Interval = 1;
            timer2.Interval = 1;

        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);//fig lag
            x_cap1 -= 10;
            x_cap2 -= 10;
            x_cap3 -= 10;
            ongtren1.Location = new Point(x_cap1, y_ongtren1);
            ongduoi1.Location = new Point(x_cap1, y_ongduoi1);

  
            ongtren2.Location = new Point(x_cap2, y_ongtren2);
            ongduoi2.Location = new Point(x_cap2, y_ongduoi2);

        
            ongtren3.Location = new Point(x_cap3, y_ongtren3);
            ongduoi3.Location = new Point(x_cap3, y_ongduoi3);

           // ktra cap1
           if(x_cap1 + ongtren1.Width <=0)
            {
                diemso++;
                x_cap1 = 950 + ongtren3.Width + 400;

                Random rd = new Random();
                y_ongtren1 = rd.Next(-600, -300);
                y_ongduoi1 = (755 + y_ongtren1) + KhoangCach2Ong;

                ongtren1.Location = new Point(x_cap1, y_ongtren1);
                ongduoi1.Location = new Point(x_cap1, y_ongduoi1);
            }
            if (x_cap2 + ongtren2.Width <= 0)
            {
                diemso++;
                x_cap2 = 950 + ongtren1.Width + 400;

                Random rd = new Random();
                y_ongtren2 = rd.Next(-600, -300);
                y_ongduoi2 = (755 + y_ongtren2) + KhoangCach2Ong;

                ongtren2.Location = new Point(x_cap2, y_ongtren2);
                ongduoi2.Location = new Point(x_cap2, y_ongduoi2);
            }
            if (x_cap3 + ongtren3.Width <= 0)
            {
                diemso++;
                x_cap3 = 950 + ongtren2.Width + 400;

                Random rd = new Random();
                y_ongtren3 = rd.Next(-600, -300);
                y_ongduoi3 = (755 + y_ongtren3) + KhoangCach2Ong;

                ongtren3.Location = new Point(x_cap3, y_ongtren3);
                ongduoi3.Location = new Point(x_cap3, y_ongduoi3);
            }
            label1.Text = "Score " + diemso.ToString();
        }
        private void nut_resert_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Visible = false;
            f1.ShowDialog();
        }
        int dem = 0;
        private void nutplay_Click(object sender, EventArgs e)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer();
            media.URL = @"E:\winforms\falp1\falp1\Resources\NhacGameFlappyBird.wav";
            dem++;
            if(dem%2 !=0)
            {
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                y_conchim -= 60;
                //Thread.Sleep(5);
                
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);//fig lag
            if (y_conchim + conchim.Height <= this.Height)
            {
                y_conchim += 9;//roi xuong 9
                conchim.Location = new Point(x_conchim, y_conchim);

                if (x_conchim + conchim.Width >= x_cap1 && x_conchim + conchim.Width <= x_cap1 + ongtren1.Width)
                {
                    if (y_conchim <= 755 + y_ongtren1 || y_conchim + conchim.Height >= y_ongduoi1)
                    {
                        timer1.Stop();
                       
                    }
                }
                if (x_conchim + conchim.Width >= x_cap2 && x_conchim + conchim.Width <= x_cap2 + ongtren2.Width)
                {
                    if (y_conchim <= 755 + y_ongtren2 || y_conchim + conchim.Height >= (755 + y_ongtren2) + KhoangCach2Ong)
                    {
                        timer1.Stop();
                        
                    }
                }
                if (x_conchim + conchim.Width >= x_cap3 && x_conchim + conchim.Width <= x_cap3 + ongtren3.Width)
                {
                    if (y_conchim <= 755 + y_ongtren3 || y_conchim + conchim.Height >= y_ongduoi3)
                    {
                        timer1.Stop();
                        
                    }
                }
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                WindowsMediaPlayer sound = new WindowsMediaPlayer();
                media.URL = @"C:\Users\Vu Duc Tinh\Downloads\bai_tap_dts\dts\đts\falp1\falp1\Resources\NhacGameFlappyBird.wav";
                media.Ctlcontrols.stop();
                DialogResult result= MessageBox.Show("Game over! Do you  want to play again?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                switch(result)
                {
                    case DialogResult.Yes:
                        nut_resert_Click(sender, e);
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                }
            }
            FileStream fs;
            String filepath = @"E:\winforms\falp1\falp1\input.txt";// đường dẫn của file muốn mở
            fs = new FileStream(filepath, FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string diem = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu, ReadToEnd là đọc hết
            fs.Close();
            if (diemso > Int32.Parse(diem))//mở file để lưu điểm;
            {
                fs = new FileStream(filepath, FileMode.Open);//mở file  tên là input.txt            
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine(diemso);// Ghi file
                sWriter.Flush();
                fs.Close();//đóng file
            }
            else
            {
                fs.Close();
            }
        }
    }
}
