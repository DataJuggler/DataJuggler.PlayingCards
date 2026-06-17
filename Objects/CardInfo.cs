

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataJuggler.RandomShuffler.Enumerations;
using DataJuggler.Blazor.Components;

#endregion

namespace DataJuggler.PlayingCards.Objects
{

    #region class CardInfo
    /// <summary>
    /// This class is used to CardInfo
    /// </summary>
    public class CardInfo
    {
        
        #region Private Variables
        private CardEnum card;
        private SuitEnum suit;
        private ImageButton cardButton;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
        #endregion
        
        #region Properties
            
            #region Card
            /// <summary>
            /// This property gets or sets the value for 'Card'.
            /// </summary>
            public CardEnum Card
            {
                get { return card; }
                set { card = value; }
            }
            #endregion
            
            #region CardButton
            /// <summary>
            /// This property gets or sets the value for 'CardButton'.
            /// </summary>
            public ImageButton CardButton
            {
                get { return cardButton; }
                set { cardButton = value; }
            }
            #endregion
            
            #region Suit
            /// <summary>
            /// This property gets or sets the value for 'Suit'.
            /// </summary>
            public SuitEnum Suit
            {
                get { return suit; }
                set { suit = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
