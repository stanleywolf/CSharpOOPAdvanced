using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    public string Name { get; private set; }
    private Pet[] rooms;
    private int middleRooms;
    public Clinic(string name,int rooms)
    {
        this.Name = name;
        this.ValidateRoom(rooms);
        this.rooms = new Pet[rooms];
        this.middleRooms = this.rooms.Length / 2;
    }

    private void ValidateRoom(int numOfRooms)
    {
        if (numOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public bool AddPet(Pet pet)
    {
        for (int i = 0; i <= middleRooms; i++)
        {
            if (this.rooms[this.middleRooms - i] == null)
            {
                this.rooms[this.middleRooms - i] = pet;
                return true;
            }
            if (this.rooms[this.middleRooms + i] == null)
            {
                this.rooms[this.middleRooms + i] = pet;
                return true;
            }
        }
        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(c => c == null);
    }

    public string GetRooms(int roomNumber)
    {
        roomNumber--;

        if (roomNumber < 0 || roomNumber >= this.rooms.Length)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return (this.rooms[roomNumber] == null)
            ? "Room empty"
            : this.rooms[roomNumber].ToString();
    }

    public string GetAllRooms()
    {
        var sb = new StringBuilder();

        foreach (var room in this.rooms)
        {
            if (room == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(room.ToString());
            }
        }

        return sb.ToString().Trim();
    }

    public bool ReleaseAnimal()
    {
        for (int i = this.middleRooms; i < this.rooms.Length; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < this.middleRooms; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms = null;
                return true;
            }
        }
        return false;
    }
    public int CompareTo(Clinic other)
    {
        return this.Name.CompareTo(other.Name);
    }
}