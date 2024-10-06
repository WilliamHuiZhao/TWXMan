using System.IO;
using System.Xml;

namespace TWXMan
{

    class ThingworxRuntime
    {
        //
        private string thingworxRuntimeName = "";
        private string thingworxPackage = "";
        private string thingworxInstallationFolder = "";
        private string tomcatRuntimeName = "";
        private string postgreHostName = "";
        private string postgrePort = "";
        private string thingworxDatabaseName = "";
        private string thingworxDBUserName = "";
        private string thingworxDBUserPassword = "";

        #region 属性
        public string ThingworxRuntimeName
        {
            get
            {
                return this.thingworxRuntimeName;
            }
            set
            {
                this.thingworxRuntimeName = value;
            }
        }
        public string ThingworxPackage
        {
            get
            {
                return this.thingworxPackage;
            }
            set
            {
                this.thingworxPackage = value;
            }
        }

        public string ThingworxInstallationFolder
        {
            get
            {
                return this.thingworxInstallationFolder;
            }
            set
            {
                this.thingworxInstallationFolder = value;
            }
        }
        public string TomcatRuntimeName
        {
            get
            {
                return this.tomcatRuntimeName;
            }
            set
            {
                this.tomcatRuntimeName = value;
            }
        }
        public string PostgreHostName
        {
            get
            {
                return this.postgreHostName;
            }
            set
            {
                this.postgreHostName = value;
            }
        }

        public string PostgrePort
        {
            get
            {
                return this.postgrePort;
            }
            set
            {
                this.postgrePort = value;
            }
        }
        public string ThingworxDatabaseName
        {
            get
            {
                return this.thingworxDatabaseName;
            }
            set
            {
                this.thingworxDatabaseName = value;
            }
        }
        public string ThingworxDBUserName
        {
            get
            {
                return this.thingworxDBUserName;
            }
            set
            {
                this.thingworxDBUserName = value;
            }
        }
        public string ThingworxDBUserPassword
        {
            get
            {
                return this.thingworxDBUserPassword;
            }
            set
            {
                this.thingworxDBUserPassword = value;
            }
        }
        #endregion

        #region ctor()
        public ThingworxRuntime()
        {

        }

        public ThingworxRuntime(XmlElement xe)
        {
            if (xe != null)
            {
                ThingworxRuntimeName = xe.GetAttribute(Constants.ATT_THINGWORXRUNTIMENAME);
                ThingworxPackage = xe.GetAttribute(Constants.ATT_THINGWORXPACKAGE);
                ThingworxInstallationFolder = xe.GetAttribute(Constants.ATT_THINGWORXINSTALLATIONFOLDER);
                TomcatRuntimeName = xe.GetAttribute(Constants.TAG_TOMCATRUNTIME);
                PostgreHostName = xe.GetAttribute(Constants.ATT_POSTGREHOSTNAME);
                PostgrePort = xe.GetAttribute(Constants.ATT_POSTGREPORT);
                ThingworxDatabaseName = xe.GetAttribute(Constants.ATT_THINGWORXDATABASENAME);
                ThingworxDBUserName = xe.GetAttribute(Constants.ATT_THINGWORXDBUSERNAME);
                ThingworxDBUserPassword = xe.GetAttribute(Constants.ATT_THINGWORXDBUSERPASSWORD);
            }
        }

        public ThingworxRuntime(string twxRuntimeName,
                string twxPackage,
                string twxInstallationFolder,
                string tomcatRuntimeName,
                string pgHostName,
                string pgPort,
                string twxDatabaseName,
                string twxDBUserName,
                string twxDBUserPassword)
        {
            this.ThingworxRuntimeName = twxRuntimeName;
            this.ThingworxPackage = twxPackage;
            this.ThingworxInstallationFolder = twxInstallationFolder;
            this.TomcatRuntimeName = tomcatRuntimeName;
            this.PostgreHostName = pgHostName;
            this.PostgrePort = pgPort;
            this.ThingworxDatabaseName = twxDatabaseName;
            this.ThingworxDBUserName = twxDBUserName;
            this.ThingworxDBUserPassword = twxDBUserPassword;
        }
        #endregion

