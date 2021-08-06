using FluentValidation;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
  public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
  {
    public CreateEventCommandValidator()
    {
      RuleFor(e => e.Name)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

      RuleFor(e => e.Date)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .GreaterThan(DateTime.Now);

      RuleFor(e => e.Price)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .GreaterThan(0);
    }
  }
}