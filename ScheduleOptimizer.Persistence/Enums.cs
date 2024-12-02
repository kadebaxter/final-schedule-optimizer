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

public enum CourseTimes
{
    MWF730,
    MWF830,
    MWF930,
    MWF1030,
    MWF1130,
    MWF1230,
    MWF130,
    MWF230,
    MWF330,
    MWF430,
    TTh730,
    TTh930,
    TTh1130,
    TTh130,
    TTh330
}