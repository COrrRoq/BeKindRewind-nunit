namespace Rewind;

public class RewindMovie : RewindBase
{
    private string genre;
    private string uuid;
    private int year;
    
    public RewindMovie(string name, string genre, int year) : base(name)
    {
        if (year > 1997)
        {
            // So cannot be a VHS cassette, right?
            throw new Exception("DVD's were released by 1997!");
        }

        this.genre = genre;
        this.uuid = Guid.NewGuid().ToString();
        this.year = year;
    }

    public string GetId()
    {
        return this.uuid;
    }
    
    public string GetGenre()
    {
        return this.genre;
    }

    public string GetYear()
    {
        return ""+this.year;
    }
}
