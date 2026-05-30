

namespace DataJuggler.PlayingCards.Enumerations
{
    
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

    #region DeckEnum : int
    /// <summary>
    /// This enum is used to set which Deck is selected. At the moment only one deck exists
    /// </summary>
    public enum DeckEnum : int
    {
        TheGildedDeck = 1
    }
    #endregion

}
