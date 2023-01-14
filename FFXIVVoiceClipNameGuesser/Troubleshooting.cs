using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public partial class Troubleshooting : Form {
        public Troubleshooting() {
            InitializeComponent();
        }

        private void Troubleshooting_Load(object sender, EventArgs e) {
            troubleshootingBox.Rtf = @"{\rtf1\ansi \b Why wont my sound change after regenerating and refreshing with an updated sound?\b0" +
                @"\par\r\n Reboot the game. Penumbra is unable to refresh sound due to how the game handles memory resources." +
                @"\par\r\n Its up to the Penumbra team to decide if this is something they can try and tackle, or even feasibly resolve." +
                @"\par\r\n Simply preview and troubleshoot all your sound changes in the tool before exporting." +
                @"\par\r\n \par\r\n \b How do I pull original sounds from the game? FFXIVExplorer doesn't have names for everything!\b0" +
                @"\par\r\n Use VFXEditor alongside Sound Filter to discover and grab original sound files. Its much more convenient, and has ALL the file names." +
                @"\par\r\n \par\r\n \b Why don't my voices work using Glamourer?\b0" +
                @"\par\r\n Glamourer will make the game either pick another in game voice for you, or give you no voice to reference depending on the situation." +
                @"\par\r\n If your character still has a voice at all, make sure you are referencing whatever voice the game decided to slap on you while using glamourer." +
                @"\par\r\n \par\r\n \b My mod is not appearing in penumbra after generation.\b0" +
                @"\par\r\n Verify you selected your root penumbra folder, and did not select any manually created folders. This tool will automatically create folders for you." +
                @"\par\r\n In a legacy version of the program you had to manually create folders, but this is no longer a requirement, and is unsupported if you do so." +
                @"\par\r\n If you selected a manually created folder, delete it. In the tool select Config -> Change Penumbra Folder. You will then be prompted to select your root penumbra folder." +
                @"\par\r\n You will not be prompted to select a folder for future mod generation, and the required folders will be created for you based on the mod name entered.}";
        }
    }
}
