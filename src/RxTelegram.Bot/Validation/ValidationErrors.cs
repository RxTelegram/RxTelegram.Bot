namespace RxTelegram.Bot.Interface.Validation
{
    public enum ValidationErrors
    {
        [ValidationErrorsString("ID lower than 1 is not allowed.")]
        IdLowerThanOne,

        [ValidationErrorsString("Field is not set, but required")]
        FieldRequired,

        [ValidationErrorsString("Only one of there properties can be set")]
        OnlyONePropertyCanBeSet,

        [ValidationErrorsString("One of these properties need to be set")]
        NonePropertySet
    }
}
