using System.Collections.Generic;

namespace GildedRoseKata;

public class SpecificItemFactory
{
    private readonly Dictionary<string, ISpecificItem> dico_specifics_items;

    public SpecificItemFactory(Item item)
    {
        dico_specifics_items = new Dictionary<string, ISpecificItem>();
        dico_specifics_items.Add(Constants.BRIE, new AgedBrie(item));
        dico_specifics_items.Add(Constants.SULFURAS, new Sulfuras());
        dico_specifics_items.Add(Constants.CONJURED_ITEM, new ConjuredItem(item));
        dico_specifics_items.Add(Constants.BACKSTAGE_PASSES, new BackstagePasses(item));
    }

    public ISpecificItem specificItem(Item item)
    {
        if (!dico_specifics_items.ContainsKey(item.Name)) return new CommonItem(item);
        return dico_specifics_items[item.Name];
    }
}