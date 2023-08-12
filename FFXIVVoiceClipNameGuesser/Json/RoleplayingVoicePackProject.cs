using System.Collections.Generic;

namespace FFXIVVoicePackCreator.Json {
    public class RoleplayingVoicePackProject {
        string name;
        Dictionary<string, List<string>> _categories = new Dictionary<string, List<string>>();

        public RoleplayingVoicePackProject(string name, Dictionary<string, List<string>> categories) {
            this.name = name;
            _categories = categories;
        }

        public string Name { get => name; set => name = value; }
        public Dictionary<string, List<string>> Categories { get => _categories; set => _categories = value; }
    }
}
