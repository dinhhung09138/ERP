namespace ERPWebUI.Shared
{
    public partial class UserInfo
    {
        [Parameter]
        public bool IsShow { get; set; } = false;

        [Parameter]
        public EventCallback<bool> OnShowChangeEvent { get; set; }

        private async Task OnHideClick()
        {
            IsShow = false;
            await OnShowChangeEvent.InvokeAsync(IsShow);
        }
    }
}
