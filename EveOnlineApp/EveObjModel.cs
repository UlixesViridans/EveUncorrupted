using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    [DataContract]
    public class EveObjModel
    {
        [DataMember]
        public bool Is_buy_order { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int Type_id { get; set; }

        [DataMember]
        public String Type_Name { get; set; }

    }
}
