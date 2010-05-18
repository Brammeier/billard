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
    }
}
