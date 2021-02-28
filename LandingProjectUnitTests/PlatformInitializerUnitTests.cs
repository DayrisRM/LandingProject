using FluentAssertions;
using LandingProject;
using LandingProject.Abstractions;
using LandingProject.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LandingProjectUnitTests
{
    [Trait("Type", "Unit")]
    public class PlatformInitializerUnitTests
    {
        [Fact]
        public void Initialize_Action_IsCalled()
        {
            var platformInitializeMock = new Mock<IPlatformInitializer<int, LandingArea>>();
            var platformInitialize = platformInitializeMock.Object;
            platformInitialize.Initialize(It.IsAny<int>());
            platformInitializeMock.Verify(m => m.Initialize(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Initialize_Parameter_Null_Throws()
        {            
            var platformInitializer = new PlatformInitializer();
            Action action = () => platformInitializer.Initialize(null);
            action.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void Initialize_Row_OutOfRange_ThrowsOutOfRange()
        {
            var startPosition = new Coordinate()
            {
                X = 15,
                Y = 15
            };

            var parameters = new PlatformParameter()
            {
                Rows = 20,
                Columns = 20,
                StartPosition = startPosition,
                LandingAreaRowSize = 10,
                LandingAreaColumnSize = 5
            };

            var platformInitializer = new PlatformInitializer();            
            Action action = () => platformInitializer.Initialize(parameters);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Initialize_Column_OutOfRange_ThrowsOutOfRange()
        {
            var startPosition = new Coordinate()
            {
                X = 15,
                Y = 15
            };

            var parameters = new PlatformParameter()
            {
                Rows = 20,
                Columns = 20,
                StartPosition = startPosition,
                LandingAreaRowSize = 5,
                LandingAreaColumnSize = 10
            };

            var platformInitializer = new PlatformInitializer();
            Action action = () => platformInitializer.Initialize(parameters);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }


    }
}
