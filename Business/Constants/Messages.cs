namespace Business.Constants
{
    public static class Messages
    {
        #region Car Messages

        public static string CarsListed = "Cars listed.";
        public static string CarRetrieved = "Car retrieved.";
        public static string CarCreated = "Car created.";
        public static string MinDailyPriceError = "Daily price must be greater then 5!";
        public static string CarDeleted = "Car deleted successfully.";
        public static string CarUpdated = "Car updated successfully.";
        public static string CarAdded = "Car added succesfully.";

        #endregion

        #region Company Messages

        public static string CompanyDeleted = "Company deleted successfully.";
        public static string CompanyUpdated = "Company updated successfully.";
        public static string CompanyAdded = "Company added succesfully.";

        #endregion

        #region Brand Messages

        public static string BrandsListed = "Brands listed.";
        public static string BrandRetrieved = "Brand retrieved.";
        public static string BrandCreated = "Brand created.";
        public static string BrandDeleted = "Brand deleted successfully.";
        public static string BrandUpdated = "Brand updated successfully.";

        #endregion

        #region Color Messages

        public static string ColorsListed = "Colors listed.";
        public static string ColorRetrieved = "Color retrieved.";
        public static string ColorCreated = "Color created.";
        public static string ColorDeleted = "Color deleted successfully.";
        public static string ColorUpdated = "Color updated successfully.";

        #endregion

        #region User Messages

        public static string UsersListed = "Users listed.";
        public static string UserRetrieved = "User retrieved.";
        public static string UserCreated = "User created.";
        public static string UserDeleted = "User deleted successfully.";
        public static string UserUpdated = "User updated successfully.";

        #endregion

        #region Customer Messages

        public static string CustomersListed = "Customers listed.";
        public static string CustomerRetrieved = "Customer retrieved.";
        public static string CustomerCreated = "Customer created.";
        public static string CustomerDeleted = "Customer deleted successfully.";
        public static string CustomerUpdated = "Customer updated successfully.";
        public static string DriveExperienceInsufficient = "Drive experience is insufficient to rent this car.";
        public static string CustomerAgeInsufficient = "Customer age is insufficient to rent this car.";

        #endregion

        #region Rental Messages

        public static string RentalsListed = "Rentals listed.";
        public static string RentalCreated = "Rental created.";
        public static string RentalDeleted = "Rental deleted successfully.";
        public static string RentalUpdated = "Rental updated successfully.";
        public static string CarAlreadyRented = "The car is already for rented.";
        public static string RentalUndeliveredCar = "The car has not yet been delivered.";
        public static string RentalDelivered = "The car has been delivered.";
        public static string RentalApproved = "The rental has been approved.";
        public static string RentalNotAvailable = "Rental is not available between the selected dates.";

        #endregion

        #region Findeks Messages

        public static string FindeksAdded = "Findeks point has added.";
        public static string FindeksUpdated = "Findeks point has updated.";
        public static string FindeksDeleted = "Findeks point has deleted.";
        public static string FindeksNotEnoughForCar = "Findeks point is not enough for the car.";
        public static string FindeksNotFound = "You have to add your findeks score.";

        #endregion

        #region CarImage

        public static string CarImageAdded = "Car image has added.";
        public static string CarImageUpdated = "Car image has updated.";
        public static string CarImageDeleted = "Car image has deleted.";
        public static string CarImageCountError = "The images of the car are the maximum number.";

        #endregion

        #region Payment

        public static string PaymentFailed = "Payment failed.";
        public static string PaymentSuccessful = "Payment Successful.";

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

        #region CreditCard

        public static readonly string CreditCardAdded = "Credit card has added.";
        public static readonly string CreditCardDeleted = "Credit card has deleted.";

        #endregion
    }
}