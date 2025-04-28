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
            
        }

        public void Shuffle(int moves = 1000) //zamíchání - udělá tisíc náhodných pohybů (tím se zajistí, že je hra dohratelná)
        {
            int index = 1;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Tiles[row, col] = new Tile(index <= 15 ? index : 0, row, col);
                    index++;
                }
            }

            var random = new Random();

            for (int i = 0; i < moves; i++)
            {
                var movableTiles = GetMovableTiles();
                var tileToMove = movableTiles[random.Next(movableTiles.Count)];
                Move(tileToMove);
            }
        }

        public List<Tile> GetMovableTiles() //seznam bloků, kterými lze pohnout
        {
            var empty = GetEmptyTile();
            var tiles = new List<Tile>();

            if (empty.Row > 0) tiles.Add(Tiles[empty.Row - 1, empty.Column]); // nahoře
            if (empty.Row < 3) tiles.Add(Tiles[empty.Row + 1, empty.Column]); // dole
            if (empty.Column > 0) tiles.Add(Tiles[empty.Row, empty.Column - 1]); // vlevo
            if (empty.Column < 3) tiles.Add(Tiles[empty.Row, empty.Column + 1]); // vpravo

            return tiles;
        }

        public Tile GetEmptyTile() //najde prázdnoý blok
        {
            foreach (var tile in Tiles)
                if (tile.IsEmpty) return tile;

            return null;
        }

        public bool CanMove(Tile tile) //zjistí, zda lze pohnout blokem
        {
            var empty = GetEmptyTile();
            if (tile == null || tile.IsEmpty) return false;

            return (tile.Row == empty.Row && Math.Abs(tile.Column - empty.Column) == 1)
                || (tile.Column == empty.Column && Math.Abs(tile.Row - empty.Row) == 1);
        }

        public void Move(Tile tile) //prohodí bloky (prázdný s číslem)
        {
            if (!CanMove(tile)) return;

            var empty = GetEmptyTile();


            int temp = tile.Value;
            tile.Value = empty.Value;
            empty.Value = temp;
        }

        public bool IsSolved() //ověří, zda jsou bloky seřazeny
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
