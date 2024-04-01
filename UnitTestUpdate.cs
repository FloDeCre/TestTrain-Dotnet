using CreateTestName;
using UserDtoName;
using Xunit;

namespace test7
{
    public class UnitTest7
    {
        //[Fact]
        public async Task TestUpdateUser()
        {
            var userDto = new UserDTO { Id = 1, Name = "JeanUpdate2" };
            bool isSuccess = await CreateTest.UpdateUser(userDto);
            Assert.True(isSuccess, "La mise à jour de l'utilisateur a échoué.");
        }
    }
}
