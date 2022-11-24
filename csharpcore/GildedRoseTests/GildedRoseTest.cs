using System.Collections.Generic;
using GildedRoseKata;
using NFluent;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Should_decrease_quality_by_one_every_day()
    {
        IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 13, Quality = 10 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("foo");
        Check.That(actualItem.SellIn).IsEqualTo(12);
        Check.That(actualItem.Quality).IsEqualTo(9);
    }

    [Fact]
    public void Should_degrades_twice_as_fast_when_salesByDate_passed()
    {
        IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("foo");
        Check.That(actualItem.SellIn).IsEqualTo(-1);
        Check.That(actualItem.Quality).IsEqualTo(8);
    }

    [Fact]
    public void Should_never_set_quality_lower_than_zero()
    {
        IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("foo");
        Check.That(actualItem.SellIn).IsEqualTo(9);
        Check.That(actualItem.Quality).IsEqualTo(0);
    }

    [Fact]
    public void Should_AgeBrie_increase_in_quality_when_getting_older()
    {
        IList<Item> Items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("Aged Brie");
        Check.That(actualItem.SellIn).IsEqualTo(9);
        Check.That(actualItem.Quality).IsEqualTo(11);
    }

    [Fact]
    public void Should_AgeBrie_increase_in_quality_when_getting_older_even_after_sellin()
    {
        IList<Item> Items = new List<Item> { new() { Name = "Aged Brie", SellIn = -1, Quality = 10 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("Aged Brie");
        Check.That(actualItem.SellIn).IsEqualTo(-2);
        Check.That(actualItem.Quality).IsEqualTo(11);
    }

    [Fact]
    public void Should_never_set_quality_to_more_than_50()
    {
        IList<Item> Items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("Aged Brie");
        Check.That(actualItem.SellIn).IsEqualTo(9);
        Check.That(actualItem.Quality).IsEqualTo(50);
    }

    [Fact]
    public void Should_never_sell_or_decrease_Sulfuras_quality()
    {
        IList<Item> Items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", Quality = 80 } };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("Sulfuras, Hand of Ragnaros");
        Check.That(actualItem.Quality).IsEqualTo(80);
        Check.That(actualItem.SellIn).IsEqualTo(0);
    }

    [Theory]
    [InlineData(11, 30, 31)]
    [InlineData(10, 30, 32)]
    [InlineData(7, 30, 32)]
    [InlineData(5, 30, 33)]
    [InlineData(2, 30, 33)]
    [InlineData(1, 30, 33)]
    [InlineData(0, 30, 0)]
    public void Should_age_backstage_normally_if_concert_more_than_ten_days_from_now(int sellInStart,
        int initialQuality, int expectedQuality)
    {
        IList<Item> Items = new List<Item>
        {
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInStart, Quality = initialQuality }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        var actualItem = Items[0];
        Check.That(actualItem.Name).IsEqualTo("Backstage passes to a TAFKAL80ETC concert");
        Check.That(actualItem.Quality).IsEqualTo(expectedQuality);
        Check.That(actualItem.SellIn).IsEqualTo(sellInStart - 1);
    }
}