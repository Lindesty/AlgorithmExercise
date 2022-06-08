using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function.Dependency;

namespace Function.LinkedList
{
    public class _83_删除排序链表中的重复元素
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode node = head;
            while (node != null && node.next != null)
            {
                int value = node.val;
                ListNode node1 = node;
                while ( node1 != null && node1.next != null)
                {
                    if (node1.next.val == value)
                    {
                        node1.next = node1.next.next;
                    }
                    else
                    {
                        node1 = node1.next;
                    }
                }

                node = node.next;
            }
            return head;
        }
    }
}
