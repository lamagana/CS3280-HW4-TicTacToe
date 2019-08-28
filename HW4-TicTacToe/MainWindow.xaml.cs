using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HW4_TicTacToe
{
    /// <summary>
    /// Interacts with with the XAML and TicTacToeBoard to manipulate
    /// the board UI
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// Creates a TicTacToe game board
        /// </summary>
        TicTacToeBoard game = new TicTacToeBoard();
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            //As soon as game starts, allow users to begin immediately playing. Can be commented out
            StartGameButton_Click(null, null);
        }
        #endregion

        #region Mouse Click Events
        /// <summary>
        /// On "Start Game" click, resets the GUI board and the game board
        /// and prepares to allow users to click on the GUI board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            game.ClearBoard();
            UpdateGUIBoard();
            ResetKeys();

            game.UsedSpots = 0;
            game.WinningMove = "";

            game.SwitchPlayers();
            GameStatusTextbox.Content = game.CurrentPlayer.Name + "'s Turn";
        }

        /// <summary>
        /// On any board Button Cick, gets the name of the button
        /// and places the current player's symbol on that button
        /// Then checks for wins/ties, otherwise switch players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Board_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Content.ToString() == "")
                {
                    int row = 0;
                    int col = 0;
                    
                    switch (btn.Name)
                    {
                        case "Btn1":
                            row = 0; col = 0;
                            break;
                        case "Btn2":
                            row = 0; col = 1;
                            break;
                        case "Btn3":
                            row = 0; col = 2;
                            break;
                        case "Btn4":
                            row = 1; col = 0;
                            break;
                        case "Btn5":
                            row = 1; col = 1;
                            break;
                        case "Btn6":
                            row = 1; col = 2;
                            break;
                        case "Btn7":
                            row = 2; col = 0;
                            break;
                        case "Btn8":
                            row = 2; col = 1;
                            break;
                        case "Btn9":
                            row = 2; col = 2;
                            break;
                    }

                    bool isBoardFull = game.Select(row, col, game.CurrentPlayer.Symbol);
                    bool isGameWon = game.CheckForWins(row, col, game.CurrentPlayer.Symbol);

                    UpdateGUIBoard();
                    if (isGameWon)
                    {
                        //If a player wins
                        game.CurrentPlayer.TotalWins++;
                        GameStatusTextbox.Content = game.CurrentPlayer.Name + " Wins!";
                        UpdateStatistics();
                        game.FillBoard();
                        HighlightBoard();
                    }
                    else if (isBoardFull)
                    {
                        //If board becomes full = Tie
                        GameStatusTextbox.Content = "It's a tie!";
                        game.Ties++;
                        UpdateStatistics();
                    }
                    else
                    {
                        //Switch players
                        game.SwitchPlayers();
                        GameStatusTextbox.Content = game.CurrentPlayer.Name + "'s Turn";
                    }
                    UpdateGUIBoard();

                }
            }
        }
        #endregion

        #region GUI Updates
        /// <summary>
        /// Assigns game board's contents (the symbols) to the button's
        /// contents
        /// </summary>
        public void UpdateGUIBoard()
        {
            Btn1.Content = game.Board[0, 0];
            Btn2.Content = game.Board[0, 1];
            Btn3.Content = game.Board[0, 2];
            Btn4.Content = game.Board[1, 0];
            Btn5.Content = game.Board[1, 1];
            Btn6.Content = game.Board[1, 2];
            Btn7.Content = game.Board[2, 0];
            Btn8.Content = game.Board[2, 1];
            Btn9.Content = game.Board[2, 2];
        }

        /// <summary>
        /// After each Tie/Win, updates the Statistics Section
        /// </summary>
        private void UpdateStatistics()
        {
            Player1WinsLabel.Content = game.Player1.TotalWins;
            Player2WinsLabel.Content = game.Player2.TotalWins;
            TiesLabel.Content = game.Ties;
        }
        #endregion

        #region Highlighting
        /// <summary>
        /// On a win, access the game's winningMove and highlight
        /// the necessary keys
        /// </summary>
        private void HighlightBoard()
        {
            switch(game.WinningMove)
            {
                case "Row0":
                    HighlightKey(Btn1);
                    HighlightKey(Btn2);
                    HighlightKey(Btn3);
                    break;
                case "Row1":
                    HighlightKey(Btn4);
                    HighlightKey(Btn5);
                    HighlightKey(Btn6);
                    break;
                case "Row2":
                    HighlightKey(Btn7);
                    HighlightKey(Btn8);
                    HighlightKey(Btn9);
                    break;
                case "Col0":
                    HighlightKey(Btn1);
                    HighlightKey(Btn4);
                    HighlightKey(Btn7);
                    break;
                case "Col1":
                    HighlightKey(Btn2);
                    HighlightKey(Btn5);
                    HighlightKey(Btn8);
                    break;
                case "Col2":
                    HighlightKey(Btn3);
                    HighlightKey(Btn6);
                    HighlightKey(Btn9);
                    break;
                case "FDiag":
                    HighlightKey(Btn1);
                    HighlightKey(Btn5);
                    HighlightKey(Btn9);
                    break;
                case "BDiag":
                    HighlightKey(Btn3);
                    HighlightKey(Btn5);
                    HighlightKey(Btn7);
                    break;
            }
        }

        /// <summary>
        /// Invertly-Highlights the passed in key
        /// </summary>
        /// <param name="btn"></param>
        private void HighlightKey(Button btn)
        {
            btn.Foreground = Brushes.Black;
            btn.Background = Brushes.Yellow;
        }

        /// <summary>
        /// Once the user selects Start Game, assign the button's back to their
        /// original color scheme
        /// </summary>
        private void ResetKeys()
        {
            Button[] btns = { Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9 };
            for (int i = 0; i < 9; i++)
            {
                btns[i].ClearValue(Button.BackgroundProperty);
                btns[i].ClearValue(Button.ForegroundProperty);   
            }
        }

        #endregion
    }
}