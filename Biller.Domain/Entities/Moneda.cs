using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class Moneda
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Status Estatus { get; set; }
}
