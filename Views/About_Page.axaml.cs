using Avalonia.Controls;
using Avalonia.Interactivity;
using Photo_Border.ViewModels;
using System.Diagnostics;

namespace Photo_Border;

public partial class About_Page : Window
{
    public About_Page()
    {
        InitializeComponent();
        this.ShowInTaskbar = false;
        var thisWindow = this;
        DataContext = new About_PageViewModel(thisWindow);

        //#if DEBUG
        //        this.AttachDevTools();
        //#endif
        //        // 在非DEBUG模式下设置窗口不显示在任务栏
        //#if RELEASE

        //        this.ShowInTaskbar = false;
        //#endif
    }

    private void Button_About_Close_click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void PdfButton_Click(object sender, RoutedEventArgs e)
    {
        string pdfFilePath = "E:/Codes/Avalonia/Photo_Border/Photo_Border/Assets/Document/Policy.pdf"; // 替换为你的PDF文件路径
        OpenPdfFile(pdfFilePath);
    }

    private void OpenPdfFile(string pdfFilePath)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = pdfFilePath,
            UseShellExecute = true
        });
    }

    private void Bilibili_Button_Click(object sender, RoutedEventArgs e)
    {
        // 哔哩哔哩官网的URL
        string bilibiliUrl = "https://space.bilibili.com/379830873";

        // 使用Process.Start打开默认浏览器并访问URL
        Process.Start(new ProcessStartInfo(bilibiliUrl) { UseShellExecute = true });
    }

    private void Github_Button_Click(object sender, RoutedEventArgs e)
    {
        string githubUrl = "https://github.com/hewenbin11";
        Process.Start(new ProcessStartInfo(githubUrl) { UseShellExecute = true });
    }

    private void Zhihu_Button_Cilck(object sender, RoutedEventArgs e)
    {
        string zhihuUrl = "https://www.zhihu.com/people/ji-zhi-0";
        Process.Start(new ProcessStartInfo(zhihuUrl) { UseShellExecute = true });
    }
}