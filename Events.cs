using System.Text.Json.Serialization;

namespace FragBot3;
public class FragBot3Event
{
    public FragBot3Event(string eventName)
    {
        EventName = eventName;
    }

    [JsonPropertyName("event")]
    public string EventName { get; }
}

public class FragBot3MatchEvent : FragBot3Event
{
    [JsonPropertyName("matchid")]
    public required long MatchId { get; init; }

    protected FragBot3MatchEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3MatchTeamEvent : FragBot3MatchEvent
{
    [JsonPropertyName("team")]
    public required string Team { get; init; }

    protected FragBot3MatchTeamEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3MapEvent : FragBot3MatchEvent
{
    [JsonPropertyName("map_number")]
    public required int MapNumber { get; init; }

    protected FragBot3MapEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3MapTeamEvent : FragBot3MapEvent
{
    [JsonPropertyName("team_int")]
    public required int TeamNumber { get; init; }

    protected FragBot3MapTeamEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3RoundEvent : FragBot3MapEvent
{
    [JsonPropertyName("round_number")]
    public required int RoundNumber { get; init; }

    protected FragBot3RoundEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3TimedRoundEvent : FragBot3RoundEvent
{
    [JsonPropertyName("round_time")]
    public required int RoundTime { get; init; }

    protected FragBot3TimedRoundEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3PlayerRoundEvent : FragBot3RoundEvent
{

    [JsonPropertyName("player")]
    public required int Player { get; init; }

    protected FragBot3PlayerRoundEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3PlayerTimedRoundEvent : FragBot3TimedRoundEvent
{
    [JsonPropertyName("player")]
    public required int Player { get; init; }

    protected FragBot3PlayerTimedRoundEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3PlayerDisconnectedEvent : FragBot3MatchEvent
{
    [JsonPropertyName("player")]
    public required int Player { get; init; }

    public FragBot3PlayerDisconnectedEvent() : base("player_disconnect")
    {
    }
}

public class FragBot3SeriesStartedEvent : FragBot3MatchEvent
{
    [JsonPropertyName("team1")]
    public required FragBot3TeamWrapper Team1 { get; init; }

    [JsonPropertyName("team2")]
    public required FragBot3TeamWrapper Team2 { get; init; }

    [JsonPropertyName("num_maps")]
    public required int NumberOfMaps { get; init; }

    public FragBot3SeriesStartedEvent() : base("series_start")
    {
    }
}

public class FragBot3SeriesResultEvent : FragBot3MatchEvent
{
    [JsonPropertyName("time_until_restore")]
    public required int TimeUntilRestore { get; init; }

    [JsonPropertyName("winner")]
    public required Winner Winner { get; init; }

    [JsonPropertyName("team1_series_score")]
    public required int Team1SeriesScore { get; init; }

    [JsonPropertyName("team2_series_score")]
    public required int Team2SeriesScore { get; init; }

    public FragBot3SeriesResultEvent() : base("series_end")
    {
    }
}

public class GoingLiveEvent : FragBot3MapEvent
{
    public GoingLiveEvent() : base("going_live")
    {
    }
}

public class FragBot3RoundEndedEvent : FragBot3TimedRoundEvent
{

    [JsonPropertyName("reason")]
    public required int Reason { get; init; }

    [JsonPropertyName("winner")]
    public required Winner Winner { get; init; }

    [JsonPropertyName("team1")]
    public required FragBot3StatsTeam StatsTeam1 { get; init; }

    [JsonPropertyName("team2")]
    public required FragBot3StatsTeam StatsTeam2 { get; init; }

    public FragBot3RoundEndedEvent() : base("round_end")
    {
    }
}

public class MapResultEvent : FragBot3MapEvent
{
    [JsonPropertyName("winner")]
    public required Winner Winner { get; init; }

    [JsonPropertyName("team1")]
    public required FragBot3StatsTeam StatsTeam1 { get; init; }

    [JsonPropertyName("team2")]
    public required FragBot3StatsTeam StatsTeam2 { get; init; }

    public MapResultEvent() : base("map_result")
    {
    }
}

public class FragBot3MapSelectionEvent : FragBot3MatchTeamEvent
{
    [JsonPropertyName("map_name")]
    public required string MapName { get; init; }

    protected FragBot3MapSelectionEvent(string eventName) : base(eventName)
    {
    }
}

public class FragBot3MapPickedEvent : FragBot3MapSelectionEvent
{
    [JsonPropertyName("map_number")]
    public required int MapNumber { get; init; }

    public FragBot3MapPickedEvent() : base("map_picked")
    {
    }
}

public class FragBot3MapVetoedEvent : FragBot3MapSelectionEvent
{
    public FragBot3MapVetoedEvent() : base("map_vetoed")
    {
    }
}

public class FragBot3SidePickedEvent : FragBot3MapSelectionEvent
{
    [JsonPropertyName("map_number")]
    public required int MapNumber { get; init; }

    [JsonPropertyName("side")]
    public required string Side { get; init; }

    public FragBot3SidePickedEvent() : base("side_picked")
    {
    }
}

public class FragBot3DemoUploadedEvent : FragBot3MatchEvent
{
    [JsonPropertyName("map_number")]
    public required int MapNumber { get; init; }

    [JsonPropertyName("filename")]
    public required string FileName { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    public FragBot3DemoUploadedEvent() : base("demo_upload_ended")
    {
    }
}