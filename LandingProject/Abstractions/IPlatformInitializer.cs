using System;
using System.Collections.Generic;
using System.Text;

namespace LandingProject.Abstractions
{
    public interface IPlatformInitializer<TInput, TOutput>
    {
        TOutput Initialize(TInput parameters);
    }
}
