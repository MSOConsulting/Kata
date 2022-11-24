namespace GildedRoseKata;

public class CommonItem : ISpecificItem
{
    private readonly Item item;

    public CommonItem(Item item)
    {
        this.item = item;
    }

    public void UpdateItem()
    {
        DecreaseSellByOne();
        if (SellInMoreThanZero())
            DecreaseQuality(DecreaseQualityBeforeLastDayToSell());
        else
            DecreaseQuality(DecreaseQualityAfterLastDayToSell());
    }

    protected virtual int DecreaseQualityBeforeLastDayToSell()
    {
        return 1;
    }

    private void DecreaseSellByOne()
    {
        item.SellIn -= 1;
    }

    private bool SellInMoreThanZero()
    {
        return item.SellIn > 0;
    }

    private void DecreaseQuality(int qualityValue)
    {
        item.Quality -= qualityValue;
    }

    private int DecreaseQualityAfterLastDayToSell()
    {
        return DecreaseQualityBeforeLastDayToSell() * 2;
    }
}