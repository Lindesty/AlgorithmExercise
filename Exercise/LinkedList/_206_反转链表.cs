using Function.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.LinkedList
{
    public class _206_反转链表
    { 
        /// <summary>
        /// 非递归反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseListByInteration(ListNode head)
        {
            if(head == null || head.next == null) {  return head; }
            ListNode newHead = null;
            while (head != null)
            { 
                ListNode tmp = head.next;
                head.next = newHead;
                newHead = head;
                head = tmp;
            }
            return newHead;
        }
        public static ListNode ReverseListByRecursion(ListNode head)
        {
            if(head == null || head.next == null) {  return head; }
            ListNode newHead = ReverseListByRecursion(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }
    }
}
