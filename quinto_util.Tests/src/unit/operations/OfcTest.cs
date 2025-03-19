using Xunit;
using quinto_util.Api.src.domain.entities;
using quinto_util.Api.src.domain.enums;
using quinto_util.Api.src.domain.operations;
using quinto_util.Api.src.domain.exceptions;
using System;

namespace quinto_util.Tests.src.unit.operations
{
    public class OfcTests
    {
        private readonly Ofc _ofc;

        public OfcTests()
        {
            _ofc = new Ofc();
        }

        [Fact]
        public void PresentValue_WithPMT_ReturnsCorrectValue()
        {
            Money fv = new Money(1000, CurrencyEnum.BRL);
            Money pmt = new Money(100, CurrencyEnum.BRL);
            float i = 0.05f;
            float n = 10;

            Money result = _ofc.PresentValue(fv, pmt, i, n);

            Assert.NotNull(result);
            Assert.Equal(CurrencyEnum.BRL, result.Currency);
        }

        [Fact]
        public void PresentValue_WithoutPMT_ReturnsCorrectValue()
        {
            Money fv = new Money(1000, CurrencyEnum.BRL);
            float i = 0.05f;
            float n = 10;

            Money result = _ofc.PresentValue(fv, i, n);

            Assert.NotNull(result);
            Assert.Equal(CurrencyEnum.BRL, result.Currency);
        }

        [Fact]
        public void FutureValue_WithPMT_ReturnsCorrectValue()
        {
            Money pv = new Money(1000, CurrencyEnum.BRL);
            Money pmt = new Money(100, CurrencyEnum.BRL);
            float i = 0.05f;
            float n = 10;

            Money result = _ofc.FutureValue(pv, pmt, i, n);

            Assert.NotNull(result);
            Assert.Equal(CurrencyEnum.BRL, result.Currency);
        }

        [Fact]
        public void FutureValue_WithoutPMT_ReturnsCorrectValue()
        {
            Money pv = new Money(1000, CurrencyEnum.BRL);
            float i = 0.05f;
            float n = 10;

            Money result = _ofc.FutureValue(pv, i, n);

            Assert.NotNull(result);
            Assert.Equal(CurrencyEnum.BRL, result.Currency);
        }

        [Fact]
        public void PresentValue_DifferentCurrencies_ThrowsException()
        {
            Money fv = new Money(1000, CurrencyEnum.BRL);
            Money pmt = new Money(100, CurrencyEnum.USD);
            float i = 0.05f;
            float n = 10;

            Assert.Throws<DomainException>(() => _ofc.PresentValue(fv, pmt, i, n));
        }
    }
}
