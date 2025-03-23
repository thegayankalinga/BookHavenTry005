using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public static class DataGridViewUtility
    {
        public static void ConfigureGrid(DataGridView gridView, List<(string Name, DataGridViewAutoSizeColumnMode SizeMode)> columns)
        {
            // Clear existing columns
            gridView.Columns.Clear();

            // Add columns based on the provided configuration
            gridView.ColumnCount = columns.Count;

            for (int i = 0; i < columns.Count; i++)
            {
                gridView.Columns[i].Name = columns[i].Name;
                gridView.Columns[i].AutoSizeMode = columns[i].SizeMode;
            }

            // Apply common styling
            ApplyCommonGridStyling(gridView);
        }

        public static void ApplyCommonGridStyling(DataGridView gridView)
        {
            // Set row height to make it look better
            gridView.RowTemplate.Height = 30;

            // Enable full row selection
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;

            // Set better visual appearance
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToResizeColumns = true;
            gridView.AllowUserToResizeRows = false;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
    }
}
