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
        /// Rayon de la balle
        /// </summary>
        const float _rayon = 5.0f;
        /// <summary>
        /// Thread de gestion des deplacements
        /// </summary>
        Thread _thread = null;
        /// <summary>
        /// Boolean pour stopper le thread
        /// </summary>
        bool _bStop = false;

        public bool BStop
        {
            get { return _bStop; }
            set { _bStop = value; }
        }

        /// <summary>
        /// Contructeur
        /// </summary>
        public Jeux()
        {
            InitializeComponent();
            _thread = new Thread(ThreadFunc);
            _p = new PointF(50, 50);
            _v = new PointF(1.0f, 1.0f);
            _thread.Start();
        }

        /// <summary>
        /// Thread gestion des deplacements
        /// </summary>
        void ThreadFunc()
        {
            for (; _bStop == false; )
            {
                //Deplacement sur les X
                _p.X += _v.X;
                //Test si on sort sur les X
                if ((_p.X<_rayon) || (_p.X > this.Width-_rayon))
                    _v.X *= -1.0f;

                //Deplacement sur les Y
                _p.Y += _v.Y;
                //Test si on sort sur les Y
                if ((_p.Y < _rayon) || (_p.Y > this.Height - _rayon))
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
            e.Graphics.DrawEllipse(pen, _p.X - _rayon, _p.Y - _rayon, _rayon*2.0f, _rayon*2.0f);
            base.OnPaint(e);
        }
    }
}
