using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace backend_api_vertical.Features.Games.CreateGame
{
    public class CreateGameValidation : AbstractValidator<CreateGameRequest>
    {
        public CreateGameValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Publisher).NotNull().NotEmpty();
        }
    }
}