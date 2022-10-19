using BibleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Services
{
    public class VerseBusinessService : IVerseBusinessService
    {
        public DAO service = new DAO();

        public List<BibleVerse> searchTerm(string searchString)
        {
            return service.searchTerm(searchString);
        }

        public List<BibleVerse> searchNewTestament(string searchString)
        {
            return service.searchNewTestament(searchString);
        }

        public List<BibleVerse> searchOldTestament(string searchString)
        {
            return service.seacrhOldTestament(searchString);
        }

        public BibleVerse searchVerse(BibleVerse verse)
        {
            return service.searchVerse(verse);
        }

        public BibleVerse getBookName(BibleVerse verse)
        {
            return service.getBookName(verse);
        }

        public BibleVerse getBookNumber(BibleVerse verse)
        {
            return service.getBookNumber(verse);
        }
    }
}
