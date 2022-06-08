using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function.Dependency;

namespace Function.LinkedList
{
    public class _876_链表的中间结点
    {
        public static ListNode MiddleNode(ListNode head)
        {
            if ( head == null || head.next == null ) return head;
            int count = 1;
            ListNode result = head;
            while (result.next != null)
            {
                count++;
                result = result.next;
            }
            int pointer = 0;
            count = count / 2;
            result = head;
            while (pointer != count)
            {

                result = result.next;
                pointer++;
            }


            return result;
        }
        public static ListNode MiddleNode2(ListNode head)
        {
            ListNode slow = head
                ,quick = head;
            while (quick != null && quick.next != null)
            {
                slow = slow.next;
                quick = quick.next.next;
            }
            return slow;
        }
    }
}
