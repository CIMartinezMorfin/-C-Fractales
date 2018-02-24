using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractales
{
    public partial class Form1 : Form
    {
        Graphics g;

        Pen lapiz = new Pen(Color.Black, 1);
        int x_orgien, y_origen;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            x_orgien = panel1.Width / 2;
            y_origen= panel1.Height;
            g.TranslateTransform(x_orgien,y_origen);
        }

        void dibujarRama(double longitud){
            g.DrawLine(lapiz, new Point(0,0), new Point(0,(int)( 0 - longitud)));
            g.TranslateTransform(0, (float)(0 - longitud));
           
            if (longitud > 2 ) {

                g.RotateTransform(trackBar1.Value);
                dibujarRama(longitud * 0.6);
                g.TranslateTransform(0, (float)(0 + longitud * 0.6));
                g.RotateTransform(trackBar1.Value*-1);


                g.RotateTransform(trackBar1.Value*-1);
                dibujarRama(longitud * 0.6);
                g.TranslateTransform(0, (float)(0 + longitud * 0.6));
                g.RotateTransform(trackBar1.Value);
   
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.ResetTransform();
            g.TranslateTransform(x_orgien, y_origen);
            dibujarRama(200);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            x_orgien = panel1.Width / 2;
            y_origen = panel1.Height;
            g.TranslateTransform(x_orgien, y_origen);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.ResetTransform();
            g.TranslateTransform(x_orgien, y_origen);
            dibujarRamaTimer(100);
        }


     void dibujarRamaTimer(double longitud)
        {
            System.Threading.Thread.Sleep(500);
            
            g.DrawLine(lapiz, new Point(0, 0), new Point(0, (int)(0 - longitud)));
            g.TranslateTransform(0, (float)(0 - longitud));

            if (longitud > 4)
            {

               
                g.RotateTransform(trackBar1.Value);
               
                dibujarRamaTimer(longitud * 0.6);
                g.TranslateTransform(0, (float)(0 + longitud * 0.6));
                g.RotateTransform(trackBar1.Value * -1);

                
                g.RotateTransform(trackBar1.Value * -1);
        
                dibujarRamaTimer(longitud * 0.6);
                g.TranslateTransform(0, (float)(0 + longitud * 0.6));
                g.RotateTransform(trackBar1.Value);

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
