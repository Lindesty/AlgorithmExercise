using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Function.Stack;

public class _20_有效的括号
{

    private Dictionary<char, char> _dictionary = new Dictionary<char, char>();

    public _20_有效的括号()
    {
        _dictionary.Add('(',')');
        _dictionary.Add('[',']');
        _dictionary.Add('{','}');
    }

    /// <summary>
    /// 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s.ToCharArray())
        {
            if (_dictionary.ContainsKey(c))
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char c2 = stack.Pop();
                if(_dictionary[c2] != c){ return false;}
            }
        }

        return stack.Count == 0;
    } 
    public static bool IsValid01(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s.ToCharArray())
        {
            if (c == '[' || c == '(' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char c2 = stack.Pop();
                if (c2 == '(' && c != ')') return false;
                if (c2 == '[' && c != ']') return false;
                if (c2 == '{' && c != '}') return false;
            }
        }

        return stack.Count == 0;
    }

    public static bool IsValid00(string s)
    {
        StringBuilder score = new StringBuilder();
        foreach (char c in s.ToCharArray())
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                    score.Append(c);
                    break;
            }
        }

        string str = score.ToString();
        while (str.Contains("()") || str.Contains("[]") || str.Contains("{}"))
        {
            str = str.Replace("()", "");
            str = str.Replace("[]", "");
            str = str.Replace("{}", "");
        }


        return (string.IsNullOrEmpty(str));
    }
}