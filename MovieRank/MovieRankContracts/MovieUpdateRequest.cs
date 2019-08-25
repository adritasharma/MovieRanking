using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRankContracts
{
    public class MovieUpdateRequest
    {
        public string MovieName { get; set; }
        public int Ranking { get; set; }
    }
}
