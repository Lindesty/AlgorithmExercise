using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function.Dependency;


namespace Function.LinkedList
{
    public class _141_环形链表
    {
        public static bool HasCycle(ListNode head)
        {
            if(head == null || head.next == null) {  return false; }
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                if(fast == slow) {  return true; }
                slow = slow.next;
                fast= fast.next.next;
            }
            return false;
        }
    }
}
