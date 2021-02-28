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
    public class LandingResolverUnitTests
    {

        [Fact]
        public void Constructor_LandingPlatform_Null_Throws()
        {
            Action action = () => new LandingResolver(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CheckTrajectory_Action_IsCalled()
        {
            var landingResolverMock = new Mock<ILandingResolver<Coordinate, string>>();
            var landingResolver = landingResolverMock.Object;
            landingResolver.CheckTrajectory(It.IsAny<Coordinate>());
            landingResolverMock.Verify(m => m.CheckTrajectory(It.IsAny<Coordinate>()), Times.Once);
        }

        [Fact]
        public void CheckTrajectory_Coordinate_Null_Throws()
        {
            var landingArea = LandingAreaInitializer();
            var landingResolver = new LandingResolver(landingArea);
            Action action = () => landingResolver.CheckTrajectory(null);
            action.Should().Throw<ArgumentNullException>();
        }


        [Fact]       
        public void CheckTrajectory_LandingAreaWithHistoric_TrajectoryResultExpected() 
        {
            var landingArea = LandingAreaInitializer();
            var landingResolver = new LandingResolver(landingArea);

            var dataToTest = new Dictionary<Coordinate, TrajectoryResult>
                {
                    {
                        new Coordinate()
                        {
                            X = 5,
                            Y = 5
                        },
                        TrajectoryResult.OkForLanding
                    },
                    {
                        new Coordinate()
                        {
                            X = 5,
                            Y = 5
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 16,
                            Y = 15
                        },
                        TrajectoryResult.OutOfPlatform
                    },
                    {
                        new Coordinate()
                        {
                            X = 7,
                            Y = 7
                        },
                        TrajectoryResult.OkForLanding
                    },
                    {
                        new Coordinate()
                        {
                            X = 7,
                            Y = 8
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 6,
                            Y = 7
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 7,
                            Y = 12
                        },
                        TrajectoryResult.OkForLanding
                    },
                    {
                        new Coordinate()
                        {
                            X = 7,
                            Y = 13
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 7,
                            Y = 11
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 8,
                            Y = 11
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 8,
                            Y = 12
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 8,
                            Y = 13
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 6,
                            Y = 11
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 6,
                            Y = 12
                        },
                        TrajectoryResult.Clash
                    },
                    {
                        new Coordinate()
                        {
                            X = 6,
                            Y = 13
                        },
                        TrajectoryResult.Clash
                    },

                };


            foreach (KeyValuePair<Coordinate, TrajectoryResult> data in dataToTest)
            {
                var result = landingResolver.CheckTrajectory(data.Key);
                Assert.Equal(result, data.Value);
            }

            
        }


        private LandingArea LandingAreaInitializer() 
        {
            var startPosition = new Coordinate()
            {
                X = 5,
                Y = 5
            };

            var parameters = new PlatformParameter()
            {
                Rows = 100,
                Columns = 100,
                StartPosition = startPosition,
                LandingAreaRowSize = 10,
                LandingAreaColumnSize = 10
            };
            var platformInitializer = new PlatformInitializer();
            var landingArea = platformInitializer.Initialize(parameters);

            return landingArea;
        }
        

    }
}
