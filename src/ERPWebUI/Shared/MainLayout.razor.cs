
using Microsoft.AspNetCore.Components;

namespace ERPWebUI.Shared
{
    public partial class MainLayout
    {
        private bool IsShowRightBar = false;

        private bool IsShowLeftSidebar = true;

        private bool IsShowSetting = false;

        private bool IsShowUserInfo = false;

        private string moduleName = string.Empty;

        private void OnModuleChange(string module)
        {
            moduleName = module;
            Console.WriteLine(moduleName);
            StateHasChanged();
        }

        private void OnShowHideRightSidebar(bool isShow)
        {
            IsShowRightBar = isShow;
            StateHasChanged();
        }

        private void OnShowHideRightSidebar()
        {
            IsShowRightBar = !IsShowRightBar;
            StateHasChanged();
        }

        private void OnShowHideUserInfo(bool isShow)
        {
            IsShowUserInfo = isShow;
        }

        private void OnShowHideUserInfo()
        {
            IsShowUserInfo = !IsShowUserInfo;
            StateHasChanged();
        }

        private void OnShowHideLeftSidebar()
        {
            IsShowLeftSidebar = !IsShowLeftSidebar;
            StateHasChanged();
        }

    }
}
