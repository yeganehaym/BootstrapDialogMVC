
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Models
{
    public class BootstrapDialog
    {

        public BootstrapDialog()
        {
            Title = "Title";
            Message = "Message";
            DialogType = BootstrapDialogType.Default;
            DialogSize = BootstrapDialogSize.SizeNormal;
            Closable = true;
            AutoDestroy = true;
        }


        //==================== properties ========================

        #region Properties

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        /// <summary>
        /// Give your dialog a specific look
        /// </summary>
        [DisplayName("Type")]
        public BootstrapDialogType DialogType { get; set; }

        [DisplayName("Size")]
        public BootstrapDialogSize DialogSize { get; set; }

        /// <summary>
        ///  	Additional css classes that will be added to your dialog. 
        /// </summary>
        [DisplayName("Cssclass")]
        public string CssClass { get; set; }

        /// <summary>
        /// When set to true, you can close the dialog by:Clicking the close icon in dialog header.Clicking outside the dialog.ESC key
        /// </summary>
        [DisplayName("Closable")]
        public bool Closable { get; set; }
        [DisplayName("Spinicon")]
        public string SpineIcon { get; set; }     

        /// <summary>
        /// When it's true, all modal stuff will be removed from the DOM tree after the dialog is popped down, set it to false if you need your dialog (same instance) pups up and down again and again. 
        /// </summary>
        [DisplayName("AutoDestroy")]
        public bool AutoDestroy { get; set; }

        /// <summary>
        /// If provided, 'aria-describedby' attribute will be added to the dialog with the description string as its value. This can improve accessibility, as the description can be read by screen readers. 
        /// </summary>
        [DisplayName("Description")]
        public string Description { get; set; }

        #endregion

        //======== Methods ===============================

        #region Data
        private ICollection<ListItem> _data { get; set; }

        public void AddData(string key, string value)
        {
            AddData(new ListItem(key, value));
        }

        public void AddData(ListItem item)
        {
            if (_data == null || _data.Count < 1)
                _data = new Collection<ListItem>();
            _data.Add(item);
        }

        public bool RemoveData(string key)
        {
            foreach (var item in _data)
            {
                if (item.Text == key)
                {
                    _data.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public ICollection<ListItem> Data
        {
            get { return _data; }
        }
        #endregion

        //===============================================================

        #region Buttons
        private ICollection<BootstrapDialogButton> _buttons;

        public void AddButton(BootstrapDialogButton button)
        {
            if(_buttons==null || _buttons.Count<1)
                _buttons=new Collection<BootstrapDialogButton>();

            _buttons.Add(button);
        }

        public bool RemoveButton(string key)
        {
            foreach (var item in _buttons)
            {
                if (item.Id == key)
                {
                    _buttons.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public ICollection<BootstrapDialogButton> Buttons
        {
            get { return _buttons; }
        }

        #endregion


        //======== Events ================

        #region Events

        /// <summary>
        /// If provided, it will be invoked when the dialog is popping up. 
        /// </summary>
         [DisplayName("onshow")]
        public string OnShow { get; set; }

        /// <summary>
        /// If provided, it will be invoked when the dialog is popped up. 
        /// </summary>
       [DisplayName("onshown")]
        public string OnShown { get; set; }

        /// <summary>
        /// If provided, it will be invoked when the dialog is popping down. 
        /// </summary>
       [DisplayName("onhide")]
        public string OnHide { get; set; }

        /// <summary>
        ///  	If provided, it will be invoked when the dialog is popped down. 
        /// </summary>
        [DisplayName("onhidden")]
        public string OnHidden { get; set; }

        #endregion
    }
}
