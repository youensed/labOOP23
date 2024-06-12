using System.Diagnostics;
using System.Drawing.Text;

namespace OOP_23
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphic = pictureBox1.CreateGraphics();// ініціалізація об'єкту класа Graphics
            Pen pen = new Pen(Color.Black, 2f);// ініціалізація об'єкту класа Pen
            graphic.Clear(Color.White);

            // відрисовка осі Х
            Point firstX = new Point(0, pictureBox1.Height / 2);
            Point secondX = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            graphic.DrawLine(pen, firstX, secondX);

            // відрисовка осі У
            Point firstY = new Point(pictureBox1.Width / 2, 0);
            Point secondY = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            graphic.DrawLine(pen, firstY, secondY);

            // відрисовка назви осі У
            Point nameOfAxisX = new Point((pictureBox1.Width / 2) + 10, 0);
            graphic.DrawString("Y", new Font("Times New Roman", 15 ,FontStyle.Bold), new SolidBrush(Color.Black), nameOfAxisX);

            //відрисовка назви осі Х
            Point nameOfAxisY = new Point(pictureBox1.Width - 20, pictureBox1.Height / 2);
            graphic.DrawString("X", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), nameOfAxisY);

            int xValues = -(pictureBox1.Width / 2) / 50;// формула для значень на осі
            int yValues = (pictureBox1.Height / 2) / 50;// формула для значень на осі

            //відрисовка значень на осі У
            for (int i = 50; i < pictureBox1.Height; i += 50)
            {
                if (yValues != 0)
                    graphic.DrawString(yValues.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(pictureBox1.Width/2, i));
                else if (yValues == 0)
                {
                    graphic.DrawString(yValues.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(pictureBox1.Width / 2, pictureBox1.Height/2));
                    i = pictureBox1.Height / 2;
                }
                    
                yValues--;
            }
            //відрисовка значень на осі Х 
            for(int i = 0; i < pictureBox1.Width; i += 50)
            {
                if(xValues != 0 && xValues%3 == 0)
                    graphic.DrawString((xValues/3).ToString()+"pi", new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(i, pictureBox1.Height / 2));
                else if (xValues == 0)
                {
                    graphic.DrawString(xValues.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(pictureBox1.Width / 2, pictureBox1.Height / 2));
                    i = pictureBox1.Width / 2;
                }
                xValues++;
            }
            
            try
            {
                float a = float.Parse(textBox1.Text);//отримання даних з textBox1
                if(a == 0)
                {
                    throw new ArgumentNullException();
                }

                // відрисовка функції Х
                for (float y = -pictureBox1.Height / 2; y < pictureBox1.Width / 2; y++)
                {
                    float x = (a * (float)(Math.Tan((double)y / 50) * 50));
                    graphic.FillRectangle(new SolidBrush(Color.Red), x + (pictureBox1.Width / 2), -y + (pictureBox1.Height / 2), 3f, 3f);
                }

                // відрисовка функції У
                for (float x = -pictureBox1.Width / 2; x < pictureBox1.Width / 2; x++)
                {
                    float y = a * (float)(Math.Pow(Math.Sin((double)x / 50) , 2) * 50);
                    graphic.FillRectangle(new SolidBrush(Color.Blue), x + (pictureBox1.Width / 2), -y + (pictureBox1.Height / 2), 3f, 3f);
                }
            }
            catch (FormatException)//виключення
            {
                graphic.Clear(Color.White);
                MessageBox.Show("Не вірний формат введених даних!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Коефіцієнт не може дорівнювати 0!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
