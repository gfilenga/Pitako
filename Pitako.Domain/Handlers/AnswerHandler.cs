using Flunt.Notifications;
using Pitako.Domain.Commands;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers.Contracts;
using Pitako.Domain.Repositories;

namespace Pitako.Domain.Handlers
{
    public class AnswerHandler :
        Notifiable,
        IHandler<CreateAnswerCommand>
    {
        private readonly IAnswerRepository _repository;

        public AnswerHandler(IAnswerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateAnswerCommand command)
        {
            // Valida os dados do domínio
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Resposta inválida",
                    command.Notifications
                );

            // busca o user e a pergunta
            var user = _repository.GetUserById(command.User.Id);
            var question = _repository.GetQuestionById(command.Question.Id);

            // compõe os dados
            var answer = new Answer(command.Description, user, question);

            // persiste a resposta
            _repository.Create(answer);

            // retorna o resultado
            return new GenericCommandResult(
                true,
                "Resposta criada",
                answer
            );
        }
    }
}