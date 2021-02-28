using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Models
{
    public class LandingArea
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Square[,] Matrix { get; set; }

        public Coordinate LastChecked { get; set; }

        public LandingArea(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Matrix = new Square[rows, columns];

            LastChecked = new Coordinate();
        }
    }   

}
