using Amazon.Lambda.Core;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaTimeTest;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string FunctionHandler(string input, ILambdaContext context)
    {
        context.Logger.LogInformation(DateTime.Now.ToString());
        context.Logger.LogInformation(DateTime.UtcNow.ToString());
        context.Logger.LogInformation("local: "+DateTime.Now.ToLocalTime().ToString());
        ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
        //foreach (TimeZoneInfo zone in zones)
        //{
        //    context.Logger.LogInformation("Zone ID-" + zone.Id + "__" + zone.DisplayName);
        //}
        //AUS Eastern Standard Time
        //TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Canberra, Melbourne, Sydney");
        // DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone);
        //context.Logger.LogInformation(cstTime.ToString());
        TimeZoneInfo aest = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
        //TimeZoneInfo aest = TimeZoneInfo.FindSystemTimeZoneById("Australia/Sydney");
        DateTime aestTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, aest);
        context.Logger.LogInformation(aestTime.ToString());
        DateTime d = DateTime.ParseExact(aestTime.ToString(), "dd-MM-yyyy HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
        context.Logger.LogInformation(d.ToString());



        return input.ToUpper();
    }
}
