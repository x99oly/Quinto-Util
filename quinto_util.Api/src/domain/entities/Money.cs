using quinto_util.Api.src.domain.enums; 

namespace quinto_util.Api.src.domain.entities
{
    public class Money
    {
    public CurrencyEnum Currency { get; private set; }
    public decimal Amount { get; private set; }

    public Money(decimal amount, CurrencyEnum currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }

    public bool HasSameCurrency(Money other) => other.Currency == Currency;

    public bool IsMoneyZero() => Currency == 0;

    public override bool Equals(object? obj)
    {
        if (obj is not Money o)
        {
            return false;
        }
        return this.Amount == o.Amount && this.Currency == o.Currency;
    }

    }
}