using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        ///  A circus is designing a tower routine consisting of people standing atop one
        /// another's shoulders. For practical and aesthetic reasons, each person must be
        /// both shorter and lighter than the person below him or her.Given the heights
        ///     and weights of each person in the circus, write a method to compute the largest
        /// possible number of people in such a tower.
        ///     EXAMPLE:
        /// Input(ht, wt) : (65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110)
        ///     Output:The longest tower is length 6 and includes from top to bottom:
        /// (56, 90) (60,95) (65,100) (68,110) (70,150) (75,190)
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person(65, 100),
                new Person(70, 150),
                new Person(56, 90),
                new Person(75, 190),
                new Person(60, 95),
                new Person(68, 110)
            };

            Person[] res = FindLongestTower(people);
            Console.WriteLine();
            Console.Write("Press ENTER...");
            Console.Read();
        }

        private static Person[] FindLongestTower(Person[] people)
        {
            List<Person> result = new List<Person>();
            result.Add(people[0]);
            for (int i = 1; i < people.Length; i++)
            {
                Person person = people[i];
                if (person.CompareTo(result.Last()) > 0)
                {
                    result.Add(person);
                }
                else if (person.CompareTo(result.First()) < 0)
                {
                    result.Insert(0, person);
                }
                else
                    InsertPerson(result, person);
            }

            return result.ToArray();
        }

        private static void InsertPerson(List<Person> result, Person person)
        {
            int i = 0;
            while (person.CompareTo(result[i]) > 0)
            {
                i++;
            }

            if(person.CompareTo(result[i]) < 0)
                result.Insert(i, person);
        }

        private class Person : IComparable
        {
            public int Height;
            public int Weight;

            public Person(int h, int w)
            {
                this.Height = h;
                this.Weight = w;
            }

            public int CompareTo(object person)
            {
                Person p = (Person)person;
                if (this.Height > p.Height && this.Weight > p.Weight)
                {
                    return 1;
                }
                else if (this.Height < p.Height && this.Weight < p.Weight)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
