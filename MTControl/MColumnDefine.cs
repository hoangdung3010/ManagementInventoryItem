using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTControl
{
   public class MColumnDefine
    {
        // Methods
        public static DataGridViewCheckBoxColumn CheckboxColumn(string properties, string name, int width) =>
            new DataGridViewCheckBoxColumn
            {
                Name = properties,
                DataPropertyName = properties,
                HeaderText = name,
                HeaderCell = { Style = {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(0, 0, 0xff),
            } },
                Width = width
            };

        public static DataGridViewCheckBoxColumn CheckboxColumn(string properties, string name, Color color, int width) =>
            new DataGridViewCheckBoxColumn
            {
                Name = properties,
                DataPropertyName = properties,
                HeaderText = name,
                Width = width,
                HeaderCell = { Style = {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = color
            } },
                DefaultCellStyle = { ForeColor = color }
            };

        public static DataGridViewTextBoxColumn TextboxColumn(string properties, string name, int width) =>
            new DataGridViewTextBoxColumn
            {
                Name = properties,
                DataPropertyName = properties,
                HeaderText = name,
                HeaderCell = { Style = {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.White
            } },
                Width = width,
                MinimumWidth = width
            };

        public static DataGridViewLinkColumn LinkColumn(string properties, string name, int width) =>
            new DataGridViewLinkColumn
            {
                Name = properties,
                DataPropertyName = properties,
                HeaderText = name,
                HeaderCell = { Style = {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.White
            } },
                Width = width,
                MinimumWidth = width
            };

        public static DataGridViewTextBoxColumn TextboxColumn(string properties, string name, Color color, int width) =>
            new DataGridViewTextBoxColumn
            {
                Name = properties,
                DataPropertyName = properties,
                HeaderText = name,
                HeaderCell = { Style = {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = color
            } },
                DefaultCellStyle = { ForeColor = color },
                Width = width
            };
    }
}
