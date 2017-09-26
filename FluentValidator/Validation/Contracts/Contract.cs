namespace FluentValidator.Validation
{
    public abstract class Contract : Notifiable
    {
        protected Contract()
        {
            ValidationContract = new ValidationContract();
        }

        public ValidationContract ValidationContract { get; set; }
    }
}