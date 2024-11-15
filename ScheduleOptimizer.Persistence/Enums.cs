namespace ScheduleOptimizer.Persistence;
public enum Semester
{
    Spring,
    Summer,
    Fall
}
public enum Preference
{
    pleaseNo,   // 0
    NotFavored, // 1
    Neutral,    // 2
    Favored,    // 3
}

public enum RoomType
{
    Lab, 
    Normal, 
    Online
}

public enum WeekDay
{
    Monday = 2, 
    Tuesday = 3, 
    Wednesday = 4,
    Thursday = 5,
    Friday = 6,
}