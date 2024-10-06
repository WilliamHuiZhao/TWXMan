using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;


namespace TWXMan
{
    class MyDir
    {
        private static string strAppDir = "";
        private static string strBinDir = "";
        private static string strConfDir = "";
        private static string strClusterDir = "";
        private static string strLogDir = "";
        private static string strRulesDir = "";
        private static string strPackageDir = "";
        private static string strHaproxyDir = "";
        private static string strIgniteDir = "";
        private static string strJDKDir = "";
        private static string strThingworxDir = "";
        private static string strTomcatDir = "";
        private static string strZookeeperDir = "";

        private static void dirNamesInit(string strAppFolder)
        {
            strAppDir = strAppFolder;
            strBinDir = strAppFolder + Constants.DIR_BIN;
            strConfDir = strAppFolder + Constants.DIR_CONF;
            strClusterDir = strAppFolder + Constants.DIR_CLUSTER;
            strLogDir = strAppFolder + Constants.DIR_LOG;
            strRulesDir = strAppFolder + Constants.DIR_RULES;
            strPackageDir = strAppFolder + Constants.DIR_PACKAGE;
            strHaproxyDir = strAppFolder + Constants.DIR_PACKAGE_HAPROXY;
            strIgniteDir = strAppFolder + Constants.DIR_PACKAGE_IGNITE;
            strJDKDir = strAppFolder + Constants.DIR_PACKAGE_JDK;
            strThingworxDir = strAppFolder + Constants.DIR_PACKAGE_THINGWORX;
            strTomcatDir = strAppFolder + Constants.DIR_PACKAGE_TOMCAT;
            strZookeeperDir = strAppFolder + Constants.DIR_PACKAGE_ZOOKEEPER;
        }

        public static string TomcatFullDir
        {
            get
            {
                return strTomcatDir;
            }
        }

        public static string ThingworxFullDir
        {
            get
            {
                return strThingworxDir;
            }
        }

        private static void createDir(string dirname)
        {
            if (Directory.Exists(dirname) == false)
                Directory.CreateDirectory(dirname);
        }

        public static void InitAppFolders(string appfolder)
        {
            dirNamesInit(appfolder);

            if (appfolder.Length > 1)
            {
                createDir(strBinDir);
                createDir(strConfDir);
                createDir(strClusterDir);
                createDir(strLogDir);
                createDir(strRulesDir);
                createDir(strPackageDir);
                createDir(strHaproxyDir);
                createDir(strIgniteDir);
                createDir(strJDKDir);
                createDir(strThingworxDir);
                createDir(strTomcatDir);
                createDir(strZookeeperDir);
            }
        }

        public static string getChecksum(string file)
        {
            using (BufferedStream stream = new BufferedStream(File.OpenRead(file), 1024 * 1024))
            {
                SHA256Managed sha = new SHA256Managed();

                byte[] checksum = sha.ComputeHash(stream);

                string result = BitConverter.ToString(checksum).Replace("-", String.Empty);

                return result;
            }
        }

        public static void IsThingworxPackage(string strFullName)
        {
            //检查文件名是否是Thingworx格式

            //验证压缩包checksum
            string checksum = getChecksum(strFullName);
        }

        public static ArrayList ListThingworxPackages(string strAppFolder)
        {
            ArrayList arr = new ArrayList();

            //扫描Thingworx手工安装包
            DirectoryInfo root = new DirectoryInfo(strThingworxDir);
            foreach (FileInfo f in root.GetFiles())
            {
                string name = f.Name;
                string fullName = f.FullName;

                //验证压缩包的Checksum

                //
                arr.Add(name);
            }


            return arr;
        }
        public static ArrayList ListTomcatPackages()
        {
            ArrayList arr = new ArrayList();

            //扫描Tomcat安装包
            DirectoryInfo root = new DirectoryInfo(strTomcatDir);
            foreach (FileInfo f in root.GetFiles())
            {
                if (f.Name.EndsWith(".zip"))
                {
                    arr.Add(f.Name);
                }
            }

            return arr;
        }

    }
}
