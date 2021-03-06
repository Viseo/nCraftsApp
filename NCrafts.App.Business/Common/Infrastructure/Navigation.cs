﻿using System.Threading.Tasks;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public delegate Task NavigateToSessionsFromMenu();
    public delegate Task NavigateToHomeFromAbout();
    public delegate Task NavigateToPersonalScheduleFromMenu();
    public delegate Task NavigateToSpeakersFromMenu();
    public delegate Task NavigateToLocationFromMenu();
    public delegate Task NavigateToAboutFromMenu();
    public delegate Task NavigateToSessionDetails(SessionId sessionId);
    public delegate Task NavigateToSpeakerDetails(SpeakerId speakerId);
}
