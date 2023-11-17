using AutoMapper;
using EnvioDeEmail.Domain.Entities;
using EnvioDeEmail.Communication.Request;

namespace EnvioDeEmail.Application.Services.AutoMapper;
public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        EntityToResponse();
    }

    private void EntityToResponse()
    {
        CreateMap<RequestSendMailJson, Mail>();
    }
}
