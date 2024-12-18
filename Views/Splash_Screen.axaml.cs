using Avalonia.Controls;

namespace Photo_Border;

public partial class Splash_Screen : Window
{
    public Splash_Screen()
    {
        InitializeComponent();

        this.ShowInTaskbar = false;

        //#if DEBUG
        //        this.AttachDevTools();
        //#endif
        //        // 在非DEBUG模式下设置窗口不显示在任务栏
        //#if RELEASE

        //        this.ShowInTaskbar = false;
        //#endif
    }
}