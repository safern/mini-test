using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnescapeString
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
        	for(int i = 0; i<1000; i++)
        	{
	            string str2 = Uri.UnescapeDataString(GenRandomEscapedString());
            	Console.WriteLine("Time: {0}", watch.ElapsedMilliseconds);
        	}
	        watch.Stop();
            Console.WriteLine("Time: {0}", watch.ElapsedMilliseconds * 0.001);
        }

        public static string GenRandomEscapedString()
        {
        	StringBuilder sb = new StringBuilder();
        	Random r = new Random();
        	for (int i = 0; i < 1000; i++){
        		sb.Append("aa");
        		int val = r.Next(0, 3);
        		switch (val)
        		{
        			case 0:
        				sb.Append("%2F%2F");
        				break;
        			case 1:
        				sb.Append("%3A");
        				break;
        			case 2:
        				sb.Append("%21");
        				break;
        			default:
        				break;
        		}
        	}
        	return sb.ToString();
        }

        public static unsafe string CopyStringUnsafe(string str)
        {
            char[] charArray = new char[str.Length];
            int index = 0;
            fixed (char* ptr = str)
            {
                while (index < str.Length)
                    charArray[index] = ptr[index++];
            }
            return new string(charArray, 0, str.Length);
        }
    }
}
