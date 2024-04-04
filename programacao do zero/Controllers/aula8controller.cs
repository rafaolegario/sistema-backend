using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programacao_do_zero.Controllers

{
    [Route("api/aula8")]
    [ApiController]
    public class aula8controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string olaMundo()
        {
            var mensagem = "OLA MUNDO API";
            return mensagem;
        }

        [Route("olapersonalizado")]
        [HttpGet]
        public string olapersonalizado(string nome)
        {
            var mensagem = "ola mundo via API " + nome;
            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string somar(int valor1,int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = "A SOMA É " + soma;

            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string media(int valor1, int valor2)
        {
            var media = (valor1 + valor2)/2;

            var mensagem = "A MEDIA É " + media;

            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]
        public string terreno(int larg, int comp, int m2)
        {
            var terreno = (larg*comp);
            var valor = terreno * m2;

            var mensagem = "A AREA DO TERRENO É " + terreno+ "\n";
            var mensagem2 = "O VALOR DO M2 É " + valor;

            return mensagem + mensagem2;
          
        }
        
        [Route("troco")]
        [HttpGet]
        public string troco(int unit, int qnt, int vldado)
        {
            var vlproduto= (unit * qnt);
            var vtroco = vldado-vlproduto;

            var mensagem = "O PREÇO DO PRODUTO É R$" + vlproduto + "\n";
            var mensagem2 = "O TROCO DEVE SER DE R$" + vtroco;

            return mensagem + mensagem2;

        }

        [Route("pagamento")]
        [HttpGet]
        public string pagamento(string nome, int vlhora, int hrstb)
        {
            var salario = (vlhora * hrstb);

            var mensagem = nome+" RECEBE R$" + salario + " DE SALARIO";

            return mensagem;

        }

        [Route("consumo")]
        [HttpGet]
        public string consumo( int kmperc, int Litrosgst)
        {
            var consumo = (kmperc/Litrosgst);

            var mensagem = "O consumo médio do veículo é de " +consumo+"km"+" por litro" ;

            return mensagem;

        }
    }
}
