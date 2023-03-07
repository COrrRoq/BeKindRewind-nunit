namespace Rewind;

public class RewindMember : RewindBase
{
    private int membership;
    
    public RewindMember(string name, int membership) : base(name)
    {
        this.membership = membership;
    }

    public string GetMembershipId()
    {
        // Padding membership identifier as six digits of 0's 
        return String.Format("#{0:000000}", this.membership);
    }
}
