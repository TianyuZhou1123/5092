//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portfolio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trade
    {
        public int TradeID { get; set; }
        public Nullable<bool> IsBuy { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> InstrumentID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
    
        public virtual Instrument Instrument { get; set; }
    }
}
