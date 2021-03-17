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
        IHandler<CreateAnswerCommand>,
        IHandler<ToggleActiveAnswerCommand>,
        IHandler<UpdateAnswerCommand>
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

        public ICommandResult Handle(ToggleActiveAnswerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Resposta inválida",
                    command.Notifications
                );

            var answer = _repository.GetById(command.Id, command.User);

            answer.ToogleStatus();

            _repository.Update(answer);

            return new GenericCommandResult(
                true,
                "Status atualizado",
                answer
            );
        }

        public ICommandResult Handle(UpdateAnswerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Resposta inválida",
                    command.Notifications
                );

            var answer = _repository.GetById(command.Id, command.User);

            // atualiza a descrição
            answer.UpdateAnswer(command.Description);

            // persiste os dados
            _repository.Update(answer);

            return new GenericCommandResult(
                true,
                "Resposta atualizada",
                answer
            );
        }
    }
}