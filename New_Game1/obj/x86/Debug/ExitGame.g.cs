﻿#pragma checksum "C:\Users\il365\Documents\תיכנות\פרוייקטים\משחק בית המקדש\New_Game1\ExitGame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A550F87E00C516423785254B2917313A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_Game1
{
    partial class ExitGame : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // ExitGame.xaml line 11
                {
                    this.CanvasEndGameScreen = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 3: // ExitGame.xaml line 12
                {
                    this.InstructionsMusic = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 4: // ExitGame.xaml line 13
                {
                    this.txtBlWage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // ExitGame.xaml line 14
                {
                    this.btnNewGame = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnNewGame).Click += this.btnNewGame_Click;
                }
                break;
            case 6: // ExitGame.xaml line 15
                {
                    this.btnEndGame = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEndGame).Click += this.btnEndGame_Click;
                }
                break;
            case 7: // ExitGame.xaml line 16
                {
                    this.txtBlThisWorld2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // ExitGame.xaml line 17
                {
                    this.txtBlNextWorld2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // ExitGame.xaml line 18
                {
                    this.txtBlNextWorld = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // ExitGame.xaml line 19
                {
                    this.txtBlThisWorld = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // ExitGame.xaml line 20
                {
                    this.btnExit = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

