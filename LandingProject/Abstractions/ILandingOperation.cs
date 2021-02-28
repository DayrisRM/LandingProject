using LandingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Abstractions
{
    public interface ILandingOperation
    {
        void UpdateLandingPositions(Coordinate coordinate);        

        void GetNeighboringLandingPositions(Coordinate coordinate);

        void AddNeighboringLandingPositions(Coordinate coordinate);       

        void SavePositionAsVisited();

    }
}
