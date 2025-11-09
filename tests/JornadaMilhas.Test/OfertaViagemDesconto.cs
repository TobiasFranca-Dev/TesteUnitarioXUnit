using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            // Arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(DateTime.Now, DateTime.Now.AddDays(10));
            double precoOriginal = 100.00;
            double desconto = 20.00;
            double precoComDesconto = precoOriginal - desconto;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco);

        }


        [Fact]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
        {
            // Arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(DateTime.Now, DateTime.Now.AddDays(10));
            double precoOriginal = 100.00;
            double desconto = 120.00;
            double precoComDesconto = 30.00;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }


        [Fact]
        public void RetornaPrecoOriginalQuandoValorDescontoNegativo()
        {
            // Arrange
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new Periodo(DateTime.Now, DateTime.Now.AddDays(10));
            double precoOriginal = 100.00;
            double desconto = -20.00;
            double precoComDesconto = precoOriginal;
            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            // Act
            oferta.Desconto = desconto;

            // Assert
            Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
        }
    }
}
