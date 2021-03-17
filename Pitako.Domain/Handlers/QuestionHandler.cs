using Flunt.Notifications;
using Pitako.Domain.Commands;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers.Contracts;
using Pitako.Domain.Repositories;

namespace Pitako.Domain.Handlers
{
    public class QuestionHandler :
        Notifiable,
        IHandler<CreateQuestionCommand>,
        IHandler<UpdateQuestionCommand>
    {
        private readonly IQuestionRepository _repository;

        public QuestionHandler(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateQuestionCommand command)
        {
            // Fail Fast Validation - Valida tudo, antes de tentar qualquer coisa
            // utilizando o método validate criado dentro de cada command
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);
            }

            // Gerar a question
            var question = new Question(command.Title, command.Description, command.Date, command.User);

            // Salva no banco
            _repository.Create(question);

            // Retorna o resultado
            return new GenericCommandResult(true, "Question criada", question);
        }

        public ICommandResult Handle(UpdateQuestionCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}