using PluginFramework.ImageEffect;

namespace PluginFramework.Effects;

public class BlurEffect : IImageEffect
{
    private int _blur;

    public BlurEffect(int blur)
    {
        _blur = blur;
    }

    public ImageEffectResult Apply(string inputImage, out string outputImage)
    {
        outputImage = "";

        if (string.IsNullOrEmpty(inputImage))
        {
            return ImageEffectResult.InvalidImage("No image is provided");
        }

        if (_blur < 0)
        {
            return ImageEffectResult.ProcessFailed("Invalid blur pixel size");
        }

        outputImage = $"{inputImage}, Add blur {_blur.ToString()} pixels size";

        return ImageEffectResult.Success();
    }

    public string GetName()
    {
        return "Blur Plugin";
    }
}
