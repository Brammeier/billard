using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace billard
{
    class Balle
    {
        /// <summary>
        /// Position de la balle
        /// </summary>
        PointF _p;

        public PointF Position
        {
            get { return _p; }
        }
        /// <summary>
        /// Vecteur de deplacement
        /// </summary>
        PointF _v;

        public PointF Vecteur
        {
            get { return _v; }
            set { _v = value; }
        }
        /// <summary>
        /// Rayon de la balle
        /// </summary>
        public const float _rayon = 5.0f;

        public Balle()
        {
            Init( new PointF(50, 50) );            
        }

        public Balle(PointF p)
        {
            Init(p);
        }

        void Init(PointF p)
        {
            _p = p;
            //_v = new PointF(1.0f, 1.0f);
        }

        public void deplacement(int Width, int Height)
        {
            //Deplacement sur les X
            _p.X += _v.X;
            //Test si on sort sur les X
            if ((_p.X < _rayon) || (_p.X > Width - _rayon))
                _v.X *= -1.0f;

            //Deplacement sur les Y
            _p.Y += _v.Y;
            //Test si on sort sur les Y
            if ((_p.Y < _rayon) || (_p.Y > Height - _rayon))
                _v.Y *= -1.0f;
        }

        public void dessin(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black));
            g.DrawEllipse(pen, _p.X - _rayon, _p.Y - _rayon, _rayon * 2.0f, _rayon * 2.0f);
        }

        /// <summary>
        /// Est que l'on est a l'interieur de la balle ?
        /// </summary>
        /// <param name="point">position du click souris</param>
        /// <returns></returns>
        internal bool isIn(Point point)
        {
            //Theoreme de pytagore
            // sqrt( a²+b² )
            double d = Math.Sqrt((point.X - _p.X) * (point.X - _p.X) + (point.Y - _p.Y) * (point.Y - _p.Y));
            return d < (_rayon * 2.0);
        }

        /// <summary>
        /// Calcul de la distance a un point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal float distance(PointF point)
        {
            return (float)Math.Sqrt((point.X - _p.X) * (point.X - _p.X) + (point.Y - _p.Y) * (point.Y - _p.Y));
        }
    }
}
