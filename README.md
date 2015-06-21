# BootstrapDialogMVC
show bootstrap dialogs on view by Helper

Download CSS File and Script File from: https://github.com/nakupanda/bootstrap3-dialog

Sample Code On View

```C#
@{
            const string dialogName = "errorDialog";
            var cancelButton = new BootstrapDialogButton();
            cancelButton.Id = "btncancel";
            cancelButton.Label = "بستن";
            cancelButton.Action = "function(){{{0}}}";
            cancelButton.Action = String.Format(cancelButton.Action, Dialogs.RunBootstrapDialogMethod(dialogName, BootstrapDialogMethods.Close));
                         
 
            var dialog = new BootstrapDialog();
            dialog.AddButton(cancelButton);
            dialog.Title = "عنوان";
            dialog.Message = "پیام هشدار";
            dialog.DialogType=BootstrapDialogType.Warning;
            dialog.DialogSize=BootstrapDialogSize.SizeNormal;
            dialog.Closable = false;
            dialog.AddData("data1","5");
        }
 
                    @Html.BootstrapDialog(dialogName, dialog)
                    @Html.RunBootstrapDialogMethod(dialogName,BootstrapDialogMethods.Open);
```
