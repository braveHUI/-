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
    
    public partial class CommentPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentPost()
        {
            this.ReplyPost = new HashSet<ReplyPost>();
        }
    
        public int CommentPost_id { get; set; }
        public int Post_id { get; set; }
        public int User_id { get; set; }
        public string Content { get; set; }
        public System.DateTime CommentTime { get; set; }
        public int CommentPraise { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplyPost> ReplyPost { get; set; }
        public virtual Post Post { get; set; }
        public virtual Users Users { get; set; }
    }
}
