using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using Xamarin.Forms;
using System.IO;

namespace adatGyujtoX.Modell
{
    class Constans
    {
        public struct ParamData
        {
            public ParamData(string idValue, string param1Value, string param2Value, string param3Value)
            {
                IdData = idValue;
                Param1Data = param1Value;
                Param2Data = param2Value;
                Param3Data = param3Value;
            }

            public string IdData { get; private set; }
            public string Param1Data { get; private set; }
            public string Param2Data { get; private set; }
            public string Param3Data { get; private set; }
        }

        public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            int zipDarab = 0;
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                        zipDarab = zipDarab + 1;
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources

                }
            }
        }
        public static string RemoveNewLines(string input)
        {
            return input.Replace("\r\n", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("\r", string.Empty);
        }
        //public static ParamData param = new List<Constans.ParamData>();
        public static Dictionary<string, string> myParam = new Dictionary<string, string>();
        public static List<Tuple<string, string, string,int>> myParam2 = new List<Tuple<string, string,string,int>>();


        public static Questions aktSurvey = new Questions();
        public static Color BackgroundColor = Color.FromRgb(58, 153, 212);
        public static Color MainTextColor = Color.White;
        public static string webUrl = "http://qnr.cognative.hu/cogsurv/regist_ios2.php";
        public static string myZipPath = "";
        public static string myZipFile = "";
        public static object errorDuma = "";
        public static List<string> kellZip = new List<string>();
        public static int kellZipIndex = 0;
        //List<string> paramFromId = new List<string, int>();
        //public static string 



    }

}
