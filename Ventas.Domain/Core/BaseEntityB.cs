namespace Ventas.Domain.Core;
public abstract class BaseEntityB
{
    public string Descripcion { get; set; }
    public bool EsActivo { get; set; }
    public Datetime FechaRegistro { get; set; }
}