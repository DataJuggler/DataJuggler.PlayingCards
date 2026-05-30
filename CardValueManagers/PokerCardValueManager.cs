using System.Collections.Generic;
using DataJuggler.RandomShuffler.Interfaces;
using DataJuggler.RandomShuffler.Objects;
using DataJuggler.RandomShuffler.Enumerations;
using DataJuggler.UltimateHelper;

namespace ObjectLibrary.Models
{

    #region PokerCardValueBase : ICardValueManager
    /// <summary>
    /// This class is used to return card values for Poker games.
    /// In Poker, Ace is high (14), face cards are 11-13, numbered cards are face value.
    /// </summary>
    public class PokerCardValueBase : ICardValueManager
    {

        #region Private Variables
        private const int ValueTwo = 2;
        private const int ValueThree = 3;
        private const int ValueFour = 4;
        private const int ValueFive = 5;
        private const int ValueSix = 6;
        private const int ValueSeven = 7;
        private const int ValueEight = 8;
        private const int ValueNine = 9;
        private const int ValueTen = 10;
        private const int ValueJack = 11;
        private const int ValueQueen = 12;
        private const int ValueKing = 13;
        private const int ValueAce = 14;
        #endregion

        #region Methods

            #region GetCardValue(Card card, int currentValue = 0)
            /// <summary>
            /// This method returns the poker value  a card.
            /// In Poker, Ace is always high (14). Current value is not used
            /// but is kept to satisfy the ICardValueManager interface.
            /// </summary>
            /// <param name="card"></param>
            /// <param name="currentValue"></param>
            /// <returns></returns>
            public int GetCardValue(Card card, int currentValue = 0)
            {
                // initial value
                int cardValue = 0;

                // if the card exists
                if (NullHelper.Exists(card))
                {
                    // Determine the return value by the CardName
                    switch (card.CardName)
                    {
                        case CardEnum.Ace:

                            // set the return value
                            cardValue = ValueAce;

                            // required
                            break;

                        case CardEnum.King:

                            // set the return value
                            cardValue = ValueKing;

                            // required
                            break;

                        case CardEnum.Queen:

                            // set the return value
                            cardValue = ValueQueen;

                            // required
                            break;

                        case CardEnum.Jack:

                            // set the return value
                            cardValue = ValueJack;

                            // required
                            break;

                        case CardEnum.Ten:

                            // set the return value
                            cardValue = ValueTen;

                            // required
                            break;

                        default:

                            // numbered cards map directly from the enum
                            cardValue = (int) card.CardName;

                            // required
                            break;
                    }
                }

                // return value
                return cardValue;
            }
            #endregion

            #region GetCardValues(Card card)
            /// <summary>
            /// This method returns all possible values for a card in Poker.
            /// Unlike Blackjack, Poker cards have only one value each.
            /// </summary>
            /// <param name="card"></param>
            /// <returns></returns>
            public List<int> GetCardValues(Card card)
            {
                // initial value
                List<int> cardValues = new List<int>();

                // if the card exists
                if (NullHelper.Exists(card))
                {
                    // get the card value
                    int cardValue = GetCardValue(card);

                    // add the value
                    cardValues.Add(cardValue);
                }

                // return value
                return cardValues;
            }
            #endregion

        #endregion

    }
    #endregion

}