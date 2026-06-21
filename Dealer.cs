

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
        private const string GreenFeltPath = "DataJuggler.PlayingCards.wwwroot.GreenFelt.png";
        private const string CardBacksFolder = "CardBacks.";
        private const string JokersFolder = "Jokers.";
        private Card cardBackImage;
        private Card jokerImage;
        #endregion
        
        #region Constructor(PlatformEnum platform, DeckEnum deck, CardBackEnum cardBack = CardBackEnum.DoNotLoadCardBack, int numberDecks = 1, int jokersCount = 0)
        /// <summary>
        /// Create a new instance of a Dealer objects.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="deck"></param>
        /// <param name="cardBack">The card back to use</param>
        public Dealer(PlatformEnum platform, DeckEnum deck, CardBackEnum cardBack = CardBackEnum.DoNotLoadCardBack, int numberDecks = 1, int jokersCount = 0)
        {
            // store the args
            this.Platform = platform;
            this.Deck = deck;
            this.Shuffler = new RandomShuffler.RandomShuffler(numberDecks, 10);

            // if any card back except Do Not Load Card Back
            if (cardBack != CardBackEnum.DoNotLoadCardBack)
            {
                // Load the CardBackImage
                this.CardBackImage = LoadCardBack(cardBack);
            }

            // If the value for jokersCount is greater than zero
            if (jokersCount > 0)
            {
                // Load the Joker
                this.JokerImage = LoadJoker();
            }
        }
        #endregion
        
        #region Methods
            
            #region GetCardBackFileName(CardBackEnum cardBack)
            /// <summary>
            /// Returns the file name for the given CardBackEnum value
            /// </summary>
            public string GetCardBackFileName(CardBackEnum cardBack)
            {
                // initial value
                string fileName = "";

                // determine the file name based on the cardBack
                switch (cardBack)
                {
                    case CardBackEnum.BlueDiamond:

                        // set the fileName
                        fileName = "BlueDiamond.png";

                        // required
                        break;

                    case CardBackEnum.CrimsonHelix:

                        // set the fileName
                        fileName = "CrimsonHelix.png";

                        // required
                        break;

                    case CardBackEnum.EmeraldLabyrinth:

                        // set the fileName
                        fileName = "EmeraldLabyrinth.png";

                        // required
                        break;

                    case CardBackEnum.VerdantAscension:

                        // set the fileName
                        fileName = "VerdantAscension.png";

                        // required
                        break;
                }

                // return value
                return fileName;
            }
            #endregion

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

                        // if the pixelDatabase exists
                        if (NullHelper.Exists(pixelDatabase))
                        {
                            // Set the Bitmap
                            card.Bitmap = pixelDatabase.DirectBitmap.Bitmap;
                        }
                    }
                }
            }
            #endregion

            #region LoadCardBack(CardBackEnum cardBack)
            /// <summary>
            /// Loads the card back image and returns it as a Card object
            /// </summary>
            public Card LoadCardBack(CardBackEnum cardBack)
            {
                // create a card to represent the card back
                Card card = new Card(CardEnum.Ace, SuitEnum.Clubs, 14, true);

                // get the file name
                string fileName = GetCardBackFileName(cardBack);

                // If the fileName exists
                if (TextHelper.Exists(fileName))
                {
                    if (Platform == PlatformEnum.Blazor)
                    {
                        // set the path for Blazor
                        card.Path = "_content/DataJuggler.PlayingCards/Decks/TheGildedDeck/CardBacks/" + fileName;
                    }
                    else if (Platform == PlatformEnum.Windows)
                    {
                        // for Windows, a Stream must be loaded to the get the imaige out of the NuGet package assembly.

                        // initial value
                        DataJuggler.PixelDatabase.PixelDatabase pixelDatabase = null;

                        // get the stream
                        Stream stream = typeof(Dealer).Assembly.GetManifestResourceStream(CardAssemblyRoot +  CardBacksFolder + fileName);

                        // load the pixelDatabase
                        pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(stream);

                        // if the pixelDatabase exists
                        if (NullHelper.Exists(pixelDatabase))
                        {
                            // Set the Bitmap
                            card.Bitmap = pixelDatabase.DirectBitmap.Bitmap;
                        }
                    }
                }

                // return value
                return card;
            }
            #endregion

            #region LoadGreenFelt()
            /// <summary>
            /// Loads a PixelDatabase from GreenFelt.png.
            /// This call is for WinForms only.
            /// </summary>
            public PixelDatabase.PixelDatabase LoadGreenFelt()
            {
                // initial value
                PixelDatabase.PixelDatabase pixelDatabase = null;

                // which platform? 
                if (Platform == PlatformEnum.Blazor)
                {
                    // raise an error wrong platform
                    throw new Exception("This call is only available for Windows");
                }
                else if (Platform == PlatformEnum.Windows)
                {
                    // for Windows, a Stream must be loaded to the get the imaige out of the NuGet package assembly.

                    // get the stream
                    Stream stream = typeof(Dealer).Assembly.GetManifestResourceStream(GreenFeltPath);

                    // load the pixelDatabase
                    pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(stream);
                }

                // return value
                return pixelDatabase;
            }
            #endregion

            #region LoadJoker()
            /// <summary>
            /// Loads a Joker CardBack
            /// </summary>
            public Card LoadJoker()
            {
                // create a card to represent the card back
                Card card = new Card(CardEnum.Joker, SuitEnum.NotSet, 100, true);

                // get the file name
                string fileName = "Joker.png";

                // If the fileName exists
                if (TextHelper.Exists(fileName))
                {
                    if (Platform == PlatformEnum.Blazor)
                    {
                        // set the path for Blazor
                        card.Path = "_content/DataJuggler.PlayingCards/Decks/TheGildedDeck/Jokers" + fileName;
                    }
                    else if (Platform == PlatformEnum.Windows)
                    {
                        // for Windows, a Stream must be loaded to the get the imaige out of the NuGet package assembly.

                        // initial value
                        DataJuggler.PixelDatabase.PixelDatabase pixelDatabase = null;

                        // get the stream
                        Stream stream = typeof(Dealer).Assembly.GetManifestResourceStream(CardAssemblyRoot +  JokersFolder + fileName);

                        // load the pixelDatabase
                        pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(stream);

                        // if the pixelDatabase exists
                        if (NullHelper.Exists(pixelDatabase))
                        {
                            // Set the Bitmap
                            card.Bitmap = pixelDatabase.DirectBitmap.Bitmap;
                        }
                    }
                }

                // return value
                return card;
            }
            #endregion
            
            #region PullNextCard(bool exposed = true)
            /// <summary>
            /// returns the Next Card
            /// </summary>
            public Card PullNextCard(bool exposed = true)
            {
                // initial value
                Card card = null;

                // if the value for HasShuffler is true
                if (HasShuffler && Shuffler.HasCards)
                {
                    // pull the next card
                    card = Shuffler.PullNextCard();

                    // Load the card image or set the path depending on the platform
                    LoadCard(card);

                    // Set the value for Exposed
                    card.Exposed = exposed;
                }

                // return value
                return card;
            }
            #endregion
            
            #region SetExposed(bool exposed)
            /// <summary>
            /// Set Exposed
            /// </summary>
            public void SetExposed(bool exposed)
            {
                // Set the value
                if ((HasShuffler) && (Shuffler.HasCards))
                {
                    // Set the value for all the cards
                    Shuffler.SetExposed(exposed);
                }
            }
            #endregion
            
            #region Shuffle(int shuffles = 5, bool exposed = false)
            /// <summary>
            /// Shuffle
            /// </summary>
            public void Shuffle(int shuffles = 5, bool exposed = false)
            {
                // if the value for HasShuffler is true
                if (HasShuffler)
                {
                    // Shuffle the decks
                    Shuffler.Shuffle(shuffles);
                }

                // Set the value for Exposed
                Shuffler.SetExposed(exposed);
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region CardBackImage
            /// <summary>
            /// This property gets or sets the value for 'CardBackImage'.
            /// </summary>
            public Card CardBackImage
            {
                get { return cardBackImage; }
                set { cardBackImage = value; }
            }
            #endregion
            
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
            
            #region HasCardBackImage
            /// <summary>
            /// This property returns true if this object has a 'CardBackImage'.
            /// </summary>
            public bool HasCardBackImage
            {
                get
                {
                    // initial value
                    bool hasCardBackImage = (CardBackImage != null);

                    // return value
                    return hasCardBackImage;
                }
            }
            #endregion
            
            #region HasJokerImage
            /// <summary>
            /// This property returns true if this object has a 'JokerImage'.
            /// </summary>
            public bool HasJokerImage
            {
                get
                {
                    // initial value
                    bool hasJokerImage = (JokerImage != null);

                    // return value
                    return hasJokerImage;
                }
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
            
            #region JokerImage
            /// <summary>
            /// This property gets or sets the value for 'JokerImage'.
            /// </summary>
            public Card JokerImage
            {
                get { return jokerImage; }
                set { jokerImage = value; }
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
