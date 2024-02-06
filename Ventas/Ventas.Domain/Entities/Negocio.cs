using System.ComponentModel.DataAnnotations;


namespace Ventas.Domain.Entities
{
    public class Negocio
    {
        public string UrlLogo { get; set; }
        public string NombreLogo { get; set; }
        public string NumeroDocumento { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public string SimboloMoneda { get; set; }
    }
}
