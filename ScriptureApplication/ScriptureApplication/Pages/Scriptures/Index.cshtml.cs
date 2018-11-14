using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureApplication.Models;

namespace ScriptureApplication.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureApplication.Models.ScriptureApplicationContext _context;

        public IndexModel(ScriptureApplication.Models.ScriptureApplicationContext context)
        {
            _context = context;
        }

        public PaginatedList<Scripture> Scripture { get;set; }
        public string SearchString { get; set; }
        public string ScriptureNote { get; set; }

        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string searchString, string scriptureNote, string sortOrder, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }

            IQueryable<Scripture> scriptureIQ = from s in _context.Scripture
                                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                scriptureIQ = scriptureIQ.Where(s => s.Book.Contains(searchString));
            }

            else if (!String.IsNullOrEmpty(scriptureNote))
            {
                scriptureIQ = scriptureIQ.Where(x => x.Note.Contains(scriptureNote) || x.Book.Contains(scriptureNote) );
                
            }
            else if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "book_desc":
                        scriptureIQ = scriptureIQ.OrderByDescending(s => s.Book);
                        break;
                    case "Date":
                        scriptureIQ = scriptureIQ.OrderBy(s => s.Date_Added);
                        break;
                    case "date_desc":
                        scriptureIQ = scriptureIQ.OrderByDescending(s => s.Date_Added);
                        break;
                    default:
                        scriptureIQ = scriptureIQ.OrderBy(s => s.Book);
                        break;
                }
                
            }
            
            int pageSize = 5;
            Scripture = await PaginatedList<Scripture>.CreateAsync(
            scriptureIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            
            SearchString = searchString;
            ScriptureNote = scriptureNote;
        }
    }
}
