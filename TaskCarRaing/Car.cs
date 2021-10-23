using System;
using System.Collections.Generic;

namespace GoToCSharp.TaskCarRacing
{
    public abstract class Car
    {
        public string CarNumber;
        public ConsoleColor Color;
        public int Speed { set; get; }
        public int DistanceTraveled { set; get; }
        List<int> SpeedHistory = new List<int>();

        protected Car(string carNumber, ConsoleColor color)
        {
            CarNumber = carNumber;
            Color = color;
        }

        public virtual string Drive()
        {
            Console.ForegroundColor = Color;
            SpeedHistory.Add(Speed);

            DistanceTraveled -= Speed;
            if (DistanceTraveled < 0) DistanceTraveled = 0;
            return $"\"{CarNumber}\" | Скорость: {Speed} км | Осталось проехать: {DistanceTraveled} км";
        }

        public void ToRace(int distance)
        {
            DistanceTraveled = distance;
            Console.WriteLine($"Машина {CarNumber} учавстует в гонке на дистанцию {distance}");
        }

        public void Finish()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Машина {CarNumber} пересекла черту ФИНИША! Поздравляем!");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"История скорости: ");
            foreach (var speedH in SpeedHistory)
                Console.Write(speedH + ", ");
        }
    }


    public class Sport : Car
    {
        private static Random random = new Random();
        private int SpeedMin = 4;
        private int SpeedMax = 10;

        public Sport(string carNumber, ConsoleColor color) : base(carNumber, color) { }

        public override string Drive()
        {
            Speed = random.Next(SpeedMin, SpeedMax);
            return $"СПОРТКАР (speed({SpeedMin} - {SpeedMax})) :: " + base.Drive();
        }
    }

    public class Passenger : Car
    {
        private static Random random = new Random();
        private int SpeedMin = 2;
        private int SpeedMax = 7;

        public Passenger(string carNumber, ConsoleColor color) : base(carNumber, color) { }

        public override string Drive()
        {
            Speed = random.Next(SpeedMin, SpeedMax);
            return $"ЛЕГКОВАЯ (speed({SpeedMin} - {SpeedMax})) :: " + base.Drive();
        }
    }

    public class Truck : Car
    {
        private static Random random = new Random();
        private int SpeedMin = 1;
        private int SpeedMax = 4;

        public Truck(string carNumber, ConsoleColor color) : base(carNumber, color) { }

        public override string Drive()
        {
            Speed = random.Next(SpeedMin, SpeedMax);
            return $"ГРУЗОВИК (speed({SpeedMin} - {SpeedMax})) :: " + base.Drive();
        }
    }

}