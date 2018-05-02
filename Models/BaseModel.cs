using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        // protectec = vai ser acessada pelas classes filhas
        public int Id { get; protected set; }
    }
}
