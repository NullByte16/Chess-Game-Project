using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class EatenPieceHolder : PictureBox
    {
        public readonly int I, J;
        readonly MainForm Papa;
        public System.Drawing.Icon Icon;

        public EatenPieceHolder(int I, int J, MainForm PapaForm, System.Drawing.Icon Icon, Color color)
        {
            if (color == Color.Black)
                this.Location = new System.Drawing.Point(J * 50 + 430, I * 50 + 225);

            else
                this.Location = new System.Drawing.Point(J * 50 + 430, I * 50 + 25);
            this.Size = new System.Drawing.Size(50, 50);
            this.Icon = Icon;

            PapaForm.Controls.Add(this);

            this.I = I;
            this.J = J;
            Papa = PapaForm;

            this.BackColor = System.Drawing.Color.Transparent;
        }

        public void PlaceEaten(System.Drawing.Image img)
        {
            this.Image = img;
        }
    }
}