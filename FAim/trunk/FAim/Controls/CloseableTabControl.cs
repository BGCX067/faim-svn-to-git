using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FAim.Controls
{
    public partial class CloseableTabControl : TabControl
    {

        //events
        public delegate void delOnHeaderClose(TabPage tab);
        public event delOnHeaderClose OnClose;

        //vars
        private bool bConfirmOnClose;

        /// <summary>
        /// Gets or Sets if user should confirm the closing of the tab.
        /// </summary>
        public bool ConfirmOnClose
        {
            get { return bConfirmOnClose; }
            set { bConfirmOnClose = value; }
        }


        /// <summary>
        /// Constructs a new CloseableTabControl
        /// </summary>
        public CloseableTabControl()
        {
            InitializeComponent();
            CustomInit();
        }

        /// <summary>
        /// Custom Init. Called after InitComponents.
        /// </summary>
        private void CustomInit()
        {

            //variable defaults
            bConfirmOnClose = false;
            this.TabStop = false;

        }

        

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            if (e.Bounds != RectangleF.Empty)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF tabTextArea = RectangleF.Empty;

                for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
                {
                    if (nIndex != this.SelectedIndex)
                    {
                        tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                        GraphicsPath _Path = new GraphicsPath();
                        _Path.AddRectangle(tabTextArea);
                        using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);
                            _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight, 
                                                      Color.FromArgb(255,SystemColors.ControlLight),SystemColors.ControlDark,
                                                      SystemColors.ControlLightLight};

                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;

                            e.Graphics.FillPath(_Brush, _Path);
                            using (Pen pen = new Pen(SystemColors.ActiveBorder))
                            {
                                e.Graphics.DrawPath(pen, _Path);
                            }


                            _ColorBlend.Colors = new Color[]{  SystemColors.ActiveBorder, 
                                                        SystemColors.ActiveBorder,SystemColors.ActiveBorder,
                                                        SystemColors.ActiveBorder};

                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;
                            e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                            using (Pen pen = new Pen(Color.White, 2))
                            {
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                            }
                            
                        }
                        //_Path.Dispose();

                    }
                    else
                    {

                        tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                        GraphicsPath _Path = new GraphicsPath();
                        _Path.AddRectangle(tabTextArea);
                        using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);
                            _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight, 
                                                      Color.FromArgb(255,SystemColors.Control),SystemColors.ControlLight,
                                                      SystemColors.Control};
                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;
                            e.Graphics.FillPath(_Brush, _Path);
                            using (Pen pen = new Pen(SystemColors.ActiveBorder))
                            {
                                e.Graphics.DrawPath(pen, _Path);
                            }
                            //Drawing Close Button
                            _ColorBlend.Colors = new Color[]{Color.FromArgb(255,231,164,152), 
                                                      Color.FromArgb(255,231,164,152),Color.FromArgb(255,197,98,79),
                                                      Color.FromArgb(255,197,98,79)};
                            _Brush.InterpolationColors = _ColorBlend;
                            e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                            e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                            using (Pen pen = new Pen(Color.White, 2))
                            {
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                                e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                            }
                            
                        }
                        _Path.Dispose();
                    }
                    string str = this.TabPages[nIndex].Text;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(str, this.Font, new SolidBrush(this.TabPages[nIndex].ForeColor), tabTextArea, stringFormat);


                }
            }

        }

        /// <summary>
        /// When the mouse moves, change header.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {

            if (!DesignMode)
            {
                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
                {
                    RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                    tabTextArea =
                        new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                                       tabTextArea.Height - 5);

                    Point pt = new Point(e.X, e.Y);
                    if (tabTextArea.Contains(pt))
                    {
                        using (
                            LinearGradientBrush _Brush =
                                new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                        LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);
                            _ColorBlend.Colors = new Color[]
                              {
                                  Color.FromArgb(255, 252, 193, 183),
                                  Color.FromArgb(255, 252, 193, 183), Color.FromArgb(255, 210, 35, 2),
                                  Color.FromArgb(255, 210, 35, 2)
                              };
                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;

                            g.FillRectangle(_Brush, tabTextArea);
                            g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                            tabTextArea.Height - 4);
                            using (Pen pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                                g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                            }
                        }
                    }
                    else
                    {
                        if (nIndex != SelectedIndex)
                        {
                            using (
                                LinearGradientBrush _Brush =
                                    new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                            LinearGradientMode.Vertical))
                            {
                                ColorBlend _ColorBlend = new ColorBlend(3);
                                _ColorBlend.Colors = new Color[]
                                  {
                                      SystemColors.ActiveBorder,
                                      SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                      SystemColors.ActiveBorder
                                  };
                                _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                                _Brush.InterpolationColors = _ColorBlend;

                                g.FillRectangle(_Brush, tabTextArea);
                                g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                                tabTextArea.Height - 4);
                                using (Pen pen = new Pen(Color.White, 2))
                                {
                                    g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                                    g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                                }
                            }
                        }
                    }
                }
                g.Dispose();
            }

        }

        /// <summary>
        /// Draws on the Mouse Leave
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {

            Graphics g = CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF tabTextArea = RectangleF.Empty;
            for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
            {
                if (nIndex != this.SelectedIndex)
                {
                    tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                    GraphicsPath _Path = new GraphicsPath();
                    _Path.AddRectangle(tabTextArea);
                    using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);

                        _ColorBlend.Colors = new Color[]{  SystemColors.ActiveBorder, 
                                                        SystemColors.ActiveBorder,SystemColors.ActiveBorder,
                                                        SystemColors.ActiveBorder};

                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;
                        g.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 2, tabTextArea.Height - 5);
                        g.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        
                    }
                    _Path.Dispose();

                }
                else
                {

                    tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                    GraphicsPath _Path = new GraphicsPath();
                    _Path.AddRectangle(tabTextArea);
                    using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);
                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };

                        _ColorBlend.Colors = new Color[]{Color.FromArgb(255,231,164,152), 
                                                      Color.FromArgb(255,231,164,152),Color.FromArgb(255,197,98,79),
                                                      Color.FromArgb(255,197,98,79)};
                        _Brush.InterpolationColors = _ColorBlend;
                        g.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        g.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            g.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }
                        
                    }
                    _Path.Dispose();
                }

            }

            g.Dispose(); 

        }//end function

        /// <summary>
        /// When the mouse is clicked.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (!DesignMode)
            {
                RectangleF tabTextArea = (RectangleF)this.GetTabRect(SelectedIndex);
                tabTextArea =
                    tabTextArea =
                    new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                                   tabTextArea.Height - 5);
                Point pt = new Point(e.X, e.Y);
                if (tabTextArea.Contains(pt))
                {
                    if (bConfirmOnClose)
                    {
                        if (
                            MessageBox.Show(
                                "You are about to close the conversation with " + this.TabPages[SelectedIndex].Text.TrimEnd() +
                                ". Are you sure you want to continue?", "Confirm close", MessageBoxButtons.YesNo) ==
                            DialogResult.No)
                            return;
                    }
                    //Fire Event to Client
                    if (OnClose != null)
                    {
                        OnClose(this.SelectedTab);
                    }
                }
                
            }

        }//end mouse down function

    }
}
