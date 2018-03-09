using System;
using System.Collections.Generic;

namespace RepoModel
{
    public class userDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userDetail()
        {
            this.skills = new HashSet<skill>();
        }

        public int userId { get; set; }
        public string userName { get; set; }
        public Nullable<bool> AccessAllowed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills { get; set; }
    }
}