        //Thingworx安装包解压到指定的文件夹
        public void ExtractThingworx()
        {
            Public.DecompressZip(this.ThingworxPackage, this.ThingworxInstallationFolder + "twxsetup");
        }

        //
        public void CreateThingworxFolders()
        {
            if (Directory.Exists(this.ThingworxInstallationFolder + "ThingworxPlatform") == false)
                Directory.CreateDirectory(this.ThingworxInstallationFolder + "ThingworxPlatform");

            if (Directory.Exists(this.ThingworxInstallationFolder + "ThingworxStorage") == false)
                Directory.CreateDirectory(this.ThingworxInstallationFolder + "ThingworxStorage");

            if (Directory.Exists(this.ThingworxInstallationFolder + "ThingworxBackupStorage") == false)
                Directory.CreateDirectory(this.ThingworxInstallationFolder + "ThingworxBackupStorage");

            if (Directory.Exists(this.ThingworxInstallationFolder + "ThingworxPostgresqlStorage") == false)
                Directory.CreateDirectory(this.ThingworxInstallationFolder + "ThingworxPostgresqlStorage");
        }

        public void CreatePlatformSettings()
        {
            //
            string filename = this.ThingworxInstallationFolder + @"ThingworxPlatform\platform-settings.json";
            StreamWriter sw = File.CreateText(filename);

            //
            sw.Write(@"{" + "\n");
            sw.Write(@"    ""PersistenceProviderPackageConfigs"": {" + "\n");
            sw.Write(@"        ""PostgresPersistenceProviderPackage"": {" + "\n");
            sw.Write(@"            ""ConnectionInformation"": {" + "\n");
            sw.Write(@"                ""jdbcUrl"": ""jdbc:postgresql://" + this.PostgreHostName + @":" + this.PostgrePort + @"/" + this.ThingworxDatabaseName + @"""," + "\n");
            sw.Write(@"                ""password"": """ + this.ThingworxDBUserPassword + @"""," + "\n");
            sw.Write(@"                ""username"": """ + this.ThingworxDBUserName + @"""" + "\n");
            sw.Write(@"            }" + "\n");
            sw.Write(@"        }" + "\n");
            sw.Write(@"    }," + "\n");
            sw.Write(@"    ""PlatformSettingsConfig"": {" + "\n");
            sw.Write(@"        ""AdministratorUserSettings"": {" + "\n");
            sw.Write(@"            ""InitialPassword"": ""rockwellautomation""" + "\n");
            sw.Write(@"        }," + "\n");
            sw.Write(@"        ""BasicSettings"": {" + "\n");
            sw.Write(@"            ""BackupStorage"": """ + this.ThingworxInstallationFolder.Replace(@"\", @"\\") + @"ThingworxBackupStorage""," + "\n");
            sw.Write(@"            ""DatabaseLogRetentionPolicy"": 7," + "\n");
            sw.Write(@"            ""EnableBackup"": true," + "\n");
            sw.Write(@"            ""EnableHA"": false," + "\n");
            sw.Write(@"            ""EnableSystemLogging"": true," + "\n");
            sw.Write(@"            ""HTTPRequestHeaderMaxLength"": 2000," + "\n");
            sw.Write(@"            ""HTTPRequestParameterMaxLength"": 2000," + "\n");
            sw.Write(@"            ""InternalAesCryptographicKeyLength"": 128," + "\n");
            sw.Write(@"            ""Storage"": """ + this.ThingworxInstallationFolder.Replace(@"\", @"\\") + @"ThingworxStorage""," + "\n");
            sw.Write(@"            ""ScriptTimeout"": 500" + "\n");
            sw.Write(@"        }," + "\n");
            sw.Write(@"        ""ContentTypeSettings"": {" + "\n");
            sw.Write(@"            ""supportedMediaEntityContentTypes"": [" + "\n");
            sw.Write(@"                ""image/svg+xml""," + "\n");
            sw.Write(@"                ""image/png""," + "\n");
            sw.Write(@"                ""image/gif""," + "\n");
            sw.Write(@"                ""image/bmp""," + "\n");
            sw.Write(@"                ""image/jpeg"", " + "\n");
            sw.Write(@"                ""application/pdf""," + "\n");
            sw.Write(@"                ""image/vnd.microsoft.icon""" + "\n");
            sw.Write(@"            ]" + "\n");
            sw.Write(@"        }," + "\n");
            sw.Write(@"        ""ExtensionPackageImportPolicy"": {" + "\n");
            sw.Write(@"            ""allowCSSResources"": true," + "\n");
            sw.Write(@"            ""allowEntities"": true," + "\n");
            sw.Write(@"            ""allowExtensibleEntities"": true," + "\n");
            sw.Write(@"            ""allowJSONResources"": true," + "\n");
            sw.Write(@"            ""allowJarResources"": true," + "\n");
            sw.Write(@"            ""allowJavascriptResources"": true," + "\n");
            sw.Write(@"            ""allowWebAppResources"": true," + "\n");
            sw.Write(@"            ""importEnabled"": true" + "\n");
            sw.Write(@"        }" + "\n");
            sw.Write(@"    }" + "\n");
            sw.Write(@"}");

            //
            sw.Close();
        }

        //创建twx937-createdb.bat
        public void CreateDBScript()
        {
            //
            string filename = this.ThingworxInstallationFolder + this.ThingworxRuntimeName + @"-createdb.bat";

            //
            StreamWriter sw = File.CreateText(filename);

            //
            sw.Write(@"@echo off" + "\n");
            sw.Write(@"pushd """ + this.ThingworxInstallationFolder + @"twxsetup\install""" + "\n");
            sw.Write(@"call thingworxPostgresDBSetup.bat"
                + @" -h " + this.PostgreHostName
                + @" -p " + this.PostgrePort
                + @" -d " + this.ThingworxDatabaseName
                + @" -t " + this.ThingworxRuntimeName
                + @" -l " + this.ThingworxInstallationFolder + @"ThingworxPostgresqlStorage"
                + @" -u " + this.ThingworxDBUserName + "\n");
            sw.Write(@"call thingworxPostgresSchemaSetup"
                + @" -h " + this.PostgreHostName
                + @" -p " + this.PostgrePort
                + @" -d " + this.ThingworxDatabaseName
                + @" -s public"
                + @" -u " + this.ThingworxDBUserName
                + @" -o all" + "\n");
            sw.Write(@"popd" + "\n");
            sw.Write(@"@echo on");

            //
            sw.Close();
        }

        //创建twx937-start.bat
        public void CreateStartScript()
        {
            //
            string filename = this.ThingworxInstallationFolder + this.ThingworxRuntimeName + @"-start.bat";

            //
            StreamWriter sw = File.CreateText(filename);

            //
            sw.Write(@"@echo off" + "\n");
            sw.Write(@"" + "\n");

            //JMXREMOTE
            //sw.Write(@"if not ""%JMXREMOTE%"" == """" goto JMXREMOTE_END" + "\n");
            //sw.Write(@"echo ""JMXREMOTE is empty""" + "\n");
            //sw.Write(@"set ""JMXREMOTE= -Dcom.sun.management.jmxremote""" + "\n");
            //sw.Write(@"set ""JMXREMOTE=%JMXREMOTE% -Dcom.sun.management.jmxremote.port=22222""" + "\n");
            //sw.Write(@"set ""JMXREMOTE=%JMXREMOTE% -Dcom.sun.management.jmxremote.ssl=false""" + "\n");
            //sw.Write(@"set ""JMXREMOTE=%JMXREMOTE% -Dcom.sun.management.jmxremote.authenticate=false""" + "\n");
            //sw.Write(@"set ""JMXREMOTE=%JMXREMOTE% -Djava.rmi.server.hostname=" + Public.GetHostName() + @"""" + "\n");
            //sw.Write(@"set ""JAVA_OPTS=%JAVA_OPTS% %JMXREMOTE%""" + "\n");
            //sw.Write(@":JMXREMOTE_END" + "\n");
            //sw.Write("\n");
            //sw.Write(@"@rem" + "\n");

            //
            sw.Write(@"set PGSERVICE=" + Public.GetPostgreServiceName() + "\n");
            sw.Write(@"set TOMCATDIR=" + getTomcatHome() + "\n");
            sw.Write(@"set TWXDIR=" + this.ThingworxInstallationFolder + "\n");
            sw.Write(@"set TITLE=" + this.ThingworxRuntimeName + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem setup environment variables" + "\n");
            sw.Write(@"set THINGWORX_PLATFORM_SETTINGS=%TWXDIR%\ThingworxPlatform" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem clear up tomcat" + "\n");
            sw.Write(@"del /q %TOMCATDIR%\logs\*.*" + "\n");
            sw.Write(@"del /q %TOMCATDIR%\temp\*.*" + "\n");
            sw.Write(@"rd /s /q %TOMCATDIR%\work\Catalina" + "\n");
            sw.Write(@"del /q %TOMCATDIR%\webapps\Thingworx.war" + "\n");
            sw.Write(@"rd /s /q %TOMCATDIR%\webapps\Thingworx" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem clean up log files" + "\n");
            sw.Write(@"del /q %TWXDIR%\ThingworxStorage\logs\*.*" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem copy files" + "\n");
            sw.Write(@"copy %TWXDIR%\twxsetup\Thingworx.war %TOMCATDIR%\webapps\Thingworx.war" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem start database" + "\n");
            sw.Write(@"net start %PGSERVICE%" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@rem start tomcat" + "\n");
            sw.Write(@"cd /d %TOMCATDIR%\bin\" + "\n");
            sw.Write(@"startup.bat" + "\n");
            sw.Write("\n\n");
            sw.Write(@"exit" + "\n");
            sw.Write("\n");
            sw.Write("\n");
            sw.Write(@"@echo on");

            //
            sw.Close();
        }

        //创建twx937-stop.bat
        public void CreateStopScript()
        {
            //
            string filename = this.ThingworxInstallationFolder + this.ThingworxRuntimeName + @"-stop.bat";

            //
            StreamWriter sw = File.CreateText(filename);

            //
            sw.Write(@"@echo off" + "\n");
            sw.Write("\n");
            //设置变量
            sw.Write(@"set PGSERVICE=" + Public.GetPostgreServiceName() + "\n");
            sw.Write(@"set TOMCATDIR=" + getTomcatHome() + "\n");
            sw.Write(@"set TWXDIR=" + this.ThingworxInstallationFolder + "\n");
            sw.Write("\n");
            //stop tomcat
            sw.Write(@"cd /d %TOMCATDIR%\bin\" + "\n");
            sw.Write(@"shutdown.bat" + "\n");
            sw.Write("\n");
            //stop database
            sw.Write(@"net stop %PGSERVICE%" + "\n");
            sw.Write("\n");
            sw.Write(@"exit" + "\n");
            sw.Write("\n");
            sw.Write(@"@echo on");

            //
            sw.Close();
        }

        public string getTomcatHome()
        {
            //获取Tomcat安装目录
            TomcatRuntimeConfiguration tomcatConfig = new TomcatRuntimeConfiguration();
            return tomcatConfig.GetTomcatHomeByName(this.TomcatRuntimeName);
        }

        //
        public void BuildThingworx()
        {
            //解压Thingworx手工安装包
            ExtractThingworx();

            //创建Thingworx目录
            CreateThingworxFolders();

            //创建platform-settings.json文件
            CreatePlatformSettings();

            //创建数据库脚本
            CreateDBScript();

            //创建启动脚本
            CreateStartScript();

            //创建停止脚本
            CreateStopScript();
        }
    }
}
