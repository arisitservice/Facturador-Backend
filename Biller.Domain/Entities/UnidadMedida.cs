
using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class UnidadMedida
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Estatus Estatus { get; set; }
}
