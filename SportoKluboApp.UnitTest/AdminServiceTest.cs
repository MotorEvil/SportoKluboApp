using System;
using System.Threading.Tasks;
using SportoKluboApp.Models;
using SportoKluboApp.Services;
using SportoKluboApp.Data;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace SportoKluboApp.UnitTest
{
   public class AdminServiceTest
    {

        [Fact]
        public async Task AddWorkout()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;

            using (var context = new ApplicationDbContext(options))
            {
                var service = new AdminService(context);

                await service.AddWorkoutAsync(new Treniruote
                {
                    Laikas = DateTime.UtcNow,
                    Pavadinimas = "Testas",
                    LaisvosVietos = 1

                });

                //await service.AddSubscriptionAsync(new Guid("fake-0000"), fakeUser.Subscription = 1);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context
                    .Items.CountAsync();
                Assert.Equal(1, itemsInDatabase);

                var item = await context.Items.FirstAsync();
                Assert.Equal("Testas", item.Pavadinimas);
                Assert.Equal(1, item.LaisvosVietos);

                var diference = DateTime.UtcNow - item.Laikas;
                Assert.True(diference < TimeSpan.FromSeconds(1));

            }
        }

        [Fact]
        public async Task AddSubscription()
        {
           /* UserManager<ApplicationUser> _userManager;
            var fakeUser = new ApplicationUser
            {
                Id = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200",
                UserName = "fake",
                Email = "fake@fake.com",
                EmailConfirmed = false,
                Subscription = 0
            };

            var testGuid = new Guid("5ea684fb-3e3e-4189-93e8-6905f4cd31d5");

            var service = new AdminService(_userManager);
            await service.AddSubscriptionAsync(testGuid, 1);
            var user = await _userManager.FindByIdAsync(testGuid.ToString());

            Assert.Equal("5ea684fb-3e3e-4189-93e8-6905f4cd31d5", user.Id);
            Assert.Equal(1, user.Subscription);

*/
        }



    }
}
