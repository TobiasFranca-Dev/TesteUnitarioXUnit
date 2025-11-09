using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2025-01-01", "2025-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2025-01-10", "2025-01-20", 100, true)]
        [InlineData(null, "São Paulo", "2025-01-01", "2025-01-02", -1, false)]
        [InlineData("Vitória", "São Paulo", "2025-01-01", "2025-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2025-01-01", "2025-01-02", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string datatIda, string dataVolta, double preco, bool validacao)
        {
            //Cenário - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(datatIda), DateTime.Parse(dataVolta));

            //Ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - assert
            Assert.Equal(validacao, oferta.EhValido);
        }


        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidoQuandoRotaNula()
        {
            //Cenário - arrange
            Rota rota = null;
            Periodo periodo = new Periodo(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            double preco = 100;

            //Ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - assert
            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }


        [Fact]
        public void RetornaMensagemDeErroDeDataInvalidaQuandoDataFinalMaiorQueDataInicial()
        {
            //Cenário - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Now.AddDays(10), DateTime.Now.AddDays(-10));
            double preco = 100;

            //Ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - assert
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }


        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            //Cenário - arrange
            Rota rota = new Rota("Origem1", "Destino1");
            Periodo periodo = new Periodo(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            double preco = -250;

            //Ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}