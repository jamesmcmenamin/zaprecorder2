using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BadWolf
{
    class BadWolf_Updater
    {
        private String trunkURL = "";
        private String pluginDir = "";
        private WebClient client;
        static readonly Regex LinkPattern = new Regex(@"<li><a href="".+"">(?<ln>.+(?:..))</a></li>", RegexOptions.CultureInvariant);

        public BadWolf_Updater(string svnLocation)
        {
            client = new WebClient();
            trunkURL = svnLocation;
            pluginDir = Application.StartupPath + "\\Plugins\\";
        }

        public int GetNewestRev()
        {
            string html = client.DownloadString(trunkURL);

            Match revisionMatch = Regex.Match(html, @"Revision ([A-Za-z0-9\-.]+):");

            if (revisionMatch.Success == true)
            {
                return int.Parse(revisionMatch.Groups[1].Value);
            }
            else
            {
                return 0;
            }
        }

        public bool UpdateAvailable(int revNumber)
        {
            return (GetNewestRev() > revNumber);
        }

        static string RemoveXmlEscapes(string xml)
        {
            return xml.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");
        }

        public Boolean DownloadUpdate()
        {
            return DownloadUpdate(trunkURL);
        }

        public Boolean DownloadUpdate(string remotePath)
        {
            try
            {
                string html = client.DownloadString(remotePath);
                MatchCollection results = LinkPattern.Matches(html);

                IEnumerable<Match> matches = from match in results.OfType<Match>() where match.Success && match.Groups["ln"].Success select match;

                foreach (Match match in matches)
                {
                    string file = RemoveXmlEscapes(match.Groups["ln"].Value);
                    string newUrl = remotePath + file.TrimStart(' ');

                    if (newUrl.Contains("Parent Directory"))
                        continue;

                    if (newUrl[newUrl.Length - 1] == '/')
                    {
                        // Recursive directory download
                        DownloadUpdate(newUrl);
                    }
                    else
                    {
                        string relativePath = pluginDir + remotePath.Replace(trunkURL, "").Replace('/', '\\');

                        String directoryName = Path.GetDirectoryName(relativePath);
                        DirectoryInfo info = new DirectoryInfo(relativePath);

                        if (!Directory.Exists(directoryName))
                        {
                            Directory.CreateDirectory(directoryName);
                        }
                        string fileName = newUrl.Replace(remotePath, "");

                        client.DownloadFile(newUrl, directoryName + "\\" + fileName);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
