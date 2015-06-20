using System.ComponentModel;

namespace Models
{
    public class BootstrapDialogButton
    {
        /// <summary>
        ///  optional, if id is set, you can use dialogInstance.getButton(id) to get the button later.
        /// </summary>
        [DisplayName("id")]
        public string Id { get; set; }
        [DisplayName("icon")]
        public string Icon { get; set; }
        [DisplayName("label")]
        public string Label { get; set; }
        /// <summary>
        /// optional, additional css class to be added to the button. 
        /// </summary>
        [DisplayName("cssclass")]
        public string CssClass { get; set; }

        /// <summary>
        /// optinal, if it's true, after clicked the button a spinning icon appears. 
        /// </summary>
        [DisplayName("autospin")]
        public bool AutoSpin { get; set; }

        /// <summary>
        ///  optional, if provided, the callback will be invoked after the button is clicked, and the dialog instance will be passed to the callback function
        /// </summary>
        [DisplayName("action")]
        public string Action { get; set; }

        [DisplayName("hotkey")]
        public int Key { get; set; }
    }
}