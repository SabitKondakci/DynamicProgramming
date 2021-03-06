using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingAlgorithms
{
    class LongestCommonSubsequence
    {
        //the method has O(m.n) time complexity
        public string LongestSubsequence(string pattern, string strSample,bool caseInsensitive=false)
        {
            if (caseInsensitive)
            {
                pattern = pattern.ToLower();
                strSample = strSample.ToLower();
            }

            StringBuilder longestPattern=new StringBuilder();
            List<char> charPattern = pattern.ToList();
            List<char> strPattern = strSample.ToList();

            charPattern.Insert(0,' ');//for mapTable compability
            strPattern.Insert(0,' ');//for mapTable compability

            int[,] mapTable=new int[charPattern.Count,strPattern.Count];

            for (int i = 1; i < charPattern.Count; i++)
            {
                for (int j = 1; j < strPattern.Count; j++)
                {
                    //if element at charPattern matches, add 1 to mapTable[i-1,j-1]
                    if (charPattern[i] == strPattern[j])
                        mapTable[i, j] = 1 + mapTable[i - 1, j - 1];
                    else
                        mapTable[i, j] = Math.Max(mapTable[i - 1, j], mapTable[i, j - 1]);
                    //check out previous and upper section, take the big value
                }
            }

            int k = charPattern.Count - 1, l = strPattern.Count - 1;
            //k :row counter , l:column counter
            while (k>0 && l>0)
            {
                //traverse the mapTable , form end to first
                //if previous column is similar to current then decrease column counter "l"
                if (mapTable[k, l] == mapTable[k, l - 1])
                    l--;
                else
                {
                    //mapTable is traversed from end to first so that insertion method is used
                    longestPattern.Insert(0,strPattern[l--]);
                    k--;
                }
                    
            }

            return longestPattern.ToString();
        }
    }
}
