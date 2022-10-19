using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    public class BibleVerse
    {
        public int Id { get; set; }
        [DisplayName("Book #")]
        public int Book { get; set; }
        [DisplayName("Book Name")]
        [Required(ErrorMessage = "Book Name is required")]
        public string BookName { get; set; }
        [DisplayName("Book Chapter")]
        [Required(ErrorMessage = "Book Chapter is required")]
        public int Chapter { get; set; }
        [DisplayName("Verse")]
        public int Verse { get; set; }
        public string Text { get; set; }
        [DisplayName("Verse")]
        public string VerseRange { get; set; }
        public List<string> VerseRangeText { get; set; } 

        public int LastVerse { get; set; }

        public BibleVerse(int id, int book, string bookName, int chapter, int verse, string text, string verseRange, int lastVerse, List<string> verseRangeText) 
        {
            this.Id = id;
            this.Book = book;
            this.BookName = bookName;
            this.Chapter = chapter;
            this.Verse = verse;
            this.Text = text;
            this.VerseRange = verseRange;
            this.LastVerse = lastVerse;
            this.VerseRangeText = verseRangeText;
        }

        public BibleVerse() { }
    }
}
