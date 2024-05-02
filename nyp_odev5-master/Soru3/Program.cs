using System;
using System.Reflection.Metadata;
using System.Security;

namespace Odev
{
    internal class TicTacToe
    {
        internal static void Main()
        {
            TicTacToe game = new TicTacToe();
            game.letPlay();
        }

        private int[,] playGround;
        internal TicTacToe()
        {
            playGround = new int[3,3] {{0,0,0},{0,0,0},{0,0,0}};
        }
        internal bool Move(int[] square,ref bool player1,ref int turn)
        {
            bool illegalMove = false;
            if(playGround[square[0]-1,square[1]-1]==0)
            {
                if(player1)
                {
                    playGround[square[0]-1,square[1]-1]=1;
                }
                else
                {
                    playGround[square[0]-1,square[1]-1]=2;
                }
            }
            else
            {
                illegalMove = true;
                Console.Write("\nERROR: Illegal move\nTry Again!\n\n");
            }
            if(!illegalMove)
            {
                turn +=1;
                player1 = !player1;
            }
            return illegalMove;
        }
        internal int[] askSquare(int turn,bool player1)
        {
            if(player1)
            {
                Console.Write($"Turn {turn}: Player 1's turn");
            }
            else
            {
                Console.Write($"Turn {turn}: Player 2's turn");
            }
            int[] square;
            square = new int[] {0,0};
            Console.Write("\nRow: ");
            square[0] = Convert.ToInt32(Console.ReadLine());
            while(square[0]<1||square[0]>3)
            {
                Console.Write("\nERROR: Illegal move\nTry Again!\n\n");
                Console.Write("\nRow: ");
                square[0] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Column: ");
            square[1] = Convert.ToInt32(Console.ReadLine());
            while(square[1]<1||square[1]>3)
            {
                Console.Write("\nERROR: Illegal move\nTry Again!\n\n");
                Console.Write("Column: ");
                square[1] = Convert.ToInt32(Console.ReadLine());
            }
            return square;
        }
        internal void letPlay()
        {
            int turn = 0;
            bool win = false;
            bool illegalMove = false;
            bool player1= true;
            bool Player1win = false;
            int[] square = new int[2];
            playGroundPrint();
            while(!win && turn < 9)
            {
                if(!illegalMove)
                {
                    square = askSquare(turn+1,player1);
                    illegalMove = Move(square,ref player1,ref turn);
                    win = controlWin(ref Player1win);
                    if(!illegalMove)
                    {
                        playGroundPrint();
                    }
                }
                while(illegalMove)
                {
                    square = askSquare(turn+1,player1);
                    illegalMove = Move(square,ref player1,ref turn);
                    win = controlWin(ref Player1win);
                    playGroundPrint();
                }
            }
            if(win && Player1win)
            {
                Console.Write("Player 1 Won!\n");
            }
            else if(win && !Player1win)
            {
                Console.Write("Player 2 Won!\n");
            }
            else if(!win && turn==9)
            {
                Console.Write("Its draw!\n");
            }
        }
        internal bool controlWin(ref bool Player1win)
        {
            bool win = false;
            Player1win = false;
            for(int i=0;i<3;i++)
            {
                if(playGround[i,0]==playGround[i,1]&&playGround[i,1]==playGround[i,2]&&playGround[i,0]!=0)
                {
                    if(playGround[i,0]==1)
                    {
                        Player1win = true;
                    }
                    win = true;
                    break;
                }
                else if(playGround[0,i]==playGround[1,i]&&playGround[2,i]==playGround[1,i]&&playGround[1,i]!=0)
                {
                    if(playGround[1,i]==1)
                    {
                        Player1win = true;
                    }
                    win = true;
                    break;
                }
            }
            if(playGround[0,0]==playGround[1,1]&&playGround[1,1]==playGround[2,2]&&playGround[1,1]!=0)
            {
                if(playGround[1,1]==1)
                {
                    Player1win = true;
                }
                win = true;
                return win;
            }
            else if(playGround[0,2]==playGround[1,1]&&playGround[1,1]==playGround[2,0]&&playGround[1,1]!=0)
            {
                if(playGround[1,1]==1)
                {
                    Player1win = true;
                }
                win = true;
                return win;
            }
            return win;
        }
        internal void playGroundPrint()
        {
            Console.Write("\n");
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    Console.Write($"{playGround[i,j]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}