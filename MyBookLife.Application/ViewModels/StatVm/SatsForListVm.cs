using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application.ViewModels.StatVm
{
    public class SatsForListVm
    {
        //TODO nie mozna edytowac dlugosci ksiazki
        public int TotalPagesRead { get; set; } 
        public string LongestReadBookTitle { get; set; } 
        public int LongestReadBookPages { get; set; } 
        public string ShortestReadBookTitle { get; set; } 
        public int ShortestReadBookPages { get; set; } 
        public string FavouriveGenre { get; set; } 
        public int TotalBooksRead { get; set; } 
        public int StartedBooks { get; set; } 
        public int TotalEntries { get; set; } 
        public double AverageLengthOfReadBooks { get; set; }
    }
}
