using Challenge.Models;

public class Patio
{
    public int Id { get; set; }
    public string NomeFilial { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public int CapacidadeTotal { get; set; }
    public string StatusOperacao { get; set; }

    public ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}
