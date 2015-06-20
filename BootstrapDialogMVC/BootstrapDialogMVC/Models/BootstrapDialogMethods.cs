namespace Models
{
    public enum BootstrapDialogMethods
    {
        Open,
        Close,
        /// <summary>
        /// Return the raw modal
        /// </summary>
        GetModal,
        /// <summary>
        ///  	Return the raw modal dialog.
        /// </summary>
        GetModalDialog,
        /// <summary>
        /// Return the raw modal content.
        /// </summary>
        GetModalContent,
        /// <summary>
        /// Return the raw modal header.
        /// </summary>
        GetModalHeader,
        /// <summary>
        ///  	Return the raw modal body.
        /// </summary>
        GetModalBody,
        /// <summary>
        /// Return the raw modal footer.
        /// </summary>
        GetModalFooter,
        /// <summary>
        /// 1 Parameter (key)
        /// </summary>
        GetData,
        /// <summary>
        /// 2 parameters (key,value)
        /// </summary>
        SetData,
        /// <summary>
        /// Disable all buttons in dialog footer when it's false, enable all when it's true.
        /// 1 parameter (true or false)
        /// </summary>
        EnableButtons,
        /// <summary>
        /// When set to true (default), dialog can be closed by clicking close icon in dialog header, or by clicking outside the dialog, or, ESC key is pressed.
        /// 1 parameter (true or false)
        /// </summary>
        SetClosable,
        /// <summary>
        /// Calling dialog.open() will automatically get this method called first, but if you want to do something on your dialog before it's shown, you can manually call dialog.realize() before calling dialog.open().
        /// </summary>
        Realize
    }
}