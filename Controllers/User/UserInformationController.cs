using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LayerApi.Contrllers.User.UserInformationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public UserInformationController(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        [HttpPost("RegisterUserInformation")]
        public async Task<bool> RegisterUserInformation([FromBody] UserInformation userInformation)
        {
            bool isRegistered = false;
            isRegistered = await _userInformationRepository.RegisterUserInformation(userInformation);
            return isRegistered;
        }

        // [HttpPost("LoginUserInformation")]
        // public async Task<UserInformation> LoginUserInformation([FromBody] UserInformation userInformation)
        // {
        //     UserInformation userInformation = null;
        //     userInformation = await _userInformationRepository.LoginUserInformation(userInfo);
        //     return userInformation;
        // }
    }
}
