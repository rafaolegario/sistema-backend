
using System;

namespace programacao_do_zero.Entities
 
{
    public class Usuario
    {
        public int Id { get; set; }

        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string genero { get; set; }

        public string senha { get; set; }

        public Guid usuarioGuid { get; set; }


    }
}
