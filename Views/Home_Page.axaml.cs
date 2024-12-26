using Avalonia.Controls;
using Avalonia.Input;
using Photo_Border.ViewModels;
using System.Data.SQLite;
using Photo_Border.DB;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System;
namespace Photo_Border;

public partial class Home_Page : Window
{
    public readonly Window Home_Pgae_window;
    
    public Home_Page()
    {
        InitializeComponent();
        
        // New_PDDDroject_File_Button.Click += SelectFolderDialog;//新建菜单

        Home_Pgae_window = this;

        //页面拖动逻辑
        Title_Drag_Area.PointerPressed += DragArea_PointerPressed;
        var storageProvider = StorageProvider;
        var parentWindow = this;
        // 设置 DataContext
        DataContext = new Home_PageViewModel(storageProvider, parentWindow);

        // ViewModel 提供命令，逻辑由视图执行
    }

    //窗口拖动逻辑实现
    private void DragArea_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // 窗口未处于全屏状态
        if (Home_Pgae_window.WindowState != Avalonia.Controls.WindowState.FullScreen)
        {
            // 按下左键开始拖动窗口
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(e);
            }
        }
    }


    ////菜单栏新建，选择文件夹位置

    //private async void SelectFolderDialog(object? sender, RoutedEventArgs args)
    //{
    //    var sp = GetStorageProvider();
    //    if (sp is null) return;
    //    var result = await sp.OpenFolderPickerAsync(new FolderPickerOpenOptions()
    //    {
    //        Title = "选择保存位置",
    //        AllowMultiple = true,
    //    });
    //}

    //private IStorageProvider? GetStorageProvider()
    //{
    //    var topLevel = TopLevel.GetTopLevel(this);
    //    return topLevel?.StorageProvider;
    //}

    //private List<FilePickerFileType>? GetFileTypes()
    //{
    //    return
    //    [
    //        FilePickerFileTypes.All,
    //        FilePickerFileTypes.TextPlain
    //    ];
    //}
}