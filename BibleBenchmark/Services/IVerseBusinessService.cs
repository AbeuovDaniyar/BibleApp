using BibleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Services
{
    interface IVerseBusinessService
    {
        List<BibleVerse> searchTerm(string searchString);
        BibleVerse searchVerse(BibleVerse verse);
        BibleVerse getBookName(BibleVerse verse);
        BibleVerse getBookNumber(BibleVerse verse);
    }
}
