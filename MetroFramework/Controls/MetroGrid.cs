using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Interfaces;
using MetroFramework.Components;
using MetroFramework;
using MetroFramework.Drawing;
using MetroFramework.Controls;

namespace MetroFramework.Controls
{
    public partial class MetroGrid : DataGridView, IMetroControl
    {
        #region Interface
        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroColorStyle.Blue;
                }

                return metroStyle;
            }
            set { metroStyle = value; StyleGrid(); }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroThemeStyle.Light;
                }

                return metroTheme;
            }
            set { metroTheme = value; StyleGrid(); }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; StyleGrid(); }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category("Metro Behaviour")]
        [DefaultValue(true)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }
        #endregion

        #region Properties
        float _offset = 0.2F;
        [DefaultValue(0.2F)]
        public float HighLightPercentage { get { return _offset; } set { _offset = value; } }
        #endregion

        MetroDataGridHelper scrollhelper = null;
        MetroDataGridHelper scrollhelperH = null;


        public MetroGrid()
        {
            InitializeComponent();

            StyleGrid();

            this.Controls.Add(_vertical);
            this.Controls.Add(_horizontal);

            this.Controls.SetChildIndex(_vertical, 0);
            this.Controls.SetChildIndex(_horizontal, 1);

            _horizontal.Visible = false;
            _vertical.Visible = false;

            scrollhelper = new MetroDataGridHelper(_vertical, this);
            scrollhelperH = new MetroDataGridHelper(_horizontal, this, false);

            this.DoubleBuffered = true;
        }

        protected override void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
        {
            base.OnColumnStateChanged(e);
            if (e.StateChanged == DataGridViewElementStates.Visible)
            {
                scrollhelper.UpdateScrollbar();
                scrollhelperH.UpdateScrollbar();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.RowCount > 1)
            {
                if (e.Delta > 0 && this.FirstDisplayedScrollingRowIndex > 0)
                {
                    this.FirstDisplayedScrollingRowIndex--;
                }
                else if (e.Delta < 0)
                {
                    this.FirstDisplayedScrollingRowIndex++;
                }
            }       
        }

        private void StyleGrid()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackColor = MetroPaint.BackColor.Form(Theme);
            this.BackgroundColor = MetroPaint.BackColor.Form(Theme);
            this.GridColor = MetroPaint.BackColor.Form(Theme);
            this.ForeColor = MetroPaint.ForeColor.Button.Disabled(Theme);
            this.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);

            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AllowUserToResizeRows = false;

            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = MetroPaint.GetStyleColor(Style);
            this.ColumnHeadersDefaultCellStyle.ForeColor = MetroPaint.ForeColor.Button.Press(Theme);

            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersDefaultCellStyle.BackColor = MetroPaint.GetStyleColor(Style);
            this.RowHeadersDefaultCellStyle.ForeColor = MetroPaint.ForeColor.Button.Press(Theme);

            this.DefaultCellStyle.BackColor = MetroPaint.BackColor.Form(Theme);

            this.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(MetroPaint.GetStyleColor(Style), _offset);
            this.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);

            this.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(MetroPaint.GetStyleColor(Style), _offset);
            this.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);

            this.RowHeadersDefaultCellStyle.SelectionBackColor = ControlPaint.Light(MetroPaint.GetStyleColor(Style), _offset);
            this.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);

            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = ControlPaint.Light(MetroPaint.GetStyleColor(Style), _offset);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 17, 17);
        }
    }

    public class MetroDataGridHelper
    {
        /// <summary>
        /// The associated scrollbar or scrollbar collector
        /// </summary>
        private MetroScrollBar _scrollbar;

        /// <summary>
        /// Associated Grid
        /// </summary>
        private DataGridView _grid;

        /// <summary>
        /// if greater zero, scrollbar changes are ignored
        /// </summary>
        private int _ignoreScrollbarChange = 0;

        /// <summary>
        /// 
        /// </summary>
        private bool _ishorizontal = false;
        private HScrollBar hScrollbar = null;
        private VScrollBar vScrollbar = null;

        public MetroDataGridHelper(MetroScrollBar scrollbar, DataGridView grid)
        {
            new MetroDataGridHelper(scrollbar, grid,true);
        }

        public MetroDataGridHelper(MetroScrollBar scrollbar, DataGridView grid, bool vertical)
        {
            _scrollbar = scrollbar;
            _scrollbar.UseBarColor = true;
            _grid = grid;
            _ishorizontal = !vertical;

            foreach (var item in _grid.Controls)
            {
                if (item.GetType() == typeof(VScrollBar))
                {
                    vScrollbar = (VScrollBar)item;
                }

                if (item.GetType() == typeof(HScrollBar))
                {
                    hScrollbar = (HScrollBar)item;
                }
            }

            _grid.RowsAdded += new DataGridViewRowsAddedEventHandler(_grid_RowsAdded);
            _grid.UserDeletedRow += new DataGridViewRowEventHandler(_grid_UserDeletedRow);
            _grid.Scroll += new ScrollEventHandler(_grid_Scroll);
            _grid.Resize += new EventHandler(_grid_Resize);
            _scrollbar.Scroll += _scrollbar_Scroll;
            _scrollbar.ScrollbarSize = 17;

            UpdateScrollbar();
        }

        void _grid_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateScrollbar();
        }

        void _scrollbar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (_ignoreScrollbarChange > 0) return;

            if (_ishorizontal)
            {
                try
                {
                    hScrollbar.Value = _scrollbar.Value;
                    _grid.HorizontalScrollingOffset = _scrollbar.Value;
                }
                catch { }
            }
            else
            {
                try
                {
                    int firstDisplayedRowIndex = 0;

                    if (_scrollbar.Value >= 0 && _scrollbar.Value < _grid.Rows.Count)
                    {
                        firstDisplayedRowIndex = _scrollbar.Value + (_scrollbar.Value == 1 ? -1 : 1) >= _grid.Rows.Count ? _grid.Rows.Count - 1 : _scrollbar.Value + (_scrollbar.Value == 1 ? -1 : 1);
                    }  else
                    {
                        firstDisplayedRowIndex = _scrollbar.Value -1;
                    }

                    while (! _grid.Rows[firstDisplayedRowIndex].Visible)
	                {
	                    if (firstDisplayedRowIndex<1) 
                        {
                            firstDisplayedRowIndex = 0;
                        } else
                        {
                            firstDisplayedRowIndex -=1;
                        }
	                }

                    _grid.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
                }
                catch (Exception)
                {
                    _grid.FirstDisplayedScrollingRowIndex = 0;
                }
            }

            _grid.Invalidate();
        }

        private void BeginIgnoreScrollbarChangeEvents()
        {
            _ignoreScrollbarChange++;
        }

        private void EndIgnoreScrollbarChangeEvents()
        {
            if (_ignoreScrollbarChange > 0)
                _ignoreScrollbarChange--;
        }

        /// <summary>
        /// Updates the scrollbar values
        /// </summary>
        public void UpdateScrollbar()
        {
            if (_grid == null) return;
            try
            {
                BeginIgnoreScrollbarChangeEvents();

                if (_ishorizontal)
                {
                    int visibleCols = VisibleFlexGridCols();
                    _scrollbar.Maximum = hScrollbar.Maximum;
                    _scrollbar.Minimum = hScrollbar.Minimum;
                    _scrollbar.SmallChange = hScrollbar.SmallChange;
                    _scrollbar.LargeChange = hScrollbar.LargeChange;
                    _scrollbar.Location = new Point(0, _grid.Height - _scrollbar.ScrollbarSize);
                    _scrollbar.Width = _grid.Width - (vScrollbar.Visible ? _scrollbar.ScrollbarSize : 0);
                    _scrollbar.BringToFront();
                    _scrollbar.Visible = hScrollbar.Visible;
                    _scrollbar.Value = hScrollbar.Value == 0 ? 1 : hScrollbar.Value;
                }
                else
                {
                    int visibleRows = VisibleFlexGridRows();
                    _scrollbar.Maximum = _grid.RowCount;
                    _scrollbar.Minimum = 1;
                    _scrollbar.SmallChange = 1;
                    _scrollbar.LargeChange = Math.Max(1, visibleRows - 1);
                    _scrollbar.Value = _grid.FirstDisplayedScrollingRowIndex;
                    if (_grid.RowCount > 0 && _grid.Rows[_grid.RowCount - 1].Cells[0].Displayed)
                    {
                        _scrollbar.Value =  _grid.RowCount;
                    }
                    _scrollbar.Location = new Point(_grid.Width - _scrollbar.ScrollbarSize, 0);
                    _scrollbar.Height = _grid.Height - (hScrollbar.Visible ? _scrollbar.ScrollbarSize : 0);
                    _scrollbar.BringToFront();
                    _scrollbar.Visible = vScrollbar.Visible;
                }
            }
            finally
            {
                EndIgnoreScrollbarChangeEvents();
            }
        }

        /// <summary>
        /// Determine the current count of visible rows
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridRows()
        {
            return _grid.DisplayedRowCount(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridCols()
        {
            return _grid.DisplayedColumnCount(true);
        }

        public bool VisibleVerticalScroll()
        {
            bool _return = false;

            if (_grid.DisplayedRowCount(true) < _grid.RowCount + (_grid.RowHeadersVisible ? 1 : 0))
            {
                _return = true;
            }

            return _return;
        }

        public bool VisibleHorizontalScroll()
        {
            bool _return = false;

            if (_grid.DisplayedColumnCount(true) < _grid.ColumnCount + (_grid.ColumnHeadersVisible ? 1 : 0))
            {
                _return = true;
            }

            return _return;
        }

        #region Events of interest

        void _grid_Resize(object sender, EventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            UpdateScrollbar();
        }
        #endregion
    }
}
