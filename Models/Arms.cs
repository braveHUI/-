//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arms
    {
        public int Arms_id { get; set; }
        public string ArmsName { get; set; }
        public string ArmsPicture { get; set; }
        public string ArmsVideo { get; set; }
        public string ArmsDes { get; set; }
        public int ArmsSection_id { get; set; }
        public string ArmsTechnical { get; set; }
        public int BigSection_id { get; set; }
        public int BigSection2_id { get; set; }
        public int BigSection3_id { get; set; }
        public string Manu { get; set; }
        public Nullable<System.DateTime> Stime { get; set; }
        public Nullable<System.DateTime> Ctime { get; set; }
    
        public virtual ArmsSection ArmsSection { get; set; }
    }
}
