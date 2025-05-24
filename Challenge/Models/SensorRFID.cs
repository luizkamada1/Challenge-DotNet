public class SensorRFID
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int ZonaId { get; set; }  // FK

    public string TipoSensor { get; set; }
    public string Ativo { get; set; }

    public Zona? Zona { get; set; } 
}
