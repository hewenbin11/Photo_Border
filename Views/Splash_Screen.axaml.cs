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
        //        // �ڷ�DEBUGģʽ�����ô��ڲ���ʾ��������
        //#if RELEASE

        //        this.ShowInTaskbar = false;
        //#endif
    }
}