

namespace DataJuggler.PlayingCards.Enumerations
{
    
    #region CardBackEnum : int
    /// <summary>
    /// This enum is for the CardBacks that are currently in the deck
    /// </summary>
    public enum CardBackEnum : int
    {
        DoNotLoadCardBack = 0,
        CardBackBlue = 1,
        CardBackRed = 2,
        CardBack2Blue = 3,
        CardBack2Red = 4
    }
    #endregion

    #region DeckEnum : int
    /// <summary>
    /// This enum is used to set which Deck is selected. At the moment only one deck exists
    /// </summary>
    public enum DeckEnum : int
    {
        TheGildedDeck = 1
    }
    #endregion

    #region PlatformEnum : int
    /// <summary>
    /// This enum is used to what type of environment is the Dealer hosted in
    /// </summary>
    public enum PlatformEnum : int
    {
        Blazor = 1,
        Windows = 2
    }
    #endregion

}
