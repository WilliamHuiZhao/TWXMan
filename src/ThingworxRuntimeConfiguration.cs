using System.Collections;
using System.IO;
using System.Xml;

namespace TWXMan
{
    class ThingworxRuntimeConfiguration
    {
        XmlDocument docThingworxRuntimeConfiguration = null;

        public ThingworxRuntimeConfiguration()
        {
            docThingworxRuntimeConfiguration = new XmlDocument();

            if (File.Exists(Constants.ThingworxRuntimeConfigurationFileName))
            {
                docThingworxRuntimeConfiguration.Load(Constants.ThingworxRuntimeConfigurationFileName);
            }
            else
            {
                XmlElement root = docThingworxRuntimeConfiguration.CreateElement(Constants.TAG_THINGWORXRUNTIMES);
                docThingworxRuntimeConfiguration.AppendChild(root);
                docThingworxRuntimeConfiguration.Save(Constants.ThingworxRuntimeConfigurationFileName);
            }
        }

        public void Save()
        {
            if (docThingworxRuntimeConfiguration != null)
            {
                docThingworxRuntimeConfiguration.Save(Constants.ThingworxRuntimeConfigurationFileName);
            }
        }

        public ArrayList ListThingworxRuntime()
        {
            ArrayList arrTWXRuntime = new ArrayList();

            if (docThingworxRuntimeConfiguration != null)
            {
                XmlNodeList nodelist = docThingworxRuntimeConfiguration.GetElementsByTagName(Constants.TAG_THINGWORXRUNTIME);

                if (nodelist != null)
                {
                    foreach (XmlElement xe in nodelist)
                    {
                        arrTWXRuntime.Add(new ThingworxRuntime(xe));
                    }
                }
            }

            return arrTWXRuntime;
        }

        public ArrayList GetThingworxRuntimeNames()
        {
            ArrayList arrNames = new ArrayList();

            if (docThingworxRuntimeConfiguration != null)
            {
                XmlNodeList nodelist = docThingworxRuntimeConfiguration.GetElementsByTagName(Constants.TAG_THINGWORXRUNTIME);

                if (nodelist != null)
                {
                    foreach (XmlElement xe in nodelist)
                    {
                        arrNames.Add(xe.GetAttribute(Constants.ATT_THINGWORXRUNTIMENAME));
                    }
                }
            }

            return arrNames;
        }

        //<Thingworx ThingworxRuntimeName="" ThingworxPackage="" ThingworxInstallationFolder="" TomcatRuntime=""
        //  PostgreHostName="" PostgrePort="true" ThingworxDatabaseName="" ThingworxDBUserName="" ThingworxDBUserPassword="" />
        public void AppendThingworxRuntime(ThingworxRuntime twxrt)
        {
            if (twxrt == null) return;

            XmlNode root = docThingworxRuntimeConfiguration.SelectSingleNode(Constants.TAG_THINGWORXRUNTIMES);

            if (root != null)
            {
                //
                XmlElement xeNew = docThingworxRuntimeConfiguration.CreateElement(Constants.TAG_THINGWORXRUNTIME);

                //
                xeNew.SetAttribute(Constants.ATT_THINGWORXRUNTIMENAME, twxrt.ThingworxRuntimeName);
                xeNew.SetAttribute(Constants.ATT_THINGWORXPACKAGE, twxrt.ThingworxPackage);
                xeNew.SetAttribute(Constants.ATT_THINGWORXINSTALLATIONFOLDER, twxrt.ThingworxInstallationFolder);
                xeNew.SetAttribute(Constants.TAG_TOMCATRUNTIME, twxrt.TomcatRuntimeName);
                xeNew.SetAttribute(Constants.ATT_POSTGREHOSTNAME, twxrt.PostgreHostName);
                xeNew.SetAttribute(Constants.ATT_POSTGREPORT, twxrt.PostgrePort);
                xeNew.SetAttribute(Constants.ATT_THINGWORXDATABASENAME, twxrt.ThingworxDatabaseName);
                xeNew.SetAttribute(Constants.ATT_THINGWORXDBUSERNAME, twxrt.ThingworxDBUserName);
                xeNew.SetAttribute(Constants.ATT_THINGWORXDBUSERPASSWORD, twxrt.ThingworxDBUserPassword);

                //
                root.AppendChild(xeNew);

                //
                Save();
            }
        }

        public void RemoveThingworxRuntime(string strName)
        {
            if (docThingworxRuntimeConfiguration == null) return;

            XmlNodeList nodelist = docThingworxRuntimeConfiguration.GetElementsByTagName(Constants.TAG_THINGWORXRUNTIME);

            if (nodelist != null)
            {
                for (int i = nodelist.Count - 1; i >= 0; i--)
                {
                    XmlNode node = nodelist[i];
                    if (node.Attributes[Constants.ATT_THINGWORXRUNTIMENAME] != null && node.Attributes[Constants.ATT_THINGWORXRUNTIMENAME].Value == strName)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
            }

            //
            Save();
        }

        public ThingworxRuntime GetThingworxRuntime(string thingworxRuntimeName)
        {
            if (docThingworxRuntimeConfiguration != null
                && thingworxRuntimeName != null
                && thingworxRuntimeName.Length > 0)
            {
                XmlNodeList nodelist = docThingworxRuntimeConfiguration.GetElementsByTagName(thingworxRuntimeName);

                if (nodelist != null)
                {
                    XmlElement xe = (XmlElement)nodelist[0];
                    if (xe != null)
                    {
                        ThingworxRuntime tr = new ThingworxRuntime();

                        tr.ThingworxRuntimeName = xe.GetAttribute(Constants.TAG_THINGWORXRUNTIME);
                        tr.ThingworxPackage = xe.GetAttribute(Constants.ATT_THINGWORXPACKAGE);
                        tr.ThingworxInstallationFolder = xe.GetAttribute(Constants.ATT_THINGWORXINSTALLATIONFOLDER);
                        tr.TomcatRuntimeName = xe.GetAttribute(Constants.TAG_TOMCATRUNTIME);
                        tr.PostgreHostName = xe.GetAttribute(Constants.ATT_POSTGREHOSTNAME);
                        tr.PostgrePort = xe.GetAttribute(Constants.ATT_POSTGREPORT);
                        tr.ThingworxDatabaseName = xe.GetAttribute(Constants.ATT_THINGWORXDATABASENAME);
                        tr.ThingworxDBUserName = xe.GetAttribute(Constants.ATT_THINGWORXDBUSERNAME);
                        tr.ThingworxDBUserPassword = xe.GetAttribute(Constants.ATT_THINGWORXDBUSERPASSWORD);

                        return tr;
                    }
                }
            }

            return null;
        }

        public bool IsExist(string strThingworxRuntimeName)
        {
            if (docThingworxRuntimeConfiguration == null) return false;

            XmlNodeList nodelist = docThingworxRuntimeConfiguration.GetElementsByTagName(Constants.TAG_THINGWORXRUNTIME);

            if (nodelist != null)
            {
                for (int i = nodelist.Count - 1; i >= 0; i--)
                {
                    XmlNode node = nodelist[i];
                    if (node.Attributes[Constants.ATT_THINGWORXRUNTIMENAME] != null && node.Attributes[Constants.ATT_THINGWORXRUNTIMENAME].Value == strThingworxRuntimeName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
