using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DESIGN_ticTacToe
    {
        //Medium
        //348
        //Design Tic-Tac-Toe
        //Design a Tic-tac-toe game that is played between two players on a n x n grid.

        //You may assume the following rules:

        //A move is guaranteed to be valid and is placed on an empty block.
        //Once a winning condition is reached, no more moves is allowed.
        //A player who succeeds in placing n of their marks in a horizontal, vertical, or diagonal row wins the game.
        //Example:
        //Given n = 3, assume that player 1 is "X" and player 2 is "O" in the board.

        //TicTacToe toe = new TicTacToe(3);

        //        toe.move(0, 0, 1); -> Returns 0 (no one wins)
        //|X| | |
        //| | | |    // Player 1 makes a move at (0, 0).
        //| | | |

        //toe.move(0, 2, 2); -> Returns 0 (no one wins)
        //|X| |O|
        //| | | |    // Player 2 makes a move at (0, 2).
        //| | | |

        //toe.move(2, 2, 1); -> Returns 0 (no one wins)
        //|X| |O|
        //| | | |    // Player 1 makes a move at (2, 2).
        //| | |X|

        //toe.move(1, 1, 2); -> Returns 0 (no one wins)
        //|X| |O|
        //| |O| |    // Player 2 makes a move at (1, 1).
        //| | |X|

        //toe.move(2, 0, 1); -> Returns 0 (no one wins)
        //|X| |O|
        //| |O| |    // Player 1 makes a move at (2, 0).
        //|X| |X|

        //toe.move(1, 0, 2); -> Returns 0 (no one wins)
        //|X| |O|
        //|O|O| |    // Player 2 makes a move at (1, 0).
        //|X| |X|

        //toe.move(2, 1, 1); -> Returns 1 (player 1 wins)
        //|X| |O|
        //|O|O| |    // Player 1 makes a move at (2, 1).
        //|X|X|X|
        //Follow up:
        //Could you do better than O(n2) per move() operation?


        //https://leetcode.com/problems/design-tic-tac-toe/discuss/260212/C-O(1)-clean-version-with-some-comments
        public class TicTacToe
        {
            int[] rowCount;
            int[] colCount;
            int diag, diag2, len;


            /** Initialize your data structure here. */
            public TicTacToe(int n)
            {
                rowCount = new int[n];
                colCount = new int[n];
                diag = diag2 = 0;
                len = n;

            }

            /** Player {player} makes a move at ({row}, {col}).
                @param row The row of the board.
                @param col The column of the board.
                @param player The player, can be either 1 or 2.
                @return The current winning condition, can be either:
                        0: No one wins.
                        1: Player 1 wins.
                        2: Player 2 wins. */
            public int Move(int row, int col, int player)
            {

                int target = player == 1 ? 1 : -1;

                rowCount[row] += target;
                colCount[col] += target;

                if (row == col)
                    diag += target;

                if (row + col == len - 1)
                    diag2 += target;

                // If game ended, return current player as winner
                // For winning count values should be -n or n
                // Condition moved to end so that it can be refactored to different method if required
                if (Math.Abs(rowCount[row]) == len
                   || Math.Abs(colCount[col]) == len
                   || Math.Abs(diag2) == len
                   || Math.Abs(diag) == len)
                    return player;

                return 0;
            }
            
        }

        //Time:O(1)
        /**
         * Your TicTacToe object will be instantiated and called as such:
         * TicTacToe obj = new TicTacToe(n);
         * int param_1 = obj.Move(row,col,player);
         */
    }
}

