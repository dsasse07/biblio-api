using AutoMapper;
using BiblioApi.Dtos.User;
using BiblioApi.Entities;

namespace BiblioApi.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      // Source Model -> Target Model
      CreateMap<User, UserDto>();
      CreateMap<CreateUserDto, User>();
      CreateMap<UpdateUserDto, User>();
      // For PATCH we need to be able to create the updateDTO from the base model
      CreateMap<User, UpdateUserDto>();
    }
  }
}