using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Payments = new HashSet<Payment>();
        }

        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}