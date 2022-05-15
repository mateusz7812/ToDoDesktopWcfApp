using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLibrary
{
    [DataContract]
    public class ToDo
    {

        [DataMember]
        public bool Completed { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Deadline { get; set; }
    }
}
