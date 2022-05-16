using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    class Bonus
    {
        public void FindBonusItem(Control.ControlCollection Controls, PictureBox plant, Player player, Game game)
        {
            var bonusSpeed = 2;
            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "bonusTriple")
                {
                    x.Top += bonusSpeed; //10
                    if (x.Top > 530)
                    {
                        Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(plant.Bounds))
                    {
                        Controls.Remove(x);
                        Sound.takeBonus.Play();
                        player.IsTriple = true;
                    }
                }
            }

            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "bonusFastPeas")
                {
                    x.Top += bonusSpeed; //10
                    if (x.Top > 530)
                    {
                        Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(plant.Bounds))
                    {
                        Controls.Remove(x);
                        Sound.takeBonus.Play();
                        player.IsFastPeas = true;
                    }
                }
            }

            foreach (Control bomb in Controls)
            {
                if ((string)bomb.Tag == "bonusBomb")
                {
                    bomb.Top += bonusSpeed; //10
                    if (bomb.Top > 530)
                    {
                        Controls.Remove(bomb);
                    }

                    foreach (Control anyPeas in Controls)
                    {
                        if ((string)anyPeas.Tag == "peas" || (string)anyPeas.Tag == "peasLeft" || (string)anyPeas.Tag == "peasCenter" || (string)anyPeas.Tag == "peasRight")
                        {
                            if (anyPeas.Bounds.IntersectsWith(bomb.Bounds))
                            {
                                game.MakeBoom(bomb, Controls, bomb.Location, game);
                                game.Shooting = false;
                                Controls.Remove(anyPeas);
                            }
                        }
                    }
                }
            }
        }
    }
}