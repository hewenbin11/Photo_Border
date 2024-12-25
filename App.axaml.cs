using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Threading.Tasks;
using Photo_Border.DB;
using System.Data.SQLite;
namespace Photo_Border
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            
        }

        //public override void OnFrameworkInitializationCompleted()
        //{
        //    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //    {
        //        // Line below is needed to remove Avalonia data validation.
        //        // Without this line you will get duplicate validations from both Avalonia and CT
        //        BindingPlugins.DataValidators.RemoveAt(0);
        //        desktop.MainWindow = new Home_Page
        //        {
        //            DataContext = new MainWindowViewModel(),
        //        };
        //    }

        //    base.OnFrameworkInitializationCompleted();
        //}

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {

              

                // 显示启动画面
                var splashScreen = new Splash_Screen();
                splashScreen.Show();

                // 异步等待 2 秒
                await Task.Delay(TimeSpan.FromSeconds(2));

                // 创建并显示主页
                var homePage = new Home_Page();
                homePage.Show();

                // 关闭启动画面（如果需要的话，可以在这里处理动画或其他效果）
                splashScreen.Close();
            }
        }
    }
}