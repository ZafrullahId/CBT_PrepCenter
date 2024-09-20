namespace Domain.Common
{
    public abstract class Option : AuditableEntity
    {

        protected Option(string optionContent, char optionAlpha, bool isCorrect, string? imageUrl)
        {
            OptionContent = optionContent;
            OptionAlpha = optionAlpha;
            IsCorrect = isCorrect;
            ImageUrl = imageUrl;
        }

        public string OptionContent { get; set; }
        public char OptionAlpha { get; set; }
        public bool IsCorrect { get; set; }
        public string? ImageUrl { get; set; }

    }
}
