using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.Dependency
{
    public static class Common
    {
        public static void Show(ListNode head)
        {
            StringBuilder result = new StringBuilder();
            result.Append('[');
            while (head != null)
            {
                result.Append(head.val).Append(',');
                head = head.next;
            }
            result.Append(']');
            Console.WriteLine(result.ToString());
        }
    }
}
