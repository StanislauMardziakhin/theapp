namespace TheApp.Constants;

public static class Messages
{
    public static class Auth
    {
        public const string AccountBlocked = "Your account is blocked.";
        public const string EmailNotRegistered = "Email is not registered.";
        public const string InvalidCredentials = "Invalid email or password.";
        public const string EmailAlreadyRegistered = "Email is already registered.";
        public const string RegistrationError = "An error occurred during registration.";
    }

    public static class Users
    {
        public const string UsersBlocked = "Users have been successfully blocked.";
        public const string UsersUnblocked = "Users have been successfully unblocked.";
        public const string UsersDeleted = "Users have been successfully deleted.";
        public const string SelectAtLeastOneUser = "Select at least one user.";
        public const string InvalidAction = "Invalid action.";
        public const string BlockUserError = "Error blocking user {0}.";
        public const string UnblockUserError = "Error unblocking user {0}.";
        public const string DeleteUserError = "Error deleting user {0}.";
        public const string UserNotFoundWithId = "User with ID {0} not found.";
        public const string SelfBlockRedirect = "You have blocked yourself. Redirecting to the login page...";
        public const string InvalidUserData = "Invalid user data.";
        public const string NoUsersFound = "No users found.";
        public const string TableUpdateError = "Error updating the table.";
        public const string UsersLoadError = "Error loading user data.";
    }

    public static class Common
    {
        public const string Error = "An error occurred.";
    }
}