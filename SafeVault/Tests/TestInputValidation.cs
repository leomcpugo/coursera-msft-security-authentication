using NUnit.Framework;

[TestFixture]
public class TestInputValidation
{
    [Test]
    public void UsernameSanitization_RemovesSqlInjectionPayload()
    {
        var maliciousInput = "'; DROP TABLE Users;--";

        var sanitized = InputSanitizer.SanitizeUsername(maliciousInput);

        Assert.That(sanitized.Contains(";"), Is.False);
        Assert.That(sanitized.Contains("--"), Is.False);
        Assert.That(sanitized.Contains("'"), Is.False);
    }

    [Test]
    public void UsernameSanitization_RemovesXssPayload()
    {
        var xssPayload = "<script>alert('xss')</script>";

        var sanitized = InputSanitizer.SanitizeUsername(xssPayload);

        Assert.That(sanitized.Contains("<"), Is.False);
        Assert.That(sanitized.Contains(">"), Is.False);
        Assert.That(sanitized.Contains("script"), Is.False);
    }
}
