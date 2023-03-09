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

    //My new tests
    [Test]
    public void RewindMultipleStock()
    {
        RewindStock rewind = new RewindStock();
        Assert.That(rewind.GetTotal(), Is.EqualTo(0));
        Assert.That(rewind.GetCount("Hello World", "Horror", 1974), Is.EqualTo(0));
        for (int i = 0; i < 10; i++)
        {
            rewind.Add("Hello World", "Horror", 1974);
        }
        Assert.That(rewind.GetTotal(), Is.EqualTo(10));
        Assert.That(rewind.GetCount("Hello World", "Horror", 1974), Is.EqualTo(10));
    }

    [Test]
    public void AddNewMovie()
    {
        RewindMovie rewind = new RewindMovie("Speed", "Action", 1994);
        Assert.That(rewind.GetId().Length, Is.EqualTo(36)); // UUID
        Assert.That(rewind.GetName(), Is.EqualTo("Speed"));
        Assert.That(rewind.GetGenre(), Is.EqualTo("Action"));
        Assert.That(rewind.GetYear(), Is.EqualTo("1994"));
    }


    [Test]
    public void After1997()
    {
        try
        {
            RewindMovie rewind = new RewindMovie("Rush Hour", "Comedy", 1998);
            Assert.Fail();
        }
        catch (Exception) 
        {
            Assert.Pass();
        }
    }


    [Test]
    public void AddThenCheckTotalStock()
    {
        RewindStock stock = new RewindStock();
        stock.Add("Hello World", "Horror", 1974);
        stock.Add("Speed", "Action", 1994);

        Assert.That(stock.GetTotal(), Is.EqualTo(2));
    }


        [Test]
    public void DuplicateMembership()
    {
        try
        {
            RewindMember rewind = new RewindMember("Cat", 7);
            RewindMember rewind2 = new RewindMember("Gwen", 7);
            //create store, add rewind and rewind 2 to the store, assert fail?
            Assert.Fail();
        }
        catch (Exception) {
            Assert.Pass();
        };
    }


     [Test]
    public void LoanSpeed()
    {
        RewindStock rewind = new RewindStock();
        RewindStore store = new RewindStore(rewind);
       
        for (int i = 0; i < 3; i++)
        {
            rewind.Add("Speed", "Action", 1994);
        }
            Assert.That(rewind.GetTotal(), Is.EqualTo(3));
            store.LoanMovie("Speed", "Action", 1994);
            Assert.That(rewind.GetTotal(), Is.EqualTo(2));
    }
}