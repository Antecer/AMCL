using JsonArchive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GetHash;

namespace ProfileSet
{
    public class Profile
    {
        public static void ProfilesSave(profiles Profiles, authenticationDatabase AuthData, String clientToken)
        {
            var launcherVer = new launcherVersion();
            launcherVer.name = "1.6.11";
            launcherVer.format = "17";

            string selectedUser = AuthData.uuid;

            AuthData.uuid = FormatUUID(AuthData.uuid);
            AuthData.userid = Hash.StringToMD5(AuthData.username);

            string selectedProfile = AuthData.displayName;


            Profiles.launcherVisibilityOnGameClose = "hide launcher and re-open when game closes";
            Profiles.useHopperCrashService = "false";
            Profiles.name = selectedProfile;

            var ProfilesJosn = new Dictionary<string, object>();

            var ProfilesList = new Dictionary<string, object>();
            var ProfilesName = new Dictionary<string, object>();
            ProfilesName.Add("name", selectedProfile);
            ProfilesName.Add("gameDir", Profiles.gameDir);
            ProfilesName.Add("lastVersionId", Profiles.lastVersionId);
            if (Profiles.resolution.Contains("*"))
            {
                var resolution = new Dictionary<string, object>();
                resolution.Add("width", (Profiles.resolution.Split('*'))[0]);
                resolution.Add("height", (Profiles.resolution.Split('*'))[1]);
                ProfilesName.Add("resolution", resolution);
            }
            ProfilesName.Add("useHopperCrashService", Profiles.useHopperCrashService);
            ProfilesName.Add("launcherVisibilityOnGameClose", Profiles.launcherVisibilityOnGameClose);
            ProfilesList.Add(selectedProfile, ProfilesName);
            ProfilesJosn.Add("profiles", ProfilesList);

            ProfilesJosn.Add("selectedProfile", selectedProfile);
            ProfilesJosn.Add("clientToken", clientToken);

            var AuthName = new Dictionary<string, object>();
            var DataBase = new Dictionary<string, object>();
            DataBase.Add("displayName", AuthData.displayName);
            DataBase.Add("accessToken", AuthData.accessToken);
            DataBase.Add("userid", AuthData.userid);
            DataBase.Add("uuid", AuthData.uuid);
            DataBase.Add("username", AuthData.username);
            AuthName.Add("authenticationDatabase", DataBase);
            ProfilesJosn.Add("authenticationDatabase", AuthName);

            ProfilesJosn.Add("selectedUser", selectedUser);

            var launcherVersion = new Dictionary<string, object>();
            launcherVersion.Add("name", launcherVer.name);
            launcherVersion.Add("format", launcherVer.format);
            ProfilesJosn.Add("launcherVersion", launcherVersion);

            String JSON = D2J.DictionaryToJson(ProfilesJosn);
            File.WriteAllText(Profiles.gameDir + @"\launcher_profiles.json", JSON);
        }

        public static string FormatUUID(string uuid)
        {
            string uuidnew = uuid;
            if (uuid.Length == 32)
            {
                uuidnew = uuid.Substring(0, 8) + "-";
                uuidnew += uuid.Substring(8, 4) + "-";
                uuidnew += uuid.Substring(12, 4) + "-";
                uuidnew += uuid.Substring(16, 4) + "-";
                uuidnew += uuid.Substring(20, 12) + "-";
            }
            return uuidnew;
        }

        public struct profiles
        {
            public string name;
            public string gameDir;
            public string lastVersionId;
            public string resolution;
            public string useHopperCrashService;
            public string launcherVisibilityOnGameClose;
        }
        public string selectedProfile;
        public string clientToken;
        public struct authenticationDatabase
        {
            public string displayName;
            public string accessToken;
            public string userid;
            public string uuid;
            public string username;
        }
        public struct launcherVersion
        {
            public string name;
            public string format;
        }
    }
}
