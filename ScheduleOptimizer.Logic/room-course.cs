using System;
using System.Collections.Generic;

namespace ScheduleOptimizer.Logic

public class Course
{
	
  private readonly List<(int RoomNumber, bool IsAvailable, string RoomType)> rooms;

  public Course(List<(int RoomNumber, bool IsAvailable, string RoomType)> initialRooms)
   {
	rooms = new List<(int, bool, string)>(initialRooms);
   }   

	
  public IReadOnlyList<(int RoomNumber, bool IsAvailable, string RoomType)> GetRooms()
   {
		return rooms.AsReadOnly();
   }
}
