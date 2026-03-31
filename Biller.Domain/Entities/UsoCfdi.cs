using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class UsoCfdi
{
    public int Id { get; set; }
    public string ClaveSat { get; set; }
    public string Descripcion { get; set; }
    public Status Estatus { get; set; }


    //Relationships
    public IList<Client> Receptores { get; set; }
}
