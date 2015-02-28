using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAuthPrototype.Controllers;
using OpenAuthPrototype.Models;

namespace OpenAuthPrototype.Tests.Controllers
{
    [TestClass]
    public class AcvhievementControllerTests
    {
        [TestMethod]
        public void PostAchievements()
        {
            var controller = new AchievementsController();
            //create 5 achievements
            for (int i = 0; i < 5; i++)
            {
                Achievement achievement = new Achievement();
                achievement.DateCreated = DateTime.Now;
                achievement.Description = String.Format("This is my {0} achievement", i);
                achievement.Title = String.Format("Awesome Achievement #{0}", i);
                achievement.UserEmail = "testuser@unipi.gr";
                achievement.UserId = 1;
                var result = controller.PostAchievement(achievement);
                var createdResult = result as CreatedAtRouteNegotiatedContentResult<Achievement>;
                // Assert
                Assert.IsNotNull(createdResult);
                Assert.AreEqual("DefaultApi", createdResult.RouteName);
                Assert.IsNotNull(createdResult.RouteValues["id"]);
                Console.WriteLine(createdResult.RouteValues["id"]);
            }

        }


        [TestMethod]
        public void GetAchievements()
        {
            // Arrange
            var controller = new AchievementsController();
            
            // Act
            var achievements = controller.GetAchievements().ToList();

            // Assert
            Assert.IsNotNull(achievements);
            achievements.ForEach(x=>Console.WriteLine("{0}", x.Title));
        }
    }
}
