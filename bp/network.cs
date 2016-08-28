using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bpc;

namespace bp
{
    public partial class Network : Control
    {
        public Form1 Form;

        public Network()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.Clear(Color.Black);

            if (Form.State == null) return;

            for (int k = 0; k < Form.Points.Count - 1; k++)
            {
                for (int i = 0; i < Form.Points[k].Count; i++)
                {
                    for (int j = 0; j < Form.Points[k + 1].Count; j++)
                    {
                        double d = Form.State.Weights[k][i][j];
                        Pen pen;

                        if (d < -2) pen = new Pen(Color.Purple);
                        else if (d < -1) pen = new Pen(Color.BlueViolet);
                        else if (d < -0.5) pen = new Pen(Color.Blue);
                        else if (d < -0.2) pen = new Pen(Color.MediumTurquoise);
                        else if (d < 0) pen = new Pen(Color.Green);
                        else if (d < 0.2) pen = new Pen(Color.YellowGreen);
                        else if (d < 0.5) pen = new Pen(Color.Yellow);
                        else if (d < 1) pen = new Pen(Color.Orange);
                        else if (d < 2) pen = new Pen(Color.OrangeRed);
                        else pen = new Pen(Color.Red);
                        e.Graphics.DrawLine(pen, Form.Points[k][i].X, Form.Points[k][i].Y, Form.Points[k + 1][j].X, Form.Points[k + 1][j].Y);
                    }
                }
            }
        }
    }
}
