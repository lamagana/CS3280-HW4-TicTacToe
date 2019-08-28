namespace HW4_TicTacToe
{
    /// <summary>
    /// Player Class - Keeps track of their 
    /// name, symbol, and how many wins they currently have
    /// </summary>
    class Player
    {
        #region Attributes
        /// <summary>
        /// Holds the name of the player: Player1 or Player2
        /// </summary>
        private string _name;

        /// <summary>
        /// Holds the symbol of the player: X or O
        /// </summary>
        private string _symbol;

        /// <summary>
        /// How many times the player has won
        /// </summary>
        private int _totalWins = 0;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public int TotalWins
        {
            get { return _totalWins; }
            set { _totalWins = value; }
        }
        #endregion

        #region Constructor
        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        #endregion

    }
}
