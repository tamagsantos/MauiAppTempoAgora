﻿namespace MauiAppTempoAgora.Models
{
    public class Tempo
    {

        public double? lon { get; set; }
        public double? lat { get; set; }
        public double? temp_min { get; set; }
        public double? temp_max { get; set; }
        public int? visibility { get; set; }
        public double? speed { get; set; }
        public double? main { get; set; }
        public string? description { get; set; }
        public string? sunrise { get; set; }
        public string? sunset { get; set; }



    }
}



public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
  
    public int pressure { get; set; }
    public int humidity { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
}

