using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.StorageLoc
{
    public class StorageLocHead_Model
    {
        public List<StorageLoc_Model> lstStorage { get; set; }
        public string Status { get; set; }

        public string Message { get; set; }
    }
}
