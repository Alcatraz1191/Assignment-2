using System;
using System.Linq;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int result = Array.BinarySearch(nums, target);

                int nums_length = nums.Length;

                //Console.WriteLine(nums[result]);

                //target smaller than smallest array value
                if (target <= nums[0])
                {
                    return 0;
                }

                //target in array
                else if (target > nums[0] && target < nums[nums_length - 1])
                {

                    int counter_1 = 0;
                    int counter_2 = 1;
                    int index_counter = 1;

                    for (int i = 0; i < nums_length; i++)
                    {

                        if (target > nums[counter_1] && target < nums[counter_2])
                        {
                            return index_counter;
                        }

                        else if (target == nums[result])
                        {
                            return result;
                        }
                        else
                        {
                            counter_1++;
                            counter_2++;
                            index_counter++;

                        }
                    }
                }


                else
                {
                    return nums_length;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                int max, min, c1 = 0, c2 = 0;
                //Initialize List
                List<int> res = new List<int>();
                //Find the array with largest length
                if (nums1.Length > nums2.Length)
                {
                    max = nums1.Length;
                    min = nums2.Length;
                }
                else
                {
                    max = nums2.Length;
                    min = nums1.Length;
                }
                //Sort the arrays
                Array.Sort(nums1);
                Array.Sort(nums2);
                //Check for intersection, and if equal store in list.
                for (int i = 0; c1 < min || c2 < min; i++)
                {
                    if (nums1[c1] < nums2[c2])
                    {
                        c1++;
                    }
                    else if (nums1[c1] > nums2[c2])
                    {
                        c2++;
                    }
                    else
                    {
                        res.Add(nums1[c1]);
                        c1++;
                        c2++;
                    }
                }
                return res.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {

                // Sort array in ascending order. 
                Array.Sort(A);

                // reverse array 
                Array.Reverse(A);

                int temp1 = 0;
                Dictionary<int, int> myDict = new Dictionary<int, int>();
                foreach (int num in A)
                {
                    if (myDict.ContainsKey(num))
                    {
                        myDict[num] += 1;
                    }
                    else
                    {
                        myDict.Add(num, 1);
                    }
                }

                foreach (KeyValuePair<int, int> element in myDict)
                {

                    if (element.Value == 1)
                    {
                        if (temp1 < element.Key)
                        {
                            temp1 = element.Key;
                        }

                    }


                }
                return temp1;


            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                //spilt keyboard into a dict of char, position
                Dictionary<char, int> keys_dict = new Dictionary<char, int>();

                int indexer = 0;
                foreach (char key in keyboard)
                {
                    keys_dict.Add(key, indexer++);

                }

                //word length (cba = 3)
                int word_length = word.Length;

                //the index of the word (cba[0])
                int word_index_counter = 0;

                //time_counter => THE FINAL ANSWER!!!
                int time_counter = 0;

                int key_positionCounter_present = 0;

                int key_positionCounter_past = 0;


                for (int i = 0; i < word_length; i++)
                {
                    foreach (KeyValuePair<char, int> key in keys_dict)
                    {
                        if (key.Key == word[word_index_counter])
                        {
                            //step1 = store the present value in present counter
                            key_positionCounter_present = key.Value;

                            //step2 
                            time_counter = time_counter + (Math.Abs(key_positionCounter_present - key_positionCounter_past));

                            //step3 = store the past value (first iteration = 0)
                            //         in the variable past counter
                            //         do at the end so that it changes for next
                            //         iteration                                                        
                            key_positionCounter_past = key_positionCounter_present;


                            //step4 = move over one letter of the word
                            word_index_counter++;

                            //step5 = goes back into foreach loop 
                            break;
                        }
                    }

                }

                //return the final time (time_counter)
                return time_counter;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                int[] temp = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    //Flip the matrix
                    int k = 2;
                    for (int j = 0; j < 3; j++)
                    {
                        temp[k] = A[i, j];
                        k--;
                    }
                    for (int m = 0; m < 3; m++)
                    {
                        A[i, m] = temp[m];
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    // Inverse the matrix
                    for (int j = 0; j < 3; j++)
                    {
                        if (A[i, j] == 0)
                        {
                            A[i, j] = 1;
                        }
                        else
                        {
                            A[i, j] = 0;
                        }
                    }
                }
                return A;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                int[,] new_intervals = new int[intervals.GetLength(0), 2];
                int[] temp = new int[intervals.GetLength(0)];
                int room = 1;
                //Store interval starting time in an array
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    temp[i] = intervals[i, 0];
                }
                //Sort the array
                Array.Sort(temp);
                //Use Sorted array to sort the 2d array of meeting start and end times
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    int c1 = 0, c2 = 0;
                    for (c1 = 0; c1 < intervals.GetLength(0); c1++)
                        if (temp[i] == intervals[c1, 0])
                        {
                            new_intervals[c2, 0] = intervals[c1, 0];
                            new_intervals[c2, 1] = intervals[c1, 1];
                            c2++;
                        }
                }
                //Check for room availability
                for (int i = 0; i < new_intervals.GetLength(0) - 1; i++)
                {
                    if (new_intervals[i, 1] > new_intervals[i + 1, 0])
                    {
                        room++;
                    }

                }
                return room;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                //Square the elements
                for (int i = 0; i < 5; i++)
                {
                    A[i] = A[i] * A[i];
                }
                //Sort the squared array
                Array.Sort(A);
                return A;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                string d = null;
                int i = 0;
                //Check if the string and its reverse is equal
                if (s.SequenceEqual(s.Reverse()))
                {
                    return true;
                }
                else
                {
                    //Remove each character and check if reverse is true
                    while (i < s.Length)
                    {
                        d = s.Remove(i, 1);
                        if (d.SequenceEqual(d.Reverse()))
                        {
                            return true;
                        }
                        i++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
