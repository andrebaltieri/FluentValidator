namespace FluentValidator.Validation
{
    public partial class ValidationContract : Notifiable
    {
        public ValidationContract Requires()
        {
            return this;
        }
    }
}
