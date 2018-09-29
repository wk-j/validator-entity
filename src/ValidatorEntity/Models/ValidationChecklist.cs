using System.Collections.Generic;

namespace EasyValidator.Entity.Models {

    public class ValidationChecklist {
        public string Group { set; get; }
        public List<string> Items { set; get; } = new List<string>();
    }
}