using CsvHelper.Configuration.Attributes;

namespace Worker.Gtfs.Feeder.Library.Models
{
    public class GtfsModel
    {
        [Name("Transportas")]
        public string TransportType { get; set; }
        
        [Name("Marsrutas")]
        public string Route { get; set; }
        
#nullable enable
        
        [Name("ReisoID")]
        public long? TripId { get; set; }
        
        [Name("MasinosNumeris")]
        public string? CarNumber { get; set; }
        
        [Name("Ilguma")]
        public long? Longitude { get; set; }
        
        [Name("Platuma")]
        public long? Latitude { get; set; }
        
        [Name("Greitis")]
        public int? Speed { get; set; }
        
        [Name("Azimutas")]
        public int? Azimuth { get; set; }
        
        [Name("ReisoPradziaMinutemis")]
        public int? TripStartInMinutes { get; set; }
        
        [Name("NuokrypisSekundemis")]
        public int? DeviationInSeconds { get; set; }
        
        [Name("MatavimoLaikas")]
        public int? MeasurementTime { get; set; }
        
        [Name("MasinosTipas")]
        public string? CarType { get; set; }
        
#nullable disable
    }
}