using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entidades
{
    /*public class Invoice
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; private set; }
        public DateTime DevolutionDate { get; private set; }
        public double SubTotal { get; private set; }
        public double IVA { get; private set; }
        public double Total { get; private set; }
        public int CostumerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

        public void Sets(List<PurchaseDetail> List_purchaseDetails)
        {
            this.InvoiceDate = DateTime.Today;
            this.DevolutionDate = InvoiceDate.AddDays(5);
            this.SubTotal = List_purchaseDetails.Sum(x => x.Subtotal);
            this.IVA = this.SubTotal * 0.13;
            this.Total = this.SubTotal + this.IVA;
        }
    }*/

    public class Invoice
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; private set; }
        public DateTime DevolutionDate { get; private set; }
        public double SubTotal { get; private set; }
        public double IVA { get; private set; }
        public double Total { get; private set; }
        public int CostumerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

        [NotMapped]
        public List<int> PurchaseDetailIds { get; set; }

        [NotMapped]
        public List<PurchaseDetail> PurchaseDetails { get; set; }

        public Invoice()
        {
            PurchaseDetailIds = new List<int>();
            PurchaseDetails = new List<PurchaseDetail>();
        }

        public void Sets(List<PurchaseDetail> List_purchaseDetails)
        {
            this.InvoiceDate = DateTime.Today;
            this.DevolutionDate = InvoiceDate.AddDays(5);
            this.SubTotal = List_purchaseDetails.Sum(x => x.Subtotal);
            this.IVA = this.SubTotal * 0.13;
            this.Total = this.SubTotal + this.IVA;
        }
    }
}
