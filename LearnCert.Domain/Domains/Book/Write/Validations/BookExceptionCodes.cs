namespace LearnCert.Domain.Domains.Book;

public class BookExceptionCodes
{
    public const string TitleNotInformed = "TITLE_NOT_INFOMED";

    public const string TitleMustBeGreaterThanTwoAndLessThanTen =
        "TITLE_MUST_BE_GREATER_THAN_TWO_AND_LESS_THAN_TEN";

    public const string TitleAlreadyUsed = "TITLE_ALREADY_USED";
    public const string BookNotFound = "BOOK_NOT_FOUND";
}