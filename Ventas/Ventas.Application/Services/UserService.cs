using Ventas.Api.Extensions.Models;
using Ventas.Application.Contracts.Factories;
using Ventas.Application.Contracts.Repositories;
using Ventas.Application.Contracts.Services;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Users;
using Ventas.Application.Exceptions;
using Ventas.Application.Exceptions.Factories;
using Ventas.Application.Extensions.Dtos;
using Ventas.Application.Messages;
using Ventas.Application.Models.Users;
using Ventas.Domain.Entities;

namespace Ventas.Application.Services
{
    public class UserService : BaseService, IUserService<UserCreateDto, UserUpdateDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IExceptionFactory _exceptionFactory;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _exceptionFactory = new UserExceptionFactory();
        }
        public async Task<ServiceResult> Create(UserCreateDto userDto)
        {
            ServiceResult result = new();
            if (userDto.Validate())
            {
                result = this.SetResult(result, false, StatusMessages.POST_INVALID);
                return result;
            }

            Dictionary<string, int> validations = new Dictionary<string, int>() {
                {"NombreCompleto", 100 },
                {"Correo", 40 },
                {"clave",40}
            };

            try
            {
                this.ValidateFields(userDto, validations, _exceptionFactory);
                User user = userDto.ToUser();
                User createdUser = await _userRepository.Create(user);
                UserCreateModel userCreateModel = createdUser.ToCreateUserModel();

                result = this.SetResult(result, true, StatusMessages.POST_SUCCESS, userCreateModel);
            }catch (UserException ex) {
                result = this.SetResult(result, false, StatusMessages.POST_INVALID, ex.Message);
            }catch(Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.POST_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new();
            try
            {
                User? user = await _userRepository.Delete(id);

                if (user == null)
                {
                    result = this.SetResult(result, false, StatusMessages.DELETE_NOTFOUND);
                    return result;
                };

                result = this.SetResult(result, true, StatusMessages.DELETE_SUCCESS, user);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.DELETE_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new();
            try
            {
                List<User> users = await _userRepository.GetEntities();
                List<UserGetModel> usersModels = users.ToGetUserModelList();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, usersModels);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetByDate(bool isDescending)
        {
            ServiceResult result = new();
            try
            {
                List<User> users = await _userRepository.GetByDate(isDescending);
                List<UserGetModel> usersModels = users.ToGetUserModelList();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, usersModels);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new();
            try
            {
                User? user = await _userRepository.GetEntity(id);

                if (user == null)
                {
                    result = this.SetResult(result, false, StatusMessages.GET_NOTFOUND);
                    return result;
                };

                UserGetModel userModel = user.ToGetUserModel();
                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS,userModel);

            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> GetByName(bool isDescending)
        {
            ServiceResult result = new();
            try
            {
                List<User> users = await _userRepository.GetByName(isDescending);
                List<UserGetModel> usersModels = users.ToGetUserModelList();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, usersModels);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetByRole(bool isDescending)
        {
            ServiceResult result = new();
            try
            {
                List<User> users = await _userRepository.GetByRole(isDescending);
                List<UserGetModel> usersModels = users.ToGetUserModelList();

                result = this.SetResult(result, true, StatusMessages.GET_SUCCESS, usersModels);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.GET_FAILURE, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> Update(UserUpdateDto userDto)
        {
            ServiceResult result = new();
            if (userDto.Validate())
            {
                result = this.SetResult(result, false, StatusMessages.PUT_INVALID);
                return result;
            }

            Dictionary<string, int> validations = new Dictionary<string, int>() {
                {"NombreCompleto", 100 },
                {"Correo", 40 },
                {"clave",40}
            };

            try
            {
                this.ValidateFields(userDto, validations, _exceptionFactory);
                User user = userDto.ToUser();
                User updatedUser = await _userRepository.Update(user, userDto.Id);
                if(updatedUser == null)
                {
                    result = this.SetResult(result, false, StatusMessages.PUT_INVALID);
                    return result;
                }
                UserUpdateModel userUpdateModel = updatedUser.ToUpdateUserModel();

                result = this.SetResult(result, true, StatusMessages.PUT_SUCCESS, userUpdateModel);
            }
            catch (UserException ex)
            {
                result = this.SetResult(result, false, StatusMessages.PUT_INVALID, ex.Message);
            }
            catch (Exception ex)
            {
                result = this.SetResult(result, false, StatusMessages.PUT_FAILURE, ex.Message);
            }

            return result;
        }
    }
}
