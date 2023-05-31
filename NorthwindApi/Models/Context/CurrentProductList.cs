using System;
using System.Collections.Generic;

namespace NorthwindApi.Models.Context
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
