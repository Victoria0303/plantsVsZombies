using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    public class GameController
    {
        public void PressKey(Player player, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.GoLeft = true;

            if (e.KeyCode == Keys.Right  || e.KeyCode == Keys.D)
                player.GoRight = true;
        }

        public void Go(Player player, PictureBox plant)
        {
            if (player.GoLeft)
            {
                if (plant.Left > 0)
                    plant.Left -= player.Speed;
            }
            if (player.GoRight)
            {
                if (plant.Right < 732)
                    plant.Left += player.Speed;
            }
        }
    }
}
