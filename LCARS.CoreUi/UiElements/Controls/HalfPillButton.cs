﻿using LCARS.CoreUi.Enums;
using LCARS.CoreUi.UiElements.Base;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LCARS.CoreUi.UiElements.Controls
{
    [System.ComponentModel.DefaultEvent("Click")]
    public class HalfPillButton : LcarsButtonBase
    {
        #region " Control Design Information "
        public HalfPillButton() : base()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SuspendLayout();
            //
            //HalfPillButton
            //
            Name = "HalfPillButton";
            Size = new Size(200, 100);
            ResumeLayout(false);

        }
        #endregion
        
        #region " Properties "
        LcarsButtonStyles buttonStyle = LcarsButtonStyles.PillRight;

        public LcarsButtonStyles ButtonStyle
        {
            get { return buttonStyle; }
            set
            {
                buttonStyle = value;
                DrawAllButtons();
            }
        }
        #endregion

        #region " Structures "
        public enum LcarsButtonStyles
        {
            PillRight = 0,
            PillLeft = 1
        }
        #endregion

        #region " Draw Half-Pill Button "
        public override Bitmap DrawButton()
        {
            Bitmap mybitmap = null;
            Graphics g = null;
            SolidBrush myBrush = new SolidBrush(ColorManager.GetColor(ColorFunction));

            if (AlertState == LcarsAlert.Red)
            {
                myBrush = new SolidBrush(Color.Red);
            }
            else if (AlertState == LcarsAlert.White)
            {
                myBrush = new SolidBrush(Color.White);
            }
            else if (AlertState == LcarsAlert.Yellow)
            {
                myBrush = new SolidBrush(Color.Yellow);
            }
            else if (AlertState == LcarsAlert.Custom)
            {
                myBrush = new SolidBrush(CustomAlertColor);
            }

            mybitmap = new Bitmap(Size.Width, Size.Height);
            g = Graphics.FromImage(mybitmap);

            g.FillRectangle(Brushes.Black, 0, 0, mybitmap.Width, mybitmap.Height);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            switch (buttonStyle)
            {
                case LcarsButtonStyles.PillRight:
                    g.FillRectangle(myBrush, 0, 0, Size.Width - (Size.Height / 2), Size.Height);
                    g.FillEllipse(myBrush, Size.Width - Size.Height, 0, Size.Height, Size.Height);
                    TextLocation = new Point(0, 0);
                    break;
                case LcarsButtonStyles.PillLeft:
                    g.FillRectangle(myBrush, Size.Height / 2, 0, Size.Width - (Size.Height / 2), Size.Height);
                    g.FillEllipse(myBrush, 0, 0, Size.Height, Size.Height);
                    TextLocation = new Point(Height / 2, 0);
                    break;
            }
            TextSize = new Size(Size.Width - (Size.Height / 2), Size.Height);
            g.Dispose();
            return mybitmap;
        }
        #endregion
    }
}
