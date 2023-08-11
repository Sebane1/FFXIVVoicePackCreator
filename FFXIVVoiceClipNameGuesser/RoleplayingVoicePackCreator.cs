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
    public partial class RoleplayingVoicePackCreator : Form {
        public RoleplayingVoicePackCreator() {
            InitializeComponent();
        }

        Dictionary<string, List<string>> _categories = new Dictionary<string, List<string>>();

        private void filePicker1_Load(object sender, EventArgs e) {

        }

        private void RoleplayingVoicePackCreator_Load(object sender, EventArgs e) {

        }

        private void soundList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void addCategoryButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(categoryComboBox.Text) && !categoryList.Items.Contains(categoryComboBox.Text)) {
                categoryList.Items.Add(categoryComboBox.Text);
                _categories.Add(categoryComboBox.Text, new List<string>());
            }
        }

        private void AddSoundButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK) {

            }
        }
    }
}
