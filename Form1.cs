using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace ISPROG1_Project1
{
    public partial class Form1 : Form
    {
        public int buttonCount = 0;
        public bool win = false;

        public int[] rgb1 = new int[3];
        public int[] rgb2 = new int[3];
        public int[] rgb3 = new int[3];
        public int[] rgb4 = new int[3];

        public int[] cAns1 = new int[3];
        public int[] cAns2 = new int[3];
        public int[] cAns3 = new int[3];
        public int[] cAns4 = new int[3];

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        //sets answers
        public void Start()
        {
            Random rand = new Random();

            //so no colors are the same
            int a = rand.Next(1, 9);

            int b = rand.Next(1, 9);
            while (b == a)
                b = rand.Next(1, 9);

            int c = rand.Next(1, 9);
            while (c == a || c == b)
                c = rand.Next(1, 9);

            int d = rand.Next(1, 9);
            while (d == a || d == b || d == c)
                d = rand.Next(1, 9);

            cAns1 = ChooseColor(a);
            cAns2 = ChooseColor(b);
            cAns3 = ChooseColor(c);
            cAns4 = ChooseColor(d);

            //uncomment to view answers before game:

            /**
            ans1.BackgroundImage = null;
            ans2.BackgroundImage = null;
            ans3.BackgroundImage = null;
            ans4.BackgroundImage = null;
            ans1.FillColor = Color.FromArgb(ChooseColor(a)[0], ChooseColor(a)[1], ChooseColor(a)[2]);
            ans2.FillColor = Color.FromArgb(ChooseColor(b)[0], ChooseColor(b)[1], ChooseColor(b)[2]);
            ans3.FillColor = Color.FromArgb(ChooseColor(c)[0], ChooseColor(c)[1], ChooseColor(c)[2]);
            ans4.FillColor = Color.FromArgb(ChooseColor(d)[0], ChooseColor(d)[1], ChooseColor(d)[2]);
            ans1.BorderColor = Color.FromArgb(ChooseColor(a)[0], ChooseColor(a)[1], ChooseColor(a)[2]);
            ans2.BorderColor = Color.FromArgb(ChooseColor(b)[0], ChooseColor(b)[1], ChooseColor(b)[2]);
            ans3.BorderColor = Color.FromArgb(ChooseColor(c)[0], ChooseColor(c)[1], ChooseColor(c)[2]);
            ans4.BorderColor = Color.FromArgb(ChooseColor(d)[0], ChooseColor(d)[1], ChooseColor(d)[2]);
            */
        }

        //color picker (1=orange, 2=lightblue, 3=yellow, etc...)
        public int[] ChooseColor(int i)
        {
            int[] colors = new int[3];

            if (i == 1)
            {
                colors[0] = 219;
                colors[1] = 99;
                colors[2] = 22;
                return colors;
            }
            else if (i == 2)
            {
                colors[0] = 128;
                colors[1] = 188;
                colors[2] = 163;
                return colors;
            }
            else if (i == 3)
            {
                colors[0] = 255;
                colors[1] = 203;
                colors[2] = 43;
                return colors;
            }
            else if (i == 4)
            {
                colors[0] = 191;
                colors[1] = 77;
                colors[2] = 40;
                return colors;
            }
            else if (i == 5)
            {
                colors[0] = 236;
                colors[1] = 129;
                colors[2] = 117;
                return colors;
            }
            else if (i == 6)
            {
                colors[0] = 45;
                colors[1] = 105;
                colors[2] = 131;
                return colors;
            }
            else if (i == 7)
            {
                colors[0] = 124;
                colors[1] = 110;
                colors[2] = 90;
                return colors;
            }
            else if (i == 8)
            {
                colors[0] = 170;
                colors[1] = 86;
                colors[2] = 100;
                return colors;
            }
            return colors;
        }

        //fill in oval and validations
        public void ColorCircle(int[] i)
        {
            int vFlag1 = 0;
            int vFlag2 = 0;
            int vFlag3 = 0;
            int vFlag4 = 0;
            int vFlag5 = 0;
            int vFlag6 = 0;
            int vFlag7 = 0;
            int vFlag8 = 0;

            int blackCount = 0;

            //loops all the ovals in form
            var ovals = Controls.OfType<Panel>()
                       .SelectMany(p => p.Controls.OfType<ShapeContainer>()
                           .SelectMany(sc => sc.Shapes.OfType<OvalShape>()));

            foreach (var oval in ovals)
            {
                if (oval.FillColor == Color.WhiteSmoke)
                {
                    oval.FillColor = Color.FromArgb(i[0], i[1], i[2]);

                    //store colors in temporary value
                    if (buttonCount % 4 == 1)
                        rgb1 = i;
                    else if (buttonCount % 4 == 2)
                        rgb2 = i;
                    else if (buttonCount % 4 == 3)
                        rgb3 = i;
                    else if (buttonCount % 4 == 0)
                        rgb4 = i;
                    break;
                }
            }

            //validations
            for (int j = 0; j < 4; j++)
            {
                foreach (var oval in ovals)
                {
                    if (oval.FillColor == Color.Gainsboro && buttonCount % 4 == 0)
                    {
                        //for black fills
                        if (rgb1[0] == cAns1[0] && vFlag1 == 0)
                        {
                            oval.FillColor = Color.Black;
                            vFlag1 = 1;
                            blackCount++;
                        }
                        else if (rgb2[0] == cAns2[0] && vFlag2 == 0)
                        {
                            oval.FillColor = Color.Black;
                            vFlag2 = 1;
                            blackCount++;
                        }
                        else if (rgb3[0] == cAns3[0] && vFlag3 == 0)
                        {
                            oval.FillColor = Color.Black;
                            vFlag3 = 1;
                            blackCount++;
                        }
                        else if (rgb4[0] == cAns4[0] && vFlag4 == 0)
                        {
                            oval.FillColor = Color.Black;
                            vFlag4 = 1;
                            blackCount++;
                        }

                        //for white fills
                        else if ((rgb1[0] == cAns2[0] || rgb1[0] == cAns3[0] || rgb1[0] == cAns4[0]) && vFlag5 == 0)
                        {
                            oval.FillColor = Color.White;
                            vFlag5 = 1;
                        }
                        else if ((rgb2[0] == cAns1[0] || rgb2[0] == cAns3[0] || rgb2[0] == cAns4[0]) && vFlag6 == 0)
                        {
                            oval.FillColor = Color.White;
                            vFlag6 = 1;
                        }
                        else if ((rgb3[0] == cAns1[0] || rgb3[0] == cAns2[0] || rgb3[0] == cAns4[0]) && vFlag7 == 0)
                        {
                            oval.FillColor = Color.White;
                            vFlag7 = 1;
                        }
                        else if ((rgb4[0] == cAns1[0] || rgb4[0] == cAns2[0] || rgb4[0] == cAns3[0]) && vFlag8 == 0)
                        {
                            oval.FillColor = Color.White;
                            vFlag8 = 1;
                        }

                        //if no similarities found, fill gray
                        else
                        {
                            oval.FillColor = Color.Gray;
                        }
                        break;
                    }
                }
            }

            //check win
            if (blackCount == 4)
            {
                win = true;
                ans1.BackgroundImage = null;
                ans2.BackgroundImage = null;
                ans3.BackgroundImage = null;
                ans4.BackgroundImage = null;

                ans1.FillColor = Color.FromArgb(cAns1[0], cAns1[1], cAns1[2]);
                ans2.FillColor = Color.FromArgb(cAns2[0], cAns2[1], cAns2[2]);
                ans3.FillColor = Color.FromArgb(cAns3[0], cAns3[1], cAns3[2]);
                ans4.FillColor = Color.FromArgb(cAns4[0], cAns4[1], cAns4[2]);

                ans1.BorderColor = Color.FromArgb(cAns1[0], cAns1[1], cAns1[2]);
                ans2.BorderColor = Color.FromArgb(cAns2[0], cAns2[1], cAns2[2]);
                ans3.BorderColor = Color.FromArgb(cAns3[0], cAns3[1], cAns3[2]);
                ans4.BorderColor = Color.FromArgb(cAns4[0], cAns4[1], cAns4[2]);

                MessageBox.Show("We have a winner!");
                NewGame();
            }

            //if lose
            if (buttonCount == 28 && win == false)
            {
                ans1.BackgroundImage = null;
                ans2.BackgroundImage = null;
                ans3.BackgroundImage = null;
                ans4.BackgroundImage = null;

                ans1.FillColor = Color.FromArgb(cAns1[0], cAns1[1], cAns1[2]);
                ans2.FillColor = Color.FromArgb(cAns2[0], cAns2[1], cAns2[2]);
                ans3.FillColor = Color.FromArgb(cAns3[0], cAns3[1], cAns3[2]);
                ans4.FillColor = Color.FromArgb(cAns4[0], cAns4[1], cAns4[2]);

                ans1.BorderColor = Color.FromArgb(cAns1[0], cAns1[1], cAns1[2]);
                ans2.BorderColor = Color.FromArgb(cAns2[0], cAns2[1], cAns2[2]);
                ans3.BorderColor = Color.FromArgb(cAns3[0], cAns3[1], cAns3[2]);
                ans4.BorderColor = Color.FromArgb(cAns4[0], cAns4[1], cAns4[2]);

                MessageBox.Show("Game over. Please try again!");
                NewGame();
            }

        }

        private void color1_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(1));
        }

        private void color2_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(2));
        }

        private void color3_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(3));
        }

        private void color4_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(4));
        }

        private void color5_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(5));
        }

        private void color6_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(6));
        }

        private void color7_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(7));
        }

        private void color8_Click(object sender, EventArgs e)
        {
            buttonCount++;
            ColorCircle(ChooseColor(8));
        }

        public void NewGame()
        {
            win = false;
            buttonCount = 0;
            var ovals = Controls.OfType<Panel>()
                       .SelectMany(p => p.Controls.OfType<ShapeContainer>()
                           .SelectMany(sc => sc.Shapes.OfType<OvalShape>()));

            foreach (var oval in ovals)
            {
                if (oval.FillColor == Color.White || oval.FillColor == Color.Black || oval.FillColor == Color.Gray || oval.FillColor == Color.Gainsboro)
                    oval.FillColor = Color.Gainsboro;
                else
                    oval.FillColor = Color.WhiteSmoke;
            }

            ans1.BackgroundImage = new Bitmap(@"C:\Users\Reg\Documents\Visual Studio 2012\Projects\ISPROG1 Project1\ISPROG1 Project1\Resources\1.jpg");
            ans2.BackgroundImage = new Bitmap(@"C:\Users\Reg\Documents\Visual Studio 2012\Projects\ISPROG1 Project1\ISPROG1 Project1\Resources\2.jpg");
            ans3.BackgroundImage = new Bitmap(@"C:\Users\Reg\Documents\Visual Studio 2012\Projects\ISPROG1 Project1\ISPROG1 Project1\Resources\3.jpg");
            ans4.BackgroundImage = new Bitmap(@"C:\Users\Reg\Documents\Visual Studio 2012\Projects\ISPROG1 Project1\ISPROG1 Project1\Resources\4.jpg");

            ans1.BorderColor = Color.Black;
            ans2.BorderColor = Color.Black;
            ans3.BorderColor = Color.Black;
            ans4.BorderColor = Color.Black;

            Start();
        }
    }


}
