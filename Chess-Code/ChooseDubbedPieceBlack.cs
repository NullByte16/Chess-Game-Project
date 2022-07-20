using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class ChooseDubbedPieceBlack : Form
    {
        public ChooseDubbedPieceBlack()
        {
            InitializeComponent();
        }

        public string chosen = null;

        private void ChooseDubbedPieceBlack_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chosen = "Queen";
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chosen = "Bishop";
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            chosen = "Knight";
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            chosen = "Rook";
            this.Close();
        }
    }
}
