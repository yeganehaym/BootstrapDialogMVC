using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Models;
using Reflections;

namespace Controls
{
    public static class Dialogs
    {


#region Bootstrap Dialog

        //========== Botstrap Dialog =========================
        //you should import these files on your page
        //"bootstrap-dialog.min.js" for script tag and "bootstrap-dialog.min.css" as style
        public static MvcHtmlString BootstrapDialog(this HtmlHelper helper, string dialogName,
            BootstrapDialog staffDialog)
        {
            //const and genral primary vars

            #region vars

            string code = "var {0} = new BootstrapDialog({{{1}}});";
            const string piece = "{0}:{1},";
            const string data = "data:{{{0}}},";
            const string pieceData = "'{0}':{1},";
            const string buttons = "buttons: [{0}]";
            const string button = "{{{0}}},";

            #endregion

            //=============== Properties ============================

            #region Properties

            var items = FetchProperties(staffDialog);
            string pieces = "";
            foreach (var listItem in items)
            {
            
                if(listItem.Value==null) continue;


                string value = listItem.Value.ToString().Trim().ToLower();



                if (!value.StartsWith("function"))
                {
                    value = string.Format("'{0}'", value);
                }



                pieces += string.Format(piece, listItem.Text.ToLower(), value);

            }

            #endregion


            //============== Enums =======================

            pieces += string.Format(piece, "size", staffDialog.DialogSize.GetDisplayText());
            pieces += string.Format(piece, "type", staffDialog.DialogType.GetDisplayText());


            #region Data Property

            if (staffDialog.Data != null && staffDialog.Data.Count > 0)
            {
                string realData = "";
                foreach (var dataItem in staffDialog.Data)
                {
                    realData += string.Format(pieceData, dataItem.Text, dataItem.Value);
                }
                pieces += string.Format(data, realData);

            }

            #endregion

            //============ Buttons ===================

            #region Buttons

            if (staffDialog.Buttons != null && staffDialog.Buttons.Count > 0)
            {

                string mybuttons = "";
                foreach (var buttonInfo in staffDialog.Buttons)
                {


                    var infos = FetchProperties(buttonInfo);
                    string realData = "";



                    foreach (var info in infos)
                    {


                        if(info.Value==null) continue;
                        string value = info.Value.ToString().Trim();


                        if (info.Type == typeof(string))
                        {
                            if (!value.ToLower().StartsWith("function"))
                                value = string.Format("'{0}'", value.ToLower());
                        }
                        else
                        {
                            value = value.ToLower();
                        }
                            realData += string.Format(piece, info.Text, value);

                       


                    }

                    mybuttons += String.Format(button, realData);

                }
                pieces += string.Format(buttons, mybuttons);



            }

            #endregion


            code = string.Format(code, dialogName,pieces);
            return MvcHtmlString.Create(code);
        }

        private static IEnumerable<ListItem> FetchProperties(object staffDialog)
        {
            var excludeStrings = new[] { "Data", "DialogType", "DialogSize","Buttons" };
            return GeneralReflections.GetPropertiesDetailed(staffDialog, null,excludeStrings);
        }

        //================================================================


        private static Dictionary<BootstrapDialogMethods, ListItem> ProvideDictionary()
        {
            var methoDictionary = new Dictionary<BootstrapDialogMethods, ListItem>();

            methoDictionary.Add(BootstrapDialogMethods.Open, new ListItem("open", 0));
            methoDictionary.Add(BootstrapDialogMethods.Close, new ListItem("close", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModal, new ListItem("getModal", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModalDialog, new ListItem("getModalDialog", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModalContent, new ListItem("getModalContent", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModalHeader, new ListItem("getModalHeader", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModalBody, new ListItem("getModalBody", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetModalFooter, new ListItem("getModalFooter", 0));
            methoDictionary.Add(BootstrapDialogMethods.GetData, new ListItem("getData", 1));
            methoDictionary.Add(BootstrapDialogMethods.SetData, new ListItem("setData", 2));
            methoDictionary.Add(BootstrapDialogMethods.EnableButtons, new ListItem("enableButtons", 0));
            methoDictionary.Add(BootstrapDialogMethods.SetClosable, new ListItem("setClosable", 0));

            methoDictionary.Add(BootstrapDialogMethods.Realize, new ListItem("realize", 0));

            return methoDictionary;
        }

        public static string RunBootstrapDialogMethod(string dialogName, BootstrapDialogMethods method, string[] paramStrings = null)
        {
            string code = "{0}.{1}({2});";

            var item = ProvideDictionary()[method];

            var paramCount = (int)item.Value;
            if (paramCount == 0)
            {
                return string.Format(code,dialogName, item.Text, "");
            }
            if (paramStrings == null || paramStrings.Length == 0) return "";

            if (paramStrings.Length != paramCount) return "";

            string parameters = "";
            for (int i = 0; i < paramStrings.Length; i++)
            {
                parameters += paramStrings[i];
                if (paramStrings.Length - 1 != i)
                    parameters += ",";
            }

            return string.Format(code,dialogName, item.Text, parameters);
        }

        public static MvcHtmlString RunBootstrapDialogMethod(this HtmlHelper helper, string dialogName, BootstrapDialogMethods method,string[] paramStrings=null)
        {
            return MvcHtmlString.Create(RunBootstrapDialogMethod(dialogName,method,paramStrings));
        }

     
#endregion


    }
}
