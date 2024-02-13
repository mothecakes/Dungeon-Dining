using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonDining
{
    internal class Tile
    {
        private bool _isWall;
        private bool _isSeen;

        public Tile()
        {
            _isWall = false;
            _isSeen = true;
        }

        public bool getWall() { return _isWall; }
        public void setWall() { _isWall = true;}
    }
}
