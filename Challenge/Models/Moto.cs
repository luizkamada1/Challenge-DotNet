using System;

namespace Challenge.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string RfidTag { get; set; }
        public string StatusMoto { get; set; }
        public int ZonaId { get; set; }
        public int PosicaoZona { get; set; }
        public DateTime DataCadastro { get; set; }

        public Zona? Zona { get; set; }
    }
}
