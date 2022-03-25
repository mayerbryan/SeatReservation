using System;

namespace SeatReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = new Room(10);
            room.RoomsSoldOutEvent += OnRoomSoldOut;

            Console.WriteLine("how many seats do you want to reserve?");
            int seatsAmount = int.Parse(Console.ReadLine());

            for (int i = 0; i <= seatsAmount; i++)
            {
                room.ReserveSeat();
            }
        }

        static void OnRoomSoldOut(object sender, EventArgs e)
        {
            Console.WriteLine("Room is Full");
        }

    }



    public class Room
    {

        public Room(int seats)
        {
            Seats = seats;
        }
        private int seatsInUse = 0;
        public int Seats { get; set; }

        public void ReserveSeat()
        {
            seatsInUse++;
            if (seatsInUse >= Seats)
            {
                OnRoomSoldOut(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("reserved seat");
            }
        }

        public event EventHandler RoomsSoldOutEvent;

        protected virtual void OnRoomSoldOut(EventArgs e)
        {
            EventHandler handler = RoomsSoldOutEvent;
            handler?.Invoke(this, e);
        }
    }
}