using ConsoleApp1;

using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<CuteMessageJob>(
    "send-cute-message",
    job => job.SendMessage(),
    "*/14 * * * *"
);

app.Run();


// public class Program
// {
//     public static async Task Main()
//     {
//         var url = "https://api.ultramsg.com/instance131579/messages/chat";
//         var token = "125ftgaic0jniefl";
//         var phoneNumbers = new List<string> {
//             "87075363580",
//             "87017827889",
//             "87051612418",
//             "87029224224",
//             "87016404888",
//             "87774445281",
//             "87753993637",
//             "87754676454",
//             "87773224422",
//             "87789620554",
//             "87017810636",
//             "87012777599",
//             "87025143414",
//             "87013691318",
//             "87021019210",
//             "87773572012"
//         };
//         List<string> failed = new List<string>();
//
//         var text =
//             "Добрый вечер, меня зовут Султан, я тренер по шахматам и вы подавали заявку на обучение по шахматам, скажите," +
//             " пожалуйста, есть ли у вашего ребенка разряд или опыт в игре, так как я хочу сформировать группы с одинаковым уровнем";
//
//         foreach (var number in phoneNumbers)
//         {
//             var client = new RestClient(url);
//             var request = new RestRequest(url, Method.Post);
//             request.AddHeader("content-type", "application/x-www-form-urlencoded");
//             request.AddParameter("token", token);
//             request.AddParameter("to", number);
//             request.AddParameter("body", text);
//
//             RestResponse response = await client.ExecuteAsync(request);
//
//             Console.WriteLine($"Отправлено на {number}: {response.StatusCode}");
//             if (response.StatusCode != System.Net.HttpStatusCode.OK)
//             {
//                 failed.Add(number);
//             }
//         }
//
//         Console.WriteLine(failed);
//     }
// }