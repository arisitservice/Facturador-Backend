using Biller.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biller.Domain.Entities.Tenant;

public class AccountTaxInfo: BaseAuditableEntity
{
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public bool Default { get; set; }


    public int TaxRegimeId { get; set; }


    public TaxRegime TaxRegime { get; set; }
}
