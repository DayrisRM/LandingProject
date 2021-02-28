using LandingProject.Abstractions;
using LandingProject.Models;
using LandingProject.Services;
using System;

namespace LandingProject
{
    public class LandingResolver
        : ILandingResolver<Coordinate, TrajectoryResult>
    {

        LandingArea LandingArea { get; set; }

        ILandingOperation LandingOperation { get; set; }

        public LandingResolver(LandingArea landingArea) 
        {
            LandingArea = landingArea ?? throw new ArgumentNullException(nameof(landingArea));
            LandingOperation = new LandingOperation(LandingArea);
        }

        public TrajectoryResult CheckTrajectory(Coordinate coordinate)
        {
            if (coordinate == null) throw new ArgumentNullException(nameof(coordinate));

            
            var square = LandingArea.Matrix[coordinate.X, coordinate.Y];

            if (square == null) 
            {
                return TrajectoryResult.OutOfPlatform;
            }

            var landing = (LandingPlatform)square;

            if (coordinate == LandingArea.LastChecked || landing.BeforeChecked)
            {
                return TrajectoryResult.Clash;
            }
           

            LandingOperation.UpdateLandingPositions(coordinate);


            return TrajectoryResult.OkForLanding;
        }
    }
}
