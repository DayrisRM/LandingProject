using LandingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Abstractions
{
    public interface IMatrixOperation
    {
        bool HasTopNeighbor(Coordinate coordinate);

        bool HasDownNeighbor(Coordinate coordinate);

        bool HasRightNeighbor(Coordinate coordinate);

        bool HasLeftNeighbor(Coordinate coordinate);


        Coordinate GetTopNeighborCoordinate(Coordinate coordinate);

        Coordinate GetDownNeighborCoordinate(Coordinate coordinate);

        Coordinate GetRightNeighborCoordinate(Coordinate coordinate);

        Coordinate GetLeftNeighborCoordinate(Coordinate coordinate);
       

    }
}
