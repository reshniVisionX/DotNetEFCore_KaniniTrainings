using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenericsLINQ
{
    internal class LINQ
    {
        public void Linq()
        {
//IEnumerable<T>:
//Where, OrderBy, Select, First, Count, Sum, Average, Min, Max, Any, All, Take, Skip

//IList<T>:
//Add, Insert, Remove, RemoveAt, IndexOf, Clear, index access([i]), etc.

            int[] numbers = [5, 10, 8, 3, 6, 12, 22, 24, 9];

            //Query syntax:
            IEnumerable<int> numQuery1 =
                from nums in numbers
                where nums % 2 == 0
                orderby nums
                select nums;

            //Method syntax:
            IEnumerable<int> numQuery2 = numbers
                .Where(num => num % 2 == 0)
                .OrderBy(n => n);

            foreach (int i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            foreach (int i in numQuery2)
            {
                Console.Write(i + " ");
            }

            IList<int> il = new List<int> { 5,78,44,62,12, 10, 9, 77, 14, 18, 23, 25, 36 };
            il.Add(21);
            il.Insert(1, 83);
            il.Remove(44);
            il.RemoveAt(4);
            Console.WriteLine("Does il conatins "+il.Contains(77));
            Console.WriteLine("Does il contains "+il.Contains(72));
            Console.WriteLine("The element in il " + il[2]);
            Console.WriteLine("The index of 18 is " + il.IndexOf(18));
            Console.WriteLine("The count " + il.Count);
            Console.WriteLine("the list into array " + il.ToArray());

            il.Clear();
            Console.WriteLine("Il is cleared : " + il);


            IEnumerable<int> num = new List<int> { 5,10,12,13,42,15,63,27,28,32,36,66};

            IEnumerable<int> filtered = num.Where(n => n > 20);
            Console.WriteLine("Filter n>20 "+string.Join(", ", filtered));

            IEnumerable<int> squared = num.Select((n) => n * n);
            Console.WriteLine("Squared nums " + string.Join(", ",squared));

            IEnumerable<int> asc = num.OrderByDescending((n) => n);
            Console.WriteLine("Ordered descending " + string.Join(", ", asc));

            IEnumerable<int> thenBy = num.OrderBy(n=>n%10).ThenBy(n=>n);
            Console.WriteLine("ThenBy (Secondary sort after OrderBy): " + string.Join(", ", thenBy));

            IEnumerable<int> skips = num.Skip(2);
            Console.WriteLine("Skips the first n elements "+string.Join(", ", skips));

            IEnumerable<int> distinct = num.Distinct();
            Console.WriteLine("Distinct removes duplicate " + string.Join(", ", distinct));

            IEnumerable<int> reversed = num.Reverse();
            Console.WriteLine("Reversed seq " + string.Join(", ", reversed));

            int first = num.First();
            Console.WriteLine("First " + first);

            int firstOrDefault = num.FirstOrDefault();
            Console.WriteLine("First or Default " + firstOrDefault);

            int last = num.Last();
            int lastOrDefault = num.LastOrDefault();
            Console.WriteLine("Last or Default " + lastOrDefault);

            int count = num.Count();
            Console.WriteLine("Count " + count);

            int sum = num.Sum();
            double avg = num.Average();
            Console.WriteLine("Sum : " + sum);
            Console.WriteLine("Average: " + avg);

            int min = num.Min();
            int max = num.Max();
            Console.WriteLine("Min : " + min + " Max: " + max);

            // checks if any matches the condition returns true
            bool anyAbove50 = num.Any(n => n > 50);
            //     All → Checks if all match condition (returns bool)
            bool allPositive = num.All(n => n > 0);
            Console.WriteLine(" Any above 50 " + anyAbove50 + " all positive " + allPositive);

            List<int> list = num.ToList();

            int[] arr = num.ToArray();


        }
    }

    class Delegates
    {
        public void DelegatesMain() {
            Admission ad = new Admission();
            decimal basefee = 50000;
            ad.AdmissionProcess("Reshni", "General", basefee);
            Console.WriteLine("");
            ad.AdmissionProcess("Shiva", "Management", basefee);
            Console.WriteLine("");
            ad.AdmissionProcess("Shree", "Sports", basefee);
        }

    }
    public delegate decimal FeeCalculationStrategy(decimal basefee);
    class Admission
    {
        public decimal GeneralFee(decimal basefee)
        {
            return basefee;
        }
        public decimal ManagementFee(decimal basefee)
        {
            return basefee * 1.25m;
        }
        public decimal SportsFee(decimal basefee)
        {
            return basefee * 0.6m;
        }
        public void AdmissionProcess(string name,string type,decimal basefee)
        {
            FeeCalculationStrategy strategy;
            switch (type)
            {
                case "Management":
                    strategy = ManagementFee;
                    break;
                case "Sports":
                    strategy = SportsFee;
                    break;
                default:
                    strategy = GeneralFee;
                    break;
            }

            decimal fees = strategy(basefee);
            Console.WriteLine($"Admission Type: {type}");
            Console.WriteLine($"Student: {name}");
            Console.WriteLine($"Base Fee: {basefee}");
            Console.WriteLine($"Final Fee: {fees}\n");
        }
    }
}
