namespace ERPWebUI.Shared
{
    public partial class HeaderTop
    {
        [Parameter]
        public EventCallback OnShowRightSidebarClickEvent { get; set; }

        [Parameter]
        public EventCallback OnShowUserInfoClickEvent { get; set; }

        [Parameter]
        public EventCallback OnShowLeftSidebarEvent { get; set; }

        [Parameter]
        public EventCallback<string> OnModuleChangeEvent { get; set; }

        string moduleSelected = string.Empty;

        private async Task OnModuleChange(string module)
        {
            moduleSelected = module;
            await OnModuleChangeEvent.InvokeAsync(moduleSelected);
        }

        private async Task OnShowSidebar(string menu)
        {
            switch (menu)
            {
                case Sidebar.RightSidebar:
                    await OnShowRightSidebarClickEvent.InvokeAsync();
                    break;
                case Sidebar.UserInfo:
                    await OnShowUserInfoClickEvent.InvokeAsync();
                    break;
                case Sidebar.LeftSidebar:
                    await OnShowLeftSidebarEvent.InvokeAsync();
                    break;
            }
        }
    }
}
