using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    public class Enemy
    {
        public int Speed { get; set; } = 5;
        public int PeasTimer { get; set; } = 300;
        public int Hp { get; set; } = 1;

        public void CheckEnemyCollision(Control.ControlCollection Controls, Enemy enemy, PictureBox plant, Label TxtScore, Timer gameTimer, Game game)
        {
            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "enemies")
                {
                    x.Left += enemy.Speed + game.TotalSum / 25;
                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(plant.Bounds))
                    {
                        Sound.gameOver.Play();
                        game.GameOver("  ☹ Game Over! ☹", TxtScore, gameTimer, game);
                        game.Count = 0;
                    }
                    foreach (Control y in Controls)
                    {
                        if ((string)y.Tag == "peas" || (string)y.Tag == "peasLeft" || (string)y.Tag == "peasCenter" || (string)y.Tag == "peasRight")
                        {
                            
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                Controls.Remove(x);
                                Controls.Remove(y);
                                Sound.death.Play();
                                game.Score += 1;
                                game.TotalSum += 1;
                                game.Shooting = false;
                            }
                        }
                    }
                }

                if ((string)x.Tag == "peas")
                {
                    x.Top -= 20; // peas speed
                    if (x.Top < 15)
                    {
                        Controls.Remove(x);
                        game.Shooting = false;
                    }
                } // map outside 

                if ((string)x.Tag == "enemyPeas")
                {
                    x.Top += 12; //Enemy peas speed
                    if (x.Top > 620) // Player height
                    {
                        Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(plant.Bounds))
                    {
                        Controls.Remove(x);
                        Sound.gameOver.Play();
                        game.GameOver("☹ Game Over! ☹", TxtScore, gameTimer, game);
                        game.TotalSum = 0;
                        game.Count = 0;
                    }
                }
            }
        }
    }
}
