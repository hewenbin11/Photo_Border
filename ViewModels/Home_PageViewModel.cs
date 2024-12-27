using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using Photo_Border.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Photo_Border.ViewModels
{
    public class Home_PageViewModel
    {
        private readonly IStorageProvider _storageProvider;
        private readonly Window _parentWindow;
        private About_Page aboutPage;

        public Home_PageViewModel(IStorageProvider storageProvider, Window parentWindow)
        {
            _storageProvider = storageProvider;
            _parentWindow = parentWindow;
            Trace.WriteLine(_parentWindow.ToString() + "父级窗口");
            ShowDialogCommand = new AsyncRelayCommand(ShowDialogAsync);

            // 初始化命令
            SelectFolderCommand = new AsyncRelayCommand(SelectFolderAsync);
            OpenFileCommand = new AsyncRelayCommand(OpenFileAsync);
            SaveFileCommand = new AsyncRelayCommand(SaveFileAsync);
            QuitApplicationCommand = new AsyncRelayCommand(QuitApplication);
            OpenAboutPageCommand = new AsyncRelayCommand(OpenAboutPage);
        }

        public IAsyncRelayCommand ShowDialogCommand { get; }

        // 拖动窗口命令
        public RelayCommand<PointerPressedEventArgs> DragWindowCommand { get; }

        // 文件操作命令
        public AsyncRelayCommand SelectFolderCommand { get; }

        public AsyncRelayCommand OpenFileCommand { get; }
        public AsyncRelayCommand SaveFileCommand { get; }

        // 退出和关于页面命令
        public AsyncRelayCommand QuitApplicationCommand { get; }

        public AsyncRelayCommand OpenAboutPageCommand { get; }

        private async Task ShowDialogAsync()
        {
            var dialog = new Home_Page();
            var result = await dialog.ShowDialog<string>(_parentWindow);

            Trace.WriteLine($"Dialog result: {result}");
        }

        // 异步选择文件夹逻辑
        private async Task SelectFolderAsync()
        {
            // 确保存储提供程序已初始化
            if (_storageProvider == null)
            {
                // 根据需求提示用户或者抛出异常
#if DEBUG
                Trace.WriteLine("StorageProvider 未初始化。");
#endif
                return;
            }

            // 打开文件夹选择对话框
            var result = await _storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "选择保存位置", // 对话框标题
                AllowMultiple = false   // 设置是否允许选择多个文件夹
            });

            // 检查是否有文件夹被选中
            if (result != null && result.Any())
            {
                // 处理选中的文件夹路径（示例中获取第一个选中的文件夹）
                var selectedFolder = result.First();
#if DEBUG
                Trace.WriteLine($"选中的文件夹路径: {selectedFolder.Path}");
#endif
                // TODO: 在此处添加具体逻辑，比如保存文件夹路径或更新 UI 数据
            }
            else
            {
#if DEBUG
                // 用户取消了选择
                Trace.WriteLine("用户未选择任何文件夹。");
#endif
            }
        }

        // 异步打开文件逻辑
        private async Task OpenFileAsync()
        {
            if (_storageProvider == null) return;

            var result = await _storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "打开文件",
                FileTypeFilter = new List<FilePickerFileType> { MyFilePickerFileTypes.WMP },
                AllowMultiple = false
            });

            // 在此处理打开的文件
        }

        // 异步保存文件逻辑
        private async Task SaveFileAsync()
        {
            if (_storageProvider == null) return;

            var result = await _storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "保存文件",
                SuggestedFileName = $"印迹工程_{DateTime.Now:yyyyMMdd_HHmmss}",
                FileTypeChoices = new List<FilePickerFileType> { MyFilePickerFileTypes.WMP },
            });

            // 在此处理保存文件的逻辑
        }

        // 打开关于页面逻辑
        private async Task OpenAboutPage()
        {
            aboutPage = new About_Page();
            // 检查是否已经打开对话框
            if (aboutPage.IsVisible)
                return;  // 如果窗口已经打开，避免重复打开
            // 打开窗口并确保它阻塞，直到窗口关闭
            await aboutPage.ShowDialog(_parentWindow);
        }

        // 退出应用逻辑
        private async Task QuitApplication()
        {
            // 使用 Dispatcher 使 Close 方法在 UI 线程上异步执行
            await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                _parentWindow.Close();
            });
        }

        public Home_PageViewModel()
        {
        }
    }
}