using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Tema_01
{
    public class Set<T>
    {
        public List<T> list;


        //am adaugat exceptii pentru ca dadea ceva eroare cu null (dar tot a persistat)
        public void Insert(T input)
        {
            try 
            { 
                list.Add(input); 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Logging - {ex.Message}");
            }

        }
        public void Remove(T input)
        {
            try
            {
                list.Remove(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging - {ex.Message}");
            }
        }
        public bool Contains(T input)
        {  
            return list.Contains(input);
        }
        public List<T> Merge(T initial,T other)
        {
            List<T> combined = null;
            combined.AddRange((IEnumerable<T>)initial);
            combined.AddRange((IEnumerable<T>)other);
            return combined;
        }

        //incercarea de a crea distinct sa primeasca T ??
/*        public List<T> Distinct(List<T> input)
        {
            var uniqueItems = input.Distinct();
            return uniqueItems;
        }
*/
        public void Print()
        {
            Console.WriteLine(list.ToString);
        }

    }

    [Serializable]
    public class ListHasDoublesException : Exception
    {
        public ListHasDoublesException( ) { }

        public ListHasDoublesException(string message)
            : base(message) { }

    }

    class Program
    {

        public static bool NoDoubles(Set<int> list)
        {
            //neavand metoda distinct decat pentru List, face una separata pentru Set<T>
            if (list.Count != list.Distinct().Count())
            {
                throw new ListHasDoublesException("Lista contine dubluri");
            }
            return true;
        }
        static async Task Main(string[] args)
        {
            Set<int> listInt = new Set<int>();
            listInt.Insert(1);
            listInt.Insert(2);
            listInt.Insert(3);
            listInt.Insert(4);
            listInt.Insert(5);
            listInt.Remove(5);

            listInt.Print();

            Set<string> listString = new Set<string>();
            listString.Insert("a");
            listString.Insert("b");
            listString.Insert("c");
            listString.Insert("d");
            listString.Insert("e");
            listString.Remove("e");

            listString.Print();

            //aparent listInt este tot vazuta ca o lista generica chiar daca contine doar inturi
            //asa ca nu poate fi aplelata functia NoDoubles(List<int>) ...
            try
            {
                if(NoDoubles(listInt) == true)
                    Console.WriteLine("Lista nu contine dubluri");
            }
            catch (ListHasDoublesException)
            {
                Console.WriteLine("Lista contine dubluri.");
            }

            //functie lambda
            var listNum = new List<int> { 1, 3, 5 , 11, 16, 6, 100, 23};
            var numberOver10 = listNum.Where(n => n > 10);
            Console.WriteLine(numberOver10);

        }
    }
}

