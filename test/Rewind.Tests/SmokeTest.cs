namespace Rewind.Tests;

using Rewind;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SanityCheckRewindBase()
    {
        RewindBase rewind = new RewindBase("Hello");
        Assert.That(rewind.GetName(), Is.EqualTo("Hello"));
    }

    [Test]
    public void SanityCheckRewindMember()
    {
        RewindMember rewind = new RewindMember("Hello", 7);
        Assert.That(rewind.GetMembershipId(), Is.EqualTo("#000007"));
    }

    [Test]
    public void SanityCheckRewindMovie()
    {
        RewindMovie rewind = new RewindMovie("Hello World", "Horror", 1974);
        Assert.That(rewind.GetId().Length, Is.EqualTo(36)); // UUID
        Assert.That(rewind.GetName(), Is.EqualTo("Hello World"));
        Assert.That(rewind.GetGenre(), Is.EqualTo("Horror"));
        Assert.That(rewind.GetYear(), Is.EqualTo("1974"));
    }

    [Test]
    public void SanityCheckRewindStock()
    {
        RewindStock rewind = new RewindStock();
        Assert.That(rewind.GetTotal(), Is.EqualTo(0));
        Assert.That(rewind.GetCount("Hello World", "Horror", 1974), Is.EqualTo(0));
        rewind.Add("Hello World", "Horror", 1974);
        Assert.That(rewind.GetTotal(), Is.EqualTo(1));
        Assert.That(rewind.GetCount("Hello World", "Horror", 1974), Is.EqualTo(1));
    }

    [Test]
    public void SanityCheckRewindStore()
    {
        RewindStock stock = new RewindStock();
        stock.Add("Hello World", "Horror", 1974);
        RewindStore store = new RewindStore(stock);
        Assert.That(store.CheckStock("Hello World", "Horror", 1974), Is.EqualTo(1));
    }
}
