//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUpSchoolProject.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Message
    {
        public int MessageID { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string SenderNameSurname { get; set; }
        public string ReceiverNameSurname { get; set; }
        public Nullable<System.DateTime> MessageDate { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
}
