using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace MyCostumControl
{
    public partial class CircleLoading : UserControl
    {
        private int count = -1;
        private ArrayList images = new ArrayList();
        public Bitmap[] bitmap = new Bitmap[8];
        private int _value = 1;
        private Color _circleColor = Color.Red;
        private float _circleSize = 0.8f;
        private Timer timer = new Timer();

        public CircleLoading()
        {
            InitializeComponent();
        }

        public Color CircleColor
        {
            get { return _circleColor; }
            set
            {
                _circleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 圆点半径
        /// </summary>
        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                if (value <= 0.0F)
                    _circleSize = 0.05F;
                else
                    _circleSize = value > 4.0F ? 4.0F : value;
                Invalidate();
            }
        }

        private Bitmap DrawCircle(int j)
        {
            const float angle = 360.0F / 8;
            Bitmap map = new Bitmap(this.pictureBox.Width, this.pictureBox.Height);
            Graphics g = Graphics.FromImage(map);

            g.TranslateTransform(this.pictureBox.Width / 2.0F, this.pictureBox.Height / 2.0F);
            g.RotateTransform(angle * _value);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int[] a = new int[8] { 25, 50, 75, 100, 125, 150, 175, 200 };
            for (int i = 1; i <= 8; i++)
            {
                int alpha = a[(i + j - 1) % 8];
                Color drawColor = Color.FromArgb(alpha, _circleColor);
                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 3.5F / _circleSize;
                    float size = Width / (6 * sizeRate);

                    float diff = (Width / 10.0F) - size;

                    float x = (Width / 80.0F) + diff;
                    float y = (Height / 80.0F) + diff;
                    g.FillEllipse(brush, x, y, size, size);
                    g.RotateTransform(angle);
                }
            }
            return map;
        }

        private void Draw()
        {
            for (int j = 0; j < 8; j++)
            {
                bitmap[7 - j] = DrawCircle(j);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            SetNewSize();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetNewSize();
            base.OnSizeChanged(e);
        }

        private void SetNewSize()
        {
            int size = Math.Max(Width, Height);
            Size = new Size(size, size);
        }

        private void set()
        {
            for (int i = 0; i < 8; i++)
            {
                Draw();
                Bitmap map = new Bitmap((bitmap[i]), new Size(120, 110));
                images.Add(map);
            }
            pictureBox.Image = (Image)images[0];
            pictureBox.Size = pictureBox.Image.Size;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            set();
            count = (count + 1) % 8;
            pictureBox.Image = (Image)images[count];

        }

        private void CircleLoading_Load(object sender, EventArgs e)
        {
            this.timer.Tick += new EventHandler(timer_Tick);
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }
    }
}
