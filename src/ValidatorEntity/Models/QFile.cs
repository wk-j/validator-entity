using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyValidator.Entity.Models {
    [Table("QFiles")]
    public class QFile : AbstractCommon {
        static int X;

        public QFile() {
            X++;
        }

        public string OriginalFileName { set; get; } = "OriginalFileName" + X;
        public string LocalFileName { set; get; } = "LocalFileName" + X;
        public string Creator { set; get; } = "Creator" + X;
        public string Validator { set; get; } = "Validator" + X;
        public string Template { set; get; } = "Template" + X;

        public DateTime CreateDate { set; get; } = DateTime.Now;
        public DateTime UploadDate { set; get; } = DateTime.MinValue;
        public DateTime ValidateDate { set; get; } = DateTime.MinValue;

        // -- [Index]
        public string Uuid { set; get; } = "Uuid" + X;

        public string AlfrescoUuid { set; get; } = "AlfrescoUuid" + X;

        public string NameFormat { set; get; } = "NameFormat" + X;
        public string PathFormat { set; get; } = "PathFormat" + X;
        public string TitleFormat { set; get; } = "TitleFormat" + X;
        public string DescriptionFormat { set; get; } = "DescriptionFormat" + X;

        public string FinalName { set; get; } = "FinalName" + X;
        public string FinalPath { set; get; } = "FinalPath" + X;

        public string Comment { set; get; } = string.Empty;

        // -- [Index]
        public Status Status { set; get; } = Status.Initialize;
    }
}
