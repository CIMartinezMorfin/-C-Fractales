using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {

         List<PointF> Initiator;
        List<PointF> lista;
        float ScaleFactor;
         List<float> GeneratorDTheta;
        Graphics g;
        int depth;
        Pen l;
        public Form1()
        {
            InitializeComponent();
            
            g = this.CreateGraphics();
            Initiator = new List<PointF>();
            lista = new List<PointF>();
            GeneratorDTheta = new List<float>();
            this.KeyPreview = true;
        }

        private void DrawSnowflake(int depth)
        {
            g.Clear(Color.White);

            for (int i = 1; i < Initiator.Count; i++)
            {
                PointF p1 = Initiator[i - 1];
                PointF p2 = Initiator[i];

                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                float theta = (float)Math.Atan2(dy, dx);
                DrawSnowflakeEdge(depth, ref p1, theta, length);
            }
        }
 private void DrawSnowflakeEdge(int depth, ref PointF p1, float theta, float dist)
        {
            if (depth == 0)
            {
                PointF p2 = new PointF(
                    (float)(p1.X + dist * Math.Cos(theta)),
                    (float)(p1.Y + dist * Math.Sin(theta)));
                lista.Add(p1);
               /* System.Threading.Thread.Sleep(1500);*/
                g.DrawLine(Pens.Black, p1, p2);
                p1 = p2;
            }else{ 

            dist *= ScaleFactor;
            for (int i = 0; i < GeneratorDTheta.Count; i++)
            {
                theta += GeneratorDTheta[i];
              /*  System.Threading.Thread.Sleep(1000);
                g.DrawRectangle(Pens.Black,new Rectangle((int)p1.X, (int)p1.Y,3,3));*/
                DrawSnowflakeEdge(depth - 1, ref p1, theta, dist);
            }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initiator.Clear();
            lista.Clear();
            GeneratorDTheta.Clear();

            double radio = double.Parse(textBox1.Text);
            double a = (Math.PI * 2) / 3;
       
            ScaleFactor = 1 / 3f;
            depth =(int) numericUpDown1.Value;
            for (int i = 0; i < 3; i++){
                float x, y;
                x =(float) (radio * Math.Cos((a) * i));
                y = (float)(radio * Math.Sin((a) * i));
                x += this.Width / 2;
                y += this.Height / 2;

                Initiator.Add(new PointF(x, y));
            }
            Initiator.Add(new PointF(Initiator[0].X, Initiator[0].Y));
            float r = (float)(Math.PI / 180.0);
            GeneratorDTheta.Add(0);            
            GeneratorDTheta.Add(-r*60);        
            GeneratorDTheta.Add(+r*120);     
            GeneratorDTheta.Add(-r * 60);

            DrawSnowflake(depth);
        }
        void dibujar() {
            g.Clear(Color.White);
            for (int i=1;i<lista.Count;i++) {
                g.DrawLine(l, lista[i], lista[i-1]);
            }
            g.DrawLine(Pens.Black, lista[lista.Count-1], lista[0]);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
      

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    double angulo = -45 * (Math.PI / 180);
                    int x_origen = this.Width / 2;
                    int y_origen = this.Height / 2;
                    var p = lista[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    p.X = (float)(x_p);
                    p.Y = (float)(y_p);
                    lista[i] = p;

                }
                l = Pens.Blue;
                dibujar();
            }
            if (e.KeyCode == Keys.D)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    double angulo = 45 * (Math.PI / 180);
                    int x_origen = this.Width / 2;
                    int y_origen = this.Height / 2;
                    var p = lista[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    p.X = (float)(x_p);
                    p.Y = (float)(y_p);
                    lista[i] = p;

                }
                l = Pens.Green;
                dibujar();
            }
        }
    }
}
