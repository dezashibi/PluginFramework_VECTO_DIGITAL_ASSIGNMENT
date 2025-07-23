using PluginFramework.ImageEffect;

namespace PluginFramework.Effects;

public class ResizeEffect : IImageEffect
{
    private int _newSize;

    public ResizeEffect(int newSize)
    {
        _newSize = newSize;
    }

    public ImageEffectResult Apply(string inputImage, out string outputImage)
    {
        outputImage = "";

        if (string.IsNullOrEmpty(inputImage))
        {
            return ImageEffectResult.InvalidImage("No image is provided");
        }

        if (_newSize <= 0)
        {
            return ImageEffectResult.ProcessFailed("Invalid new size");
        }

        outputImage = $"{inputImage}, Resize to {_newSize.ToString()} pixels";

        return ImageEffectResult.Success();
    }

    public string GetName()
    {
        return "Resize Image Plugin";
    }
}
