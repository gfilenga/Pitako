using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;

namespace Pitako.Domain.Commands
{
    public class UpdateUserPasswordCommand : Notifiable, ICommand
    {
        public UpdateUserPasswordCommand() { }

        public UpdateUserPasswordCommand(string currentPassword, string newPassword, string confirmPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(CurrentPassword, 6, "Current", "Mínimo de 6 caracteres")
                .HasMaxLen(CurrentPassword, 20, "Current", "Máximo de 20 caracteres")
                .HasMinLen(NewPassword, 6, "New", "Mínimo de 6 caracteres")
                .HasMaxLen(NewPassword, 20, "New", "Máximo de 20 caracteres")
                .HasMinLen(ConfirmPassword, 6, "Confirm", "Mínimo de 6 caracteres")
                .HasMaxLen(ConfirmPassword, 20, "Confirm", "Máximo de 20 caracteres")
                .AreEquals(NewPassword, ConfirmPassword, "Confirm", "Senhas não batem")
            );
        }
    }
}