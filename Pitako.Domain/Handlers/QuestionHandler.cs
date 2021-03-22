using System;
using System.Collections.Generic;
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
        IHandler<UpdateQuestionCommand>,
        IHandler<ToggleActiveCommand>,
        IHandler<ListQuestionsCommand>,
        IHandler<DeleteQuestionCommand>
    {
        private readonly IQuestionRepository _repository;
        private readonly IUserRepository _userRepository;

        public QuestionHandler(
            IQuestionRepository repository,
            IUserRepository userRepository
        )
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public ICommandResult Handle(CreateQuestionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua pergunta está inválida!",
                    command.Notifications);
            }


            var user = _userRepository.GetById(command.UserId);


            if (user == null)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que seu usuário é inválido!",
                    command.Notifications);
            }

            // Gerar a question
            var question = new Question(command.Title, command.Description, command.UserId);

            // Salva no banco
            _repository.Create(question);

            // Retorna o resultado
            return new GenericCommandResult(true, "Pergunta criada", question);
        }

        public ICommandResult Handle(UpdateQuestionCommand command)
        {
            // valida
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua pergunta está inválida!",
                    command.Notifications);
            }

            // recupera do banco
            var question = _repository.GetById(command.Id);

            // altera as infos
            question.UpdateQuestion(command.Title, command.Description);

            // salva no banco as infos novas
            _repository.Update(question);

            // retorna o resultado
            return new GenericCommandResult(true, "Pergunta salva", question);
        }

        public ICommandResult Handle(ToggleActiveCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ocorreu um erro ao mudar a privacidade da sua pergunta",
                    command.Notifications
                );

            var question = _repository.GetById(command.Id);

            question.ToogleStatus();

            _repository.Update(question);

            return new GenericCommandResult(
                true,
                "Status atualizado",
                question
            );
        }

        public ICommandResult Handle(ListQuestionsCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "id inválido",
                    command.Notifications
                );

            var user = _userRepository.GetById(command.UserId);

            var question = _repository.GetAllByUser(user.Id.ToString());

            return new GenericCommandResult(
                true,
                "Lista de perguntas: ",
                question
            );
        }

        public ICommandResult Handle(DeleteQuestionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Pergunta não encontrada",
                    command.Notifications
                );

            _repository.Delete(command.Id);

            return new GenericCommandResult(
                true,
                "Perguntada deletada!",
                null
            );
        }
    }
}