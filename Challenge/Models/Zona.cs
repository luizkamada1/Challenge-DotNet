using Challenge.Models;

public class Zona
{
    public int Id { get; set; }
    public string NomeZona { get; set; }
    public string TipoFuncional { get; set; }
    public int QtdVagas { get; set; }
    public int PatioId { get; set; }  

    public Patio? Patio { get; set; }
    public ICollection<Moto> Motos { get; set; } = new List<Moto>();
    public ICollection<SensorRFID> Sensores { get; set; } = new List<SensorRFID>();
}
