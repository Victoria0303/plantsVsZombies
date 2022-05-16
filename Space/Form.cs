using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space
{
    public partial class Form1 : Form
    {
        private readonly Game game;
        private readonly Player player = new Player();
        private readonly Bonus bonus = new Bonus();
        private readonly Shooting shooting = new Shooting();
        private readonly GameController gameController = new GameController();
        private readonly Form2 menu;
        private readonly Random random = new Random();

        public Form1(Form2 menu)
        {
            this.menu = menu;
            this.MaximizeBox = false;
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            game = new Game(Controls);
            game.MakeEnemies(++game.Count,  Controls);
            game.GameSetup(game, gameTimer, game.enemy, TxtScore, Controls, game.Enemies);
            FormClosing += (s, e) => menu.Show(); 
            Paint += new PaintEventHandler(OnPaint);
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            Invalidate();
            GameText.UpdateText(TxtScore, totalScore, game);
            gameController.Go(player, plant);
            game.enemy.PeasTimer -= 12; //12
            if (game.enemy.PeasTimer < 1)
            {
                game.enemy.PeasTimer = 300;
                game.MakePeas("enemyPeas", plant, Controls);
            }
            bonus.FindBonusItem(Controls, plant, player, game);
            shooting.MoveTriple(Controls, game);
            game.enemy.CheckEnemyCollision(Controls, game.enemy, plant, TxtScore, gameTimer, game);
            game.CheckWin(game, game.Enemies, TxtScore, Controls, gameTimer);
            if (player.IsFastPeas == true)
            {
                var timer = new Timer() { Interval = 120 };
                var peasCount = 0;
                timer.Start();
                timer.Tick += (sender, e) =>
                {
                    game.MakePeas("peas", plant, Controls);
                    peasCount += 1;
                    Sound.shot.Play();
                    if (peasCount == 20)
                    {
                        timer.Stop();
                    }
                };
                player.IsFastPeas = false;
            }
            if (player.IsFastPeas == true)
            {
                Sound.shot.Play();
                for (var i = 0; i < 10000000; i++)
                    game.MakePeas("peas", plant, Controls);
                game.Shooting = true;
                player.IsFastPeas = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            gameController.PressKey(player, e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.GoLeft = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                player.GoRight = false;
            if (e.KeyCode == Keys.Space && game.Shooting == false && player.IsTriple == true)
            {
                game.MakeTriplePeasBonus(plant, Controls);
                Sound.shot.Play();
                game.Shooting = true;
                player.IsTriple = false;
            }
            if (e.KeyCode == Keys.Space && game.Shooting == false)
            {
                Sound.shot.Play();
                game.Shooting = true;
                game.MakePeas("peas", plant, Controls);
            }
            if (e.KeyCode == Keys.Enter && game.IsGameOver == true)
            {
                game.RemoveAll(game.Enemies, Controls);
                game.GameSetup(game, gameTimer, game.enemy, TxtScore, Controls, game.Enemies);
                game.MakeEnemies(1, Controls);
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString($"Score: {game.Score}", new Font("Comic Sans MS", 14, FontStyle.Bold), new SolidBrush(Color.Black), new System.Drawing.Point(-2, 515));
            e.Graphics.DrawString($"Total score: {game.TotalSum}", new Font("Comic Sans MS", 14, FontStyle.Bold), new SolidBrush(Color.Black), new System.Drawing.Point(550, 515));
        }
    }
}
