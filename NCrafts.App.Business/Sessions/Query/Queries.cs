﻿using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    class Queries
    {
        public static GetSessionSumariesQuery CreateGetSessionSumariesQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => dataSourceRepository.Retreive().Sessions
                            .Select(x => new SessionSummary { Id = x.Id, Title = x.Title })
                            .ToList();
        }

        public static GetSessionDetailsQuery CreateGetSessionDetailsQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                .Where(x => x.Id.Equals(sessionId))
                .Select(x => new SessionDetails
                {
                    Id = x.Id,
                    Title = x.Title,
                    Interval = x.Interval,
                    Speakers = string.Join("\n", x.Speakers.Select(s => s.FirstName + " " + s.LastName)),
                    Tags = string.Join(", ", x.Tags.Select(t => t.Title)),
                    Description = x.Description,
                })
                .First();
        }
    }
}
