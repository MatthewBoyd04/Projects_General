using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _3N_1_32Bit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu: Please Select");
            Console.WriteLine("Mode 1: Loop and update List");
            Console.WriteLine("Mode 2: Run Singular Number and show trail");
            Console.WriteLine("Mode 3: Run Next Valid Number ONLY and show trail");
            int UserChoice = Convert.ToInt32(Console.ReadLine());
            switch (UserChoice)
            {
                case 1:
                    {
                        Mode1();
                        break;
                    }
                case 2:
                    {
                        Mode2();
                        break;
                    }
                case 3:
                    {
                        Mode3();
                        break;
                    }
            }
        }

        static void Mode1()
        {
            for (int i = 0; i < 1000; i++)
            {
                i--;
                Console.Clear();
                int nextValidNumber = FindNextValidNumber();
                Console.WriteLine("Next Valid Number: " + nextValidNumber);
                Check_Next_Number(nextValidNumber, true);
            }
            Console.ReadLine();



        }
        static void Mode2()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number:");
            int Num = Convert.ToInt32(Console.ReadLine());
            List<int> PreviousNumbers = new List<int>();
            while (Num != 1)
            {
                PreviousNumbers.Add(Num);
                Num = Calculate(Num);
                Console.Clear();
                Console.WriteLine("Original Number: " + PreviousNumbers[0]);
                Console.WriteLine("Currently On: " + Num);
                int j = 0;
                foreach (int i in PreviousNumbers)
                {
                    Console.Write(PreviousNumbers[j] + " > ");
                    j++;
                }

            }
            Console.ReadLine();
        }
        static void Mode3()
        {
            Console.Clear();
            int Num = FindNextValidNumber();
            List<int> PreviousNumbers = new List<int>();
            while (Num != 1)
            {
                PreviousNumbers.Add(Num);
                Num = Calculate(Num);
                Console.Clear();
                Console.WriteLine("Original Number: " + PreviousNumbers[0]);
                Console.WriteLine("Currently On: " + Num);
                int j = 0;
                foreach (int i in PreviousNumbers)
                {
                    Console.Write(PreviousNumbers[j] + " > ");
                    j++;
                }

            }
            Console.ReadLine();
        }

        private static int FindNextValidNumber()
        {
            int[] InvalidNumbers = ReadNumbersFromFile("C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt");
            Array.Sort(InvalidNumbers);
            int VNum = 1;
            int j = 0;
            foreach (int i in InvalidNumbers)
            {

                //Console.WriteLine("Checking VNum = " + VNum + " Against i = " + i);
                if (VNum == InvalidNumbers[j])
                {
                    VNum++;
                    //    Console.WriteLine("VNum Increased"); 
                }
                else
                {
                    //    Console.WriteLine("All Lower Numbers Checked"); 

                }
                j++;

            }
            return VNum;
        }

        public static int[] ReadNumbersFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] numberStrings = content.Split(',');
                int[] numbers = new int[numberStrings.Length];

                for (int i = 0; i < numberStrings.Length; i++)
                {
                    if (int.TryParse(numberStrings[i], out int number))
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing number: {numberStrings[i]}");
                        // You can choose to handle the error differently, like skipping the invalid number.
                    }
                }

                return numbers;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please make sure the specified file exists.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return new int[0]; // Return an empty array if an error occurs.
        }

        static int Check_Next_Number(int Num, bool x)
        {
            string filePath = "C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Checked_Numbers.txt";
            int[] InvalidNumbers = ReadNumbersFromFile(filePath);
            List<int> NumberTrail = new List<int>();
            int OriginalNumber = Num;
            Console.WriteLine("x = " + x);
            while (x)
            {
                NumberTrail.Add(Num);
                Num = Calculate(Num);
                int j = 0;
                Console.Clear();
                Console.WriteLine("Currently Checking: " + OriginalNumber);
                foreach (int i in InvalidNumbers)
                {
                    if (Num == InvalidNumbers[j])
                    {
                        Console.WriteLine(OriginalNumber + " Will go to 1, found at:" + InvalidNumbers[j]);
                        x = false;
                    }
                    if (Num < 0)
                    {
                        Console.ReadLine();
                    }
                    j++;
                }

                Console.WriteLine("Number Trail:");
                foreach (int number in NumberTrail)
                {
                    Console.Write(number + " ");

                }
                Console.WriteLine();
            }
            // Combine the NumberTrail list with the InvalidNumbers list
            List<int> combinedList = NumberTrail.Concat(InvalidNumbers).ToList();

            // Remove duplicates from the combinedList
            combinedList = new HashSet<int>(combinedList).ToList();

            // Sort the combined list
            combinedList.Sort();

            // Write the sorted list back to the file in the desired format
            File.WriteAllText(filePath, string.Join(",", combinedList));

            File.WriteAllText("C:\\Users\\chunk\\Desktop\\3N + 1 Challenge\\Numbers_Checked.txt", combinedList.Count.ToString());

            //Longest Number Trail so far: 

            return 0;
        }
        static int Calculate(int Num)
        {
            int NewNum = 0;
            if (Num % 2 == 0)
            {
                NewNum = Num / 2;
                Console.WriteLine("Num = " + Num + " (Even), therefore /2    = " + NewNum);

            }
            else
            {
                NewNum = (Num * 3) + 1;
                Console.WriteLine("Num = " + Num + " (Odd), therefore *3 + 1 = " + NewNum);
            }

            return NewNum;
        }
    }
}