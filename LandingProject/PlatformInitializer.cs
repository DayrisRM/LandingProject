using System;
using System.Collections.Generic;
using System.Text;
using LandingProject.Abstractions;
using LandingProject.Models;

namespace LandingProject
{
    public class PlatformInitializer
        : IPlatformInitializer<PlatformParameter, LandingArea>
    {
        public LandingArea Initialize(PlatformParameter parameters)
        {

            if(parameters == null) throw new ArgumentNullException(nameof(parameters));
            

            var landingArea = new LandingArea(parameters.Rows, parameters.Columns);             

            var rowLimitPosition = parameters.StartPosition.X + parameters.LandingAreaRowSize;
            var columnLimitPosition = parameters.StartPosition.Y + parameters.LandingAreaColumnSize;

            if (rowLimitPosition > parameters.Rows) 
            {
                throw new ArgumentOutOfRangeException(nameof(rowLimitPosition));
            }

            if (columnLimitPosition > parameters.Columns)
            {
                throw new ArgumentOutOfRangeException(nameof(columnLimitPosition));
            }

            for (int x = parameters.StartPosition.X; x <= rowLimitPosition; x++)
            {
                for (int y = parameters.StartPosition.Y; y <= columnLimitPosition; y++)
                {
                    landingArea.Matrix[x, y] = new LandingPlatform();
                }
            }

            return landingArea;
        }
    }
}
