using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Abstractions
{
    public interface ILandingResolver<TInput, TOutput>
    {
        TOutput CheckTrajectory(TInput coordenate);
    }
}

