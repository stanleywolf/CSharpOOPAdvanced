using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager
{
    private IList<Pet> pets;
    private IList<Clinic> clinics;

    public Manager()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void CreatePet(string name, int age, string kind)
    {
        this.pets.Add(new Pet(name,age,kind));
    }

    public void CreateClinic(string name, int numOfRooms)
    {
        this.clinics.Add(new Clinic(name,numOfRooms));
    }

    public bool HasEmptyRooms(string clinicName)
    {
        return this.GetRightClinic(clinicName).HasEmptyRooms();
    }

    public string PrintClinic(string clinicName)
    {
        return this.GetRightClinic(clinicName).GetAllRooms();
    }
    public string PrintRoom(string clinicName, int roomNumber)
    {
        return this.GetRightClinic(clinicName).GetRooms(roomNumber);
    }

    public bool ReleaseAnumalFromClinic(string clinicName)
    {
        return this.GetRightClinic(clinicName).ReleaseAnimal();
    }
    internal bool AddPetToAClinic(string petName, string clinicName)
    {
        var currentPet = this.GetConcretePet(petName);
        var currentClinic = this.GetRightClinic(clinicName);
        return currentClinic.AddPet(currentPet);
    }

    private Pet GetConcretePet(string petName)
    {
        var currentPet = this.pets.FirstOrDefault(p => p.Name == petName);
        if (currentPet == null)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return currentPet;
    }

    private Clinic GetRightClinic(string clinicName)
    {
       var currentClinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
        if (currentClinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        return currentClinic;
    }
    
}