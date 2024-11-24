using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using YoutubeExplode.Playlists;

namespace YTPlayListDownloader.Models;

public class DBContext : DbContext
{
    public virtual DbSet<Video> Video { get; set; }
    public virtual DbSet<PlayList> Playlists { get; set; }
    public virtual DbSet<PlayListVideos> PlaylistVideos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./YoutubePlayList.db;foreign keys=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        var videos = jsonContent.items
            .Select(item => new Video(item.Id, item.Title, item.comment))
            .ToList();
        var playlists = jsonContent.items.SelectMany(playlists => playlists.Playlists).Distinct()
            .Select(playlist => new PlayList(playlist.Id, playlist.Title, playlist.Owner))
            .ToList();

        var playlistVideos = new List<PlayListVideos>();
        foreach (var item in jsonContent.items)
        {
            var video = videos.FirstOrDefault(v => v.Id == item.Id);
            foreach (var playlist in item.Playlists)
            {
                playlistVideos.Add(new PlayListVideos
                    { Position = playlist.Position, VideoId = video.Id, PlayListId = playlist.Id });
            }
        }

        modelBuilder.Entity<PlayListVideos>().HasKey(p => new { p.VideoId, p.PlayListId });
        modelBuilder.Entity<PlayListVideos>().HasData(playlistVideos);

        modelBuilder.Entity<Video>().HasData(videos);
        modelBuilder.Entity<PlayList>().HasData(playlists);
    }
}