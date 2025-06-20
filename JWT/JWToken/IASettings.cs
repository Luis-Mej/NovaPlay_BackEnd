using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Configuracion
{
    public class IASettings
    {
        [Required(ErrorMessage = "El ApiKey es obligatorio.")]
        public string ApiKey { get; set; }

        [Required(ErrorMessage = "La URL del modelo por defecto es obligatoria.")]
        [Url(ErrorMessage = "El campo DefaultModelUrl debe ser una URL válida.")]
        public string DefaultModelUrl { get; set; }

        public Dictionary<string, string> ModelUrls { get; set; } = new();

        public string GetModelUrl(string nombreModelo = null)
        {
            if (!string.IsNullOrEmpty(nombreModelo) && ModelUrls.TryGetValue(nombreModelo, out var url))
            {
                return url;
            }

            return DefaultModelUrl;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new InvalidOperationException("Falta el ApiKey de Hugging Face en la configuración.");
            if (string.IsNullOrWhiteSpace(DefaultModelUrl))
                throw new InvalidOperationException("Falta la URL del modelo por defecto en la configuración.");
        }
    }
}
