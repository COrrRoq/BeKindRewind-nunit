namespace Rewind;

public class RewindStore
{
    private RewindStock stock;

    // Dictionary of members by their public key for lookup later
    private Dictionary<string, RewindMember> membership = new Dictionary<string, RewindMember>();

    public RewindStore(RewindStock stock)
    {
        this.stock = stock;
    }

    public void AddMember(RewindMember member)
    {
        this.membership.Add(member.GetMembershipId(), member);
    }

    public int CheckStock(string name, string genre, int year)
    {
        return this.stock.GetCount(name, genre, year);
    }

    public RewindMember GetMember(string membershipId)
    {
        return this.membership[membershipId];
    }

    public bool HasMember(string membershipId)
    {
        return this.membership.ContainsKey(membershipId);
    }

    public RewindMovie LoanMovie(string name, string genre, int year)
    {
        return this.stock.RemoveMovie(name, genre, year);
    }

    public void ReturnMovie(RewindMovie movie)
    {
        this.stock.Replace(movie);
    }
}
