using PluginFramework.ImageEffect;

namespace PluginFramework.Effects;

public class GrayScaleEffect : IImageEffect
{
    public ImageEffectResult Apply(string inputImage, out string outputImage)
    {
        outputImage = "";

        if (string.IsNullOrEmpty(inputImage))
        {
            return ImageEffectResult.InvalidImage("No image is provided");
        }

        outputImage = $"{inputImage}, Convert to gray scale";

        return ImageEffectResult.Success();
    }

    public string GetName()
    {
        return "GrayScale Plugin";
    }
}
