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
        
        // New_PDDDroject_File_Button.Click += SelectFolderDialog;//�½��˵�

        Home_Pgae_window = this;

        //ҳ���϶��߼�
        Title_Drag_Area.PointerPressed += DragArea_PointerPressed;
        var storageProvider = StorageProvider;
        var parentWindow = this;
        // ���� DataContext
        DataContext = new Home_PageViewModel(storageProvider, parentWindow);

        // ViewModel �ṩ����߼�����ͼִ��
    }

    //�����϶��߼�ʵ��
    private void DragArea_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // ����δ����ȫ��״̬
        if (Home_Pgae_window.WindowState != Avalonia.Controls.WindowState.FullScreen)
        {
            // ���������ʼ�϶�����
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(e);
            }
        }
    }


    ////�˵����½���ѡ���ļ���λ��

    //private async void SelectFolderDialog(object? sender, RoutedEventArgs args)
    //{
    //    var sp = GetStorageProvider();
    //    if (sp is null) return;
    //    var result = await sp.OpenFolderPickerAsync(new FolderPickerOpenOptions()
    //    {
    //        Title = "ѡ�񱣴�λ��",
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