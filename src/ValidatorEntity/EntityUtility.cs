using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyValidator.Entity {
    public static class EntityUtility {
        public static string CreateUuid() => Guid.NewGuid().ToString("N");
    }
}
