using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TranQuangDuy_5951071008.Models
{
    [DataContract]
    public class StudentInfo
    {
        [DataMember(Name = "msv")]
        public string MSV { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "birthday")]
        public DateTime Birthday { get; set; }
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
    }
}