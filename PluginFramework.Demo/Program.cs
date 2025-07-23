using PluginFramework.Effects;
using PluginFramework.ImageEffect;

namespace PluginFramework.Demo;

internal static class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, IImageEffect[]> tasks = new()
        {
            { "Image#1", [new ResizeEffect(100), new BlurEffect(2)] },
            { "Image#2", [new ResizeEffect(100)] },
            { "Image#3", [new ResizeEffect(150), new BlurEffect(5), new GrayScaleEffect()] }
        };

        foreach (var task in tasks)
        {
            var procRes = ImageEffectProcessor.ApplyEffects(task.Key, out var result, task.Value);

            if (procRes.IsSuccess)
            {
                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine($"{task.Key} process failed with {procRes.Message}");
            }
        }
    }
}
