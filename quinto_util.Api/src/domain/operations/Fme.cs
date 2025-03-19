using quinto_util.Api.src.domain.entities;
using quinto_util.Api.src.domain.exceptions;

namespace quinto_util.Api.src.domain.operations
{
    public class Fme
    {
        public Money Sum(Money x, Money y)
        {
            if (!x.HasSameCurrency(y))
            {
                throw new DomainException("Os valores devem estar na mesma moeda.");
            }
            return new Money(x.Amount + y.Amount, x.Currency);
        }

        public Money Subtract(Money x, Money y)
        {
            if (!x.HasSameCurrency(y))
            {
                throw new DomainException("Os valores devem estar na mesma moeda.");
            }
            return new Money(x.Amount - y.Amount, x.Currency);
        }

        public Money Multiply(Money x, Money y)
        {
            if (!x.HasSameCurrency(y))
            {
                throw new DomainException("Os valores devem estar na mesma moeda.");
            }
            return new Money(x.Amount * y.Amount, x.Currency);
        }

        public Money Divide(Money x, Money y)
        {
            if (!x.HasSameCurrency(y))
            {
                throw new DomainException("Os valores devem estar na mesma moeda.");
            }
            if (y.Amount == 0)
            {
                throw new DomainException("Não é possível dividir por zero.");
            }
            return new Money(x.Amount / y.Amount, x.Currency);
        }

        public decimal Percent(Money x, Money y)
        {
            if (!x.HasSameCurrency(y))
            {
                throw new DomainException("Os valores devem estar na mesma moeda.");
            }
            if (y.Amount == 0)
            {
                throw new DomainException("O total a ser mensurado deve ser maior que 0.");
            }
            return (x.Amount * 100) / y.Amount;       
        }

        public Money Pow(Money x, int y)
        {
            return new Money((decimal)Math.Pow((double)x.Amount, y), x.Currency);
        }

        public Money Rad(Money x, int y)
        {
            if (y == 0)
            {
                throw new DomainException("O índice da raiz deve ser maior que 0.");
            }
            return new Money((decimal)Math.Pow((double)x.Amount, 1.0 / y), x.Currency);
        }
    }
}
