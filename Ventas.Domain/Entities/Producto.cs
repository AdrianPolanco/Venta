using Ventas.Domain.Core;

public class Producto : BaseEntityB
{
    public string CodigoBarra { get; set; }
    public string Marca { get; set; }
    public int IdCategoria { get; set; }
    public int Stock { get; set; }
    public string UrlImagen { get; set; }
    public string NombreImagen { get; set; }
    public decimal Precio { get; set; }

}