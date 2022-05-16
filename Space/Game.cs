using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    public class Game
    {
        public int Score { get; set; }
        public bool Shooting { get; set; }
        public bool IsGameOver { get; set; }
        public int Count { get; set; }
        public int TotalSum { get; set; }
        public PictureBox[] Enemies { get; set; }
        public Enemy enemy { get; } = new Enemy();
        private readonly Timer bonusTimer;
        private readonly Control.ControlCollection Controls;

        private readonly PictureBox boom;

        public Game(Control.ControlCollection Controls)
        {
            bonusTimer = new Timer() { Interval = 1000 };
            bonusTimer.Tick += new EventHandler(OnBonusTimer);
            this.Controls = Controls;
            boom = new PictureBox
            {
                Size = new Size(500, 500),
                Image = Properties.Resources.boom,
                Tag = "explosion",
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
        }

        private void OnBonusTimer(object sender, EventArgs e)
        {
            bonusTimer.Interval = new Random().Next(1000, 10000);
            switch (new Random().Next(3))
            {
                case 0:
                    MakeBonus(Controls);
                    break;
                case 1:
                    MakeBonusBomb(Controls);
                    break;
                case 2:
                    MakeBonusFastPeas(Controls);
                    break;
            }
        }

        public void RemoveAll(PictureBox[] enemies, Control.ControlCollection Controls)
        {
            foreach (var i in enemies)
            {
                Controls.Remove(i);
            }
            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "peas" || (string)x.Tag == "enemyPeas" || (string)x.Tag == "peasLeft"
                    || (string)x.Tag == "peasCenter" || (string)x.Tag == "peasRight" || (string)x.Tag == "peasCenter" 
                        || (string)x.Tag == "explosion"  || (string)x.Tag == "bonusTriple" || (string)x.Tag == "bonusBomb"
                            || (string)x.Tag == "3")
                {
                    Controls.Remove(x);
                }
            }
        }

        public void GameSetup(Game game, Timer gameTimer, Enemy enemy, Label TxtScore, Control.ControlCollection Controls, PictureBox[] enemies)
        {
            TxtScore.Text = "Score: 0";
            game.Score = 0;
            game.IsGameOver = false;
            enemy.PeasTimer = 300;
            game.Shooting = false;
            gameTimer.Start();
            bonusTimer.Start();
        }

        public void GameOver(string message, Label TxtScore, Timer gameTimer, Game game)
        {
            game.IsGameOver = true;
            gameTimer.Stop();
            TxtScore.Text = "Score: " + game.Score + " " + message;
            bonusTimer.Stop();
        }

        public void MakePeas(string peasTag, PictureBox plant, Control.ControlCollection Controls)
        {
            var peas = new PictureBox
            {
                Image = Properties.Resources.bullet3,
                Size = new Size(50, 50),
                Tag = peasTag,
                Left = plant.Left + plant.Width / 2,
                BackColor = Color.Transparent
            };
            if ((string)peas.Tag == "peas")
            {
                peas.Top = plant.Top - 20;
            }
            else if ((string)peas.Tag == "enemyPeas")
            {
                peas.Top = -100;
            }
            Controls.Add(peas);
            peas.BringToFront();
        }

        public void MakeTriplePeasBonus(PictureBox plant, Control.ControlCollection Controls)
        {
            //Left
            var peasLeft = new PictureBox
            {
                Image = Properties.Resources.bullet3,
                Size = new Size(50, 50),
                Tag = "peasLeft",
                Left = plant.Left + plant.Width / 2,
                BackColor = Color.Transparent
            };
            if ((string)peasLeft.Tag == "peasLeft")
            {
                peasLeft.Top = plant.Top - 20;
            }
            Controls.Add(peasLeft);
            peasLeft.BringToFront();

            //Center
            var peasCenter = new PictureBox
            {
                Image = Properties.Resources.bullet3,
                Size = new Size(50, 50),
                Tag = "peasCenter",
                Left = plant.Left + plant.Width / 2,
                BackColor = Color.Transparent
            };
            if ((string)peasCenter.Tag == "peasCenter")
            {
                peasCenter.Top = plant.Top - 20;
            }
            Controls.Add(peasCenter);
            peasCenter.BringToFront();

            //Right
            var peasRight = new PictureBox
            {
                Image = Properties.Resources.bullet3,
                Size = new Size(50, 50),
                Tag = "peasRight",
                Left = plant.Left + plant.Width / 2,
                BackColor = Color.Transparent
            };
            if ((string)peasRight.Tag == "peasRight")
            {
                peasRight.Top = plant.Top - 20;
            }
            Controls.Add(peasRight);
            peasRight.BringToFront();
        }

        public void MakeEnemies(int count, Control.ControlCollection Controls)
        {
            Enemies = new PictureBox[count];
            var left = 0;
            for (var i = 0; i < Enemies.Length; i++)
            {
                    Enemies[i] = new PictureBox
                    {
                        Size = new Size(60, 50),
                        Image = Properties.Resources.invader,
                        BackColor = Color.Transparent,
                        Top = 5,
                        Tag = "enemies",
                        Left = left,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Controls.Add(Enemies[i]);
                    left -= 80;
            }
        }

        public void MakeBonus(Control.ControlCollection Controls)
        {
            var bonusTriple = new PictureBox
            {
                Size = new Size(50, 50),
                Image = Properties.Resources.bonusTriple,
                BackColor = Color.Transparent,
                Top = 75,
                Tag = "bonusTriple",
                Location = new Point(new Random().Next(10, 650), 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(bonusTriple);
        }

        public void MakeBonusFastPeas(Control.ControlCollection Controls)
        {
            var bonusFastPeas = new PictureBox
            {
                Size = new Size(50, 50),
                Image = Properties.Resources.fastPeas,
                BackColor = Color.Transparent,
                Top = 75,
                Tag = "bonusFastPeas",
                Location = new Point(new Random().Next(10, 650), 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(bonusFastPeas);
        }

        public void MakeBonusBomb(Control.ControlCollection Controls)
        {
            var bonusBomb = new PictureBox
            {
                Size = new Size(50, 50),
                Image = Properties.Resources.bomb,
                BackColor = Color.Transparent,
                Top = 75,
                Tag = "bonusBomb",
                Location = new Point(new Random().Next(10, 650), 0),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(bonusBomb);
        }

        public void MakeBoom(Control x, Control.ControlCollection Controls, Point point, Game game)
        {
            var timer = new Timer() { Interval = 500 };
            x.Size = new Size(300, 300);
            var location = new Point(point.X - x.Size.Width / 2, point.Y - x.Size.Height / 2);
            boom.Location = location;
            Controls.Add(boom);
            Controls.Remove(x);
            x.Tag = "bombPB";
            Sound.bomb.Play();
            for (var i = 0; i < Controls.Count;i++ )
            {
                if ((string)Controls[i].Tag == "enemies" && boom.Bounds.IntersectsWith(Controls[i].Bounds))
                {
                    Controls.Remove(Controls[i]);
                    game.Score += 1;
                    i -= 1;
                    game.TotalSum += 1;
                    game.Shooting = false;
                }
            }
            timer.Start();
            timer.Tick += (sender, e) =>
            {
                Controls.Remove(boom);
                timer.Stop();
            };
        }

        public void CheckWin(Game game, PictureBox[] enemies, Label TxtScore, Control.ControlCollection Controls, Timer gameTimer)
        {
            if (game.Score == enemies.Length)
            {
                Sound.win.Play();
                TxtScore.Text = $"game.Score = {game.Score}/t enemies.Length = {enemies.Length}";
                game.GameSetup(game, gameTimer, enemy, TxtScore, Controls, enemies);
                game.Count += 1;
                game.MakeEnemies(game.Count,  Controls);
            }
        }
    }
}
