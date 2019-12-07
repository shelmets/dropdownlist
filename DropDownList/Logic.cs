using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DropDownList
{
    public interface ILogic
    {
        IEnumerable<string> GetOptions(IStream str, string target, uint limit);
        IEnumerable<Tuple<string,string>> GetInformation(IStream str, string nameUniversity);
        string CreateSynonum(IStream str, string nameUniversity, string Synonum);
    }
    public class Logic : ILogic
    {
        private void swap<T>(ref T x, ref T y)
        {
            T z = x;
            x = y;
            y = z;
        }
        //distance for different length a and b 
        /*private int DamerauLevenshteinDistance(string a, string b) 
        {
            int n = a.Length, m = b.Length;
            if (n > m)
            {
                swap<string>(ref a, ref b);
                swap<int>(ref n, ref m);
            }
            int[] CurrentRow = new int[n + 1];
            int[] PreviousRow = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
                CurrentRow[i] = i;
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                    PreviousRow[j] = CurrentRow[j];
                for (int j = 1; j < n + 1; j++)
                    CurrentRow[j] = 0;
                CurrentRow[0] = i;
                for (int j = 1; j < n + 1; j++)
                {
                    int add = PreviousRow[j] + 1, delete = CurrentRow[j-1]+1, change = PreviousRow[j-1];
                    if (a[j-1] != b[i-1])
                        change++;
                    int[] ins = { add, delete, change };
                    CurrentRow[j] = ins.Min();
                }
            }
            return CurrentRow[n];
        }*/
        private int DamerauLevenshteinDistance(string a, string b)
        {
            int n = a.Length;
            int[] CurrentRow = new int[n + 1];
            int[] PreviousRow = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
                CurrentRow[i] = i;
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                    PreviousRow[j] = CurrentRow[j];
                for (int j = 1; j < n + 1; j++)
                    CurrentRow[j] = 0;
                CurrentRow[0] = i;
                for (int j = 1; j < n + 1; j++)
                {
                    int add = PreviousRow[j] + 1, delete = CurrentRow[j - 1] + 1, change = PreviousRow[j - 1];
                    if (a[j - 1] != b[i - 1])
                        change++;
                    int[] ins = {add, delete, change};
                    CurrentRow[j] = ins.Min();
                }
            }
            return CurrentRow[n];
        }
        public IEnumerable<string> GetOptions(IStream str, string target, uint limit)
        {
            target = target.Trim();
            List<Tuple<string, int>> top = new List<Tuple<string, int>>();
            int target_length = target.Length;
            bool mark_zero = false;
            if (target_length != 0)
            {
                foreach (var i in str.IterRowsUnivers())
                {
                    if (i.Item1.Length >= target_length)
                    {
                        int distance = DamerauLevenshteinDistance(target.ToLower(), i.Item1.Substring(0, target_length).ToLower());
                        if (distance == 0)
                        {
                            top.RemoveAll(x => x.Item2 > 0);
                            if (i.Item2 == 0)
                                top.Add(new Tuple<string, int>(i.Item1, distance));
                            else
                                top.Add(new Tuple<string, int>(str.GetNameUniver(i.Item2), distance));
                            mark_zero = true;
                        }
                        else if ((distance <= target_length/3) && !mark_zero)
                            if (i.Item2 == 0)
                                top.Add(new Tuple<string, int>(i.Item1, distance));
                            else
                                top.Add(new Tuple<string, int>(str.GetNameUniver(i.Item2), distance));
                    }
                }
            }
            return top.OrderBy(x => x.Item2).Select(x => x.Item1).Take((int)limit);
        }
        public string CreateSynonum(IStream str, string nameUniversity, string Synonum)
        {
            return str.CreateSynonum(nameUniversity, Synonum);
        }
        public IEnumerable<Tuple<string,string>> GetInformation(IStream str, string nameUniversity)
        {
            List<Tuple<string,string>> b = new List<Tuple<string, string>>();
            foreach (var i in str.IterRowsInfor(nameUniversity))
            {
                b.Add(i);
            }
            return b;
        }
    }
}
