using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID.SingleResponsibilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entires = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entires.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index) 
        {
            entires.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entires);
        }

        // This violates single resposibility principle
        public void Save(string filename)
        {
            File.WriteAllText(filename, ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            journal.AddEntry("Today I'm documenting my knowledge");
            journal.AddEntry("It's going great");

            Console.WriteLine(journal); // This works because we have override ToString
        }
    }
}
