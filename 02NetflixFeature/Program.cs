using _02NetflixFeature;
using System.Collections.Generic;

class Program
{
    public static LinkedListNode Merge2SortedLists(LinkedListNode l1, LinkedListNode l2)
    {
        LinkedListNode dummy = new(-1);

        LinkedListNode prev = dummy;
        
        // Pushing all to single node list
        while (l1 != null && l2 != null)
        {
            if (l1.data <= l2.data)
            {
                prev.next = l1;
                l1 = l1.next;
            }
            else
            {
                prev.next = l2;
                l2 = l2.next;
            }
            prev = prev.next;
        }

        if (l1 == null) prev.next = l2;
        else prev.next = l1;

        return dummy.next;
    }

    public static LinkedListNode MergeKSortedLists(List<LinkedListNode> lists)
    {
        if (lists.Count > 0)
        {
            LinkedListNode res = lists[0];
            for (int i = 1; i < lists.Count; i++) res = Merge2SortedLists(res, lists[i]);
            return res;
        }
        return new LinkedListNode(-1);
    }

    public static void Main(string[] args)
    {
        LinkedListNode a = LinkedList.CreateLinkedList(new int[] { 11, 41, 51 });
        LinkedListNode b = LinkedList.CreateLinkedList(new int[] { 21, 23, 42 });
        LinkedListNode c = LinkedList.CreateLinkedList(new int[] { 25, 56, 66, 72 });

        List<LinkedListNode> list1 = new();
        list1.Add(a);
        list1.Add(b);
        list1.Add(c);

        Console.WriteLine("All movie ID's from best to worse are:");
        LinkedList.Display(MergeKSortedLists(list1));
    }
}