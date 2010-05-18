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
        List<Balle> _balles = new List<Balle>();

        /// <summary>
        /// Thread de gestion des deplacements
        /// </summary>
        Thread _thread = null;
        /// <summary>
        /// Boolean pour stopper le thread
        /// </summary>
        bool _bStop = false;
        /// <summary>
        /// Position de la souris
        /// </summary>
        Point _mouseDown;
        /// <summary>
        /// Etat de la souris
        /// </summary>
        bool _bMouseDown = false;
        /// <summary>
        /// La balle selectionne par la souris
        /// </summary>
        Balle _curBalle = null;

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
            _thread.Start();
            _balles.Add(new Balle(new PointF(50.0f,50.0f)));
            _balles.Add(new Balle(new PointF(150.0f, 100.0f)));
        }

        /// <summary>
        /// Thread gestion des deplacements
        /// </summary>
        void ThreadFunc()
        {
            for (; _bStop == false; )
            {
                foreach (var item in _balles)
                {
                    item.deplacement(this.Width, this.Height);
                }
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
            foreach (var item in _balles)
            {
                item.dessin(e.Graphics); 
            }            
            base.OnPaint(e);
        }

        private void Jeux_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var item in _balles)
            {
                if (item.isIn(e.Location))
                {
                    _mouseDown = new Point((int)item.Position.X, (int)item.Position.Y);
                    _bMouseDown = true;
                    _curBalle = item;
                }
            }

        }

        private void Jeux_MouseUp(object sender, MouseEventArgs e)
        {
            if (_bMouseDown)
            {
                float x = e.X - _curBalle.Position.X ;
                float y = e.Y - _curBalle.Position.Y ;
                float max = Math.Max( x, y );
                x /= max ;
                y /= max ;
                _curBalle.Vecteur = new PointF( -x, -y);
            }
            _bMouseDown = false;
        }

        private void Jeux_MouseMove(object sender, MouseEventArgs e)
        {
            if (_bMouseDown)
            {
                Graphics g = CreateGraphics();
                Pen pen = new Pen(new SolidBrush(Color.Black));
                g.DrawLine(pen, _mouseDown, e.Location);
            }
        }
    }
}
