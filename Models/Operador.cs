using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace BravoSix.Models
{
    public class Operador
    {
        public int  Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Função { get; set; }
        public List<string> Classe { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Imagem { get; set; }

        public Operador()
        {
            Classe = new();
        }
        
    }
}