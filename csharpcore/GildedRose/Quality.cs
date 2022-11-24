namespace GildedRoseKata;

public class Quality
{
    public static void SetItemQuality(Item item)
    {
        if (item.Quality < 0)
            item.Quality = 0;
        else if (item.Name.Equals(Constants.SULFURAS) && item.Quality > Constants.HIGHEST_VALUE_SULFURAS)
            item.Quality = Constants.HIGHEST_VALUE_SULFURAS;
        else if (!item.Name.Equals(Constants.SULFURAS) && item.Quality > Constants.HIGHEST_VALUE_OTHER_ITEMS)
            item.Quality = Constants.HIGHEST_VALUE_OTHER_ITEMS;
    }
}