using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")
                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("O nome de usuário não pode ser vazio.")
                .NotNull()
                .WithMessage("O nome de usuário não pode ser nulo.")
                .MinimumLength(8)
                .WithMessage("O nome de usuário deve ter no mínimo 8 caracteres.")
                .MaximumLength(30)
                .WithMessage("O nome de usuário deve ter no máximo 30 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")
                .NotNull()
                .WithMessage("O email não pode ser nulo.")
                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")
                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(x => x.Phone)
                .MinimumLength(8)
                .WithMessage("O número de telefone deve ter no mínimo 8 caracteres.")
                .MaximumLength(14)
                .WithMessage("A número de telefone deve ter no máximo 14 caracteres.")
                .Matches(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$")
                .WithMessage("O número de telefone não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                .MinimumLength(8)
                .WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .MaximumLength(1000)
                .WithMessage("A senha deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")
                .NotNull()
                .WithMessage("O email não pode ser nulo.")
                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")
                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            // Todo = Avatar
            // Todo = QRCode
            // Todo = IsPresent
            // Todo = Score
            // Todo = Linkedin
            // Todo = Github
        }
    }
}