using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRankContracts
{
    public class MovieRankResponse
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public int Ranking { get; set; }
        public string TimeRanked { get; set; }
    }
}
