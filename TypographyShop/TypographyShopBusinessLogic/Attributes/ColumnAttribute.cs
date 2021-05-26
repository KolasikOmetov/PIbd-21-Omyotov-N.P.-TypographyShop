using System;
using System.Windows.Forms;

namespace TypographyShopBusinessLogic.Attributes
{
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string title = "", bool visible = true, int width = 0, bool readOnly = true, GridViewAutoSize gridViewAutoSize = GridViewAutoSize.None, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.NotSet)
        {
            Title = title;
            Visible = visible;
            Width = width;
            GridViewAutoSize = gridViewAutoSize;
            Alignment = alignment;
            ReadOnly = readOnly;
        }
        public string Title { get; private set; }
        public bool Visible { get; private set; }
        public int Width { get; private set; }
        public bool ReadOnly { get; private set; }
        public GridViewAutoSize GridViewAutoSize { get; private set; }
        public DataGridViewContentAlignment Alignment { get; private set; }
    }
}
