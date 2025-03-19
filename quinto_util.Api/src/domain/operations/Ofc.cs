using quinto_util.Api.src.domain.entities;
using quinto_util.Api.src.domain.exceptions;
using quinto_util.Api.src.domain.enums;
using quinto_util.Api.src.domain.operations;

namespace quinto_util.Api.src.domain.operations
{
    public class Ofc
    {
        private Fme _fme = new Fme();

        public Money PresentValue(Money fv, Money pmt, float i, float n)
        {
            if (!fv.HasSameCurrency(pmt)) throw new DomainException("Os valores devem estar na mesma moeda.");
            if (!IsPeriodAndTaxOk(i,n)) return new Money(0, fv.Currency);

            double df = DiscountFactor(i,n);

            return _fme.Sum( PresentValue(fv,i,n), _fme.Multiply(pmt, df) );
        }
        public Money PresentValue(Money fv, float i, float n)
        {
            if (!IsPeriodAndTaxOk(i,n)) return new Money(0, fv.Currency);

            return _fme.Divide( fv, Math.Pow( (1+i),n ) );
        }

        public Money FutureValue(Money pv, Money pmt, float i, float n)
        {
            if (!pv.HasSameCurrency(pmt)) throw new DomainException("Os valores devem estar na mesma moeda.");
            if (!IsPeriodAndTaxOk(i,n)) return new Money(0, CurrencyEnum.BRL);

            Money sfv = FutureValue(pv,i,n);
            Money cfv = _fme.Multiply( pmt, ((Math.Pow((1+i),n))-1)*i );

            return _fme.Sum(sfv,cfv);
        }

        public Money FutureValue(Money pv, float i, float n)
        {
            if (!IsPeriodAndTaxOk(i,n)) return new Money(0, pv.Currency);

            return _fme.Multiply(pv, Math.Pow((1+i),n));
        }

        private double DiscountFactor(float i, float n) => ( (Math.Pow((1-(1+i)), -n)/i)*(1+i) );
        private double DiscountFactor(float i, int n) => ( (Math.Pow((1-(1+i)), -n)/i)*(1+i) );

        private bool IsPeriodAndTaxOk(float i, float n) => i > 0 && n > 0;

    }
}