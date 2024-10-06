using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace TWXMan
{
    class Public
    {
        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public static int CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!System.IO.Directory.Exists(destFolder))
                {
                    System.IO.Directory.CreateDirectory(destFolder);
                }
                //得到原文件根目录下的所有文件
                string[] files = System.IO.Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = System.IO.Path.GetFileName(file);
                    string dest = System.IO.Path.Combine(destFolder, name);
                    System.IO.File.Copy(file, dest);//复制文件
                }
                //得到原文件根目录下的所有文件夹
                string[] folders = System.IO.Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = System.IO.Path.GetFileName(folder);
                    string dest = System.IO.Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);//构建目标路径,递归复制文件
                }
                return 1;
            }
            catch (Exception e)
            {
                //todo
                e.ToString();
                return -1;
            }
        }

        public static void DecompressZip(string zipFile, string unzipToThisFolder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(unzipToThisFolder);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            ZipFile.ExtractToDirectory(zipFile, unzipToThisFolder);
        }

        public static void ExtractTomcat(string zipFile, string tomcatTargetDir)
        {
            string distributionName = "";
            if (Public.ExtractTomcatDistributionName(zipFile, out distributionName))
            {
                //临时目录
                string tempDir = Path.GetTempPath() + Guid.NewGuid().ToString() + @"\";

                //把tomcat压缩包解压到临时目录中
                DecompressZip(zipFile, tempDir);

                //解压缩之后的临时目录名
                string tempTomcatDir = tempDir + distributionName + @"\";

                //创建最终tomcat目录
                if (Directory.Exists(tomcatTargetDir) == false)
                    Directory.CreateDirectory(tomcatTargetDir);

                //拷贝temp下的tomcatFolderName目录中的所有文件到tomcat最终目录
                CopyFolder(tempTomcatDir, tomcatTargetDir);

                //删除临时目录
                Directory.Delete(tempDir, true);
            }

        }

        public static bool ExtractTomcatDistributionName(string zipPath, out string distributionName)
        {
            bool result = false;
            string dirname = "";

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                dirname = archive.Entries[0].FullName;

                //"apache-tomcat-9.0.63/"
                if (dirname.StartsWith("apache-tomcat-"))
                {
                    result = true;

                    //替换截取末尾的"/"
                    distributionName = dirname.Replace("/", "");
                }
                else
                {
                    result = false;
                    distributionName = "";
                }
            }

            return result;
        }

        public static bool ChangeTomcatPort(string tomcatDir, string strPort)
        {
            string serverxml = tomcatDir + @"\conf\server.xml";

            //如果文件server.xml不存在
            if (File.Exists(serverxml) == false)
                return false;

            //打开server.xml
            XmlDocument doc = new XmlDocument();

            doc.Load(serverxml);

            //
            XmlNodeList nodelist = doc.GetElementsByTagName("Connector");
            XmlElement xe = (XmlElement)nodelist[0];
            string str = xe.GetAttribute("port");
            xe.SetAttribute("port", strPort);

            //todo 保存后的XML空白、回车不应该被修改
            doc.Save(serverxml);

            return true;
        }

        public static bool CreateTomcatSetEnvFile(string tomcatDir)
        {
            string tmpfile = tomcatDir + @"\bin\setenv.bat";

            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(tmpfile, false, utf8);

            sw.WriteLine("set \"JAVA_OPTS=%JAVA_OPTS% -Duser.language=en -Duser.region=US -Dsun.jnu.encoding=UTF-8\"");
            sw.WriteLine("set \"JAVA_OPTS=%JAVA_OPTS% -Duser.timezone=UTC\"");
            sw.WriteLine("set \"JAVA_OPTS=%JAVA_OPTS% -Dserver -Dd64 -XX:+UseG1GC -Dfile.encoding=UTF-8\"");
            sw.WriteLine("set \"JAVA_OPTS=%JAVA_OPTS% -Djava.library.path=" + tomcatDir + "webapps\\Thingworx\\WEB-INF\\extensions\"");

            sw.Close();

            return true;
        }

        public static string GetHostName()
        {
            string host = Environment.GetEnvironmentVariable("COMPUTERNAME");
            return host;
        }

        public static string GetPostgreServiceName()
        {
            string name = "";

            List<string> list = ServiceManager.GetAllServiceName();

            foreach (string s in list)
            {
                if (s.StartsWith("postgresql-x64-"))
                    name = s;
            }

            return name;
        }
    }
}
