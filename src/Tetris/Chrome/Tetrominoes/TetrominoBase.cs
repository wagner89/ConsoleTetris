using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Chrome.Tetrominoes
{
    public class TetrominoBase
    {
        public Point TopLeft { get; set; }

        public byte Color { get; set; }

        public int Speed { get; set; }

        public Rotation Rotation { get; set; }

        public virtual void Draw()
        {
        }
    }
}
