using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
namespace AlgorithmsLAB1
{
    class Program
    {
        public static void OutputResult(bool isFound)
        {
            if (isFound)
            {
                Console.WriteLine("Element was found");
            }
            else
            {
                Console.WriteLine("Element wasn\'t found");
            }
        }

        public static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }
        public static int[] ArrayCreator()
        {
            Console.Write("Enter the size of your array:");
            int range = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[range];

            Random rndNumber = new Random();
            Console.WriteLine("Your Array:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rndNumber.Next(-1000, 1000);
                Console.Write($"{array[i]}\t");
            }
            Console.WriteLine();
            return array;
        }
        public class Node
        {
            public int data;
            public Node next;

            public Node(int D)
            {
                data = D;
                next = null;
            }
            public static  Node AddFront(Node head, int data)
            {
                Node newNode = new Node(data);
                newNode.next = head;
                head = newNode;

                return head;
            }
            public static Node MiddleNode(Node start, Node last, bool isGoldenRatio)
            {
                if (start == null)
                {
                    return null;
                }
                Node slow = start;
                Node fast = start.next;
                
                while (fast != last)
                {
                    if (isGoldenRatio)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if(fast != last)
                                fast = fast.next;
                        }
                    }
                    else
                    {
                        fast = fast.next;
                    }
                    if (fast != last)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                }
                return slow;
            }
           
            public static Node BinarySearchMethod(Node head, int key, bool isGoldenRatio)
            {
                Node start = head;
                Node last = null;
                do
                {
                    Node mid =  MiddleNode(start, last, isGoldenRatio);

                    if (mid == null)
                    {
                        return null;
                    }

                    if (mid.data == key)
                    {
                        return mid;
                    }

                    else if (mid.data > key)
                    {
                        start = mid.next;
                    }

                    else
                    {
                        last = mid;
                    }

                } while (last == null || last != start);

                return null;
            }
        }

        
      
            static void Main(string[] args)
        {
            int[] array = ArrayCreator();
            while (true)
            {
                Console.Write("\nChose alghorith to find your element: \n 1.Linear Search \n 2.Search with barier \n 3.Binary search \n 4.Golden Ratio\n 5.Create new array\n\nEnter your choise:");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            LinearSearch(array);
                            break;
                        }
                    case 2:
                        {
                            BarierSearch(array);
                            break;
                        }
                    case 3:
                        {
                            BinaryMethodSearch(array);
                            break;
                        }
                    case 4:
                        {
                            GolderRatio(array);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            array = ArrayCreator();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            OutputArray(array);
                            break;
                        }

                }
            }


        }
        public static void LinearSearch(int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            int searchedElement, choise;
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Linear Search\n");
                OutputArray(array);

                Console.Write("\n\nWhat element you want to find:");

                if (Int32.TryParse(Console.ReadLine(), out searchedElement))
                {
                    Console.WriteLine($"Your element:{searchedElement}");

                }
                else
                {
                    Console.WriteLine("Sorry, but you entered wrong type of data:(");
                }

                Console.Write("1.Array\n2.Linear linked list\n3.Exit\n");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {

                    case 1:
                        {
                            ArraySearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            LinkedListSearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            run = false;

                            Console.Clear();
                            break;
                        }

                }
            }

            void ArraySearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                int i;
                bool isFound = false;
                for (i = 0; i < array.Length; i++)
                {
                    if (searchedElement == array[i])
                    {
                        isFound = true;
                        stopWatch.Stop();
                        break;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine("Element was found");
                }
                else
                {
                    Console.WriteLine("Element wasn\'t found");
                }
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"Num of Iterrations: {i + 1}\nRunTime:{ts.TotalMilliseconds}");
            }
            void LinkedListSearch(int[] array)
            {
                stopWatch.Reset();

                stopWatch.Start();
                bool isFound = false;
                LinkedList<int> myLinkedList = new LinkedList<int>(array);

                foreach (var i in myLinkedList)
                {
                    if (i == searchedElement)
                    {
                        isFound = true;
                        stopWatch.Stop();
                        break;
                    }
                }
                OutputResult(isFound);
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
            }
        }
        public static void BarierSearch(int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            int searchedElement, choise;
            bool run = true;
            int[] arrayWithBarier = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                arrayWithBarier[i] = array[i];
            }

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Barier Search\n\n");
                Console.WriteLine("Before adding barier:");
                OutputArray(array);

                Console.Write("\n\nWhat element you want to find:");

                if (Int32.TryParse(Console.ReadLine(), out searchedElement))
                {
                    Console.WriteLine($"Your element:{searchedElement}");
                }
                else
                {
                    Console.WriteLine("Sorry, but you entered wrong type of data:(");
                }

                arrayWithBarier[arrayWithBarier.Length - 1] = searchedElement;
                Console.WriteLine("After adding barier:");
                OutputArray(arrayWithBarier);
                Console.Write("\n1.Array\n2.Linear linked list\n3.Exit\n");
                choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            ArraySearch(arrayWithBarier);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            LinkedListSearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            run = false;
                            Console.Clear();
                            break;
                        }
                }
            }
            void ArraySearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                int i;
                bool isFound = false;
                for (i = 0; i < array.Length; i++)
                {
                    if (searchedElement == array[i] && i != array.Length - 1)
                    {
                        isFound = true;
                        stopWatch.Stop();
                        break;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine("Element was found");
                }
                else
                {
                    Console.WriteLine("Element wasn\'t found");
                }
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"Num of Iterrations: {i + 1}\nRunTime:{ts.TotalMilliseconds}");
            }
            void LinkedListSearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                bool isFound = false;
                int counter = 0;
                LinkedList<int> myLinkedList = new LinkedList<int>(array);
                int arrayLenght = array.Length;
                myLinkedList.AddLast(searchedElement);
                foreach (var i in myLinkedList)
                {
                    counter += 1;

                    if (i == searchedElement && counter != arrayLenght + 1)
                    {
                        isFound = true;
                        stopWatch.Stop();
                        break;
                    }

                }
                if (isFound)
                {
                    Console.WriteLine("Element was found");
                }
                else
                {
                    Console.WriteLine("Element wasn\'t found");
                }
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
            }
        }
        
        public static void BinaryMethodSearch(int[] array)
        {
            Array.Sort(array);
            Stopwatch stopWatch = new Stopwatch();
            int searchedElement, choise;
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Binary Search\n\n");
                Console.WriteLine("Sorted Array:");
                OutputArray(array);

                Console.Write("\n\nWhat element you want to find:");

                if (Int32.TryParse(Console.ReadLine(), out searchedElement))
                {
                    Console.WriteLine($"Your element:{searchedElement}");
                }
                else
                {
                    Console.WriteLine("Sorry, but you entered wrong type of data:(");
                    run = false;
                }

                Console.Write("\n1.Array\n2.Linear linked list\n3.Exit\n");
                choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            ArraySearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            LinkedListSearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            run = false;
                            Console.Clear();
                            break;
                        }
                }
            }
            
            void BinaryRecursiveSearch(int[]array, int key)
            {
                stopWatch.Reset();
                stopWatch.Start();
                int arrayLength = array.Length;
                int min = 0, max = arrayLength-1;
                while (min <= max)
                {
                    // int arrayMid = arrayLength % 2 == 0 ? arrayLength / 2 : arrayLength + 1 / 2;
                    int arrayMid = (min + max) / 2;
                    
                    if (key == array[arrayMid] )
                    {
                        stopWatch.Stop();
                        OutputResult(true);
                        TimeSpan ts = stopWatch.Elapsed;
                        Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
                        break;
                    }
                    else if (key < array[arrayMid])
                    {
                        max = arrayMid - 1;


                    }
                    else 
                    {
                        min = arrayMid + 1;
                    }

                }
                stopWatch.Stop();
                TimeSpan tms = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{tms.TotalMilliseconds}");
                OutputResult(false);

            }
            void LinkedListSearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                Node head = null;
                bool isGoldenRatio = false;
                for (int i = 0; i<array.Length; i++)
                {
                    head = Node.AddFront(head, array[i]);
                }
                if(Node.BinarySearchMethod(head, searchedElement, isGoldenRatio) == null)
                {
                    OutputResult(false);
                }else
                {
                    stopWatch.Stop();
                    OutputResult(true);
                }
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
            }
            void ArraySearch(int[] array)
            {
                
                stopWatch.Reset();
                stopWatch.Start();
               
                BinaryRecursiveSearch(array, searchedElement);

                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
            }
        }
        public static void GolderRatio (int[] array)
        {
            Array.Sort(array);
            Stopwatch stopWatch = new Stopwatch();
            int searchedElement, choise;
            bool run = true;
            bool isGoldenRatio = true;
            Array.Sort(array);
            while (run)
            {

                Console.Clear();

                Console.WriteLine("Binary Search with Golden Ratio\n\n");
                Console.WriteLine("Sorted Array:");
                OutputArray(array);
                Console.Write("\n\nWhat element you want to find:");

                if (Int32.TryParse(Console.ReadLine(), out searchedElement))
                {
                    Console.WriteLine($"Your element:{searchedElement}");
                }
                else
                {
                    Console.WriteLine("Sorry, but you entered wrong type of data:(");
                    run = false;
                }

                Console.Write("\n1.Array\n2.Linear linked list\n3.Exit\n");
                choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            ArraySearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            LinkedListSearch(array);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            run = false;
                            Console.Clear();
                            break;
                        }
                }
            }
            void ArraySearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                int left = 0;
                int right = array.Length - 1;
                bool isFound = false;
                while ((left <= right) && (isFound == false))
                {
                    int ratio = (int)(left + 0.618 * (right - left   ));
                    if (array[ratio] == searchedElement)
                    {
                        stopWatch.Stop();
                        isFound = true;
                        break;
                    }
                    else if (array[ratio] < searchedElement)
                    {
                        left = ratio + 1;
                    }
                    else if (ratio == array.Length  )
                    {
                        stopWatch.Stop();
                        isFound = false;
                    }
                    else
                    {
                        right = ratio - 1;
                    }
                }
                OutputResult(isFound);
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
                Console.ReadKey();
            }
            void LinkedListSearch(int[] array)
            {
                stopWatch.Reset();
                stopWatch.Start();
                Node head = null;
                for (int i = 0; i < array.Length; i++)
                {
                    head = Node.AddFront(head, array[i]);
                }
                if (Node.BinarySearchMethod(head, searchedElement, isGoldenRatio) == null)
                {
                    OutputResult(false);
                }
                else
                {
                    stopWatch.Stop();
                    OutputResult(true);
                }
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine($"\nRunTime(in Milliseconds):{ts.TotalMilliseconds}");
            }
        }
    }
}
