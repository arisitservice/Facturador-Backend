using Biller.Domain.Enums;

namespace Biller.Domain.Entities;

public class CfdiComplementoPago
{
    public int Id { get; set; }
    public int IdCfdi { get; set; }
    public int IdFacturaRelacion { get; set; }
    public int IdFormaPago { get; set; }
    public int IdMoneda { get; set; }
    public decimal TipoCambio { get; set; }
    public DateTime FechaPago { get; set; }
    public string? NumOperacion { get; set; }
    public ObjetoImpuesto ObjetoImpuesto { get; set; }
    public string? Serie { get; set; }
    public decimal Equivalencia { get; set; }
    public int NumParcialidad { get; set; }
    public decimal ImporteSaldoAnterior { get; set; }
    public decimal ImportePagado { get; set; }
    public decimal ImportePagadoInsoluto { get; set; }
    public Status Estatus { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
   
    public Cfdi Cfdi { get; set; }
}
