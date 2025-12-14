using NUnit.Framework;
using System.Security.Claims;

[TestFixture]
public class TestAuthorization
{
    [Test]
    public void UserWithoutAdminRoleIsDenied()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Role, "user")
        });

        var hasAdmin = identity.HasClaim(ClaimTypes.Role, "admin");

        Assert.That(hasAdmin, Is.False);
    }

    [Test]
    public void AdminRoleIsRecognized()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Role, "admin")
        });

        var hasAdmin = identity.HasClaim(ClaimTypes.Role, "admin");

        Assert.That(hasAdmin, Is.True);
    }
}
