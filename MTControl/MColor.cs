using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MTControl
{
    public class MColor
    {
        //Màu cho grid control
        public static Color HeaderGridBackColor = Color.FromArgb(173, 199, 231);
        public static Color BorderHeaderGridColor = Color.FromArgb(173, 199, 231);

        public static Color FocusBackColor = Color.FromArgb(187, 222, 251);

        public static Color GridEvenRowBackColor = Color.White;
        public static Color GridOldRowBackColor = Color.WhiteSmoke;

        //Màu button trên form
        public static Color BackColorButtonBlue = Color.FromArgb(15,110,117);//Xanh đậm

        public static Color BackColorButtonGreen = Color.FromArgb(15, 176, 80);//Xanh lá cây
        public static Color BackColorButtonLightGray = Color.FromArgb(229, 229, 229);//Xám

        public static Color BackColorButtonDefault = Color.FromArgb(14,110,117);//Xanh đậm

        public static Color BackColorButtonCancel = Color.FromArgb(255, 42, 0);//Đỏ

        public static Color BackColorButtonDelete = BackColorButtonCancel;
        public static Color BackColorButtonSearch = BackColorButtonDefault;
        public static Color BackColorButtonNew = Color.FromArgb(76, 175, 80);//Xanh lá cây

        public static Color BackColorButtonOk = BackColorButtonDefault;//Xanh đậm

        public static Color BackColorButtonPrint = Color.FromArgb(255, 156, 45);//Xanh đậm

        public static Color BackgroundColorForm = Color.FromArgb(173, 199, 231);
        //Màu nền cho header grid,combo

        public static Color BackgroundColorHeader = Color.FromArgb(230,230,230);

        //Màu label
        public static Color ColorLabel = Color.FromArgb(0, 0, 0);

        //Màu của borderform
        public static Color BorderColorForm =  Color.FromArgb(15, 110, 176);

        public static Color BorderColorHeaderForm = Color.FromArgb(39, 134, 200);

        //Màu nền cho các control nhập liệu
        public static Color BackColorEditor = Color.FromArgb(255, 255, 255);
        public static Color BackColorEditorCheckbox = Color.FromArgb(235, 236, 239);
        

        //Màu khi focus vào control nhập liệu
        public static Color BorderColorFocusEditor = Color.FromArgb(9, 115, 185);

        public static Color BorderColorDefaultEditor = Color.FromArgb(0, 113, 193);
        public static Color ForeColorMenuStrip = Color.FromArgb(255,255,255);
        public static Color ForeColorSubMenuStrip = Color.FromArgb(255, 255, 255);

        public static Color BackColorMenuStrip = Color.FromArgb(9,115,185);
        public static Color BackColorSubMenuStrip = Color.FromArgb(0,80,130);
        //Màu text của tabpage
        public static Color ForeColorTabPage = Color.FromArgb(0, 114, 118);

        //Disable các control
        public static Color BackColorDisable = Color.FromArgb(229, 230, 235);
    }
}
