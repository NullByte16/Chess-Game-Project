using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class AI
    {
        Color Color;
        Logic game;
        Dictionary<Type, int> worths = new Dictionary<Type, int>();

        public Move ChooseMove()
        {
            var root = BuildTree(2, game.GetTurn(), this.CloneGame(game));

            // now we have to find the son with max score
            // we can use the fact the root's score == max score of its sons
            // so we will iterate over sons to find a son with score eq to ours
            List<TreeNode> BestSons = new List<TreeNode>();
            foreach (var son in root.sons)
            {
                if (son.score == root.score)
                {
                    BestSons.Add(son);

                }
            }

            Random rnd = new Random();
            int ChosenOne = rnd.Next(0, BestSons.Count - 1);
            return BestSons[ChosenOne].whatGotUsHere;


            throw new Exception("ai did not find any move to play. at all"); //Unreachable Code?
        }

        public AI(Color color, Logic game)
        {
            this.Color = color;
            this.game = game;
            this.worths[Type.Pawn] = 1;
            this.worths[Type.Knight] = 3;
            this.worths[Type.Bishop] = 3;
            this.worths[Type.Rook] = 5;
            this.worths[Type.Queen] = 9;
            this.worths[Type.King] = 0;
        }

        /// <summary>
        /// Assess the current state of the game, in favor of a certain color (whoIsToPlay).
        /// Returns an integer between -100 and 100, ranking how good the state of the game is for specified color.
        /// </summary>
        private int Assess(Logic game, Color Color) // pretty much heuristic
        {
            /*
             * L = my pieces sum - his pices sum (on start: 39 - 39 = 0, but after we lost the queen -9)
             * we multiply L by a large wieght (say 10,000) to make it matter very much. -> queenloss = -90,000
             * 
             * C = for each piece in the center: if its ours sum its value (1, 3, 5, 9) if its his piece, sum his minus value
             * multiply this by, say, 1.
             * if we are not in the center but hes too, then c = 0. if we both control it equally, then C = 0
             * C becomes somethinh when there is a diference.
             * 
             * V = our king safety - his. this one's weight = 100 
             */


            // todo return a number from -inf(we lose) to inf(we win)
            // optional aspects:
            // are we (or they) close to the centre
            // are any piece lost
            // is the king vulnerable
            int centerControl, piecesLost, kingVulnerability;
            const int a = 1, b = 10000, c = 100;
            //First we'll check whoIsToPlay's control over the center.
            //1: How many pieces from each side physically occupy the center?
            int countWhite = OccupyCenter(game, Color.White);
            int countBlack = OccupyCenter(game, Color.Black);

            centerControl = this.Color == Color.White ? a * (countWhite - countBlack) : a * (countBlack - countWhite);

            //Next, we will compare our losses against the opponent's.
            countWhite = 0;
            countBlack = 0;
            int WhiteVulnerability = 0, BlackVulnerability = 0; // num of opponent's pieces that can get into king palace

            Cell whiteKing = game.FindKing(Color.White), blackKing = game.FindKing(Color.Black);

            HashSet<Cell> surroundingWhiteKing = new HashSet<Cell>();
            HashSet<Cell> surroundingBlackKing = new HashSet<Cell>();
            for (int i = whiteKing.I - 2; i < whiteKing.I + 2; i++)
            {
                for(int j = whiteKing.J  -2; j < whiteKing.J + 2; j++)
                {
                    if (game.ValidIndexes(i, j))
                        surroundingWhiteKing.Add(game.grid[i, j]);
                }
            }

            for (int i = blackKing.I - 2; i < blackKing.I + 2; i++)
            {
                for (int j = blackKing.J - 2; j < blackKing.J + 2; j++)
                {
                    if (game.ValidIndexes(i, j))
                        surroundingBlackKing.Add(game.grid[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.grid[i, j].piece != null)
                    {
                        if (game.grid[i, j].piece.GetColor() == Color.White)
                        {
                            countWhite += worths[game.grid[i, j].piece.GetType()];

                            foreach (var move in game.GetValidMoves(game.grid[i, j]))
                            {
                                if (surroundingWhiteKing.Contains(move))
                                {
                                    WhiteVulnerability++;
                                    break;
                                }
                            }

                        }

                        else
                        {
                            countBlack += worths[game.grid[i, j].piece.GetType()];

                            foreach (var move in game.GetValidMoves(game.grid[i, j]))
                            {
                                if (surroundingBlackKing.Contains(move))
                                {
                                    BlackVulnerability++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            piecesLost = this.Color == Color.White ? b * (countWhite - countBlack) : b * (countBlack - countWhite);
            kingVulnerability = this.Color == Color.White ? c * (countWhite - countBlack) : b * (countBlack - countWhite);

            return a * centerControl + b * piecesLost + c * kingVulnerability;
        }

        //Receives a game and a color. Returns how many pieces of that color physically occupy the center.
        private int OccupyCenter(Logic game, Color Color)
        {
            int count = 0;
            if (game.grid[3, 3].piece != null && game.grid[3, 3].piece.GetColor() == Color)
                count++;
            if (game.grid[4, 4].piece != null && game.grid[4, 4].piece.GetColor() == Color)
                count++;
            if (game.grid[3, 4].piece != null && game.grid[3, 4].piece.GetColor() == Color)
                count++;
            if (game.grid[4, 3].piece != null && game.grid[4, 3].piece.GetColor() == Color)
                count++;
            return count;

        }

        private bool HasValidMoves(Logic state, Color WhoIsToPlay)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (state.grid[i, j].piece != null && state.grid[i, j].piece.GetColor() == WhoIsToPlay && state.GetValidMoves(state.grid[i, j]).Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        int idFactory = 0;

        TreeNode BuildTree(int levelsLeftToBuild, Color WhoIsToPlay, Logic state) // the function's final result would be the tree's root

        {
            TreeNode resultNode = new TreeNode();

            bool hasAnyValidMoves; // todo check if checkmate or stalemate.
            hasAnyValidMoves = HasValidMoves(state, WhoIsToPlay);

            if (levelsLeftToBuild > 0 && hasAnyValidMoves) // recursion end
            {
                /* for each possible move, named m:
                 *     clone the current game (deep copy)
                 *     in the clone, play m. alternatively - remember what you have done to reמשהו it
                 *     son (with all its descendants along) = buildTree(levels - 1, opposite_color)
                 *     result.sons.add(son);
                */

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (state.grid[i, j].piece != null && state.grid[i, j].piece.GetColor() == WhoIsToPlay)
                        {

                            LinkedList<Cell> ValidMoves = state.GetValidMoves(state.grid[i, j]);

                            Piece movingPiece = state.grid[i, j].piece;
                            state.grid[i, j].piece = null;
                            Piece occupied_piece;// To save any existing pieces in the current move of the current piece, from being deleted.

                            foreach (var target_cell in ValidMoves)
                            {
                                occupied_piece = target_cell.piece;
                                target_cell.piece = movingPiece;

                                var son = BuildTree(levelsLeftToBuild - 1, WhoIsToPlay == Color.Black ? Color.White : Color.Black, state);
                                son.whatGotUsHere = new Move(state.grid[i, j], target_cell);
                                resultNode.sons.Add(son);

                                target_cell.piece = occupied_piece;

                            }
                            state.grid[i, j].piece = movingPiece;

                            idFactory++;
                        }
                    }
                }
                // now after recur is done, 

                if (WhoIsToPlay == this.Color)
                    resultNode.score = resultNode.GetMaxSonScore();
                else
                    resultNode.score = resultNode.GetMinSonScore();
            }
            else // we are a leaf!
            {
                if (!hasAnyValidMoves)
                {
                    if (state.InCheck(WhoIsToPlay))
                        resultNode.score = WhoIsToPlay == this.Color ? int.MinValue : int.MaxValue; // won or lost
                    else
                        resultNode.score = 0; // stale, mate!
                }
                else
                    resultNode.score = Assess(state, WhoIsToPlay);

            }

            return resultNode;
        }

        public Logic CloneGame(Logic game)
        {
            Cell[,] Grid = new Cell[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.grid[i, j].piece != null)
                        Grid[i, j] = new Cell(i, j, new Piece(game.grid[i, j].piece.GetType(), game.grid[i, j].piece.GetColor()));

                    else
                        Grid[i, j] = new Cell(i, j, null);

                }
            }

            Logic Clone = new Logic();
            Clone.grid = Grid;

            return Clone;
        }
    }

    public class Move
    {
        readonly public Cell from, to;

        public Move(Cell from, Cell to)
        {
            this.from = from;
            this.to = to;
        }
    }

    public class TreeNode
    {
        public List<TreeNode> sons = new List<TreeNode>();
        public int score;
        public Move whatGotUsHere = null;

        public int GetMaxSonScore()
        {
            int MaxScore = int.MinValue;

            foreach (TreeNode son in this.sons)
            {
                if (MaxScore < son.score)
                {
                    MaxScore = son.score;
                }
            }

            return MaxScore;
        }

        public int GetMinSonScore()
        {
            int MinScore = int.MaxValue;
            foreach (TreeNode son in this.sons)
            {
                if (MinScore > son.score)
                {
                    MinScore = son.score;
                }
            }

            return MinScore;
        }

    }
}
