public interface IUserInformationRepository
{
    Task<bool> RegisterUserInformation(UserInformation userInformation);
    // Task<UserInformation> LoginUserInformation(UserInformation userInformation);
}