using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int countRack = 1;
            int clothesSum = 0;


            while (stack.Any())
            {
                var currElement = stack.Pop(); 
                if (clothesSum + currElement <= capacityOfRack)    
                {
                    clothesSum += currElement;                
                }
                else
                {
                    clothesSum = currElement;      
                    countRack++;
                }
            }

            Console.WriteLine(countRack);
        }
    }
}