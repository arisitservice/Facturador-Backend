using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Estatus Estatus { get; set; }
}
