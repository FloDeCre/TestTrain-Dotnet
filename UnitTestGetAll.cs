using CreateTestName;
using UserModelName;
using UserDatabase;
using UserDtoName;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;


namespace test2
{
    public class UnitTest2
    {
        //[Fact]
        public async Task TestGetAllUser()
        {
            var resultAll = await CreateTest.GetAllUser();
            Assert.NotNull(resultAll);
            if (resultAll != null && resultAll.Data != null)
            {
                Assert.NotEmpty(resultAll.Data);
                foreach (var user in resultAll.Data)
                {
                    Assert.NotNull(user);
                    Assert.NotEqual(0, user.Id);
                    Assert.NotNull(user.Name);
                }
            }
        }
    }
}
