using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyValidator.Entity.Models {
    [Table("QReconciles")]
    public class QReconcile : AbstractCommon {

        private static int x;

        public QReconcile() {
            x++;
        }

        public DateTime DocumentDate { set; get; } = DateTime.MinValue;
        public string Reference { set; get; } = "";
        public string Site { set; get; } = "Site" + x;
        public string Category { set; get; } = "Category" + x;
        public string TCode { set; get; } = "TCode" + x;
        public string ObjectType { set; get; } = "ObjectType" + x;
        public string Creator { set; get; } = "Creator" + x;
        public DateTime ModifiedDate { set; get; } = DateTime.Now;
        public string Reference1 { set; get; } = "Reference1" + x;
        public string Reference2 { set; get; } = "Reference2" + x;
    }
}