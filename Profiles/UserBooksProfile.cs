using AutoMapper;
using BiblioApi.Dtos.UserBook;
using BiblioApi.Entities;

namespace BiblioApi.Profiles
{
  public class UserBooksProfile : Profile
  {
    public UserBooksProfile()
    {
      // Source Model -> Target Model
      CreateMap<UserBook, UserBookDto>();
      CreateMap<CreateUserBookDto, UserBook>();
      CreateMap<UpdateUserBookDto, UserBook>();
      // For PATCH we need to be able to create the updateDTO from the base model
      CreateMap<UserBook, UpdateUserBookDto>();
    }
  }
}