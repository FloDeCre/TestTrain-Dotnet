using CreateTestName;
using Xunit;
using System.Threading.Tasks;

namespace test4
{
    public class UnitTest4
    {
        // Ajouter [Fact] ici pour rendre le test valide
        public async Task TestDeleteUser()
        {
            int userId = 1; // Modifier ID suivant bdd
            bool isSuccess = await CreateTest.DeleteById(userId);
            Assert.True(isSuccess, "La suppression de l'utilisateur a échoué.");
        }
    }
}
