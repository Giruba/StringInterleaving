using System;

namespace StringInterleaving
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is a string interleaved of two strings!");
            Console.WriteLine("---------------------------------------");

            bool isInterleaving = GetDPInterleaving();
            if (isInterleaving)
            {
                Console.WriteLine("The third string is interleaving of the " +
                    "first and second");
            }
            else {
                Console.WriteLine("No interleaving!");
            }

            Console.ReadLine();
        }

        private static bool GetDPInterleaving() {
            bool result = false;

            Console.WriteLine("Enter the first string");
            String result1 = Console.ReadLine();
            Console.WriteLine("Enter the second string");
            String result2 = Console.ReadLine();
            Console.WriteLine("Enter the third string");
            String result3 = Console.ReadLine();

            result = _GetDPInterleaving(result1, result2, result3);

            return result;
        }

        private static bool _GetDPInterleaving(String result1, String result2, 
                                                String result3) {

            bool[,] resultantMatrix = new bool[(result1.Length+1),
                                               (result2.Length+1)];

            if (result3.Length != (result1.Length + result2.Length)) {
                return false;
            }

            for (int i = 0; i <= result1.Length; i++) {
                for (int j = 0; j <= result2.Length; j++) {

                    if (i == 0 && j == 0) {
                        resultantMatrix[i, j] = true;
                    }

                    else if (i == 0 && result2[j - 1] == result3[j - 1]) {
                        resultantMatrix[i, j] = resultantMatrix[i, j - 1];
                    }

                    else if (j == 0 && result1[i - 1] == result3[i - 1]) {
                        resultantMatrix[i, j] = resultantMatrix[i-1, j];
                    }

                    else if (i> 0 && result1[i - 1] == result3[i + j - 1] &&
                            result2[j - 1] == result3[i + j - 1]) {
                        resultantMatrix[i, j] = ( resultantMatrix[i-1, j]
                            || resultantMatrix[i, j-1]);
                    }

                    else if (i>0 && j>0 && result1[i - 1] != result3[i + j - 1] &&
                        result2[j - 1] == result3[i + j - 1]) {
                        resultantMatrix[i, j] = resultantMatrix[i, j-1];
                    }

                    else if (i>0 && j>0 && result1[i - 1] == result3[i + j - 1] &&
                        result2[j - 1] != result3[i + j - 1]) {
                        resultantMatrix[i, j] = resultantMatrix[i-1, j];
                    }
                }
            }
            return resultantMatrix[resultantMatrix.GetLength(0)-1,
                    resultantMatrix.GetLength(1)-1];

        }
    }
}
