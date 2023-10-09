using System.Runtime.InteropServices;
using AstroOffice.Enums;

namespace AstroOffice.Components
{
    internal class AdvRichTextBox : RichTextBox
    {
        private const int EM_SETEVENTMASK = 1073;

        private const int EM_GETPARAFORMAT = 1085;

        private const int EM_SETPARAFORMAT = 1095;

        private const int EM_SETTYPOGRAPHYOPTIONS = 1226;

        private const int WM_SETREDRAW = 11;

        private const int TO_ADVANCEDTYPOGRAPHY = 1;

        private const int PFM_ALIGNMENT = 8;

        private const int SCF_SELECTION = 1;

        private int updating = 0;

        private int oldEventMask = 0;

        private struct PARAFORMAT
        {
            public int cbSize;

            public uint dwMask;

            public short wNumbering;

            public short wReserved;

            public int dxStartIndent;

            public int dxRightIndent;

            public int dxOffset;

            public short wAlignment;

            public short cTabCount;

            public int[] rgxTabs;

            public int dySpaceBefore;

            public int dySpaceAfter;

            public int dyLineSpacing;

            public short sStyle;

            public byte bLineSpacingRule;

            public byte bOutlineLevel;

            public short wShadingWeight;

            public short wShadingStyle;

            public short wNumberingStart;

            public short wNumberingStyle;

            public short wNumberingTab;

            public short wBorderSpace;

            public short wBorderWidth;

            public short wBorders;
        }

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = false)]
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = false)]
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lp);

        public new TextAlign SelectionAlignment
        {
            get
            {
                TextAlign textAlign;
                PARAFORMAT PARAFORMAT = new();
                PARAFORMAT.cbSize = Marshal.SizeOf(PARAFORMAT);
                _ = SendMessage(new HandleRef(this, base.Handle), 1085, 1, ref PARAFORMAT);
                if ((PARAFORMAT.dwMask & 8) != 0)
                {
                    textAlign = (TextAlign)PARAFORMAT.wAlignment;
                }
                else
                {
                    textAlign = TextAlign.Left;
                }
                return textAlign;
            }
            set
            {
                PARAFORMAT PARAFORMAT = new()
                {
                    dwMask = 8,
                    wAlignment = (short)value
                };
                PARAFORMAT.cbSize = Marshal.SizeOf(PARAFORMAT);
                _ = SendMessage(new HandleRef(this, base.Handle), 1095, 1, ref PARAFORMAT);
            }
        }

        public AdvRichTextBox() { }

        public void BeginUpdate()
        {
            updating++;
            if (updating <= 1)
            {
                oldEventMask = SendMessage(new HandleRef(this, base.Handle), 1073, 0, 0);
                _ = SendMessage(new HandleRef(this, base.Handle), 11, 0, 0);
            }
        }

        public void EndUpdate()
        {
            updating--;
            if (updating <= 0)
            {
                _ = SendMessage(new HandleRef(this, base.Handle), 11, 1, 0);
                _ = SendMessage(new HandleRef(this, base.Handle), 1073, 0, this.oldEventMask);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _ = SendMessage(new HandleRef(this, base.Handle), 1226, 1, 1);
        }
    }
}
