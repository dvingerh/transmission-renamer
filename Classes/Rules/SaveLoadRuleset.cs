using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace transmission_renamer.Classes.Rules
{
    public static class SaveLoadRuleset
    {
        public static bool SaveRulesToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Globals.RenameRules, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Ruleset files (*.json)|*.json",
                    Title = "Save ruleset",
                    InitialDirectory = Assembly.GetEntryAssembly().Location
            };
                DialogResult dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    File.WriteAllText(saveFileDialog.FileName, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save ruleset to file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool LoadRulesFromFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Ruleset files (*.json)|*.json",
                    Title = "Open saved ruleset",
                    InitialDirectory = Assembly.GetEntryAssembly().Location
                };
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    using (var stream = new StreamReader(openFileDialog.FileName))
                    {
                        Globals.RenameRules = JsonConvert.DeserializeObject<List<IRenameRule>>(stream.ReadToEnd(), new JsonSerializerSettings()
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load ruleset from file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
