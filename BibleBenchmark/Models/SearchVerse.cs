using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    public class SearchVerse
    {
        public int Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }

        public SearchVerse() { }

        public SearchVerse(int book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
        }
    }
}
