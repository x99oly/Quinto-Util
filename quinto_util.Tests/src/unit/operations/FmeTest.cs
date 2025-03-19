using System;
using Xunit;
using quinto_util.Api.src.domain.entities; // Ajuste o namespace conforme necessário
using quinto_util.Api.src.domain.enums;   // Para acessar CurrencyEnum
using quinto_util.Api.src.domain.exceptions;
using quinto_util.Api.src.domain.operations;

namespace quinto_util.Tests.src.unit.operations
{
    public class FmeTests
    {
        private readonly Fme _fme;

        public FmeTests()
        {
            _fme = new Fme(); // Inicializando a classe Fme
        }

        // Teste de Soma
        [Fact]
        public void TestSum()
        {
            // Arrange
            var money1 = new Money(10, CurrencyEnum.BRL);
            var money2 = new Money(20, CurrencyEnum.BRL);
            var expected = new Money(30, CurrencyEnum.BRL);

            // Act
            var result = _fme.Sum(money1, money2);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de Subtração
        [Fact]
        public void TestSubtract()
        {
            // Arrange
            var money1 = new Money(30, CurrencyEnum.BRL);
            var money2 = new Money(10, CurrencyEnum.BRL);
            var expected = new Money(20, CurrencyEnum.BRL);

            // Act
            var result = _fme.Subtract(money1, money2);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de Multiplicação
        [Fact]
        public void TestMultiply()
        {
            // Arrange
            var money1 = new Money(5, CurrencyEnum.USD);
            var money2 = new Money(6, CurrencyEnum.USD);
            var expected = new Money(30, CurrencyEnum.USD);

            // Act
            var result = _fme.Multiply(money1, money2);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de Divisão
        [Fact]
        public void TestDivide()
        {
            // Arrange
            var money1 = new Money(20, CurrencyEnum.BRL);
            var money2 = new Money(4, CurrencyEnum.BRL);
            var expected = new Money(5, CurrencyEnum.BRL);

            // Act
            var result = _fme.Divide(money1, money2);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de Percentual
        [Fact]
        public void TestPercent()
        {
            // Arrange
            var money1 = new Money(50, CurrencyEnum.BRL);
            var money2 = new Money(200, CurrencyEnum.BRL);
            var expected = 25m;

            // Act
            var result = _fme.Percent(money1, money2);

            // Assert
            Assert.Equal(expected, result);
        }

        // Teste de Potência
        [Fact]
        public void TestPow()
        {
            // Arrange
            var money = new Money(2, CurrencyEnum.BRL);
            var expected = new Money(8, CurrencyEnum.BRL); // 2^3 = 8

            // Act
            var result = _fme.Pow(money, 3);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de Raiz
        [Fact]
        public void TestRad()
        {
            // Arrange
            var money = new Money(16, CurrencyEnum.BRL);
            var expected = new Money(4, CurrencyEnum.BRL); // √16 = 4

            // Act
            var result = _fme.Rad(money, 2);

            // Assert
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.Currency, result.Currency);
        }

        // Teste de exceção ao tentar operar com moedas diferentes
        [Fact]
        public void TestDifferentCurrencyException()
        {
            // Arrange
            var money1 = new Money(10, CurrencyEnum.BRL);
            var money2 = new Money(10, CurrencyEnum.USD);

            // Act & Assert
            Assert.Throws<DomainException>(() => _fme.Sum(money1, money2));
        }

        // Teste de exceção ao tentar dividir por zero
        [Fact]
        public void TestDivideByZeroException()
        {
            // Arrange
            var money1 = new Money(10, CurrencyEnum.BRL);
            var money2 = new Money(0, CurrencyEnum.BRL);

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _fme.Divide(money1, money2));
        }
    }
}
