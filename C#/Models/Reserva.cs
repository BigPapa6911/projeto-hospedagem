namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool validacaoCapacidadeHospedes = hospedes.Count() >= Suite.Capacidade ? false : true;
            if (validacaoCapacidadeHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("O numero de hospedes excede a capacidade da suíte!!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int numeroDeHospedes = Hospedes.Count();
            return numeroDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            double valor = (double)(DiasReservados * Suite.ValorDiaria);

            bool concederDesconto = DiasReservados >= 10 ? true : false;
            if (concederDesconto)
            {
                valor = valor - valor*0.1;
            }

            return (decimal)valor;
        }
    }
}