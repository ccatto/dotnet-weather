using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace weatherCatto.Models
{
    public class WeatherData
    {
        [Key]
        public int WeatherId { get; set; }

        [JsonProperty("name")]
        public string? Title { get; set; }

        [JsonProperty("coord")]
        public Coord? Coord { get; set; }

        [JsonProperty("weather")]
        public Weather[]? Weather { get; set; }

        [JsonProperty("base")]
        public string? Base { get; set; }

        [JsonProperty("main")]
        public Main? Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind? Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds? Clouds { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("sys")]
        public Sys? Sys { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cod")]
        public long Cod { get; set; }
    }

    public class Clouds
    {
        [Key]
        public int CloudsId { get; set; }
 
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public class Coord
    {
        [Key]
        public int CoordsId { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    public class Main
    {
        [Key]
        public int MainId { get; set; }

        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double temp_max { get; set; }

        [JsonProperty("feels_like")]
        public double feels_like { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string? Visibility { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }
    }

    public class Wind
    {
        [Key]
        public int WindId { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}




