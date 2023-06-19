using StudentsRM.Helper;
using StudentsRM.Models;
using StudentsRM.Models.Auth;
using StudentsRM.Models.User;
using StudentsRM.Repository.Interface;
using StudentsRM.Service.Interface;

namespace StudentsRM.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public UserResponseModel GetUser(string userId)
        {
            var response = new UserResponseModel();
            var user = _unitOfWork.Users.GetUser(x => x.Id == userId);

            if (user is null)
            {
                response.Message = $"User with {userId} does not exist";
                return response;
            }

            response.Data = new UserViewModel
            {
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.RoleName,
            };
            response.Message = $"User successfully retrieved";
            response.Status = true;

            return response;
        }

        public UserResponseModel Login(LoginViewModel request)
        {
            var response = new UserResponseModel();
            try
            {
                var user = _unitOfWork.Users.GetUser(x =>  
                x.Email.ToLower() == request.Email.ToLower());

                if (user is null)
                {
                    response.Message = $"Account does not exist!";
                    return response;
                }

                string hashedPassword = HashingHelper.HashPassword(request.Password, user.HashSalt);

                if (!user.PasswordHash.Equals(hashedPassword))
                {
                    response.Message = $"Incorrect email or password!";
                    return response;
                }

                response.Data = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    RoleName = user.Role.RoleName,
                };
                response.Message = "Welcome";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel UpdatePassword(string userId, UpdateUserViewModel update)
        {
            var response = new BaseResponseModel();
            string modifiedBy = "";
            string saltString = HashingHelper.GenerateSalt();
            string hashedPassword = HashingHelper.HashPassword(update.Password, saltString);
            var userExist = _unitOfWork.Users.Exists(u => u.Id == userId);

            if (!userExist)
            {
                response.Message = "user does not exist.";
                return response;
            }

            var user = _unitOfWork.Users.Get(userId);
            user.PasswordHash = hashedPassword;
            user.ModifiedBy = modifiedBy;
            
            try
            {
                _unitOfWork.Users.Update(user);
                _unitOfWork.SaveChanges();
                response.Message = "Password updated successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update the user: {ex.Message}";
                return response;
            }
        }
    }
}