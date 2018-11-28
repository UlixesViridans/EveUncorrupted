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
        public bool is_buy_order { get; set; }

        [DataMember]
        public double price { get; set; }

        [DataMember]
        public int type_id { get; set; }

    }
}
