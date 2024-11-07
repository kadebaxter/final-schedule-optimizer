namespace ScheduleOptimizer.Logic;
using System;

public class Room
{

    public int RoomNumber { get; set; }
  
    public bool IsAvailable { get; set; }
    
    private string roomType;    // roomType should be one of these 3:
                                // "lab", "normal", or "online"
    

    public Room(int roomNumber, string type)
    {

        RoomNumber = roomNumber;
        IsAvailable = true;
        roomType = type;

    }

    public bool BookRoom()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
           // Console.WriteLine($"Room {RoomNumber} has been successfully occupied.");

            return true;
        }
        else
        {
           // Console.WriteLine($"Room {RoomNumber} is currently unavailable.");
            return false;
        }
    }

    public void ReleaseRoom()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
           // Console.WriteLine($"Room {RoomNumber} has been released and is now available.");
        }
        else
        {
           // Console.WriteLine($"Room {RoomNumber} is already available.");
        }
    }
}
