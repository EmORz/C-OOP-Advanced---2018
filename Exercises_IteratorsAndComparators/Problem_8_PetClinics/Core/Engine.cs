namespace Problem_8_PetClinics.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    public class Engine
    {
        public void Run()
        {
            List<Pet> pets = new List<Pet>();
            List<Clinic> clinics = new List<Clinic>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                string command = input[0];
                Clinic clinic;
                switch (command)
                {
                    case "Create":
                        if (input[1] == "Pet")
                        {
                            pets.Add(new Pet(input[2], int.Parse(input[3]), input[4]));
                        }

                        if (input[1] == "Clinic")
                        {
                            clinics.Add(new Clinic(input[2], int.Parse(input[3])));
                        }
                        break;
                    case "Add":
                        var pet = pets.SingleOrDefault(x => x.Name == input[1]);
                        clinic = clinics.Single(x => x.Name == input[2]);
                        try
                        {
                            Console.WriteLine(clinic.Add(pet));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Release":
                        clinic = clinics.Single(x => x.Name == input[1]);
                        Console.WriteLine(clinic.Release());
                        break;
                    case "Print":
                        clinic = clinics.Single(x => x.Name == input[1]);
                        if (input.Length == 2)
                        {
                            clinic.Print();
                        }
                        else if (input.Length == 3)
                        {
                            clinic.PrintRoom(int.Parse(input[2]));
                        }
                        break;
                    case "HasEmptyRooms":
                        clinic = clinics.Single(x => x.Name == input[1]);
                        Console.WriteLine(clinic.HasEmptyRooms());
                        break;


                }
            }
        }
    }
}
