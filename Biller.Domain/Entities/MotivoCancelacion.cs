using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class MotivoCancelacion
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Estatus Estatus { get; set; }
}
