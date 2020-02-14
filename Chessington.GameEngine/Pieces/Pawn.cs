﻿using System.Collections.Generic;
using System.Linq;
 using System.Runtime.InteropServices.WindowsRuntime;
 using System.Transactions;

 namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentLocation = board.FindPiece(this);

            var currentRow = currentLocation.Row;

            var currentCol = currentLocation.Col;
            
            List<Square> squaresToMoveTo = new List<Square>();

            Square nextSquare;
            Square secondNextSquare;
            
            if (Player == Player.Black)
            {
               nextSquare = Square.At(currentRow + 1 , currentCol);
               secondNextSquare = Square.At(currentRow + 2, currentCol);
            }
            else
            {
               nextSquare = Square.At(currentRow - 1, currentCol);
               secondNextSquare = Square.At(currentRow - 2, currentCol);
            }
            
            if (HasPlayMoved(currentRow))
            {
                if (IsSquareFree(board, nextSquare))
                {
                    squaresToMoveTo.Add(nextSquare);
                }
                else
                {
                    //don't add moves 
                }
            }
            else
            {
                if (IsSquareFree(board, nextSquare))
                {
                    if (IsSquareFree(board, secondNextSquare))
                    {
                        squaresToMoveTo.Add(nextSquare);
                        squaresToMoveTo.Add(secondNextSquare);
                    }
                    else
                    {
                        squaresToMoveTo.Add(nextSquare);
                    }
                }
                else
                {
                    //don't add moves
                }
            }
            return squaresToMoveTo;
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
        }
        
        //if player1 is blocked by player 2 the piece cannot move forward and it cannot take the piece in front 
        //needs to check if square on board is free or check if piece in square
        
        //if piece in square return true
        //else no piece in square return false
        private bool IsSquareFree(Board board, Square square)
        {

            if (board.GetPiece(square) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}