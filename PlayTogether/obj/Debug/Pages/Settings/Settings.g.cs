﻿

#pragma checksum "E:\projetC#\PlayTogether\PlayTogether\Pages\Settings\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "56090FBFBCD0EAD3855DF8A3468C4DCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayTogether.Pages.Settings
{
    partial class Settings : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 95 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Cancel_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 90 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Save_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 76 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.VibrationGrid_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 68 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SoundGrid_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 51 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.scoreStartDown;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 52 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.scoreStartUp;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 34 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.timeStartDown;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 35 "..\..\..\Pages\Settings\Settings.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.timeStartUp;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

