using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyValidator.Entity.Models {
    [Table("QTemplates")]
    public class QTemplate : AbstractCommon {
        // -- [Index]
        public string Template { set; get; }

        // -- [Index]
        public bool ValidationRequire { set; get; }
        public string ValidationKey { set; get; }
        public string ValidationChecklistsText { set; get; }

        [NotMapped]
        public List<ValidationChecklist> ValidationChecklists {
            get {
                return new List<ValidationChecklist>();
            }
        }
    }
}