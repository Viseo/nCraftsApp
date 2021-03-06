using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Sessions.Query
{
    public class SessionDetails
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Room { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public bool IsRegister { get; set; }
        public List<SpeakerId> SpeakersId { get; set; } 
    }
}