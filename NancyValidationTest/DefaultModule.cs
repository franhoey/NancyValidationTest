using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;

namespace NancyValidationTest
{
    public class DefaultModule : NancyModule
    {
        public DefaultModule()
        {
            Post["/"] = parameters =>
            {
                var model = this.Bind<ExampleModel>();

                var validation = this.Validate(model);

                return validation.IsValid ? "Valid" : "Invalid";
            };
        }
    }
}