using System;
using Flunt.Notifications;
using Flunt.Validations;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;

namespace Pitako.Domain.Commands
{
    public class ToggleActiveAnswerCommand : Notifiable, ICommand
    {
        public ToggleActiveAnswerCommand()
        {
        }
        public ToggleActiveAnswerCommand(Guid id, Question question, User user)
        {
            Id = id;
            Question = question;
            User = user;
        }

        public Guid Id { get; set; }
        public Question Question { get; set; }
        public User User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasLen(Id.ToString(), 36, "Id", "Id inválido")
                .HasMinLen(User.Username, 2, "Name", "Please, write a valid name")
                .HasMaxLen(User.Username, 254, "Name", "Please, don't exceed 254 letters")
                .IsEmail(User.Email, "Email", "Please, write a valid email")
                .HasMinLen(User.Password, 6, "Password", "Please, write a password with more than 6 letters")
                .HasMaxLen(User.Password, 20, "Password", "Please, write a password with less than 20 letters")
                .HasMinLen(Question.Title, 2, "Name", "Please, write a title with more than 2 letters")
                .HasMaxLen(Question.Title, 124, "Name", "Please, don't exceed 124 letters")
                .HasMinLen(Question.Description, 2, "Description", "Please, write a description with more than 2 letters")
                .HasMaxLen(Question.Description, 1024, "Description", "Please, don't exceed 1024 letters")
            );
        }
    }
}