using Avalonia.Controls;
using Avalonia.Input;

public interface IWindowService
{
    void BeginMoveDrag(PointerPressedEventArgs e); // 开始拖动窗口

    WindowState GetWindowState(); // 获取窗口状态
}