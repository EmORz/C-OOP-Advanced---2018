namespace Problem_8_PetClinics.Models
{
    using System;
    using System.Linq;

    public class Clinic
    {
        private Pet[] rooms;
        private int addIndex;
        private int addRealase;


        public Clinic(string name, int rooms)
        {



            this.Name = name;
            this.rooms = new Pet[rooms];
            this.addIndex = rooms / 2;
            this.addRealase = rooms / 2;
        }

        public string Name { get; private set; }

        public bool Add(Pet pet)
        {
            if (pet == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i <= this.addIndex; i++)
            {
                if (this.rooms[addIndex-i]==null)
                {
                    this.rooms[addIndex - i] = pet;
                    return true;
                }

                if (this.rooms[addIndex + i] == null)
                {
                    rooms[addIndex + i] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool Release()
        {

            for (int i = addRealase; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < addRealase; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    return true;
                }

            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.rooms.Any(r => r == null);
        }

        public void PrintRoom(int n)
        {
            var result = this.rooms[n - 1] != null ? $"{rooms[n - 1]}" : "Room empty";
            Console.WriteLine(result);
        }
        public void Print()
        {
            foreach (var pet in rooms)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }

    }
}
