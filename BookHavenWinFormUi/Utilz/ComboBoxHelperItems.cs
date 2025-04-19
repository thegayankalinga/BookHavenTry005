using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public class ComboBoxHelperItem<TId>
    {
        public TId Id { get; set; }
        public string Label { get; set; } = string.Empty;

        public ComboBoxHelperItem(TId id, string label)
        {
            Id = id;
            Label = label;
        }

        public override string ToString() => Label;
    }
}
