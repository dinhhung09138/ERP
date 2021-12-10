namespace ERPWebUI.Shared
{
    public partial class RightSidebar
    {
        [Parameter]
        public  bool IsShow { get; set; } = false;

        [Parameter]
        public EventCallback<bool> OnShowChangeEvent { get; set; }

        private async Task OnHide()
        {
            IsShow = false;
            await OnShowChangeEvent.InvokeAsync(IsShow);
        }
    }
}
