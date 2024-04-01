using CreateTestName;
using UserModelName;
using UserDatabase;
using UserDtoName;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json.Nodes;


namespace test3
{
    public class UnitTest3
{
    //[Fact]
    public async Task TestGetUserById()
    {
        int userId = 1; // Modifier ID suivant bdd
        bool isSuccess = await CreateTest.GetById(userId);
        Assert.True(isSuccess, "La récupération de l'utilisateur par ID a échoué.");
    }
}

}
