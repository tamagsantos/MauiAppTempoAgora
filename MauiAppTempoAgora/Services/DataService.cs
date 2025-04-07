using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MauiAppTempoAgora.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace MauiAppTempoAgora.Services
{
    public class DataService
    {
        public static async Task<Tempo?> GetPrevisao(string cidade)
        {
            Tempo? t = null;

            //definição da variavel chave
            string chave = "a1ff34dd681c41fe84492d61843185ae";

            //usado $ para interpilação da string
            string url = $"https://api.openweathermap.org/data/2.5/weather?" +
                $"q={cidade}&units=metric&appid={chave}";


            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(url);

                if(resp.IsSuccessStatusCode)
                {
                    string json = await resp.Content.ReadAsStringAsync();

                    var rascunho = JObject.Parse(json);

                    DateTime time = new();
                    DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                    DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunset"]).ToLocalTime();


                    t = new()
                    {
                        lat = (double)rascunho["coord"]["lat"],
                        lon = (double)rascunho["coord"]["lon"],
                        description = (string)rascunho["weather"][0]["description"],
                        main = (double)rascunho["weather"][0]["main"],
                        temp_min = (double)rascunho["main"]["temp_min"],
                        temp_max = (double)rascunho["main"]["temp_max"],
                        speed = (double)rascunho["wind"]["speed"], 
                        visibility = (int)rascunho["visibility"],
                        sunrise = sunrise.ToString(),
                        sunset = sunset.ToString(),
                        
                    };// Fecha obj do tempo.
                }// Fecha if se o status do servidor foi de sucesso
            } // Fecha laço using

                return t;
        }
    }
}
