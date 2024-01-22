using System.Net.Http.Headers;

namespace Pong
{
    public partial class Form1 : Form
    {
        bool intersects(Rectangle a, Rectangle b)
        {
            // a is ball |  b is paddle
            //a.Left <= b.Right || a.Right >= b.Left && (a.Top <= b.Bottom && a.Bottom >= b.Bottom || a.Bottom >= b.Top && a.Top <= b.Top)
            if (ball.IntersectsWith(b))
            {
                gfx.FillRectangle(Brushes.Crimson, b);
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
        int winning_score = 10;
        int l_score = 0;
        int r_score = 0;
        HashSet<Keys> pressedKeys;
        public Form1()
        {
            InitializeComponent();
            score_text_box.Text = $"            {l_score} | {r_score}";
            leftPaddle = new Rectangle(0,0,50, 120);
            rightPaddle = new Rectangle(750, 120, 50, 120);
            ball = new Rectangle(190, 80, 30, 30);
            //ball = new Rectangle(720, 150, 30, 30);

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
            ball.X += speed.X;//speed.X;
            ball.Y += speed.Y;//speed.Y;

            // walls
            if (ball.Top <= 0 || ball.Bottom >= ClientSize.Height)
            {
                speed.Y *= -1;
            }
            if (ball.Left <= 0)
            {
                speed.X *= -1;
                r_score++;
                // flip player off
            }
            else if (ball.Right >= ClientSize.Width)
            {
                speed.X *= -1;
                l_score++;
            }
            if (intersects(ball, leftPaddle))
            {

                //speed.X *= -1;
                speed.X = Math.Abs(speed.X);
            }
            else if (intersects(ball, rightPaddle))
            {

                //speed.X *= -1;
                speed.X = -Math.Abs(speed.X);
            }

            score_text_box.Text = $"            {l_score} | {r_score}";

            if (r_score == winning_score)
            {
                score_text_box.Enabled = false;
                score_text_textbox.Enabled = false;
                speed.X = 0;
                speed.Y = 0;
            }
            else if (l_score == winning_score)
            {
                score_text_box.Enabled = false;
                score_text_textbox.Enabled = false;
                speed.X = 30;
                speed.Y = 30;
            }
            
            if(pressedKeys.Contains(Keys.S))
            {
                leftPaddle.Y += 5;
                //do shit
            }
            if(pressedKeys.Contains(Keys.W))
            {
                leftPaddle.Y -= 5;
            }
            if(pressedKeys.Contains(Keys.Down))
            {
                rightPaddle.Y += 5;
            }
            if(pressedKeys.Contains(Keys.Up))
            {
                rightPaddle.Y -= 5;
            }

            pictureBox1.Image = bmp;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var keyPress = e.KeyCode;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}