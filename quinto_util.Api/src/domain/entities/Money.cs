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

    public override // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())  return false;
        
        Money o = obj as Money;
        if (o == null) return false;

        return this.Amount == o.Amount && this.Currency == o.Currency;        
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }

    }
}