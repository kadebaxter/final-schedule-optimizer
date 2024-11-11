using System;
using System.Collections.Generic;

namespace ScheduleOptimizer.Logic
{
	// I updated the course class and added descripton,room list and needs lab properties and methods. 
	
	public class Course
	{
	  public int CourseId { get; set; }
		
	  public string CourseName { get; set; }
		
	  string Description { get; set; }
		
	  public bool NeedsLab { get; set; }
		
	  public List<Room> AssignedRooms { get; private set; }

	  public Course(int courseId, string courseName, string description = "N/A", bool needsLab = false)
		
		{
			CourseId = courseId;
			CourseName = courseName;
			Description = description;
			NeedsLab = needsLab;
			AssignedRooms = new List<Room>();
		}

	  public void AddRoom(Room room)
		{
		   if ((NeedsLab && room.RoomType == RoomType.Lab) || !NeedsLab)
		   {
				AssignedRooms.Add(room);
				Console.WriteLine($"Room {room.RoomNumber} assigned to {CourseName}.");
		   }
			else
		   {
				Console.WriteLine($"Room {room.RoomNumber} does not meet lab requirements for {CourseName}.");
		   }
		}

		public void DisplayCourseInfo()
		{
			Console.WriteLine($"Course ID: {CourseId}");
			Console.WriteLine($"Course Name: {CourseName}");
			Console.WriteLine($"Description: {Description}");
			Console.WriteLine($"Needs Lab: {NeedsLab}");
			Console.WriteLine("Assigned Rooms:");
			foreach (var room in AssignedRooms)
			{
				Console.WriteLine($" - Room {room.RoomNumber} ({room.RoomType})");
			}
		}
	}

	public enum RoomType
	{
		Lab,
		Normal,
		Online
	}

	public class Room
	{
	  public int RoomNumber { get; set; }
		
      public bool IsAvailable { get; set; }
		
	  public RoomType RoomType { get; private set; }

	  public Room(int roomNumber, RoomType type)
		{
			RoomNumber = roomNumber;
			IsAvailable = true;
			RoomType = type;
		}

	  public bool BookRoom()
		{
		  if (IsAvailable)
		  {
		     IsAvailable = false;
			 Console.WriteLine($"Room {RoomNumber} has been successfully booked.");
			 return true;
		  }
			 Console.WriteLine($"Room {RoomNumber} is currently unavailable.");
			 return false;
		} 

		public void ReleaseRoom()
		{
			if (!IsAvailable)
			{
				IsAvailable = true;
				Console.WriteLine($"Room {RoomNumber} has been released and is now available.");
			}
			else
			{
				Console.WriteLine($"Room {RoomNumber} is already available.");
			}
		}
	}

	
	public class Program
	{
		public static void Main()
		{
			var course = new Course(1, "Computer Science CS 2024", "Introduction to software engineering", true);

			var room1 = new Room(101, RoomType.Lab);
			
			var room2 = new Room(102, RoomType.Normal);
			
			var room3 = new Room(103, RoomType.Online);

			course.AddRoom(room1); // Should be accepted
			course.AddRoom(room2); // Should be rejected if course requires a lab
			course.AddRoom(room3); // Should be accepted as per room requirements

			course.DisplayCourseInfo();
		}
	}
}
