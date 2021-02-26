using LandingProject.Abstractions;
using LandingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject
{
    public class LandingResolver
        : ILandingResolver<Coordinate, string>
    {
        public string CheckTrajectory(Coordinate coordenate)
        {
            throw new NotImplementedException();
        }
    }
}
