using SecureServer.Models.DAL;
using SecureServer.Models.Domain;
using SecureServer.Models.DTO;

namespace SecureServer.Services
{
    public interface IMapService
    {
        NoteModel Map(NoteDAL noteDal);
        NoteDTO Map(NoteModel noteModel);
        UserDAL Map(UserModel userModel);
        UserModel Map(UserDTO userDTO);
        RequestResultDTO Map(RequestResultModel requestResultModel);
        UserModel Map(SignInDTO signInDTO);
        RequestResultDTO Map(AuthResultModel result);
    }
}