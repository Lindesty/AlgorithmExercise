using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function.Dependency;

namespace Function.LinkedList
{
    public class _203_移除链表元素
    {
        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null){return head;}
            if (head.val == val && head.next == null)
            {
                return null;
            }
            ListNode result = new ListNode(0);
            ListNode node = result;
            while (head != null)
            {
                if (head.val != val)
                {
                    node.next = new ListNode(head.val);
                    node = node.next;
                }
                head = head.next;
            }




            return result.next;
        }
    }
}
