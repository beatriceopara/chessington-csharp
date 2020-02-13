﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var square = board.FindPiece(this);

            var row = square.Row;

            var col = square.Col;

            //if player == black 
            //else player == white
            if (Player == Player.Black)
            {
                List<Square> squares = new List<Square>
                {
                    Square.At(row + 1, col),
                };
                return squares;
            }
            else
            {
                List<Square> squares = new List<Square>
                {
                    Square.At(row - 1, col),
                };
                return squares;
            }
            

            
        }
    }
}