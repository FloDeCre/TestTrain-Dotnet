using CreateTestName;
using UserModelName;
using UserDatabase;
using UserDtoName;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json.Nodes;


namespace testAll
{
    public class AllInOne
    {
        [Fact]
        public async Task TestAllInOne()
        {
            //Create
            var userDto = new UserDTO { Id = 1, Name = "Jean" };
            var result = await CreateTest.CreateUser(userDto);
            Assert.NotNull(result);
            if (result != null && result.Data != null)
            {
                Assert.Equal(userDto.Name, result.Data.Name);
            }
            //Update
            var userDto2 = new UserDTO { Id = 1, Name = "JeanUpdate2" };
            bool isSuccess = await CreateTest.UpdateUser(userDto2);
            Assert.True(isSuccess, "La mise à jour de l'utilisateur a échoué.");
            //GetAll
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
            //GetOne
            int userId = 1; // Modifier ID suivant bdd
            bool isSuccess2 = await CreateTest.GetById(userId);
            Assert.True(isSuccess2, "La récupération de l'utilisateur par ID a échoué.");
            //Delete
            int userId2 = 1; // Modifier ID suivant bdd
            bool isSuccess3 = await CreateTest.DeleteById(userId2);
            Assert.True(isSuccess3, "La suppression de l'utilisateur a échoué.");
        }
    }
}
