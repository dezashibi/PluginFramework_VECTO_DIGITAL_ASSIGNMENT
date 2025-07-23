namespace PluginFramework.ImageEffect;

public enum ImageEffectResultKind
{
    Success,
    InvalidImage,
    ProcessFailed,
}

public record struct ImageEffectResult(ImageEffectResultKind Kind, string Message)
{
    public readonly bool IsSuccess => Kind == ImageEffectResultKind.Success;

    public static ImageEffectResult Success()
    {
        return new(ImageEffectResultKind.Success, "");
    }

    public static ImageEffectResult InvalidImage(string message)
    {
        return new(ImageEffectResultKind.InvalidImage, message);
    }

    public static ImageEffectResult ProcessFailed(string message)
    {
        return new(ImageEffectResultKind.ProcessFailed, message);
    }
}

public interface IImageEffect
{
    public string GetName();

    public ImageEffectResult Apply(string inputImage, out string outputImage);
}
