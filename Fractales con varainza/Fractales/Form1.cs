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
    
            if (longitud > 20) {

                lapiz.Color = Color.Blue;
                Random rn = new Random();
         
                int angulo;double l;
                angulo = rn.Next(-5,5);
                l = rn.Next(4,9) / 10.0; 

                g.RotateTransform(trackBar1.Value+ angulo);
                dibujarRama(longitud * l);
                g.TranslateTransform(0, (float)(0 + longitud * l));
                g.RotateTransform((trackBar1.Value + angulo) * -1);
                lapiz.Color = Color.Black;
                angulo = rn.Next(-5, 5);
                l = rn.Next(4, 9) / 10.0;
                g.RotateTransform(angulo);
                dibujarRama(longitud * l);
                g.TranslateTransform(0, (float)(0 + longitud * l));
                g.RotateTransform((angulo) * -1);

                lapiz.Color = Color.Green;
                angulo = rn.Next(-5, 5);
                l = rn.Next(4, 9) / 10.0;
                g.RotateTransform((trackBar1.Value+ angulo) * -1); 
                dibujarRama(longitud * l);
                g.TranslateTransform(0, (float)(0 + longitud *l));
                g.RotateTransform(trackBar1.Value+ angulo);

            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.ResetTransform();
            g.TranslateTransform(x_orgien, y_origen);
            dibujarRama(100);
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
            dibujarRamaTimer(200);
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
