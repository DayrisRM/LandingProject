using LandingProject.Abstractions;
using LandingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Services
{
    public class LandingOperation
        : ILandingOperation
    {

        LandingArea LandingArea { get; set; }

        IMatrixOperation MatrixOperation { get; set; }

        private List<Coordinate> Coordinates { get; set; }

        public LandingOperation(LandingArea landingArea)
        {
            LandingArea = landingArea ?? throw new ArgumentNullException(nameof(landingArea));
            MatrixOperation = new MatrixOperation(LandingArea.Matrix);
            Coordinates = new List<Coordinate>();
        }


        public void UpdateLandingPositions(Coordinate coordinate)
        {
            LandingArea.LastChecked = coordinate;

            GetNeighboringLandingPositions(coordinate);

            SavePositionAsVisited();

        }

        public void SavePositionAsVisited()
        {
            foreach (var coor in Coordinates)
            {
                var square = LandingArea.Matrix[coor.X, coor.Y];
                if (square != null)
                {
                    var landing = (LandingPlatform)square;
                    landing.BeforeChecked = true;
                }
            }
        }

        public void GetNeighboringLandingPositions(Coordinate coordinate)
        {
            AddNeighboringLandingPositions(coordinate);

            if (MatrixOperation.HasLeftNeighbor(coordinate))
            {
                var leftCoordinate = MatrixOperation.GetLeftNeighborCoordinate(coordinate);
                AddNeighboringLandingPositions(leftCoordinate);
            }
            if (MatrixOperation.HasRightNeighbor(coordinate))
            {
                var rightcoordinate = MatrixOperation.GetRightNeighborCoordinate(coordinate);
                AddNeighboringLandingPositions(rightcoordinate);
            }
        }

        public void AddNeighboringLandingPositions(Coordinate coordinate)
        {
            Coordinates.Add(coordinate);

            if (MatrixOperation.HasTopNeighbor(coordinate))
            {
                var topCoordinate = MatrixOperation.GetTopNeighborCoordinate(coordinate);
                
                Coordinates.Add(topCoordinate);
            }

            if (MatrixOperation.HasDownNeighbor(coordinate))
            {
                var downCoordinate = MatrixOperation.GetDownNeighborCoordinate(coordinate);
                Coordinates.Add(downCoordinate);
            }

        }

        
    }
}
