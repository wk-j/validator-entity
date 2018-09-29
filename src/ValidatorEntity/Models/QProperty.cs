using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyValidator.Entity.Models {

    [Table("QProperties")]
    public class QProperty : AbstractCommon {
        private static int X;

        public QProperty() {
            X++;
        }

        public string Name { set; get; }
        public string Title { set; get; } = "Title" + X;
        public PropertyType PropertyType { set; get; }

        public string StringValue { set; get; }
        public float NumberValue { set; get; } = 100;
        public DateTime DateTimeValue { set; get; } = DateTime.MinValue;

        [ForeignKey("QFileId")]
        public QFile QFile { set; get; }
        public int QFileId { set; get; }
    }

    [Table("QRejectReasons")]
    public class QRejectReason : AbstractCommon {
        public string ReasonId { set; get; }
        public string Description { set; get; }

        [ForeignKey("QFileId")]
        public QFile QFile { set; get; }
        public int QFileId { set; get; }
    }
}