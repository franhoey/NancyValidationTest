using System.Runtime;
using Nancy.Testing;
using Nancy.Validation.FluentValidation;
using NancyValidationTest;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DefaultModuleTests
    {
        [Test]
        public void WithDisabledAutoRegistrations_PostInvalidDataReturnsInvalid()
        {
            var browser = new Browser(with =>
            {
                with.Module<DefaultModule>();
                with.DisableAutoRegistrations();

                with.Dependency<DefaultFluentAdapterFactory>();
            });

            var result = browser.Post("/", with =>
            {
                with.HttpRequest();
                with.FormValue("Name", string.Empty);
            });

            Assert.AreEqual("Invalid", result.Body.AsString());
        }

        [Test]
        public void PostInvalidDataReturnsInvalid()
        {
            var browser = new Browser(with =>
            {
                with.Module<DefaultModule>();
            });

            var result = browser.Post("/", with =>
            {
                with.HttpRequest();
                with.FormValue("Name", string.Empty);
            });

            Assert.AreEqual("Invalid", result.Body.AsString());
        }

        [Test]
        public void PostValidDataReturnsValid()
        {
            var browser = new Browser(with =>
            {
                with.Module<DefaultModule>();
            });

            var result = browser.Post("/", with =>
            {
                with.HttpRequest();
                with.FormValue("Name", "anything");
            });

            Assert.AreEqual("Valid", result.Body.AsString());
        }

    }
}