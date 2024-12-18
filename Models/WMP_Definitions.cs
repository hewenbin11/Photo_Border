using Avalonia.Platform.Storage;

namespace Photo_Border.Models
{
    public static class MyFilePickerFileTypes
    {
        //自定义格式WMP
        public static FilePickerFileType WMP { get; } = new("印迹工程文件(Watermark Project)")
        {
            Patterns = new[] { "*.wmp*" },
            AppleUniformTypeIdentifiers = new[] { "com.Yinji.Project" },
            MimeTypes = new[] { "application/x-watermark-project" }
        };
    }
}