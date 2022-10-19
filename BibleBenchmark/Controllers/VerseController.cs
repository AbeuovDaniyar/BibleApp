using BibleApp.Models;
using BibleApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Controllers
{
    public class VerseController : Controller
    {
        public VerseBusinessService service = new VerseBusinessService();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResults(string searchString, string testament) 
        {
            List<BibleVerse> result;

            if (Int32.Parse(testament) == 1)
            {
                result = service.searchOldTestament(searchString);
            }
            else if (Int32.Parse(testament) == 2)
            {
                result = service.searchNewTestament(searchString);
            }
            else 
            {
                result = service.searchTerm(searchString);
            }
            return View(result);
        }

        public IActionResult SearchVerse(BibleVerse searchVerse) 
        {
            BibleVerse result = new BibleVerse();
            //get book number from book name
            result = service.getBookNumber(searchVerse);

            //set verse range
            char[] delimeterChars = { ' ', ',', '-' };

            string[] verseRange = result.VerseRange.Split(delimeterChars);

            result.Verse = Convert.ToInt32(verseRange[0]);
            result.LastVerse = Convert.ToInt32(verseRange[1]);

            return View(service.searchVerse(result));
        }
    }
}
