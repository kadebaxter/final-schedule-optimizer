namespace ScheduleOptimizer.Persistence;

public class Persistence
{
    public List<Logic.Professor> Professors { get; set; } = new List<Logic.Professor>();
    
    // remember to make constructor in professor class to initialize a ton of professors for this. 

    private enum Preference
    {
        pleaseNo,   // 0
        NotFavored, // 1
        Neutral,    // 2
        Favored,    // 3
    }

}
