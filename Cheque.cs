//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GazLink
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cheque
    {
        public int idApplication { get; set; }
        public int idProduct { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Applications Applications { get; set; }
        public virtual Product Product { get; set; }
    }
}
