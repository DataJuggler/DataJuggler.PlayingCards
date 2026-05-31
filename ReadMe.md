
# DataJuggler.PlayingCards

A .NET playing card library that includes **The Gilded Deck** — a complete 52-card deck plus 4 card back images with a luxurious gilded aesthetic. Cards are 400 x 560 with a 2px transparent margin on each border.

## Installation

Install via the .NET CLI:

    dotnet add package DataJuggler.PlayingCards

Or search for **DataJuggler.PlayingCards** in Visual Studio's NuGet Package Manager.

## Five Card Draw WinForms Example

    // create a shuffler - 1 deck, shuffle 10 times
    RandomShuffler shuffler = new RandomShuffler(1, 10);

    // create a dealer
    Dealer dealer = new Dealer(PlatformEnum.Windows, DeckEnum.TheGildedDeck);

    // Shuffle the cards (already shuffled above, just showing an example)
    dealer.Shuffle();

    // iterate the cards
    for (int x = 0; x < 5; x++)
    {
        // get the next card
        Card card = shuffler.PullNextCard();

        // If the card object exists
        if (NullHelper.Exists(card))
        {
            // get the pictureBox
            PictureBox pictureBox = GetPictureBox(x);

            // If the pictureBox object exists
            if (NullHelper.Exists(pictureBox))
            {
                // stretch to fit
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // Set the image
                pictureBox.Image = card.Bitmap;
            }
        }
    }

    // GetPictureBox just returns PictureBox1 - PictureBox5 for a Video Poker Sample I am working on.
    // Card.Bitmap is set in Dealer.PullNextCard() method for WinForms

# Blazor Example Coming Soon

Card.Path is set for Blazor projects. This will return something like:

    // Set the imageUrl
    this.Card1.ImageUrl = card.Path;

In the above example, Card1 is a DataJuggler.Blazor.Components.ImageComponent. 

When you call Dealer.PullNextCard and the Platform equals PlatformEnum.Blazor, Card.Path is set by calling this method.

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

# Card Full Name

Card Full Name is a read only property that return Card Name + Suit Name + ".png";

# Example Card Full Names
TwoHearts.png
JackSpades.png
KingClubs.png
AceDiamonds.png

# Updates
5.31.2026: I fixed the Dealer class. It now works for WinFroms. I will finish the WInForms sample and build a Blazor 
sample as soon as I get some time.

# The Gilded Deck

This NuGet package uses a deck of cards I created called The Gilded Deck. I am copying the read me from here so you can 
see the card previews. 

**Please enjoy these cards** — I worked really hard to create them.

This is a complete 52-card deck plus 4 card back images with a luxurious gilded aesthetic. 
Each card is 400 x 560 and has a 2 px transparent margin on each border.

### Download Instructions

To download all cards:

Click the green Code button at the top of this page, then select Download ZIP.

### Please Leave A Star!

If you find these images worth the price.

## Card Previews

### Aces
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/AceClubs.png?raw=true" width="160" height="224" alt="Ace of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/AceDiamonds.png?raw=true" width="160" height="224" alt="Ace of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/AceHearts.png?raw=true" width="160" height="224" alt="Ace of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/AceSpades.png?raw=true" width="160" height="224" alt="Ace of Spades"/>
</div>

### Twos
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TwoClubs.png?raw=true" width="160" height="224" alt="2 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TwoDiamonds.png?raw=true" width="160" height="224" alt="2 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TwoHearts.png?raw=true" width="160" height="224" alt="2 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TwoSpades.png?raw=true" width="160" height="224" alt="2 of Spades"/>
</div>

### Threes
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/ThreeClubs.png?raw=true" width="160" height="224" alt="3 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/ThreeDiamonds.png?raw=true" width="160" height="224" alt="3 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/ThreeHearts.png?raw=true" width="160" height="224" alt="3 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/ThreeSpades.png?raw=true" width="160" height="224" alt="3 of Spades"/>
</div>

### Fours
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FourClubs.png?raw=true" width="160" height="224" alt="4 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FourDiamonds.png?raw=true" width="160" height="224" alt="4 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FourHearts.png?raw=true" width="160" height="224" alt="4 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FourSpades.png?raw=true" width="160" height="224" alt="4 of Spades"/>
</div>

### Fives
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FiveClubs.png?raw=true" width="160" height="224" alt="5 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FiveDiamonds.png?raw=true" width="160" height="224" alt="5 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FiveHearts.png?raw=true" width="160" height="224" alt="5 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/FiveSpades.png?raw=true" width="160" height="224" alt="5 of Spades"/>
</div>

