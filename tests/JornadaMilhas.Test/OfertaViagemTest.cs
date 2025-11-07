using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTest
    {
        [Fact]
        public void TestandoOfertaValida()
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
        public void TestandoOfertaComRotaNula()
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
    }
}