using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class UsoCfdi
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Estatus Estatus { get; set; }


    //Relationships
    public IList<Receptor> Receptores { get; set; }
}
