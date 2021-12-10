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

        private async Task OnShowSidebar(string menu)
        {
            switch (menu)
            {
                case "right-sidebar":
                    await OnShowRightSidebarClickEvent.InvokeAsync();
                    break;
                case "user-info":
                    await OnShowUserInfoClickEvent.InvokeAsync();
                    break;
                case "left-sidebar":
                    await OnShowLeftSidebarEvent.InvokeAsync();
                    break;
            }
        }
    }
}