### Sixes
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SixClubs.png?raw=true" width="160" height="224" alt="6 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SixDiamonds.png?raw=true" width="160" height="224" alt="6 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SixHearts.png?raw=true" width="160" height="224" alt="6 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SixSpades.png?raw=true" width="160" height="224" alt="6 of Spades"/>
</div>

### Sevens
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SevenClubs.png?raw=true" width="160" height="224" alt="7 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SevenDiamonds.png?raw=true" width="160" height="224" alt="7 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SevenHearts.png?raw=true" width="160" height="224" alt="7 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/SevenSpades.png?raw=true" width="160" height="224" alt="7 of Spades"/>
</div>

### Eights
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/EightClubs.png?raw=true" width="160" height="224" alt="8 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/EightDiamonds.png?raw=true" width="160" height="224" alt="8 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/EightHearts.png?raw=true" width="160" height="224" alt="8 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/EightSpades.png?raw=true" width="160" height="224" alt="8 of Spades"/>
</div>

### Nines
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/NineClubs.png?raw=true" width="160" height="224" alt="9 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/NineDiamonds.png?raw=true" width="160" height="224" alt="9 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/NineHearts.png?raw=true" width="160" height="224" alt="9 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/NineSpades.png?raw=true" width="160" height="224" alt="9 of Spades"/>
</div>

### Tens
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TenClubs.png?raw=true" width="160" height="224" alt="10 of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TenDiamonds.png?raw=true" width="160" height="224" alt="10 of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TenHearts.png?raw=true" width="160" height="224" alt="10 of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/TenSpades.png?raw=true" width="160" height="224" alt="10 of Spades"/>
</div>

### Jacks
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/JackClubs.png?raw=true" width="160" height="224" alt="Jack of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/JackDiamonds.png?raw=true" width="160" height="224" alt="Jack of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/JackHearts.png?raw=true" width="160" height="224" alt="Jack of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/JackSpades.png?raw=true" width="160" height="224" alt="Jack of Spades"/>
</div>

### Queens
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/QueenClubs.png?raw=true" width="160" height="224" alt="Queen of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/QueenDiamonds.png?raw=true" width="160" height="224" alt="Queen of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/QueenHearts.png?raw=true" width="160" height="224" alt="Queen of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/QueenSpades.png?raw=true" width="160" height="224" alt="Queen of Spades"/>
</div>

### Kings
<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/KingClubs.png?raw=true" width="160" height="224" alt="King of Clubs"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/KingDiamonds.png?raw=true" width="160" height="224" alt="King of Diamonds"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/KingHearts.png?raw=true" width="160" height="224" alt="King of Hearts"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/KingSpades.png?raw=true" width="160" height="224" alt="King of Spades"/>
</div>

### Card Backs

<div align="center" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 12px; margin-bottom: 20px;">
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/CardBackBlue.png?raw=true" width="160" height="224" alt="Blue Back"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/CardBackRed.png?raw=true" width="160" height="224" alt="Red Back"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/CardBack2Blue.png?raw=true" width="160" height="224" alt="Blue Back 2"/>
<img src="https://github.com/DataJuggler/TheGildedDeck/blob/master/CardBack2Red.png?raw=true" width="160" height="224" alt="Red Back 2"/>
</div>

---

## How These Card Images Were Made

Most of the images were generated with **ChatGPT Images 2** in Comfy UI. While the AI produced beautiful base
artwork, it created inconsistencies across the deck — varying fonts, symbol sizes, and positions.

To bring everything together into a cohesive style, I used my own tools:

- **[DataJuggler.PixelDatabase](https://github.com/DataJuggler/PixelDatabase)** — my NuGet package for pixel-level image manipulation. For this project I added new features including drawing text upside down and rotating images. I also wrote `FindFirstVisiblePixel()` and `FindFirstNonWhitePixel()` specifically to handle the deck's needs.

- **[Isolator](https://github.com/DataJuggler/Isolator)** — another new open-source project of mine that makes it easy to isolate objects from transparent backgrounds.

**Grok** (from xAI) helped me build a **Marching Ants selector** tool that simplified isolating and refining the images.
** Claude ** also helped with some graphics programming help. Most of the credit goes to
** CHatGPT Images 2 ** in ** Comfy UI **

I spent about **$10 on Comfy UI credits** to generate high-quality face cards and card backs.

---

These images are **completely free to use** in any project — commercial or personal. No attribution required, though it's always appreciated.

If you like the deck, please leave a star on this repo and drop a link if you use the cards in your own work. 
It helps more people discover the project!

Thanks for stopping by — I hope The Gilded Deck brings some elegance to your games, projects, or collections.

Corby / Data Juggler
