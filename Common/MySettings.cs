using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Common
{
    public class MySettings
    {
        public static void Reload()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the collection of the section groups.
            ConfigurationSectionGroupCollection sectionGroups = config.SectionGroups;

            // Show the configuration values
            ShowSectionGroupCollectionInfo(sectionGroups);

            Console.WriteLine("FilePath {0}", config.FilePath);

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();

            string filename = fileMap.ExeConfigFilename;

            fileMap.ExeConfigFilename = @"ConfigTest.exe.config";
            // relative path names possible

            // Open another config file
            Configuration configToMap =
               ConfigurationManager.OpenMappedExeConfiguration(fileMap,
               ConfigurationUserLevel.None);

            //read/write from it as usual
            ConfigurationSection mySection = configToMap.GetSection("System.Configuration.ClientSettingsSection");
            configToMap.SectionGroups.Clear(); // make changes to it

            configToMap.Save(ConfigurationSaveMode.Full);  // Save changes
        }

        static void ShowSectionGroupCollectionInfo(ConfigurationSectionGroupCollection sectionGroups)
        {
            ClientSettingsSection clientSection;
            SettingValueElement value;

            foreach (ConfigurationSectionGroup group in sectionGroups)
            // Loop over all groups
            {
                if (!group.IsDeclared)
                    // Only the ones which are actually defined in app.config
                    continue;

                Console.WriteLine("Group {0}", group.Name);

                // get all sections inside group
                foreach (ConfigurationSection section in group.Sections)
                {
                    clientSection = section as ClientSettingsSection;
                    Console.WriteLine("\tSection: {0}", section);

                    if (clientSection == null)
                        continue;


                    foreach (SettingElement set in clientSection.Settings)
                    {
                        value = set.Value as SettingValueElement;
                        // print out value of each section
                        Console.WriteLine("\t\t{0}: {1}", set.Name, value.ValueXml.InnerText);
                    }
                }
            }
        }
    }
}
