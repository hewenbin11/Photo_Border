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

              

                // ��ʾ��������
                var splashScreen = new Splash_Screen();
                splashScreen.Show();

                // �첽�ȴ� 2 ��
                await Task.Delay(TimeSpan.FromSeconds(2));

                // ��������ʾ��ҳ
                var homePage = new Home_Page();
                homePage.Show();

                // �ر��������棨�����Ҫ�Ļ������������ﴦ����������Ч����
                splashScreen.Close();
            }
        }
    }
}