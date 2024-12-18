using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace Photo_Border.ViewModels
{
    public class About_PageViewModel
    {
        private readonly Window _this_Window;

        public About_PageViewModel(Window this_Window)
        {
            About_PageCloseCommand = new AsyncRelayCommand(About_Page_Close);
            this_Window = this_Window;
        }

        public AsyncRelayCommand About_PageCloseCommand { get; }

        private async Task About_Page_Close()
        {

        }
    }
}