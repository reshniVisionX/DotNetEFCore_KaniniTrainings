using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal interface IRoom<T, K> 
    {
        T AddRoom(T room);
        IList<T> GetAllRooms();

        T DeleteRoom(K item);
    }

    internal class RoomNonAC
    {
        public int RoomId;
        public string Category;
        public decimal Price;
    }

    internal class RoomAC
    {
        public int RoomId;
        public string Category;
        public decimal Price;
    }

    internal class Hotel : IRoom<RoomAC, int>, IRoom<RoomNonAC, int>
    {
        List<RoomAC> acrooms = new List<RoomAC>();

        List<RoomNonAC> nonacrroooms = new List<RoomNonAC>();

        public RoomAC AddRoom(RoomAC room)
        {
            acrooms.Add(room);
            return room;
        }

        public RoomNonAC AddRoom(RoomNonAC room)
        {
            nonacrroooms.Add(room);
            return room;
        }

        public RoomAC DeleteRoom(int roomid)
        {
            RoomAC room = acrooms.FirstOrDefault(x => x.RoomId == roomid);
            acrooms.Remove(room);
            return room;
        }

        public IList<RoomAC> GetAllRooms()
        {
            return acrooms;
        }

        RoomNonAC IRoom<RoomNonAC, int>.DeleteRoom(int item)
        {
            RoomNonAC rm = nonacrroooms.FirstOrDefault(x => x.RoomId == item);
            nonacrroooms.Remove(rm);
            return rm;
        }

        IList<RoomNonAC> IRoom<RoomNonAC, int>.GetAllRooms()
        {
            return nonacrroooms;
        }

    }

    class Vehicles
    {
        public string Number { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Type} - {Number}";
        }
    }

    class Parking<T> where T : Vehicles
    {
        private Stack<T> vehicles = new Stack<T>();

        public void AddVehicles(T name)
        {
            vehicles.Push(name);
            Console.WriteLine($"Vehicle {name} parked");
        }
        public void RemoveVehicles()
        {
            if (vehicles.Count > 0)
            {
                T popped = vehicles.Pop();
                Console.WriteLine($"{popped} has left the parking");
            }
            else
            {
                Console.WriteLine("The parking has no vehicle");
            }

        }

        public void ShowVehicles()
        {
            Console.WriteLine("Vehicles in parking are : ");
            foreach (T vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        public T peekVehicle()
        {
            return vehicles.Peek();
        }
        public int parkingCount()
        {
            return vehicles.Count;
        }
        public bool searchVehicles(String number)
        {
            foreach (T veh in vehicles)
            {
                if (veh.Number == number)
                {
                    Console.WriteLine("Vehicle found");
                    return true;
                }
            }
               
                    Console.WriteLine("Vehicle not found: ");
                    return false;

               
        }

        
    }
    class GenericsMain
    {
        public void CallGenerics()
        {
            Parking<Vehicles> pk = new Parking<Vehicles>();
            pk.AddVehicles(new Vehicles{ Number = "TN101", Type = "Bike" });
            pk.AddVehicles(new Vehicles { Number = "TN102", Type = "Honda" });
            pk.ShowVehicles();
            pk.RemoveVehicles();
            pk.ShowVehicles();
            Console.WriteLine();
            Console.WriteLine("Parking Count: " + pk.parkingCount());

            Console.WriteLine("Top Vehicle: " + pk.peekVehicle());

            pk.searchVehicles("TN101");
            pk.searchVehicles("TN999");



            //Hotel ht = new Hotel();
            //ht.AddRoom(new RoomAC() { RoomId = 111, Category = "Classic", Price = 4000 });

            //ht.AddRoom(new RoomAC() { RoomId = 113, Category = "Premium", Price = 5000 });

            //ht.AddRoom(new RoomNonAC() { RoomId = 101, Category = "Classic", Price = 2500 });

            //ht.AddRoom(new RoomNonAC() { RoomId = 102, Category = "Premium", Price = 3500 });


            //IList<RoomAC> acrooms = ht.GetAllRooms();

            //foreach (RoomAC room in acrooms)
            //{
            //    Console.WriteLine(room.Category + " " + room.Price + " " + room.RoomId);
            //}

            //IList<RoomNonAC> nonacrooms = ((IRoom<RoomNonAC, int>)ht).GetAllRooms();

            //foreach (RoomNonAC room in nonacrooms)
            //{
            //    Console.WriteLine(room.Category + " " + room.Price + " " + room.RoomId);
            //}

            //RoomAC rm = ht.DeleteRoom(115);
            //Console.WriteLine($"{rm.RoomId} got deleted");


        }
    }
}
