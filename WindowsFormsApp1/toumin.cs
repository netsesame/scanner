﻿
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace toumin
{

    public class TransTextBox : RichTextBox
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prams = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    prams.ExStyle |= 0x020; // transparent 
                    prams.ClassName = "RICHEDIT50W";// TRANSTEXTBOXW
                }
                return prams;
            }
        }
    }
}
