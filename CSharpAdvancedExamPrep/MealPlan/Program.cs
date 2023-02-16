using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                { "salad" , 350},
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790},
            };

            int mealsSum = meals.Select(m => table[m]).Sum();
            int caloriesSum = calories.Sum();
            int initialMealsCount = meals.Count();

            string currMeal = string.Empty;
            int mealValue = 0;


            if (mealsSum > caloriesSum)
            {
                List<string> mealsLeft = new List<string>();

                for (int i = 0; i < meals.Count; i++)
                {
                    currMeal = meals.Dequeue();
                    mealValue = table[currMeal];
                    i--;
                    caloriesSum -= mealValue;

                    if (caloriesSum < 0)
                    {
                        for (int j = i + 1; j < meals.Count; j++)
                        {
                            currMeal = meals.Dequeue();
                            j--;
                            mealsLeft.Add(currMeal);
                            
                        }
                    }
                }

                Console.WriteLine($"John ate enough, he had {initialMealsCount - mealsLeft.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsLeft)}.");

            }
            else
            {
                int currDayCal = calories.Pop();

                for (int i = 0; i < meals.Count; i++)
                {
                    currMeal = meals.Dequeue();
                    mealValue = table[currMeal];
                    currDayCal -= mealValue;
                    i--;

                    if (currDayCal < 0)
                    {
                        currDayCal += calories.Pop();
                        
                    }
                }

                if (calories.Any())
                {
                    if (currDayCal > 0)
                    {
                        calories.Push(currDayCal);
                    }
                    Console.WriteLine($"John had {initialMealsCount} meals.");
                    Console.Write($"For the next few days, he can eat {string.Join(", ", calories)} calories.");

                }
                else
                {
                    Console.WriteLine($"John had {initialMealsCount} meals.");
                    Console.Write($"For the next few days, he can eat {currDayCal} calories.");
                }
            }
        }
    }
}
