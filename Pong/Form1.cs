namespace Pong
{
    public partial class Form1 : Form
    {
        bool intersects(Rectangle a, Rectangle b)
        {
            // a is ball |  b is paddle
            if (a.Left <= b.Right || a.Right >= b.Left  && (a.Top <= b.Bottom && a.Bottom >= b.Bottom || a.Bottom >= b.Top && a.Top <= b.Top))
            {
                gfx.FillRectangle(Brushes.Crimson, leftPaddle);
                return true;
            }
            else
            {
                return false;
            }
        }
        //bool intersectsRight(Rectangle a, Rectangle b)
        //{
        //    if  && (a.Top <= b.Bottom && a.Bottom >= b.Bottom || a.Bottom >= b.Top && a.Top <= b.Top))
        //    {
        //        gfx.FillRectangle(Brushes.Aquamarine, rightPaddle);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        Graphics gfx;
        Bitmap bmp;
        Rectangle leftPaddle;
        Rectangle rightPaddle;
        Rectangle ball;
        Point speed = new Point(5, 5);
        public Form1()
        {

            leftPaddle = new Rectangle(0,0,50, 120);
            rightPaddle = new Rectangle(750, 120, 50, 120);
            //ball = new Rectangle(190, 80, 30, 30);
            ball = new Rectangle(720, 150, 30, 30);
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(bmp);
            //gfx.FillEllipse(Brushes.Peru, new Rectangle(0, 0, 109, 100)); bob
            pictureBox1.Image = bmp;//this is how you draw, now make pong.
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) // loop
        {
            gfx.Clear(Color.WhiteSmoke);
            
            gfx.FillRectangle(Brushes.Chocolate, leftPaddle);
            gfx.FillRectangle(Brushes.BurlyWood, rightPaddle);
            gfx.FillEllipse(Brushes.DarkMagenta, ball);
            ball.X += 0;//speed.X;
            ball.Y += 0;//speed.Y;

            // walls
            if (ball.Y <= 0 || ball.Y + ball.Height >= ClientSize.Height)
            {
                speed.Y *= -1;
            }
            if (ball.X <= 0 || ball.Right >= ClientSize.Width)
            {
                speed.X *= -1;
                // flip player off
            }
            if (intersects(ball, leftPaddle))
            {
             
                speed.X = Math.Abs(speed.X);
            }
            if (intersects(ball, rightPaddle))
            {
                
                speed.X = -Math.Abs(speed.X);
            }
            // paddles  
            //if(ball.X <= leftPaddle.Right)
            //{
            //    speed.X *= -1;
            //}
            //if(ball.Y <= leftPaddle.Height)
            //{
            //    //speed.Y *= -1;
            //}






            pictureBox1.Image = bmp;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var keyPress = e.KeyCode;
            if (keyPress == Keys.Down)
            {
                leftPaddle.Y += 5;
            //do shit
            }
            if (keyPress == Keys.Up)
            {
                leftPaddle.Y -= 5;
            }
        }
    }
}