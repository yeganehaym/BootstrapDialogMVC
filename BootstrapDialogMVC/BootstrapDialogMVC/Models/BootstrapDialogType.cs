using Reflections;

namespace Models
{
    public enum BootstrapDialogType 
    {
        [EnumDescription("BootstrapDialog.TYPE_DEFAULT")]
        Default,
        [EnumDescription("BootstrapDialog.TYPE_PRIMARY")]
        Primary,
        [EnumDescription("BootstrapDialog.TYPE_INFO")]
        Info,
        [EnumDescription("BootstrapDialog.TYPE_SUCCESS")]
        Success,
        [EnumDescription("BootstrapDialog.TYPE_DANGER")]
        Danger,
        [EnumDescription("BootstrapDialog.TYPE_WARNING")]
        Warning 
    }
}