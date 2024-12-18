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

    private int _currentPageIndex = 0; // ���һ��˽���ֶ����洢��ǰҳ������

    public Guide_Page()
    {
        InitializeComponent();
        DataContext = this; // ����DataContextΪ��ǰ����ʵ��
    }

    public void Next(object source, RoutedEventArgs args)
    {
        Guide_Page_Slides.Next();
        if (_currentPageIndex < Guide_Page_Slides.Items.Count - 1)
        {
            _currentPageIndex++;

            Trace.WriteLine(_currentPageIndex); // �����ǰҳ������
        }
    }

    public void Previous(object source, RoutedEventArgs args)
    {
        Guide_Page_Slides.Previous();
        if (_currentPageIndex > 0)
        {
            _currentPageIndex--;

            Trace.WriteLine(_currentPageIndex); // �����ǰҳ������
        }
    }

    // ����һ�����ԣ��Ա��ⲿ���Ի�ȡ��ǰҳ������
    public int CurrentPageIndex
    {
        get => _currentPageIndex;
        set
        {
            if (_currentPageIndex != value)
            {
                _currentPageIndex = value;
                RaisePropertyChanged(CurrentPageIndexProperty, _currentPageIndex, value); // ֪ͨ����ֵ�Ѹ���
            }
        }
    }

    private void Button_Close_Guide_Click(object sender, RoutedEventArgs e)
    {
        // �رմ���
        this.Close();
    }
}