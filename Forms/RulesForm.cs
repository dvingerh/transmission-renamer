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
        private readonly bool editMode = false;
        private readonly bool debug = true;
        private RenameRule currentlyEditedRule;

        public RulesForm(bool editMode = false, RenameRule rule = null)
        {
            InitializeComponent();
            this.editMode = editMode;
            if (editMode && rule != null)
                ApplyEditingState(rule);
            else
                RuleTypeListBox.SelectedIndex = 0;

            if (debug)
            {
                InsertTextTextBox.Text = "S02E";
                InsertAfterTextRadioButton.Checked = true;
                InsertAfterTextTextBox.Text = "!! - ";
            }
        }

        private void ApplyEditingState(RenameRule rule)
        {
            Text = "Edit Rule";
            currentlyEditedRule = rule;
            switch (rule)
            {
                case InsertRule insertRule:
                    RuleTypeListBox.SelectedIndex = 0;
                    InsertTextTextBox.Text = insertRule.InsertText;
                    InsertPrefixRadioButton.Checked = insertRule.Prefix;
                    InsertSuffixRadioButton.Checked = insertRule.Suffix;
                    InsertAtPositionRadioButton.Checked = insertRule.Position;
                    InsertPositionNumericUpDown.Value = insertRule.PositionIndex;
                    InsertPositionRightLeftCheckBox.Checked = insertRule.PositionRightToLeft;
                    InsertBeforeTextRadioButton.Checked = insertRule.BeforeText;
                    InsertBeforeTextTextBox.Text = insertRule.BeforeTextStr;
                    InsertAfterTextRadioButton.Checked = insertRule.AfterText;
                    InsertAfterTextTextBox.Text = insertRule.AfterTextStr;
                    ReplaceCurrentFileNameRadioButton.Checked = insertRule.ReplaceFileName;
                    InsertIgnoreExtensionCheckBox.Checked = insertRule.IgnoreExtension;
                    break;
                case DeleteRule deleteRule:
                    RuleTypeListBox.SelectedIndex = 1;
                    DeleteFromPositionRadioButton.Checked = deleteRule.FromPosition;
                    DeleteFromPositionNumericUpDown.Value = deleteRule.FromPositionIndex;
                    DeleteFromDelimiterRadioButton.Checked = deleteRule.FromDelimiter;
                    DeleteFromDelimiterTextBox.Text = deleteRule.FromDelimiterStr;
                    DeleteToPositionRadioButton.Checked = deleteRule.ToPosition;
                    DeleteToPositionNumericUpDown.Value = deleteRule.ToPositionIndex;
                    DeleteToDelimiterRadioButton.Checked = deleteRule.ToDelimiter;
                    DeleteToDelimiterTextBox.Text = deleteRule.ToDelimiterStr;
                    DeleteToEndRadioButton.Checked = deleteRule.DeleteToEnd;
                    DeleteEntireFileNameCheckBox.Checked = deleteRule.DeleteEntireFileName;
                    DeleteKeepDelimitersCheckBox.Checked = deleteRule.KeepDelimiters;
                    DeleteIgnoreExtensionCheckBox.Checked = deleteRule.IgnoreExtension;
                    break;
            }
        }

        private void SelectRuleTab(object sender, EventArgs e)
        {
            RuleTypeTabControl.SelectedIndex = RuleTypeListBox.SelectedIndex;
            switch (RuleTypeTabControl.SelectedIndex)
            {
                case 0:
                    InsertTextTextBox.Focus();
                    break;
                case 1:
                    DeleteFromDelimiterTextBox.Focus();
                    break;
                default:
                    break;
            }
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
                    InsertRule insertRule = new InsertRule(insertText: InsertTextTextBox.Text,
                        beforeTextStr: InsertBeforeTextTextBox.Text,
                        afterTextStr: InsertAfterTextTextBox.Text,
                        prefix: InsertPrefixRadioButton.Checked,
                        suffix: InsertSuffixRadioButton.Checked,
                        position: InsertAtPositionRadioButton.Checked,
                        positionRightToLeft: InsertPositionRightLeftCheckBox.Checked,
                        beforeText: InsertBeforeTextRadioButton.Checked,
                        afterText: InsertAfterTextRadioButton.Checked,
                        replaceFileName: ReplaceCurrentFileNameRadioButton.Checked,
                        ignoreExtension: InsertIgnoreExtensionCheckBox.Checked,
                        positionIndex: (int)InsertPositionNumericUpDown.Value);

                    if (editMode)
                    {
                        int oldRuleIndex = Globals.RenameRules.IndexOf(Globals.RenameRules.Find(rule => rule.Id == currentlyEditedRule.Id));
                        Globals.RenameRules[oldRuleIndex] = insertRule;
                    }
                    else
                        Globals.RenameRules.Add(insertRule);
                    DialogResult = DialogResult.OK;
                    break;
                case 1:
                    DeleteRule deleteRule = new DeleteRule(fromPosition: DeleteFromPositionRadioButton.Checked,
                        fromDelimiter: DeleteFromDelimiterRadioButton.Checked,
                        toPosition: DeleteToPositionRadioButton.Checked,
                        toDelimiter: DeleteToDelimiterRadioButton.Checked,
                        deleteToEnd: DeleteToEndRadioButton.Checked,
                        deleteEntireFileName: DeleteEntireFileNameCheckBox.Checked,
                        ignoreExtension: DeleteIgnoreExtensionCheckBox.Checked,
                        rightToLeft: DeleteRightToLeftCheckBox.Checked,
                        keepDelimiters: DeleteKeepDelimitersCheckBox.Checked,
                        fromPositionIndex: (int)DeleteFromPositionNumericUpDown.Value,
                        toPositionIndex: (int)DeleteToPositionNumericUpDown.Value,
                        fromDelimiterStr: DeleteFromDelimiterTextBox.Text,
                        toDelimiterStr: DeleteToDelimiterTextBox.Text);

                    if (editMode)
                    {
                        int oldRuleIndex = Globals.RenameRules.IndexOf(Globals.RenameRules.Find(rule => rule.Id == currentlyEditedRule.Id));
                        Globals.RenameRules[oldRuleIndex] = deleteRule;
                    }
                    else
                        Globals.RenameRules.Add(deleteRule);
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    MessageBox.Show("An unknown error has occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void RulesForm_Shown(object sender, EventArgs e)
        {
            SelectRuleTab(null, null);
        }
    }
}
