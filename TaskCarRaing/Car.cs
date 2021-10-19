using System;
using System.Collections.Generic;
using System.Threading;

namespace GoToCSharp.TaskCarRacing
{
    public class Car
    {
        public bool goStart;
        public string CarNumber;
        ConsoleColor Color;
        int Speed;
        public int DistanceTraveled { set; get; }


        public Car(string carNumber, ConsoleColor color, int speed, bool toRace)
        {
            CarNumber = carNumber;
            Color = color;
            Speed = speed;
            goStart = toRace;
        }

        public void Drive(int distance)
        {
            Console.ForegroundColor = Color;
            DistanceTraveled -= Speed;
            Console.WriteLine($"{CarNumber} : {Speed} км/м | Осталось роехать: {DistanceTraveled} / {distance} км");
        }

        public void toRace()
        {
            Console.WriteLine($"Машине {CarNumber} учавстует в гонке");
        }

        public void DistanceNow(int distance)
        {
            DistanceTraveled = distance;
            Console.WriteLine($"Машине {CarNumber} задано дистанцию {distance} км");
        }

    }

    public delegate void StartDelegate();
    public delegate void DistanceDelegate(int distance);

    //public class SportCar : Car
    //{
    //    public SportCar(string carNumber, ConsoleColor color, int speed) : base(carNumber, color, speed) { }

    //    public string Drive()
    //    {
    //        return $"Спортивная " + base.Drive();
    //    }


    //}


    public class Game
    {
        //public List<Car> cars = new List<Car>();
        private SortedList<string, StartDelegate> list = new SortedList<string, StartDelegate>();

        private int Distance;


        //public Game(List<Car> cars)
        //{
        //    this.cars = cars;
        //}

        //public void Start()
        //{
        //    Thread.Sleep(1000);
        //    foreach (var car in cars)
        //    {
        //        Console.WriteLine(car.Drive());
        //    }

        //}


        public event StartDelegate Regestr
        {
            add
            {
                if ((value.Target as Car).goStart)
                {
                    list.Add((value.Target as Car).CarNumber, value);
                }
            }
            remove
            {
                if (!(value.Target as Car).goStart)
                {
                    list.Remove((value.Target as Car).CarNumber);
                }
            }
        }




        public event DistanceDelegate Finish;
        //{
        //    add
        //    {
        //        if ((value.Target as Car).DistanceTraveled > 0)
        //        {
        //            cars.Add(value.Target);
        //        }
        //    }
        //    remove
        //    {
        //        if ((value.Target as Car).DistanceTraveled <= 0)
        //        {
        //            cars.Remove(value.Target as Car);
        //        }
        //    }
        //}

        public void OnEvent(int dis)
        {
            if (Finish != null)
            {
                Finish(dis);
            }
            throw new Exception("Что-то пошло не так");
        }


        public void Reg()
        {
            foreach (var item in list)
            {
                item.Value();
            }
        }


        public void DistanceSet(int distance)
        {
            //Distance = distance;
            //foreach (var item in cars)
            //{

            //    item.DistanceNow(Distance);
            //}
        }

    }


}