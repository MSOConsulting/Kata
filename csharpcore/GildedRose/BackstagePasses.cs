namespace GildedRoseKata;

public class BackstagePasses : ISpecificItem
{
    private readonly Item item;

    public BackstagePasses(Item item)
    {
        this.item = item;
    }

    public void UpdateItem()
    {
        if (item.SellIn > 10)
            item.Quality += 1;
        else if (item.SellIn > 5)
            item.Quality += 2;
        else if (item.SellIn > 0)
            item.Quality += 3;
        else
            item.Quality = 0;

        item.SellIn -= 1;
    }
}