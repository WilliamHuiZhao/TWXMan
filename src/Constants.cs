namespace TWXMan
{
    static class Constants
    {
        //
        public const string DIR_BIN = @"\bin\";
        public const string DIR_CONF = @"\conf\";
        public const string DIR_CLUSTER = @"\cluster\";
        public const string DIR_LOG = @"\log\";
        public const string DIR_RULES = @"\rules\";
        public const string DIR_PACKAGE = @"\package\";
        public const string DIR_PACKAGE_HAPROXY = @"\package\haproxy\";
        public const string DIR_PACKAGE_IGNITE = @"\package\ignite\";
        public const string DIR_PACKAGE_JDK = @"\package\jdk\";
        public const string DIR_PACKAGE_THINGWORX = @"\package\thingworx\";
        public const string DIR_PACKAGE_TOMCAT = @"\package\tomcat\";
        public const string DIR_PACKAGE_ZOOKEEPER = @"\package\zookeeper\";

        //用于TomcatRuntimeConfiguration
        public const string TomcatRuntimeConfigurationFileName = @"conf\TomcatRuntime.xml";
        public const string TAG_TOMCATRUNTIMES = "TomcatRuntimes";
        public const string TAG_TOMCATRUNTIME = "TomcatRuntime";
        public const string ATT_TOMCATRUNTIMENAME = "Name";
        public const string ATT_TOMCATRUNTIMEDESCRIPTION = "Description";
        public const string ATT_TOMCATPACKAGE = "Package";
        public const string ATT_TOMCATHOME = "Home";
        public const string ATT_TOMCATPORT = "Port";
        public const string ATT_SETENVFORTHINGWORX = "SetEnv";

        //用于ThingworxRuntimeConfiguration
        public const string ThingworxRuntimeConfigurationFileName = @"conf\ThingworxRuntime.xml";
        public const string TAG_THINGWORXRUNTIMES = "ThingworxRuntimes";
        public const string TAG_THINGWORXRUNTIME = "ThingworxRuntime";
        public const string ATT_THINGWORXRUNTIMENAME = "Name";
        public const string ATT_THINGWORXPACKAGE = "ThingworxPackage";
        public const string ATT_THINGWORXINSTALLATIONFOLDER = "ThingworxInstallationFolder";
        public const string ATT_POSTGREHOSTNAME = "DBHost";
        public const string ATT_POSTGREPORT = "DBPort";
        public const string ATT_THINGWORXDATABASENAME = "DBName";
        public const string ATT_THINGWORXDBUSERNAME = "DBUser";
        public const string ATT_THINGWORXDBUSERPASSWORD = "DBPassword";

        //
        public const int PostgrePort = 5432;
        public const string ThingworxDBUserName = "twadmin";
        public const string ThingworxDBUserPassword = "postgres";

        //
        public const string Head_ThingworxRuntime = "Thingworx Runtime";
        public const string Head_TomcatRuntime = "Tomcat Runtime";

        //
        public const int TomcatPort = 8080;
    }
}
