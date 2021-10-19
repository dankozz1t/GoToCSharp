using System;
using System.Collections.Generic;

namespace GoToCSharp.TaskCarRacing
{
    public class MainCarRacing
    {
        static void MainCar(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Task Car Racing";


            //game.cars.Add(new SportCar());
            //game.cars.Add(new SportCar("UE9840", ConsoleColor.Red, 10));
            //game.cars.Add(new SportCar("EE3434", ConsoleColor.Cyan, 5));


            List<Car> cars = new List<Car>
            {
                new Car("ВМ5445", ConsoleColor.Green, 7, true),
                new Car("UE9840", ConsoleColor.Red, 10, true),
                new Car("NENE00", ConsoleColor.DarkBlue, 3, false),
                new Car("EE3434", ConsoleColor.Cyan, 5,true)
            };

            Car sportCar = new Car("MIMI233", ConsoleColor.Magenta, 2, true);
            cars.Add(sportCar);


            Game game = new Game();




            foreach (var car in cars)
            {
                game.Regestr += car.toRace;
                //game.Finish += car.Drive;
            }

            game.Reg();

            game.DistanceSet(50);
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    //game.Finish += game.cars[j].DistanceNow;
                } 

                foreach (var car in cars)
                {
                    car.Drive(50);
                }
                //foreach (var car in cars)
                //{
                //    game.Finish += car.DistanceNow;
                //    //game.Finish += car.Drive;
                //}

            }

            //GoToCSharpStud.Teacher teacher = new Teacher();

            //foreach (var item in students)
            //{
            //    teacher.ExamEvent += item.Exam;
            //}
            //teacher.SetExam(new DateTime(2021, 10, 15));
            ;
            Console.WriteLine($"--- РАСТОЯНИЕ 50 км ---");







            Console.Read();
        }
    }
}