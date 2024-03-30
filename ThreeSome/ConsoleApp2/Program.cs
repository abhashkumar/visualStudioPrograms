using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine(new Program().ThreeSum(nums).Count);
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            
            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();


            
            IList<IList<int>> l = new List<IList<int>>();
            int rand = new Random().Next(0, l.Count);
            List<int> p = new List<int>();
            
            
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            if(!(hs1.Contains(nums[i]) && hs2.Contains(nums[j])))
                            {
                                Console.WriteLine($"{nums[i]}, {nums[j]}, {nums[k]}");
                                List<int> temp = new List<int>();
                                temp.Add(nums[i]);
                                temp.Add(nums[j]);
                                temp.Add(nums[k]);
                                l.Add(temp);
                                hs1.Add(nums[i]);
                                hs2.Add(nums[j]);
                            }
                        }
                    }
                }
            }
            return l;
        }
    }
}
