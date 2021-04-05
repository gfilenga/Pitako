using System;
using AutoMapper;
using Flunt.Notifications;
using Pitako.Domain.Commands;
using Pitako.Domain.Commands.Contracts;
using Pitako.Domain.Entities;
using Pitako.Domain.Handlers.Contracts;
using Pitako.Domain.Repositories;

namespace Pitako.Domain.Handlers
{
    public class QuestionHandler :
        Notifiable
    {
        private readonly IQuestionRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public QuestionHandler(
            IQuestionRepository repository,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
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

            // Gera a question
            var question = _mapper.Map<Question>(command);

            // Salva no banco
            _repository.Create(question);

            // Retorna o resultado
            return new GenericCommandResult(
                true,
                "Pergunta criada",
                question
            );
        }

        public ICommandResult Handle(UpdateQuestionCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua pergunta está inválida!",
                    command.Notifications
                );

            // recupera do banco
            var question = _repository.GetById(id);

            if (question == null)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua pergunta não foi encontrada",
                    null
                );

            // salva no banco as infos novas
            _repository.Update(_mapper.Map(command, question));


            // retorna o resultado
            return new GenericCommandResult(
                true,
                "Pergunta atualizada!",
                question
            );
        }

        public ICommandResult HandleToggleStatus(Guid id)
        {
            var question = _repository.GetById(id);

            if (question == null)
                new GenericCommandResult(
                    false,
                    "Pergunta não encontrada",
                    null
                );

            question.ToogleStatus();

            _repository.Update(question);

            return new GenericCommandResult(
                true,
                "Status atualizado",
                question
            );
        }
    }
}