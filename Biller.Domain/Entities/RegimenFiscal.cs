using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class RegimenFiscal
{
    public int Id { get; set; }
    public int ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Estatus Estatus { get; set; }
}
