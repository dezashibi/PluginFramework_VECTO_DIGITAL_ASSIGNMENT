using PluginFramework.ImageEffect;

namespace PluginFramework;

public static class ImageEffectProcessor
{
    public static ImageEffectResult ApplyEffects(string inputImage, out string outputImage, params IImageEffect[] effects)
    {
        outputImage = inputImage;

        foreach (var effect in effects)
        {
            // Chaining output of the last effect to the next effect
            // starting from the inputImage
            ImageEffectResult result = effect.Apply(outputImage, out outputImage);

            Console.WriteLine($"Log: {effect.GetName()} is being applied");

            if (!result.IsSuccess)
            {
                return result;
            }
        }


        return ImageEffectResult.Success();
    }
}
