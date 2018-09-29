using System.ComponentModel.DataAnnotations;

namespace EasyValidator.Entity.Models {

    public abstract class AbstractCommon {
        [Key]
        public int Id { set; get; }
    }
}