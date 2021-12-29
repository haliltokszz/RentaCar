namespace Core.Constants
{
    public static class CoreAspectMessages
    {
        #region ValidationAspectMessages
        public static string WrongValidationType = "Wrong Validation Type";
        public static string CanNotBeBlank = "Can not be blank.";
        public static string InvalidEmailAddress = "Email Address in Invalid Format.";
        #endregion 
        
        #region SecuredAspectMessages
        public static string AuthorizationDenied = "You are not authorized.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password is wrong.";
        public static string SuccessfulLogin = "Login to the system is successful.";
        public static string UserAlreadyExists = "This user already exists.";
        public static string UserRegistered = "User successfully registered.";
        public static string AccessTokenCreated = "Access token successfully created. ";
        #endregion

        #region UserOperationClaim
        public static string UserOperationClaimAdded = "User operation claim has added.";
        public static string UserOperationClaimUpdated = "User operation claim has updated.";
        public static string UserOperationClaimDeleted = "User operation claim has deleted.";
        #endregion

        #region OperationClaim
        public static string OperationClaimAdded = "Operation claim has added.";
        public static string OperationClaimUpdated = "Operation claim has updated.";
        public static string OperationClaimDeleted = "Operation claim has deleted.";
        #endregion
        
    }
}