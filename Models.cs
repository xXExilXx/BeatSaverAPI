namespace BeatSaverAPI.Models
{
    // MapDetail.cs
    public class MapDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MapStats Stats { get; set; }
        public string DownloadUrl => $"https://beatsaver.com/api/download/key/{Id}";
    }

    public class MapStats
    {
        public int Downloads { get; set; }
        public int Plays { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }

    // UserDetail.cs
    public class UserDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserStats Stats { get; set; }
        // Add more fields based on the API response
    }

    public class UserStats
    {
        public int MapsCreated { get; set; }
        public int MapsDownloaded { get; set; }
        // Add more fields
    }

    // SearchResponse.cs
    public class SearchResponse
    {
        public MapDetail[] Docs { get; set; }
        public int TotalDocs { get; set; }
        public int Page { get; set; }
    }

    // Playlist.cs
    public class Playlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PlaylistStats Stats { get; set; }
        // Add more fields
    }

    public class PlaylistStats
    {
        public int Maps { get; set; }
        public int Downloads { get; set; }
    }

}
