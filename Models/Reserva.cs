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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido

            int capacidade = Suite.Capacidade;
            int quantidadeHospedes = hospedes.Count();

            if (quantidadeHospedes <= capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                try
                {
                    throw new Exception("Capacidade excedida! Não é possível acomodar mais hóspedes.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                }

            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes(List<Pessoa> hospedes)
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quantidadeHospedes = hospedes.Count();

            return quantidadeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valorDiaria = Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = Suite.ValorDiaria * 0.1M;
                valorDiaria = valorDiaria - desconto;
            }
            else
            {
                valorDiaria = Suite.ValorDiaria;
            }

            return valorDiaria;
        }

        public decimal CalcularValorTotal()
        {

            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {

                decimal desconto = Suite.ValorDiaria * 0.1M;

                decimal valorDiaria = Suite.ValorDiaria - desconto;

                valorTotal = DiasReservados * valorDiaria;

            }
            else
            {
                 valorTotal = DiasReservados * Suite.ValorDiaria;
            }

            return valorTotal;
        }
    }
}