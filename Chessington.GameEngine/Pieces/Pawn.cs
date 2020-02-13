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
            //if play hasn't move 
            //Square + 2 
            //else Square + 1
            
            //if player = white
            //if play hasn't move 
            //Square + 2 
            //else Square + 1
            
            //else player == white
            List<Square> squares = new List<Square>();
            
            if (Player == Player.Black)
            {
                squares.Add(Square.At(row + 1, col));
                if (!HasPlayMoved(row))
                {
                    squares.Add(Square.At(row + 2, col) );
                   
                }
            }
            else
            {
                squares.Add(Square.At(row - 1, col));
                if (!HasPlayMoved(row))
                {
                    squares.Add(Square.At(row - 2, col));
                }
            }
            return squares;
        }

        private bool HasPlayMoved(int row)
        {
            if (Player == Player.Black)
            {
                return row != 1;
            }
            else
            {
                return row != 6;
            }
            //if player == black 
            //if play hasn't move 
            //Square + 2 (return false)
            //else Square + 1 (return true)
            //return square 
            //origin == 1,0 or origin == 6,0
        }
    }
}