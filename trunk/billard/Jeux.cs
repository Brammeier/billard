using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace billard
{
    /// <summary>
    /// Classe du plateau de billard
    /// </summary>
    public partial class Jeux : UserControl
    {
        /// <summary>
        /// Position de la balle
        /// </summary>
        PointF _p ;
        /// <summary>
        /// Vecteur de deplacement
        /// </summary>
        PointF _v ;
        /// <summary>
        /// Diametre de la balle
        /// </summary>
        const float _diam = 10.0f;
        /// <summary>
        /// Thread de gestion des deplacements
        /// </summary>
        Thread _thread = null;

        /// <summary>
        /// Contructeur
        /// </summary>
        public Jeux()
        {
            InitializeComponent();
            _thread = new Thread(ThreadFunc);
            _p = new PointF(10, 10);
            _v = new PointF(1.0f, 1.0f);
            _thread.Start();
        }

        /// <summary>
        /// Thread gestion des deplacements
        /// </summary>
        void ThreadFunc()
        {
            for (; ; )
            {
                //Deplacement sur les X
                _p.X += _v.X;
                //Test si on sort sur les X
                if ((_p.X<0.0f) || (_p.X > this.Width))
                    _v.X *= -1.0f;

                //Deplacement sur les Y
                _p.Y += _v.Y;
                //Test si on sort sur les Y
                if  ((_p.Y<0.0f) || (_p.Y > this.Height))
                    _v.Y *= -1.0f;

                //Attente
                Thread.Sleep(10);
                //Force le repaint 
                this.Invalidate();
            }
        }

        /// <summary>
        /// Surcharge de la fonction de dessin
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black));
            e.Graphics.DrawEllipse(pen, _p.X, _p.Y, _diam, _diam);
            base.OnPaint(e);
        }
    }
}
