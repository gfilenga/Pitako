using System;
using System.Collections.Generic;
using AutoMapper;
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
        IHandler<ListAnswersCommand>
    {
        private readonly IAnswerRepository _repository;
        private readonly IMapper _mapper;

        public AnswerHandler(IAnswerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(CreateAnswerCommand command)
        {
            // Valida os dados do comando
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Resposta inválida",
                    command.Notifications
                );

            // busca o user e a pergunta
            var user = _repository.GetUserById(command.UserId);
            var question = _repository.GetQuestionById(command.QuestionId);

            if (question == null)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua pergunta é inválida!",
                    command.Notifications);
            }

            if (user == null)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que seu usuário é inválido!",
                    command.Notifications);
            }

            // compõe a resposta
            // var answer = new Answer(command.Description, question.Id, user.Id);
            var answer = _mapper.Map<Answer>(command);

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

            var answer = _repository.GetById(command.Id);

            answer.ToogleStatus();

            _repository.Update(answer);

            return new GenericCommandResult(
                true,
                "Status atualizado",
                answer
            );
        }

        public ICommandResult Handle(UpdateAnswerCommand command, Guid id)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Resposta inválida",
                    command.Notifications
                );

            var answer = _repository.GetById(id);

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

        public ICommandResult Handle(ListAnswersCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Pergunta inválida",
                    command.Notifications
                );

            var question = _repository.GetQuestionById(command.QuestionId);

            if (question == null)
                return new GenericCommandResult(
                    false,
                    "Pergunta não encontrada",
                    null
                );

            var answers = _repository.GetAnswers(command.QuestionId);

            if (answers == null)
                return new GenericCommandResult(
                    false,
                    "Nenhuma resposta nesta pergunta",
                    null
                );

            return new GenericCommandResult(
                true,
                "Respostas: ",
                answers
            );
        }

    }
}