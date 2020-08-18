using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using transmission_renamer.Classes.Rules;

namespace transmission_renamer.Forms
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();
            RuleTypeListBox.SelectedIndex = 0;
        }

        private void SelectRuleTab(object sender, EventArgs e)
        {
            RuleTypeTabControl.SelectedIndex = RuleTypeListBox.SelectedIndex;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (Globals.RenameRules == null)
                Globals.RenameRules = new List<RenameRule>();
            switch (RuleTypeTabControl.SelectedIndex)
            {
                case 0:
                    InsertRule insertRule = new InsertRule(insertText: InsertTextTextBox.Text, beforeTextStr: InsertBeforeTextTextBox.Text,
                        afterTextStr: InsertAfterTextTextBox.Text, prefix: InsertPrefixRadioButton.Checked, suffix: InsertSuffixRadioButton.Checked,
                        position: PositionRadioButton.Checked, beforeText: InsertBeforeTextRadioButton.Checked, afterText: InsertAfterTextRadioButton.Checked,
                        replaceFileName: ReplaceCurrentFileNameRadioButton.Checked, ignoreExtension: InsertIgnoreExtensionCheckBox.Checked,positionIndex: (int)InsertPositionNumericUpDown.Value);

                    Globals.RenameRules.Add(insertRule);
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    MessageBox.Show("An unknown error has occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
