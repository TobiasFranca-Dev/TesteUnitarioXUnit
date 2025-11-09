using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            //Cenário - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            double preco = 100;

            var validacao = true;

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