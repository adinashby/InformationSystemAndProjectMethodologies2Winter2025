using System;
using System.Collections.Generic;

public class NewsAgency
{
    private string news;
    private List<IChannel> channels = new List<IChannel>();

    // Add observer
    public void AddObserver(IChannel channel)
    {
        channels.Add(channel);
    }

    // Remove observer
    public void RemoveObserver(IChannel channel)
    {
        channels.Remove(channel);
    }

    // Notify all observers when news updates
    public void SetNews(string news)
    {
        this.news = news;
        foreach (var channel in channels)
        {
            channel.Update(news);
        }
    }
}

public interface IChannel
{
    void Update(string news);
}

public class NewsChannel : IChannel
{
    private string news;

    public void Update(string news)
    {
        this.news = news;
        Console.WriteLine("NewsChannel received: " + this.news);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NewsAgency newsAgency = new NewsAgency();

        // Create observer channels
        NewsChannel channel1 = new NewsChannel();
        NewsChannel channel2 = new NewsChannel();

        // Register observers
        newsAgency.AddObserver(channel1);
        newsAgency.AddObserver(channel2);

        // Update news
        newsAgency.SetNews("Breaking news: Design Patterns in C#!");
    }
}