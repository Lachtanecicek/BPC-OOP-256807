using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patnactka
{
    public class Tile
    {
        public int Value { get; set; } // 1–15, 0 = prázdné
        public int Row { get; set; }
        public int Column { get; set; }

        public Tile(int value, int row, int column)
        {
            Value = value;
            Row = row;
            Column = column;
        }

        public bool IsEmpty => Value == 0;
    }
}
