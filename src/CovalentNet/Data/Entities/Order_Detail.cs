namespace CovalentNet.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Order Details")]
    public partial class Order_Detail : IEntityBase<int>
    {
        [NotMapped]
        public int Id
        {
            get { return this.OrderID; }
            set { this.OrderID = value; } 
        }

        
        [Column(Order = 0)]
        public int OrderID { get; set; }

       
        [Column(Order = 1)]
        public int ProductID { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public virtual Order Order { get; set; }

       public virtual Product Product { get; set; }
    }
}
