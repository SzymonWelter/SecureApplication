using SecureServer.Models.DAL;
using SecureServer.Models.Domain;
using SecureServer.Models.DTO;

namespace SecureServer.Services
{
    internal class MapService : IMapService
    {
        public NoteModel Map(NoteDAL noteDal)
        {
            return new NoteModel
            {
                NoteId = noteDal.NoteId,
                Title = noteDal.Title,
                Text = noteDal.Text,
                IsPublic = noteDal.IsPublic
            };
        }

        public NoteDTO Map(NoteModel noteModel){
            return new NoteDTO
            {
                NoteId = noteModel.NoteId,
                Title = noteModel.Title,
                Text = noteModel.Text,
                IsPublic = noteModel.IsPublic
            };
        }

        public NoteModel Map(NoteDTO noteModel){
            return new NoteModel
            {
                NoteId = noteModel.NoteId,
                Title = noteModel.Title,
                Text = noteModel.Text,
                IsPublic = noteModel.IsPublic
            };
        }

        public NoteDAL MapToDAL(NoteModel noteModel){
            return new NoteDAL
            {
                NoteId = noteModel.NoteId,
                Title = noteModel.Title,
                Text = noteModel.Text,
                IsPublic = noteModel.IsPublic
            };
        }

        public UserDAL MapToDAL(UserModel userModel)
        {
            return new UserDAL{
                UserId = userModel.UserId,
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email
            };
        }
        public UserModel Map(UserDTO userDTO)
        {
            return new UserModel{
                Username = userDTO.Username,
                Password = userDTO.Password,
                Email = userDTO.Email
            };
        }

        public RequestResultDTO Map(RequestResultModel requestResultModel){
            return new RequestResultDTO{
                IsSuccess = requestResultModel.IsSuccess,
                Message = requestResultModel.Message
            };
        }

        public UserModel Map(SignInDTO signInDTO)
        {
            return new UserModel{
                Username = signInDTO.Username,
                Password = signInDTO.Password
            };
        }

        public RequestResultDTO Map(AuthResultModel result)
        {
            return new RequestResultDTO{
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }
    }
}