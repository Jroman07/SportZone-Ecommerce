﻿using System.Text.Json.Serialization;

namespace Entidades
{
    public class PurchaseDetail
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; private set; }
        public int CustomerId { get; set; }
        public int ShoeId { get; set; }
        public bool IsPagar { get; private set; }
        public PurchaseDetail() { IsPagar = true;}

        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Shoe? Shoe { get; set; }
        public void setPrice(Shoe shoe){ this.Subtotal = Quantity * shoe.Price; }
        public void changeIsPagar() { this.IsPagar = false; }
        
    }
}
