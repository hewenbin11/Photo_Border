using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace Photo_Border;

public partial class Guide_Page : Window
{
    private static readonly DirectProperty<Guide_Page, int> CurrentPageIndexProperty =
       AvaloniaProperty.RegisterDirect<Guide_Page, int>(
           nameof(CurrentPageIndex),
           o => o.CurrentPageIndex,
           (o, v) => o.CurrentPageIndex = v);

    private int _currentPageIndex = 0; // 添加一个私有字段来存储当前页面索引

    public Guide_Page()
    {
        InitializeComponent();
        DataContext = this; // 设置DataContext为当前窗口实例
    }

    public void Next(object source, RoutedEventArgs args)
    {
        Guide_Page_Slides.Next();
        if (_currentPageIndex < Guide_Page_Slides.Items.Count - 1)
        {
            _currentPageIndex++;

            Trace.WriteLine(_currentPageIndex); // 输出当前页面索引
        }
    }

    public void Previous(object source, RoutedEventArgs args)
    {
        Guide_Page_Slides.Previous();
        if (_currentPageIndex > 0)
        {
            _currentPageIndex--;

            Trace.WriteLine(_currentPageIndex); // 输出当前页面索引
        }
    }

    // 公开一个属性，以便外部可以获取当前页面索引
    public int CurrentPageIndex
    {
        get => _currentPageIndex;
        set
        {
            if (_currentPageIndex != value)
            {
                _currentPageIndex = value;
                RaisePropertyChanged(CurrentPageIndexProperty, _currentPageIndex, value); // 通知属性值已更改
            }
        }
    }

    private void Button_Close_Guide_Click(object sender, RoutedEventArgs e)
    {
        // 关闭窗口
        this.Close();
    }
}