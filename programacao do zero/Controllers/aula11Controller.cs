using programacao_do_zero.Models;
using Microsoft.AspNetCore.Mvc;


namespace programacao_do_zero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class aula11Controller : ControllerBase
    {
        [Route("veiculo")]
        [HttpGet]
        public veiculo obterveiculo()
        {
            var meuVeiculo = new veiculo();

            meuVeiculo.cor = "vermelha";
            meuVeiculo.marca = "ferrari";
            meuVeiculo.modelo = "488 PISTA.";
            meuVeiculo.placa = "XXF-2234";

            meuVeiculo.acelerar();

            return meuVeiculo;
        }
        [Route("carro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.cor = "preto";
            meuCarro.marca = "ferrari";
            meuCarro.modelo = "488 PISTA.";
            meuCarro.placa = "XXF-2234";
            

            return meuCarro;
        }
        [Route("moto")]
        [HttpGet]
        public moto obterMoto()
        {
            var minhaMoto = new moto();

            minhaMoto.cor = "Verde";
            minhaMoto.modelo = "Fazer 250";
            minhaMoto.marca = "Yamaha";
            minhaMoto.placa = "TDS-1244";

            return minhaMoto;
        }

    }
}
