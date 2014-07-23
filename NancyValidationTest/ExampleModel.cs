using System.Data;
using FluentValidation;

namespace NancyValidationTest
{
    public class ExampleModel
    {
         public string Name { get; set; }
    }

    public class ExampleModelValidator : AbstractValidator<ExampleModel>
    {
        public ExampleModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}