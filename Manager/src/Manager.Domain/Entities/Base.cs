using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace Manager.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _errors = new();

        public IReadOnlyCollection<string>? Errors => _errors;

        public bool IsValid => _errors.Count == 0;

        private void AddErrorList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
                _errors.Add(error.ErrorMessage);
        }

        protected bool Validate<V, O>(V validator, O obj)
            where V : AbstractValidator<O>
        {
            var validation = validator.Validate(obj);

            if (validation.Errors.Count > 0)
            {
                AddErrorList(validation.Errors);
            }

            return IsValid;
        }

        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
            {
                builder.AppendLine(error);
            }

            return builder.ToString();
        }
    }
}