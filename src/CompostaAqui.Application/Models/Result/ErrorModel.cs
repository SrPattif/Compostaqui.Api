namespace CompostaAqui.Application.Models.Result
{
    public class ErrorModel : IEquatable<ErrorModel>
    {
        public string Code { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string MessageCustomer { get; set; } = null!;

        public bool Equals(ErrorModel other)
        {
            return other != null &&
                   Code == other.Code &&
                   Message == other.Message &&
                   MessageCustomer == other.MessageCustomer;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ErrorModel);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Message, MessageCustomer);
        }
    }
}
