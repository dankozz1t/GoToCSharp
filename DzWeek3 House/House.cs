using System;
using System.Collections.Generic;

namespace GoToCSharp.DzWeek3_House
{
    //public static class GoToStart
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.ForegroundColor = ConsoleColor.Yellow;
    //        Console.Title = "DZ_Week1_3_Building_House";
    //    }
    //}

    public interface IPart
    {
        string Print();
    }


    public class Basement : IPart
    {

        public string Print()
        {
            return " +Фундамент";
        }
    }

    public class Walls : IPart
    {
        public string Print()
        {
            return " +Стены";
        }
    }


    public class House
    {
        private Basement basement;
        private Walls walls;

        public List<IPart> parts;

        void Print()
        {
            Console.WriteLine("ДОМ!");
            foreach (var part in parts)
            {
                part.Print();
            }

            Console.WriteLine("------");
        }
    }

    public abstract class Builder
    {
        public abstract void CreateBasement();
        public abstract void CreateWalls();
    }

    public class HouseBuilder : Builder
    {
        private House house;

        public override void CreateBasement()
        {
           house.parts.Add(new Basement());
        }

        public override void CreateWalls()
        {
            house.parts.Add(new Walls());
        }
    }

    public interface IWorker
    {
        void Work();
    }

    public class Worker : IWorker
    {
        private Builder Builder;

        public void Work()
        {
            Console.WriteLine("Я работник, я работаю");
            Builder.CreateBasement();
            Builder.CreateWalls();
        }

    }




}