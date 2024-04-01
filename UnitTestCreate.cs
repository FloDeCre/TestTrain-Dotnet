using CreateTestName;
using UserModelName;
using UserDatabase;
using UserDtoName;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json.Nodes;


namespace test
{
    public class UnitTest1
    {
        //[Fact]
        public async Task TestCreateUser()
        {
            var userDto = new UserDTO { Id = 1, Name = "Jean" };
            var result = await CreateTest.CreateUser(userDto);

            Assert.NotNull(result);
            if (result != null && result.Data != null)
            {
                Assert.Equal(userDto.Name, result.Data.Name);
            }
        }
    }
}
