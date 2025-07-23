using PluginFramework.Effects;
using PluginFramework.ImageEffect;

namespace PluginFramework.Tests;

public class ImageEffectUnitTests
{
    [Fact]
    public void ImageEffectTest_ResizeEffectWorksCorrectly()
    {
        string image = "TestImage";

        ResizeEffect effect = new(100);

        string outputImage = "";

        ImageEffectResult result = effect.Apply(image, out outputImage);

        Assert.Equal(ImageEffectResultKind.Success, result.Kind);
        Assert.True(result.IsSuccess);
        Assert.True(!string.IsNullOrEmpty(outputImage));
        Assert.Equal("TestImage, Resize to 100 pixels", outputImage);
    }

    [Fact]
    public void ImageEffectTest_BlurEffectWorksCorrectly()
    {
        string image = "TestImage";

        BlurEffect effect = new(100);

        string outputImage = "";

        ImageEffectResult result = effect.Apply(image, out outputImage);

        Assert.Equal(ImageEffectResultKind.Success, result.Kind);
        Assert.True(result.IsSuccess);
        Assert.True(!string.IsNullOrEmpty(outputImage));
        Assert.Equal("TestImage, Add blur 100 pixels size", outputImage);
    }

    [Fact]
    public void ImageEffectTest_GrayScaleEffectWorksCorrectly()
    {
        string image = "TestImage";

        GrayScaleEffect effect = new();

        string outputImage = "";

        ImageEffectResult result = effect.Apply(image, out outputImage);

        Assert.Equal(ImageEffectResultKind.Success, result.Kind);
        Assert.True(result.IsSuccess);
        Assert.True(!string.IsNullOrEmpty(outputImage));
        Assert.Equal("TestImage, Convert to gray scale", outputImage);
    }

    [Fact]
    public void ImageEffectTest_ImageProcessorWorksCorrectly()
    {
        string image = "TestImage";

        IImageEffect[] effects = [new ResizeEffect(100), new GrayScaleEffect()];

        string outputImage = "";

        ImageEffectResult result = ImageEffectProcessor.ApplyEffects(image, out outputImage, effects);

        Assert.Equal(ImageEffectResultKind.Success, result.Kind);
        Assert.True(result.IsSuccess);
        Assert.True(!string.IsNullOrEmpty(outputImage));
        Assert.Equal("TestImage, Resize to 100 pixels, Convert to gray scale", outputImage);
    }

    [Fact]
    public void ImageEffectTest_ImageProcessorFailsOnInvalidImage()
    {
        string image = "";

        IImageEffect[] effects = [new ResizeEffect(100), new GrayScaleEffect()];

        string outputImage = "";

        ImageEffectResult result = ImageEffectProcessor.ApplyEffects(image, out outputImage, effects);

        Assert.Equal(ImageEffectResultKind.InvalidImage, result.Kind);
        Assert.False(result.IsSuccess);
        Assert.Equal("No image is provided", result.Message);
    }

    [Fact]
    public void ImageEffectTest_ImageProcessorFailsOnPluginInternalFailure()
    {
        string image = "TestImage";

        IImageEffect[] effects = [new ResizeEffect(0), new GrayScaleEffect()];

        string outputImage = "";

        ImageEffectResult result = ImageEffectProcessor.ApplyEffects(image, out outputImage, effects);

        Assert.Equal(ImageEffectResultKind.ProcessFailed, result.Kind);
        Assert.False(result.IsSuccess);
        Assert.Equal("Invalid new size", result.Message);
    }
}