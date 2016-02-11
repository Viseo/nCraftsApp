﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Speakers.Query
{
    public delegate ICollection<SpeakerSummary> GetSpeakerSumariesQuery();
    public delegate SpeakerDetails GetSpeakerDetailsQuery(SpeakerId id);

    class Queries
    {
        public static GetSpeakerSumariesQuery CreateGetSpeakerSumariesQuery(IDataSourceRepository dataSourceRepository)
        {
            return
                () =>
                    dataSourceRepository.Retreive()
                        .Speakers.Select(x => new SpeakerSummary {Id = x.Id, Name = x.FirstName + " " + x.LastName, ProfilPicture = x.ProfilPicture})
                        .ToList();
        }

        public static GetSpeakerDetailsQuery CreateGetSpeakerDetailsQuery(IDataSourceRepository dataSourceRepository)
        {
            return
                speakerId =>
                    dataSourceRepository.Retreive()
                        .Speakers.Where(x => x.Id.Equals(speakerId))
                        .Select(x => new SpeakerDetails
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Details = x.Details,
                            ProfilPicture = x.ProfilPicture,
                            SessionsIds = x.Sessions
                        })
                        .First();
        }
    }
}