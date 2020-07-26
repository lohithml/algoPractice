using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_websitePattern_1152M
    {
        //Medium
        //1152
        //We are given some website visits: the user with name username[i] visited the website website[i] at time timestamp[i].
        //A 3-sequence is a list of websites of length 3 sorted in ascending order by the time of their visits.  (The websites in a 3-sequence are not necessarily distinct.)
        //Find the 3-sequence visited by the largest number of users.If there is more than one solution, return the lexicographically smallest such 3-sequence.

        //Example 1:
        //Input: username = ["joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary"], timestamp = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], website = ["home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career"]
        //Output: ["home","about","career"]
        //Explanation: 
        //The tuples in this example are:
        //["joe", 1, "home"]
        //["joe", 2, "about"]
        //["joe", 3, "career"]
        //["james", 4, "home"]
        //["james", 5, "cart"]
        //["james", 6, "maps"]
        //["james", 7, "home"]
        //["mary", 8, "home"]
        //["mary", 9, "about"]
        //["mary", 10, "career"]
        //The 3-sequence ("home", "about", "career") was visited at least once by 2 users.
        //The 3-sequence("home", "cart", "maps") was visited at least once by 1 user.
        //The 3-sequence("home", "cart", "home") was visited at least once by 1 user.
        //The 3-sequence("home", "maps", "home") was visited at least once by 1 user.
        //The 3-sequence("cart", "maps", "home") was visited at least once by 1 user.

        //Note:
        //3 <= N = username.length = timestamp.length = website.length <= 50
        //1 <= username[i].length <= 10
        //0 <= timestamp[i] <= 10^9
        //1 <= website[i].length <= 10
        //Both username[i] and website[i] contain only lowercase characters.
        //It is guaranteed that there is at least one user who visited at least 3 websites.
        //No user visits two websites at the same time.

        public class Visit
        {
            public string username;
            public string website;
            public int timestamp;
            public Visit(string username, string website, int timestamp)
            {
                this.username = username;
                this.website = website;
                this.timestamp = timestamp;
            }
        }
        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {

            Visit[] log = new Visit[username.Length];
            var count = new Dictionary<string, int>();
            for (int i = 0; i < username.Length; i++)
            {
                //3 seq with user-time-website
                log[i] = new Visit(username[i], website[i], timestamp[i]);

                //count of users
                if (!count.ContainsKey(username[i]))
                    count.Add(username[i], 1);
                else
                    count[username[i]]++;
            }

            //sort visits
            Array.Sort(log, (a, b) => a.username == b.username ? a.timestamp.CompareTo(b.timestamp) : a.username.CompareTo(b.username));

            //user based search
            var start = 0;
            var dict = new Dictionary<string, int>();
            int max = int.MinValue;
            string res = "";
            while (start < log.Length)
            {
                string user = log[start].username;
                int size = count[user];
                //crete 3 seq for each user
                var hs = new HashSet<string>();
                for (int i = start; i < start + size - 2; i++)
                {
                    for (int j = i + 1; j < start + size - 1; j++)
                    {
                        for (int k = j + 1; k < start + size; k++)
                        {
                            string cur = log[i].website + "$" + log[j].website + "$" + log[k].website;
                            hs.Add(cur);
                        }
                    }
                }

                //get top elements
                foreach (string s in hs)
                {
                    int temp = dict.ContainsKey(s) ? dict[s] + 1 : 1;

                    if (temp > max || (temp == max && s.CompareTo(res) < 0))
                    {
                        max = temp;
                        res = s;
                    }
                    dict[s] = temp;
                }

                start += size;
            }
            return res.Split('$').ToList();
        }


    }
}