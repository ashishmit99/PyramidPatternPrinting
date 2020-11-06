using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
    class Program
    {

        public static void Main(string[] args)
        {
            //Read test cases count from input
            //The first line of input contains an integer t which is the number of test cases.
            int testCaseCount = int.Parse(Console.ReadLine());
            //This will store test cases details
            IList<string> testCases = new List<string>(testCaseCount);
            //Each test case contains three space separated tokens viz. the string s,
            //height of the pyramid h. The next token is either 1 for upright pyramid and - 1 for inverted pyramid.

            string input;
            for (int i = 1; i <= testCaseCount; i++)
            {
                input = Console.ReadLine();
                testCases.Add(input);
            }
            string[] tokens;
            string pyramidContent;
            int height;
            foreach (string testCase in testCases)
            {
                //split test cases details
                tokens = testCase.Split(null);
                //extract height of pyramid
                height = int.Parse(tokens[1]);
                pyramidContent = getPyramidContent(tokens[0], height);
                //whether upright pyramid or down depending upon tokens[2]
                if ("1".Equals(tokens[2]))
                {
                    printUpPyramid(pyramidContent, height);
                }
                else
                {
                    printDownPyramid(pyramidContent, height);
                }
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static string getPyramidContent(string seq, int height)
        {
            StringBuilder content = new StringBuilder("");
            int contentLength = height * height;
            int seqRepetitionCount = contentLength / seq.Length + 1;
            for (int i = 1; i <= seqRepetitionCount; i++)
            {
                content.Append(seq);
            }
            return content.ToString().Substring(0, contentLength);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="height"></param>
        private static void printUpPyramid(string content, int height)
        {
            StringBuilder whiteSpace = new StringBuilder("");
            for (int i = 1; i <= height - 1; i++)
            {
                whiteSpace.Append(" ");
            }
            int printFrom = 0;
            string pattern;
            for (int line = 1; line <= height; line++)
            {
                Console.Write(whiteSpace.ToString().Substring(0, height - line));
                if (line % 2 == 1)
                {
                    pattern = content.Substring(printFrom, (line * 2) - 1);
                }
                else
                {

                    pattern = ReverseStringWithInbuiltMethod(content.Substring(printFrom, (line * 2) - 1));
                }
                Console.Write(pattern);
                Console.WriteLine();
                printFrom += ((line * 2) - 1);
            }

          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="height"></param>
        private static void printDownPyramid(string content, int height)
        {
            StringBuilder whiteSpace = new StringBuilder("");
            for (int i = 1; i <= height - 1; i++)
            {
                whiteSpace.Append(" ");
            }
            int printFrom = 0;
            string pattern;
            for (int line = height, i = 1; line >= 1; line--, i++)
            {
                Console.Write(whiteSpace.ToString().Substring(0, height - line));
                if (i % 2 == 1)
                {
                    pattern = content.Substring(printFrom, (line * 2) - 1);
                }
                else
                {
                    pattern = ReverseStringWithInbuiltMethod(content.Substring(printFrom, (line * 2) - 1));
                }
                Console.Write(pattern);
                Console.WriteLine();
                printFrom += ((line * 2) - 1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        private static string ReverseStringWithInbuiltMethod(string stringInput)
        {
            // With Inbuilt Method Array.Reverse Method  
            char[] charArray = stringInput.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
