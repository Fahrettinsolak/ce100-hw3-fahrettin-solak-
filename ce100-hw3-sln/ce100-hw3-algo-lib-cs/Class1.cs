using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* @file ce100_hw3_algo_lib_cs *
* @author Fahrettin SOLAK *
* @date 10 April 2022 * 
*
* @brief <b> hw-3 Functions </b> *
*
* HW-3 Sample Lib Functions *
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
*/


namespace ce100_hw3_algo_lib_cs
{
    public class Class1
    {
        public static string LongestCommonSubsquence(string R, string S, int a, int e)
        {
            int[,] L = new int[a + 1, e + 1];
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= e; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;
                    }
                    else if (R[i - 1] == S[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                    }
                }
            }
            int index = L[a, e];
            string lcs = string.Empty;
            int k = a, l = e;
            while (k > 0 && l > 0)
            {
                if (R[k - 1] == S[l - 1])
                {
                    lcs = R[k - 1] + lcs;
                    k--;
                    l--;
                    index--;
                }
                else if (L[k - 1, l] > L[k, l - 1])
                { k--; }
                else
                { l--; }
            }
            return lcs;
        }
        public static int MatrixChainOrder(int[] p, int i, int j)
        {

            if (i == j)
                return 0;

            int min = int.MaxValue;

            for (int k = i; k < j; k++)
            {
                int count = MatrixChainOrder(p, i, k)
                            + MatrixChainOrder(p, k + 1, j)
                            + p[i - 1] * p[k] * p[j];

                if (count < min)
                    min = count;
            }

            return min;
        }
    }
}









