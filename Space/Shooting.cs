using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    public class Shooting
    {
        public void MoveTriple(Control.ControlCollection Controls, Game game)
        {
            foreach (Control x in Controls)
            {
                if ((string)x.Tag == "peasLeft")
                {
                    x.Top -= 20;
                    x.Left += 10; //5
                    if (x.Top < 15)
                    {
                        Controls.Remove(x);
                        game.Shooting = false;
                    }
                }

                if ((string)x.Tag == "peasCenter")
                {
                    x.Top -= 20;
                    if (x.Top < 15)
                    {
                        Controls.Remove(x);
                        game.Shooting = false;
                    }
                }

                if ((string)x.Tag == "peasRight")
                {
                    x.Top -= 20;
                    x.Left -= 10; //5
                    if (x.Top < 15)
                    {
                        Controls.Remove(x);
                        game.Shooting = false;
                    }
                }
            }
        }
    }
}
