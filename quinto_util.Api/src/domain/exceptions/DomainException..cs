

namespace quinto_util.Api.src.domain.exceptions
{
    public class DomainException: Exception
    {
        private const string DefaultMessage = "Ação não permitida dentro do domínio do negócio.";

        public DomainException(): base(DefaultMessage) {}
        public DomainException(string message): base(message) {}
    }
}