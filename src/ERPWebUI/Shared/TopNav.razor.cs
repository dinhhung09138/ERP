using Microsoft.AspNetCore.Components;

namespace ERPWebUI.Shared
{
    public partial class TopNav
    {

        #region " Notification "

        string notifyAlert = "alert";
        string notifyEmail = "email";
        string notifyUser = "user";

        string notificationItem = string.Empty;

        private void OnShowNotification(string currentMenu, string newMenu)
        {
            if (currentMenu == newMenu)
            {
                notificationItem = string.Empty;
            } 
            else
            {
                notificationItem = newMenu;
            }
            StateHasChanged();
        }

        #endregion
    }
}
