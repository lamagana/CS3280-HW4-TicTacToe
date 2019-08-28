namespace HW4_TicTacToe
{
    /// <summary>
    /// TicTacToeBoard Class - Holds the array for the board and creates
    /// the two Players needed for the game. Also does the game functionality
    /// such as Select, CheckForWins, ClearBoard, SwitchPlayers
    /// </summary>
    class TicTacToeBoard
    {
        #region Attributes
        /// <summary>
        /// Array that holds the TicTacToe game data - X's and O's
        /// </summary>
        private string[,] _array = new string[3, 3];

        /// <summary>
        /// Creates Two Players
        /// </summary>
        private Player _p1 = new Player("Player 1", "X");
        private Player _p2 = new Player("Player 2", "O");

        /// <summary>
        /// Holds the current player
        /// </summary>
        private Player _currentPlayer;

        /// <summary>
        /// Holds the winning move
        /// </summary>
        private string _winningMove;

        /// <summary>
        /// Counts the amount of used spots -> Used to count ties
        /// </summary>
        private int _usedSpots = 0;

        /// <summary>
        /// Counts the number of times ties have occured
        /// </summary>
        private int _ties = 0;
        #endregion

        #region Properties
        public string[,] Board
        {
            get { return _array; }
            set { _array = value; }
        }

        public Player Player1
        {
            get { return _p1; }
            set { _p1 = value; }
        }

        public Player Player2
        {
            get { return _p2; }
            set { _p2 = value; }
        }
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public int UsedSpots
        {
            get { return _usedSpots; }
            set { _usedSpots = value; }
        }

        public string WinningMove
        {
            get { return _winningMove; }
            set { _winningMove = value; }
        }

        public int Ties
        {
            get { return _ties; }
            set { _ties = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Clears the board - assigns array to empty spaces
        /// Assigns the CurrentPlayer to Player2 - will be swapped to Player1 at initial startup
        /// </summary>
        public TicTacToeBoard()
        {
            ClearBoard();
            CurrentPlayer = Player2;
        }
        #endregion

        #region Gameboard Functions
        /// <summary>
        /// Places the user's symbol at the row and column selected
        /// and increments used
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public bool Select(int row, int col, string symbol)
        {
            Board[row, col] = symbol;
            UsedSpots++;
            return (UsedSpots == 9);
        }

        /// <summary>
        /// Checks for any potential winning moves and if so, set the WinningMove that
        /// will be used to highlight the correct buttons
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public bool CheckForWins(int row, int col, string symbol)
        {
            bool isWin = false;

            if (Board[row, 0] == symbol && Board[row, 1] == symbol && Board[row, 2] == symbol)
            {
                //Check the rows
                WinningMove = "Row" + row;
                isWin = true;
            }
            else if (Board[0, col] == symbol && Board[1, col] == symbol && Board[2, col] == symbol)
            {
                //Check the columns
                WinningMove = "Col" + col;
                isWin = true;
            }
            else if (Board[0, 0] == symbol && Board[1, 1] == symbol && Board[2, 2] == symbol)
            {
                //Check for forward diagonal
                WinningMove = "FDiag";
                isWin = true;
            }
            else if (Board[2, 0] == symbol && Board[1, 1] == symbol && Board[0, 2] == symbol)
            {
                //Check for back diagonal
                WinningMove = "BDiag";
                isWin = true;
            }

            return isWin;

        }

        /// <summary>
        /// Swaps current player
        /// </summary>
        public void SwitchPlayers()
        {
            CurrentPlayer = (CurrentPlayer.Equals(Player1)) ? Player2 : Player1;
        }

        /// <summary>
        /// Clears the board with empty strings to allow users to begin
        /// selecting cells
        /// </summary>
        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Board[i, j] = "";
        }

        /// <summary>
        /// When a match is won, fill the empty spots of the board to spaces to
        /// not allow the user to keep selecting spots
        /// </summary>
        public void FillBoard()
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (Board[row, col] == "")
                        Board[row, col] = " ";
        }
        #endregion

    }
}
