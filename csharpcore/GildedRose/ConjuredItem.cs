namespace GildedRoseKata;

public class ConjuredItem : CommonItem
{
    public ConjuredItem(Item item) : base(item)
    {
    }

    protected override int DecreaseQualityBeforeLastDayToSell()
    {
        return 2;
    }
}