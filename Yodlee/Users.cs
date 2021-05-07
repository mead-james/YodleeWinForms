using Newtonsoft.Json;

namespace Yodlee
{
    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Preferences
    {
        public string currency { get; set; }
        public string timeZone { get; set; }
        public string dateFormat { get; set; }
        public string locale { get; set; }
    }

    public class User
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonIgnore]
        public string loginName { get; set; }
        public string email { get; set; }
        public Name name { get; set; }
        public Preferences preferences { get; set; }
        public Address address { get; set; }
    }

    public class Users
    {
        public User user { get; set; }
    }
}
