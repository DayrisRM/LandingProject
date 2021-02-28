using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Models
{
    public class PlatformParameter
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Coordinate StartPosition { get; set; }

        public int LandingAreaRowSize { get; set; }

        public int LandingAreaColumnSize { get; set; }


    }
}
