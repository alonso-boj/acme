namespace ACME.Store.Domain.Constants;

public static class ValidationErrorMessages
{
    #region Customer

    public const string NAME_NOT_EMPTY = "Name cannot be empty or null";

    public const string NAME_LENGTH = "Name must be between 3 and 128 characters";

    public const string PHONE_NOT_EMPTY = "Phone cannot be empty or null";

    public const string PHONE_LENGTH = "Phone must be exactly 11 characters";

    public const string MAIL_NOT_EMPTY = "Mail cannot be empty or null";

    public const string INVALID_MAIL = "Mail must be a valid e-mail address";

    #endregion

    #region Address

    public const string STREET_NOT_EMPTY = "Street cannot be empty or null";

    public const string STREET_LENGTH = "Street must be between 3 and 128 characters";

    public const string NUMBER_NOT_EMPTY = "Number cannot be null or zero";

    public const string COMPLEMENT_NOT_NULL = "Complement cannot be null";

    public const string COMPLEMENT_LENGTH = "Complement must be between 3 and 128 characters";

    public const string NEIGHBORHOOD_NOT_EMPTY = "Neighborhood cannot be empty or null";

    public const string NEIGHBORHOOD_LENGTH = "Neighborhood must be between 3 and 128 characters";

    public const string CITY_NOT_EMPTY = "City cannot be empty or null";

    public const string CITY_LENGTH = "City must be between 3 and 128 characters";

    public const string STATE_NOT_EMPTY = "State cannot be empty or null";

    public const string STATE_LENGTH = "State must be between 3 and 64 characters";

    public const string ZIPCODE_NOT_EMPTY = "ZipCode cannot be null or zero";

    public const string ZIPCODE_LENGTH = "ZipCode must be exactly 8 characters";

    #endregion
}
