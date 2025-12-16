using System;

namespace AccessSystemSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тест системы доступа");

            // Часть A: enum + switch
            Console.WriteLine("\nЧасть A (enum + switch):");

            AccessContext context1 = new AccessContext
            {
                HasTwoFactor = true,
                IsFromTrustedIP = false,
                IsSuspicious = false
            };

            AccessScoreCalculatorEnum calculator1 = new AccessScoreCalculatorEnum();

            Console.WriteLine($"Viewer: {calculator1.CalculateScore(UserRole.Viewer, context1)}");
            Console.WriteLine($"Editor: {calculator1.CalculateScore(UserRole.Editor, context1)}");
            Console.WriteLine($"Manager: {calculator1.CalculateScore(UserRole.Manager, context1)}");
            Console.WriteLine($"Admin: {calculator1.CalculateScore(UserRole.Admin, context1)}");

            // Часть B: иерархия классов
            Console.WriteLine("\nЧасть B (иерархия классов):");

            AccessContext context2 = new AccessContext
            {
                HasTwoFactor = true,
                IsFromTrustedIP = true,
                IsSuspicious = true
            };

            AccessScoreCalculatorOop calculator2 = new AccessScoreCalculatorOop();

            Console.WriteLine($"Viewer: {calculator2.CalculateScore(new Viewer(), context2)}");
            Console.WriteLine($"Editor: {calculator2.CalculateScore(new Editor(), context2)}");
            Console.WriteLine($"Manager: {calculator2.CalculateScore(new Manager(), context2)}");
            Console.WriteLine($"Admin: {calculator2.CalculateScore(new Admin(), context2)}");
        }
    }
}