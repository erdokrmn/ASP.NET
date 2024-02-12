using Microsoft.AspNetCore.Mvc.RazorPages;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;

namespace EShopAPI.API.Aspects
{
    [PSerializable]
    public class DurationLoggingAttribute :MethodInterceptionAspect
    {
        public override async Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            var sw = Stopwatch.StartNew();
            await args.ProceedAsync();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"{args.Method} executed in {sw.ElapsedMilliseconds}");
        }
    }
   
}
