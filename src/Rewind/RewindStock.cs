namespace Rewind;

public class RewindStock
{
    // Total of all movies in stock
    private int total = 0;
    
    // Dictionary of movies by key to know how many of each title owned
    private Dictionary<string, List<RewindMovie>> stock = new Dictionary<string, List<RewindMovie>>();

    // Consruct a key based on movie name, genre and year
    private Func<string, string, int, string> key = (name, genre, year) =>
        String.Format("[{0}#{1}#{2}]", name, genre, year);

    public void Add(string name, string genre, int year)
    {
        string movieKey = key(name, genre, year);
        if (!this.stock.ContainsKey(movieKey))
        {
            this.stock.Add(movieKey, new List<RewindMovie>());
        }
        
        this.stock[movieKey].Add(new RewindMovie(name, genre, year));
        this.total++;
    }

    public int GetCount(string name, string genre, int year)
    {
        string movieKey = key(name, genre, year);
        if (this.stock.ContainsKey(movieKey))
        {
            return this.stock[movieKey].Count();
        }

        return 0;
    }

    public int GetTotal()
    {
        return this.total;
    }

    public RewindMovie RemoveMovie(string name, string genre, int year)
    {
        string movieKey = key(name, genre, year);
        RewindMovie movie = this.stock[movieKey][0];
        this.stock[movieKey].RemoveAt(0);
        this.total--;
        return movie;
    }

    public void Replace(RewindMovie movie)
    {
        string movieKey = key(movie.GetName(), movie.GetGenre(), Int32.Parse(movie.GetYear()));
        if (!this.stock.ContainsKey(movieKey))
        {
            this.stock.Add(movieKey, new List<RewindMovie>());
        }
        
        this.stock[movieKey].Add(movie);
        this.total++;
    }
}
