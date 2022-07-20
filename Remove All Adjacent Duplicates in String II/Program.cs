using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_All_Adjacent_Duplicates_in_String_II
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "deeedbbcccbdaa";
      int k = 3;
      Solution sol = new Solution();
      var answer = sol.RemoveDuplicates(s, k);
      Console.WriteLine(answer);
    }
  }


  public class Solution
  {
    public string RemoveDuplicates(string s, int k)
    {
      Stack<Node> stk = new Stack<Node>();
      // push the first char
      stk.Push(new Node(s[0], 1));
      for (int i = 1; i < s.Length; i++)
      {
        // any any time stack is emplty, insert the current char and skip rest of the code
        if (stk.Count == 0)
        {
          stk.Push(new Node(s[i], 1));
          continue;
        }

        // get the previous
        var prev = stk.Peek();
        var currentChar = s[i];
        // of current and prev are same
        if (prev.c == currentChar)
        {
          // increase the count
          stk.Peek().count++;
          // after increasing the countif it matches with k ? Pop the last element
          if (stk.Peek().count == k) stk.Pop();
        }
        else
        {
          // if its a new element insert it
          stk.Push(new Node(currentChar, 1));
        }
      }

      StringBuilder sb = new StringBuilder();
      while (stk.Count > 0)
      {
        var node = stk.Pop();
        int size = node.count;
        while (size-- > 0)
        {
          sb.Insert(0, node.c);
        }
      }

      return sb.ToString();
    }

    public class Node
    {
      public char c;
      public int count;
      public Node(char c, int count)
      {
        this.c = c;
        this.count = count;
      }
    }
  }
}
