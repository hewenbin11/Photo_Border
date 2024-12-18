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
        //        // �ڷ�DEBUGģʽ�����ô��ڲ���ʾ��������
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
        string pdfFilePath = "E:/Codes/Avalonia/Photo_Border/Photo_Border/Assets/Document/Policy.pdf"; // �滻Ϊ���PDF�ļ�·��
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
        // ��������������URL
        string bilibiliUrl = "https://space.bilibili.com/379830873";

        // ʹ��Process.Start��Ĭ�������������URL
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