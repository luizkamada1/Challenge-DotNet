using Challenge.Models;

public class HistoricoMovimentacao
{
    public int Id { get; set; }

    public int MotoId { get; set; }
    public int ZonaId { get; set; }
    public int SensorId { get; set; }

    public DateTime DataMovimentacao { get; set; }
    public string ImagemCapturada { get; set; }
    public string TipoEvento { get; set; }

    public Moto? Moto { get; set; }
    public Zona? Zona { get; set; }
    public SensorRFID? Sensor { get; set; }
}
