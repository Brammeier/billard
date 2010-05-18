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
        /// <summary>
        /// Vecteur de deplacement
        /// </summary>
        PointF _v;
        /// <summary>
        /// Rayon de la balle
        /// </summary>
        const float _rayon = 5.0f;

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
            _v = new PointF(1.0f, 1.0f);
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
    }
}
