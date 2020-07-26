using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_GroupAnagrams
    {
    //Medium
    //49
    //Given an array of strings, group anagrams together.

    //Example:
    //Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
    //Output:
    //[
    //  ["ate","eat","tea"],
    //  ["nat","tan"],
    //  ["bat"]
    //]
    //Note:
    //All inputs will be in lowercase.
    //The order of your output does not matter.

    public List<List<String>> groupAnagrams(String[] strs) 
        {            
            var dict = new Dictionary<String, List<String>>();
            
            foreach (var s in strs)
            {
                char[] ca = s.ToCharArray();
                //sort method- Time- O(NKlogK)... logK added because of sort.. K is length of each string
                //Array.Sort(ca);
                //String sa=new String(ca);

                //method 2
                //Time- O(NK)
                var count = new int[26]; 
                foreach (char c in ca) count[c - 'a']++;
                var sb = new StringBuilder("");
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                String sa = sb.ToString();

                if (!dict.ContainsKey(sa)) dict.Add(sa, new List<String>());
                dict[sa].Add(s);
            }

            return dict.Values.ToList();

            //return new List<IList<String>>(dict.Values); 
            // in case you get Compiler Error CS0266 .. An explicit conversion exists (are you missing a cast?)
        }
    
    //Time- O(NKlogK)-- sort method... K length of string
    //Time- O(NK)
    //Space-O(NK)
    
    }
}