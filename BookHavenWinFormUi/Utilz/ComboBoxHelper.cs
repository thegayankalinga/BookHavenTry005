using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public static class ComboBoxHelper
    {
        public static void LoadEnumToComboBox<TEnum>(ComboBox comboBox) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var enumList = new List<KeyValuePair<string, TEnum>>();

            foreach (var value in enumValues)
            {
                var fieldInfo = typeof(TEnum).GetField(value.ToString());
                var enumMemberAttribute = fieldInfo?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                                                   .FirstOrDefault() as EnumMemberAttribute;

                string displayName = enumMemberAttribute?.Value ?? value.ToString();
                enumList.Add(new KeyValuePair<string, TEnum>(displayName, value));
            }

            comboBox.DataSource = enumList;
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
        }
    

    public static void SelectEnumInComboBox<TEnum>(ComboBox comboBox, TEnum enumValue) where TEnum : Enum
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i] is KeyValuePair<string, TEnum> item && EqualityComparer<TEnum>.Default.Equals(item.Value, enumValue))
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

    }
}
