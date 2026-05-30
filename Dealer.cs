

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataJuggler.PixelDatabase;
using DataJuggler.PlayingCards.Enumerations;
using DataJuggler.RandomShuffler;
using DataJuggler.RandomShuffler.Enumerations;
using DataJuggler.RandomShuffler.Interfaces;
using DataJuggler.RandomShuffler.Objects;
using DataJuggler.UltimateHelper;
using System.Runtime.Versioning;

#endregion

namespace DataJuggler.PlayingCards
{

    #region class Dealer
    /// <summary>
    /// This class is the CardManager for this library. 
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class Dealer
    {
        
        #region Private Variables
        private PlatformEnum platform;
        private DeckEnum deck;
        private RandomShuffler.RandomShuffler shuffler;
        private const string CardAssemblyRoot = "DataJuggler.PlayingCards.wwwroot.Decks.TheGildedDeck.";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a Dealer objects.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="deck"></param>
        public Dealer(PlatformEnum platform, DeckEnum deck, int numberDecks = 1)
        {
            // store the args
            this.Platform = platform;
            this.Deck = deck;
            this.Shuffler = new RandomShuffler.RandomShuffler(numberDecks, 2, 14, 5);
        }
        #endregion
        
        #region Methods
            
            #region GetCardPath(Card card)
            /// <summary>
            /// returns the Card Path
            /// </summary>
            public string GetCardPath(Card card)
            {
                // initial value
                string path = "";
                
                // If the card object exists
                if (NullHelper.Exists(card))
                {
                    // set the path for Blazor using the _content/ convention
                    path = $"_content/DataJuggler.PlayingCards/Decks/TheGildedDeck/{card.CardFullName}";
                }

                // return value
                return path;
            }
            #endregion
            
            #region LoadCard(Card card)
            /// <summary>
            /// returns the Card Path
            /// </summary>
           public void LoadCard(Card card)
            {
                // If the card object exists
                if (NullHelper.Exists(card))
                {
                    // get the full name of this card
                    string cardName = card.CardFullName;

                    if (Platform == PlatformEnum.Blazor)
                    {
                        // set the path for Blazor
                        card.Path = GetCardPath(card);
                    }
                   else if (Platform == PlatformEnum.Windows)
                    {
                        // initial value
                        DataJuggler.PixelDatabase.PixelDatabase pixelDatabase = null;

                        // Set the Path for Windows
                        Stream stream = typeof(Dealer).Assembly.GetManifestResourceStream(CardAssemblyRoot + cardName);

                        // load the pixelDatabase
                        pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(stream);
                    }
                }
            }
            #endregion
            
            #region PullNextCard()
            /// <summary>
            /// returns the Next Card
            /// </summary>
            public Card PullNextCard()
            {
                // initial value
                Card card = null;

                // if the value for HasShuffler is true
                if (HasShuffler && Shuffler.CanPullNextItem())
                {
                    // pull the next card
                    card = Shuffler.PullNextCard();

                    // if this is Blazor
                    if (Platform == PlatformEnum.Blazor)
                    {
                        // Set the card path
                        card.Path = GetCardPath(card);
                    }
                    else
                    {
                        
                    }
                }

                // return value
                return card;
            }
            #endregion
            
            #region Shuffle()
            /// <summary>
            /// Shuffle
            /// </summary>
            public void Shuffle()
            {
                // if the value for HasShuffler is true
                if (HasShuffler)
                {
                    // Shuffle the decks
                    Shuffler.Shuffle(5);
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Deck
            /// <summary>
            /// This property gets or sets the value for 'Deck'.
            /// </summary>
            public DeckEnum Deck
            {
                get { return deck; }
                set { deck = value; }
            }
            #endregion
            
            #region HasShuffler
            /// <summary>
            /// This property returns true if this object has a 'Shuffler'.
            /// </summary>
            public bool HasShuffler
            {
                get
                {
                    // initial value
                    bool hasShuffler = (Shuffler != null);

                    // return value
                    return hasShuffler;
                }
            }
            #endregion
            
            #region Platform
            /// <summary>
            /// This property gets or sets the value for 'Platform'.
            /// </summary>
            public PlatformEnum Platform
            {
                get { return platform; }
                set { platform = value; }
            }
            #endregion
            
            #region Shuffler
            /// <summary>
            /// This property gets or sets the value for 'Shuffler'.
            /// </summary>
            public RandomShuffler.RandomShuffler Shuffler
            {
                get { return shuffler; }
                set { shuffler = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
