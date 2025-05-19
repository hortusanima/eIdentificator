using eIdentificator.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eIdentificator.Infrastructure.Helpers
{
    public class FormHelper : IFormHelper
    {
        public void PopulateComboBoxByList(
            ComboBox comboBox,
            List<string> list
        )
        {
            comboBox.Items.Clear();
            foreach (string item in list)
            {
                comboBox.Items.Add(item);
            }
        }

        public void PopulateTextBoxByList<T>(
            TextBox textBox,
            List<T> list
        )
        {
            textBox.Text = string.Empty;

            foreach (T item in list)
            {
                var properties = item.GetType()
                    .GetProperties();
                string itemString = string.Join(
                    ", ", 
                    properties
                        .Select(
                            p => p.GetValue(item)?.ToString())
                );
                textBox.Text += "\r\n" + itemString;
            }

            if (list.Count > 0)
            {
                textBox.Text = textBox.Text.Substring(2);
            }
        }

        public void CenterControlHorizontal(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control.Parent != null)
                {
                    control.Left = (
                        control.Parent.ClientSize.Width - control.Width) / 2;
                }
            }
        }

        public void SetControlAbility(
            bool isEnabled, 
            params Control[] controls
        )
        {
            foreach (var control in controls)
            {
                control.Enabled = isEnabled;
            }
        }
    }
}
