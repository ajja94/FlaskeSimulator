using System;

namespace FlaskeOppgave
{
    class Program
    {
        private static string[] operationNames = new[]
{
            "Fylle flaske 1 fra springen",
            "Fylle flaske 2 fra springen",
            "Tømme flaske 1 i flaske 2",
            "Tømme flaske 2 i flaske 1",
            "Fylle opp flaske 2 med flaske 1",
            "Fylle opp flaske 1 med flaske 2",
            "Tømme flaske 1 (kaste vannet)",
            "Tømme flaske 2 (kaste vannet)",
        };

        static void Main(string[] args)
        {
            var bottle1 = new Bottle(7);
            var bottle2 = new Bottle(9);
            var wantedVolume = 8;

            var numberOfOperations = 1;
            while (true)
            {
                var isSolved = TryWithGivenNumberOfOperations(numberOfOperations, bottle1, bottle2, wantedVolume);
                if (isSolved)
                {
                    break;
                }
                numberOfOperations++;
            }
        }
        private static bool TryWithGivenNumberOfOperations(int numberOfOperations, Bottle bottle1, Bottle bottle2, int wantedVolume)
        {
            Console.WriteLine();
            Console.WriteLine($"Prøver med {numberOfOperations} oprasjon(er).");
            var operations = new int[numberOfOperations];
            while (true)
            {
                DoOperations(operations, bottle1, bottle2);
                var isSolved = IsSolved(bottle1, bottle2, wantedVolume, operations);
                if (isSolved) return true;
                var success = UpdateOperations(operations);
                if (!success) break;
            }
            return false;
        }
        private static bool IsSolved(Bottle bottle1, Bottle bottle2, int wantedVolume, int[] operations)
        {
            if (bottle1.Content != wantedVolume && bottle2.Content != wantedVolume && bottle1.Content + bottle2.Content != wantedVolume)
                return false;
            for(var i = 0; i<operations.Length; i++)
            {
                var operation = operations[i];
                Console.WriteLine($"{i + 1} : {operationNames[operation]}");
            }
            return true;
        } 
        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2)
        {
            bottle1.Empty();
            bottle2.Empty();

            foreach(var operation in operations)
            {
                if (operation == 0) bottle1.FillToTopFromTap();
                else if (operation == 1) bottle2.FillToTopFromTap();

                else if (operation == 2) bottle2.Fill(bottle1.Empty());
                else if (operation == 3) bottle1.Fill(bottle2.Empty());

                else if (operation == 4) bottle2.FillToTop(bottle1);
                else if (operation == 5) bottle1.FillToTop(bottle2);

                else if (operation == 6) bottle1.Empty();
                else if (operation == 7) bottle2.Empty();
            }
        }
        private static bool UpdateOperations(int[] operations)
        {
            int i;
            for (i = operations.Length -1; i>=0; i--)
            {
                if(operations[i] < 7)
                {
                    operations[i]++;
                    break;
                }
                operations[i] = 0;
            }
            return i != -1;
        }
    }
}
