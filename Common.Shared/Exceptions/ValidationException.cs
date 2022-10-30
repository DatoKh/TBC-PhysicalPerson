using Common.Shared.Resources;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Common.Shared.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException()
            : base(ErrorMessages.ValidationError)
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(string error)
            : base(error)
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures) : base(ModifyMessage(failures))
        {
            Failures = new Dictionary<string, string[]>();

            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        private static string ModifyMessage(List<ValidationFailure> failures)
        {
            var myFailures = new Dictionary<string, string[]>();

            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                myFailures.Add(propertyName, propertyFailures);
            }

            return JsonConvert.SerializeObject(myFailures, Formatting.Indented);
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
