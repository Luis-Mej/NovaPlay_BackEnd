using Dtos;
using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Entities.Context;
using Entities.Models;
using JWT.JWToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class RecomendacionesServicios
    {
        private readonly NovaplayDbContext _context;
        private readonly spotifySettings _spotifySettings;

        public RecomendacionesServicios(NovaplayDbContext context, IOptions<spotifySettings> spotifySettings)
        {
            _context = context;
            _spotifySettings = spotifySettings.Value;
        }

        private async Task<string> ObtenerTokenSpotify()
        {
            using var client = new HttpClient();

            var authHeader = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{_spotifySettings.ClientId}:{_spotifySettings.ClientSecret}")
            );

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"No se pudo obtener el token: {error}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return result["access_token"].ToString();
        }

        public async Task<ResponseBase<List<string>>> ObtenerTopGlobalAsync()
        {
            var token = await ObtenerTokenSpotify();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var playlistId = "37i9dQZEVXbMDoHDwVN2tF";
            var url = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return new ResponseBase<List<string>>(500, "Error al obtener los datos");

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonDocument.Parse(json);
            var canciones = new List<string>();

            foreach (var item in data.RootElement.GetProperty("items").EnumerateArray())
            {
                var track = item.GetProperty("track");
                var nombre = track.GetProperty("name").GetString();
                var artista = track.GetProperty("artists")[0].GetProperty("name").GetString();
                canciones.Add($"{nombre} - {artista}");
            }

            return new ResponseBase<List<string>>(200, "Top global obtenido");
        }

        public async Task<ResponseBase<List<string>>> GetAsync()
        {
            var recomendaciones = await _context.RecomendacionesIa
                .Select(r => r.Recomendacion)
                .ToListAsync();

            return new ResponseBase<List<string>>(200, "Recomendaciones obtenidas");
        }

        public async Task<ResponseBase<string>> PostAsync(RecomendacioneME dto)
        {
            var nueva = new RecomendacionesIum
            {
                Prompt = dto.Prompt,
                Fecha = DateTime.Now
            };

            _context.RecomendacionesIa.Add(nueva);
            await _context.SaveChangesAsync();

            return new ResponseBase<string>(201, "Recomendación creada correctamente");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var recomendacion = await _context.RecomendacionesIa.FindAsync(id);

            if (recomendacion == null)
                return new ResponseBase<string>(404, null, "Recomendación no encontrada");

            _context.RecomendacionesIa.Remove(recomendacion);
            await _context.SaveChangesAsync();

            return new ResponseBase<string>(200, "Recomendación eliminada correctamente");
        }

        public async Task<ResponseBase<List<string>>> RecomendacionesPorGustosAsync(string prompt)
        {
            var token = await ObtenerTokenSpotify();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(prompt)}&type=track&limit=10";

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return new ResponseBase<List<string>>(500, "Error al buscar canciones en Spotify");

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonDocument.Parse(json);
            var canciones = new List<string>();

            foreach (var item in data.RootElement.GetProperty("tracks").GetProperty("items").EnumerateArray())
            {
                var nombre = item.GetProperty("name").GetString();
                var artista = item.GetProperty("artists")[0].GetProperty("name").GetString();
                canciones.Add($"{nombre} - {artista}");
            }

            return new ResponseBase<List<string>>(200, "Recomendaciones generadas", canciones);
        }

    }
}
