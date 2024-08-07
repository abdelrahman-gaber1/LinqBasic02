using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using static LinqBasic02.ListGenerator;
namespace LinqBasic02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Element Operators

            #region 1
            var productOut = ProductsList.FirstOrDefault(P => P.UnitsInStock == 0);
            //Console.WriteLine(productOut);

            #endregion

            #region 2

            var productP = ProductsList.FirstOrDefault(p => p.UnitPrice > 1000 , null );
            //Console.WriteLine(productP);
            #endregion

            #region 3 /
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var second = Arr.Where(p=> p>5).Skip(1).FirstOrDefault();
            //Console.WriteLine(second);
            #endregion

            #endregion 

            #region Aggregate Operators 2

            #region 1

            int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var count = Arr01.Count(p=>p%2 == 1);
            //Console.WriteLine(count);

            #endregion

            #region 2

            var listCustomers = CustomersList.Select(C => new {C , Order = C.Orders.Count()} );

            foreach (var c in listCustomers)
                Console.WriteLine(c);

            #endregion

            #region 3 /

            var listCat = ProductsList.GroupBy(P=>P.Category).Select(O=> new {O.Key ,Product= O.Count()});

            //foreach (var c in listCat)
            //{
            //     Console.WriteLine(c);
            //}


            #endregion

            #region 4

            int[] Arr03 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var total = Arr03.Sum();
            //Console.WriteLine(total);
            #endregion

            #region 5

            string[] DictionaryEnglish = File.ReadAllLines("D:\\Route\\LINQ\\LinqBasic02\\LinqBasic02\\dictionary_english.txt");
            var allCharC = DictionaryEnglish.Count();
            //Console.WriteLine(allCharC);
            #endregion

            #region 6

            var shortest = DictionaryEnglish.OrderBy( A => A.Length).First().Count();
           // Console.WriteLine(shortest);

            #endregion

            #region 7
            var longest = DictionaryEnglish.OrderByDescending(A => A.Length).First().Count();

            //Console.WriteLine(longest);

            #endregion

            #region 8

            var Average = DictionaryEnglish.Average(A => A.Length);
            //Console.WriteLine(Average);

            #endregion

            #region 9

            var totalUnit = ProductsList.GroupBy(P=>P.Category).
                Select(O => new {O.Key , totalUnit = O.Sum(P=>P.UnitsInStock)});
            //foreach( var item in totalUnit )
            //    Console.WriteLine(item);

            #endregion

            #region 10

            var CheapestPrice = ProductsList.GroupBy(p => p.Category)
                .Select(p => new { p.Key , cheapest = p.MinBy(P=>P.UnitPrice).UnitPrice });
            foreach (var item in CheapestPrice)
                Console.WriteLine(item);

            #endregion

            #region 11//


            #endregion

            #region 12

            var mostExpensivePrice = ProductsList.GroupBy(P => P.Category)
                .Select(O => new { O.Key, max = O.MaxBy(O => O.UnitPrice).UnitPrice });
            //foreach( var item in mostExpensivePrice)
            //    Console.WriteLine(item);

            #endregion

            #region 13

            var mostExpensiveProd = ProductsList.GroupBy(P => P.Category)
                .Select(O => new { O.Key, Product = O.MaxBy(O => O.UnitPrice).ProductName });
            //foreach( var item in mostExpensiveProd)
            //Console.WriteLine(item);

            #endregion

            #region 14

            var AvgCat = ProductsList.GroupBy(P => P.Category)
                .Select(O => new {O.Key ,Avarage= O.Average(P=>P.UnitPrice)});

            //foreach( var item in AvgCat )
            //    Console.WriteLine(item);

            #endregion


            #endregion


            #region Set Operators 

            #region 1

            var uniqe = ProductsList.DistinctBy(P => P.Category).Select(p=> p.Category);

            //foreach(var x in  uniqe)
            //    Console.WriteLine(x);

            #endregion

            #region 2 /

            var resultSeq = ProductsList.Select(P=>P.ProductName.ElementAt(0)).UnionBy(CustomersList.Select(C=>C.CustomerName.ElementAt(0)), P=>P);
            //foreach(var item in resultSeq)
            //    Console.WriteLine(item);

            #endregion

            #region 3

            var CommenFirst = ProductsList.Select(P => P.ProductName.ElementAt(0)).
                IntersectBy(CustomersList.Select(C => C.CustomerName.ElementAt(0)), P => P);
            //foreach( var c in CommenFirst)
            //    Console.WriteLine(c);
            #endregion

            #region 4

            var expectProduct = ProductsList.Select(P => P.ProductName.ElementAt(0))
                .ExceptBy(CustomersList.Select(C => C.CustomerName.ElementAt(0)), P => P);
            //foreach(var p  in expectProduct) 
            //    Console.WriteLine(p);

            #endregion

            #region 5


            var LastThree = ProductsList.Select(p=> p.ProductName.TakeLast(3).ToArray()).
                Concat(CustomersList.Select(C => C.CustomerName.TakeLast(3).ToArray()));
            //foreach (var last in LastThree)
            //    Console.WriteLine(last);

            #endregion

            #endregion


            #region Partitioning Operators


            #region 1

            var Customer = CustomersList.Where(C => C.City == "Washington").SelectMany(C => C.Orders).Take(3);
            foreach (var x in Customer) 
                Console.WriteLine(x);

            #endregion

            #region 2

            var customer01 = CustomersList.Where(C=>C.City =="Washington").SelectMany(O=>O.Orders).Skip(2);
            foreach (var x in customer01)
                Console.WriteLine(x);
            #endregion

            #region 3

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var allNumbers = numbers.TakeWhile((p, i) => p > i);
            //foreach (var x in allNumbers)
            //    Console.WriteLine(x);

            #endregion

            #region 4
            
            int[] numbers01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberD = numbers01.SkipWhile(N => N % 3 != 0);
            //foreach (var item in numberD)
            //    Console.WriteLine(item);

            #endregion

            #region 5

            int[] numbers02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lessPostion = numbers02.SkipWhile((N, I) => N > I);
            //foreach (var item in lessPostion)
            //    Console.WriteLine(item);

            #endregion

            #endregion

            #region Quantifiers 
            
            #region 1

            var AnyEi = DictionaryEnglish.Any(D => D.Contains("ei"));
            //Console.WriteLine(AnyEi);

            #endregion

            #region 2 

            var ListP = from p in ProductsList
                        group p by p.Category
                        into PT
                        where PT.Any(P => P.UnitsInStock == 0)
                        select PT;
            //foreach(var item in ListP)
            //    foreach(var i in item)
            //    Console.WriteLine(i);


            #endregion

            #region 3 

            var ListO = from p in ProductsList
                        group p by p.Category
                        into PT
                        where PT.All(P=>P.UnitsInStock >1)
                        select PT;
            //foreach (var item in ListO)
            //    foreach (var i in item)
            //    Console.WriteLine(i);

            #endregion

            #endregion

            #region Grouping Operators 1

            #region 1 

            List<int> numbers03 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var numberDivide = numbers03.GroupBy(N => N % 5 );
            //foreach (var item in numberDivide)
            //{
            //    int counter = 0;
            //    Console.WriteLine($"Numbers with a remainder of {counter} when divided by 5 ");
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //        counter++;
            //}
            #endregion

            #region 2

            var WordGroub = DictionaryEnglish.GroupBy(P => P.ElementAt(0));
            //foreach (var item in WordGroub)
            //{
            //    foreach (var i in item)
            //    { Console.WriteLine(i); }
            //}
            #endregion

            #region 3 //
            String[] ArrS = { "from", "salt", "earn", " last", "near", "form" };

           

            #endregion

            #endregion

            // 33
        }
    }
}
