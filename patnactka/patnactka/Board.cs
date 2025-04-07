using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patnactka
{
    public class Board
    {
        public Tile[,] Tiles { get; private set; } = new Tile[4, 4];

        public Board()
        {
            Initialize();
        }

        public void Initialize()
        {
            var numbers = Enumerable.Range(1, 15).ToList();
            numbers.Add(0); // 0 = prázdná

            var random = new Random();
            numbers = numbers.OrderBy(_ => random.Next()).ToList();

            int index = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Tiles[row, col] = new Tile(numbers[index], row, col);
                    index++;
                }
            }
        }

        public Tile GetEmptyTile()
        {
            foreach (var tile in Tiles)
                if (tile.IsEmpty) return tile;

            return null;
        }

        public bool CanMove(Tile tile)
        {
            var empty = GetEmptyTile();
            if (tile == null || tile.IsEmpty) return false;

            return (tile.Row == empty.Row && Math.Abs(tile.Column - empty.Column) == 1)
                || (tile.Column == empty.Column && Math.Abs(tile.Row - empty.Row) == 1);
        }

        public void Move(Tile tile)
        {
            if (!CanMove(tile)) return;

            var empty = GetEmptyTile();

            // Swap values
            int temp = tile.Value;
            tile.Value = empty.Value;
            empty.Value = temp;
        }

        public bool IsSolved()
        {
            int expected = 1;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (row == 3 && col == 3) return Tiles[row, col].IsEmpty;
                    if (Tiles[row, col].Value != expected) return false;
                    expected++;
                }
            }
            return true;
        }
    }
}
