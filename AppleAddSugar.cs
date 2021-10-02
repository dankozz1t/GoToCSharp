using System;

namespace GoToCSharp
{
    public partial class Apple
    {
        public void AddSugar()
        {
            Console.Write($" ЯБЛОКО №{Number} | ");
            Console.WriteLine($" ВКУС ЯБЛОКА: {Taste} ");
            Console.WriteLine(" Добавляю сахара.... ");
            Taste = "Сладкое";
            Console.WriteLine($" ВКУС ЯБЛОКА: {Taste} ");
        }
    }
}