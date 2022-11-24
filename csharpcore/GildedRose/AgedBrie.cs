namespace GildedRoseKata;

public class AgedBrie : ISpecificItem
{
    private readonly Item item;

    public AgedBrie(Item item)
    {
        this.item = item;
    }

    public void UpdateItem()
    {
        decreaseSellInByOne();
        increaseQualityByOne();
    }

    private void decreaseSellInByOne()
    {
        item.SellIn -= 1;
    }

    private void increaseQualityByOne()
    {
        item.Quality += 1;
    }
}