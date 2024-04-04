

namespace programacao_do_zero.Models
{
    public class veiculo
    {
        public veiculo()
        {
            combustivel = 40;
        }

        public string cor { get; set; }

        public string marca { get; set; }

        public string placa { get; set; }

        public string modelo { get; set; }

        public int combustivel { get; set; }

        public void acelerar()
        {
         
                combustivel = combustivel - 1;
                
            
        }
        public void frear()
        {

        }
    }
}
