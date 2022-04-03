using System.Data;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if(placa.Length == 8 && placa != null){
                veiculos.Add(placa);
            }
            else 
            {
                Console.WriteLine("Placa inválida: Verifica a placa do veiculo novamente");
                return;
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            
            string placa = Console.ReadLine();

            
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a hora de entrada doveículo (formato HH:mm):");
                DateTime entrada = DateTime.ParseExact(Console.ReadLine(), "HH:mm:", null);

                Console.WriteLine("Digite a hora de saída do veículo (formato HH:mm)");
                DateTime saida = DateTime.ParseExact(Console.ReadLine(), "HH:mm",null);

                TimeSpan duracao = saida - entrada;
                int horasEstacionado = (int)duracao.TotalHours;

                
            
                decimal valorTotal = precoInicial + (precoPorHora *  horasEstacionado);

                veiculos.Remove (placa); 




                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                

                foreach (var veiculos in veiculos){
                    Console.WriteLine(veiculos);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

