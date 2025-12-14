using NUnit.Framework;

[TestFixture]
public class TestAuthentication
{
    [Test]
    public void InvalidPasswordFailsAuthentication()
    {
        var hash = PasswordHasher.HashPassword("correct");

        var result = PasswordHasher.VerifyPassword("wrong", hash);

        Assert.That(result, Is.False);
    }

    [Test]
    public void ValidPasswordSucceedsAuthentication()
    {
        var hash = PasswordHasher.HashPassword("secret");

        var result = PasswordHasher.VerifyPassword("secret", hash);

        Assert.That(result, Is.True);
    }
}
