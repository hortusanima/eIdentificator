using System.Collections.Generic;
using System.Windows.Forms;

namespace eIdentificator.Domain.Interfaces
{
    public interface IFormHelper
    {
        void PopulateComboBoxByList(ComboBox comboBox, List<string> list);
        void PopulateTextBoxByList<T>(TextBox textBox, List<T> list);
        void CenterControlHorizontal(params Control[] controls);
        void SetControlAbility(bool isEnabled, params Control[] controls);
    }
}
