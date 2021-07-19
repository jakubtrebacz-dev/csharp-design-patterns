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
    }

    public class Persistance
    {
        public void SaveToFile(string content, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, content);
            }
        }

        public string LoadFromFile(string fileName)
        {
            string content = File.ReadAllText(fileName);
            return content;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            journal.AddEntry("Today I'm documenting my knowledge");
            journal.AddEntry("It's going great");

            Console.WriteLine(journal);

            Persistance journalPersistance = new Persistance();
            journalPersistance.SaveToFile(journal.ToString(), "firstJournal.txt");
        }
    }
}
