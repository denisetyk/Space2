using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        bool goleft, goright, goingright;
        int playerspeed = 12;
        int enemyspeed = 5;
        int score = 0;
        int enemybullettier = 300;

        PictureBox[] invadersarray;
        bool shooting;
        bool isgameover;

        public Form1()
        {
            InitializeComponent();
            Gamesetup();
        }

   



        private void Keyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = false;
                Makebullet("bullet");
            }
            if (e.KeyCode == Keys.Enter && isgameover == true)
            {
                Removeall();
                Gamesetup();
            }
        }

        private void Makeinvaders()
            {

                invadersarray = new PictureBox[20];
                int left = 0;

            for (int i = 1; i < invadersarray.Length; i++)
                {
                    invadersarray[i] = new PictureBox();
                    invadersarray[i].Size = new Size(60, 50);
                
                    invadersarray[i].Image = Properties.Resources.pudding;
                    invadersarray[i].Top = 5;
                    invadersarray[i].Tag = "invader";
                    invadersarray[i].Left = left;
                    this.Controls.Add(invadersarray[i]);
                    left = left + 70;
                }


            int left1 = 20;
            for (int i = 0; i < invadersarray.Length; i++)
            {
                invadersarray[i] = new PictureBox();
                invadersarray[i].Size = new Size(60, 50);

                invadersarray[i].Image = Properties.Resources.pudding;
                invadersarray[i].Top = 75;
                invadersarray[i].Tag = "invader";
                invadersarray[i].Left = left1;
                this.Controls.Add(invadersarray[i]);
                left1 = left1 + 70;
            }

            int left2 = 40;
            for (int i = 0; i < invadersarray.Length; i++)
            {
                invadersarray[i] = new PictureBox();
                invadersarray[i].Size = new Size(60, 50);

                invadersarray[i].Image = Properties.Resources.pudding;
                invadersarray[i].Top = 145;
                invadersarray[i].Tag = "invader";
                invadersarray[i].Left = left2;
                this.Controls.Add(invadersarray[i]);
                left2 = left2 + 70;
            }


            int left3 = 60;
            for (int i = 0; i < invadersarray.Length; i++)
            {
                invadersarray[i] = new PictureBox();
                invadersarray[i].Size = new Size(60, 50);

                invadersarray[i].Image = Properties.Resources.pudding;
                invadersarray[i].Top = 205;
                invadersarray[i].Tag = "invader";
                invadersarray[i].Left = left3;
                this.Controls.Add(invadersarray[i]);
                left3 = left3 + 70;
            }


        }

        private void Gamesetup()
            {
                txtScore.Text = "Score: 0";
                score = 0;
                isgameover = false;

                enemybullettier = 300;
                enemyspeed = 5;
                shooting = false;

                Makeinvaders();
                Gametimer.Start();

            }

            private void Gameover(string message)
            {
                isgameover = true;
                Gametimer.Stop();
                txtScore.Text = "Score: " + score + " " + message;
            }

            private void Removeall()
            {
                foreach (PictureBox p in invadersarray)
                { this.Controls.Remove(p);
                }

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        if ((string)x.Tag == "bullet" || (string)x.Tag == "invaderbullet")
                        {
                            this.Controls.Remove(x);
                        }
                    }
                }

            }

       
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            else if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Gametimerevent(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + score;
            if (goleft)
            {
                player.Left -= playerspeed;
            }

            if (goright)
            {
                player.Left += playerspeed;
            }

            enemybullettier -= 10;

            if (enemybullettier < 1)
            {
                enemybullettier = 300;
                Makebullet("invaderbullet");
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "invader" )
                {
                    x.Left += enemyspeed; // shuffling right

                   

                    if (x.Left > 1440)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        Gameover("Player bounds intersect with Invader bounds");

                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (x.Bounds.IntersectsWith(y.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1;
                                shooting = false;



                            }

                        }
                    }
                }


                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;

                    if (x.Top < 15)

                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }

                }

                if (x is PictureBox && (string)x.Tag == "invaderbullet")
                {
                    x.Top += 20;

                    if (x.Top >= 720)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(x);
                        Gameover("Dead. Got shot");
                    }

                }
            }


            if (score > 8)
            {
                enemyspeed = 6;
            }

            if (score == 4*invadersarray.Length)
            {
                Gameover("Won");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Makebullet(string bulletTag)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.bullet;
                bullet.Tag = bulletTag;
                bullet.Size = new Size(5, 20);
  
                bullet.Left = player.Left + player.Width / 2;

                if ((string)bullet.Tag == "bullet")
                {
                    bullet.Top = player.Top - 20;
                }
                else if ((string)bullet.Tag == "invaderbullet")
                {
                    bullet.Top = -100;
                }

                this.Controls.Add(bullet);
                bullet.BringToFront();



            }


        }
    }