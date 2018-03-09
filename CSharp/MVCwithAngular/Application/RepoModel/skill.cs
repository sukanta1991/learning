using System;
using System.Collections.Generic;

namespace RepoModel
{
    public class skill
    {
        public int skillId { get; set; }
        public string skills { get; set; }
        public Nullable<bool> trained { get; set; }
        public Nullable<int> userId { get; set; }

        public virtual userDetail userDetail { get; set; }
    }
}
