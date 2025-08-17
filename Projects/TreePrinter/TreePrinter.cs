using System;
using System.Collections.Generic;

public class TreePrinter
{
    public interface IPrintableNode
    {
        IPrintableNode GetLeft();
        IPrintableNode GetRight();
        string GetText();
    }

    public static void Print<T>(T[] elems)
    {
        Node root = GetNode(elems, 0);
        Print(root);
    }

    private static Node GetNode<T>(T[] elems, int index)
    {
        if (index < elems.Length)
        {
            var n = new Node(elems[index]?.ToString() ?? "");
            n.Left = GetNode(elems, 2 * index + 1);
            n.Right = GetNode(elems, 2 * index + 2);
            return n;
        }
        else
        {
            return null;
        }
    }

    public class Node : IPrintableNode
    {
        public string Val;
        public Node Left;
        public Node Right;
        public Node(string val) { Val = val; }
        public IPrintableNode GetLeft() => Left;
        public IPrintableNode GetRight() => Right;
        public string GetText() => Val;
    }

    public static void Print(IPrintableNode root)
    {
        var lines = new List<List<string>>();
        var level = new List<IPrintableNode>();
        var next = new List<IPrintableNode>();
        level.Add(root);
        int nn = 1;
        int widest = 0;
        while (nn != 0)
        {
            var line = new List<string>();
            nn = 0;
            foreach (var n in level)
            {
                if (n == null)
                {
                    line.Add(null);
                    next.Add(null);
                    next.Add(null);
                }
                else
                {
                    string aa = n.GetText();
                    line.Add(aa);
                    if (aa.Length > widest) widest = aa.Length;
                    next.Add(n.GetLeft());
                    next.Add(n.GetRight());
                    if (n.GetLeft() != null) nn++;
                    if (n.GetRight() != null) nn++;
                }
            }
            if (widest % 2 == 1) widest++;
            lines.Add(line);
            var tmp = level;
            level = next;
            next = tmp;
            next.Clear();
        }
        int perpiece = lines[lines.Count - 1].Count * (widest + 4);
        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            int hpw = (int)Math.Floor(perpiece / 2f) - 1;
            if (i > 0)
            {
                for (int j = 0; j < line.Count; j++)
                {
                    char c = ' ';
                    if (j % 2 == 1)
                    {
                        if (line[j - 1] != null)
                        {
                            c = (line[j] != null) ? '┴' : '┘';
                        }
                        else
                        {
                            if (j < line.Count && line[j] != null) c = '└';
                        }
                    }
                    Console.Write(c);
                    if (line[j] == null)
                    {
                        for (int k = 0; k < perpiece - 1; k++) Console.Write(" ");
                    }
                    else
                    {
                        for (int k = 0; k < hpw; k++) Console.Write(j % 2 == 0 ? " " : "─");
                        Console.Write(j % 2 == 0 ? "┌" : "┐");
                        for (int k = 0; k < hpw; k++) Console.Write(j % 2 == 0 ? "─" : " ");
                    }
                }
                Console.WriteLine();
            }
            for (int j = 0; j < line.Count; j++)
            {
                string f = line[j] ?? "";
                int gap1 = (int)Math.Ceiling(perpiece / 2f - f.Length / 2f);
                int gap2 = (int)Math.Floor(perpiece / 2f - f.Length / 2f);
                for (int k = 0; k < gap1; k++) Console.Write(" ");
                Console.Write(f);
                for (int k = 0; k < gap2; k++) Console.Write(" ");
            }
            Console.WriteLine();
            perpiece /= 2;
        }
    }
}
