namespace BravoSix.Models;

public class DetailsVM
{
    public Operador Anterior { get; set; }
    public Operador Atual { get; set; }
    public Operador Proximo { get; set; }
    public List<Funcao> Funcoes { get; set; }
}