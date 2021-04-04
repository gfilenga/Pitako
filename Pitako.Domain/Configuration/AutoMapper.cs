
using AutoMapper;
using Pitako.Domain.Commands;
using Pitako.Domain.Entities;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        // User
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserPasswordCommand>().ReverseMap();

        // Question
        CreateMap<Question, CreateQuestionCommand>().ReverseMap();
        CreateMap<Question, DeleteQuestionCommand>().ReverseMap();
        CreateMap<Question, ToggleActiveCommand>().ReverseMap();
        CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
        CreateMap<Question, ListQuestionsCommand>().ReverseMap();

        // Answer
        CreateMap<Answer, CreateAnswerCommand>().ReverseMap();
        CreateMap<Answer, DeleteAnswerCommand>().ReverseMap();
        CreateMap<Answer, ToggleActiveAnswerCommand>().ReverseMap();
        CreateMap<Answer, UpdateAnswerCommand>().ReverseMap();
    }
}