using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        

        private void Start_Click(object sender, EventArgs e)
        {
            var form = new Form1(this);
            this.Hide();
            form.Show();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
