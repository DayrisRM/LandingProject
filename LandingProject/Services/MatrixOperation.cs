using LandingProject.Abstractions;
using LandingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Services
{
    public class MatrixOperation
        : IMatrixOperation
    {

        public Square[,] Matrix { get; set; }

        public MatrixOperation(Square[,] matrix)
        {
            Matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
        }

        public Coordinate GetTopNeighborCoordinate(Coordinate coordinate)
        {
            var topCoordinate = new Coordinate()
            {
                X = coordinate.X - 1,
                Y = coordinate.Y
            };

            return topCoordinate;
        }

        public Coordinate GetDownNeighborCoordinate(Coordinate coordinate)
        {
            var downCoordinate = new Coordinate()
            {
                X = coordinate.X + 1,
                Y = coordinate.Y
            };

            return downCoordinate;
        }

        public Coordinate GetLeftNeighborCoordinate(Coordinate coordinate)
        {
            var leftCoordinate = new Coordinate()
            {
                X = coordinate.X,
                Y = coordinate.Y - 1
            };

            return leftCoordinate;
        }

        public Coordinate GetRightNeighborCoordinate(Coordinate coordinate)
        {
            var rihtCoordinate = new Coordinate()
            {
                X = coordinate.X,
                Y = coordinate.Y + 1
            };

            return rihtCoordinate;
        }


        public bool HasTopNeighbor(Coordinate coordinate)
        {
            var result = false;

            var topCoordinate = GetTopNeighborCoordinate(coordinate);

            var square = Matrix[topCoordinate.X, topCoordinate.Y];

            if (square != null) result = true;

            return result;
        }

        public bool HasDownNeighbor(Coordinate coordinate)
        {
            var result = false;

            var downCoordinate = GetDownNeighborCoordinate(coordinate);

            var square = Matrix[downCoordinate.X, downCoordinate.Y];

            if (square != null) result = true;

            return result;
        }

        public bool HasLeftNeighbor(Coordinate coordinate)
        {
            var result = false;

            var leftCoordinate = GetLeftNeighborCoordinate(coordinate);

            var square = Matrix[leftCoordinate.X, leftCoordinate.Y];

            if (square != null) result = true;

            return result;
        }

        public bool HasRightNeighbor(Coordinate coordinate)
        {
            var result = false;

            var rightCoordinate = GetRightNeighborCoordinate(coordinate);

            var square = Matrix[rightCoordinate.X, rightCoordinate.Y];

            if (square != null) result = true;

            return result;
        }

       
    }
}
