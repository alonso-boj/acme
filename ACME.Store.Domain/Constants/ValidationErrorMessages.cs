namespace ACME.Store.Domain.Constants;

public static class ValidationErrorMessages
{
    public const string NAME_NOT_EMPTY = "Name cannot be empty or null";

    public const string NAME_LENGTH = "Name must be between 3 and 128 characters";

    public const string PHONE_NOT_EMPTY = "Phone cannot be empty or null";

    public const string PHONE_LENGTH = "Phone must be exactly 11 characters";

    public const string MAIL_NOT_EMPTY = "Mail cannot be empty or null";

    public const string INVALID_MAIL = "Mail must be a valid e-mail address";
}
