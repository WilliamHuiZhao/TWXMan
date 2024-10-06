using System.Collections;
using System.IO;
using System.Xml;

namespace TWXMan
{
    class TomcatRuntimeConfiguration
    {
        XmlDocument doc = null;

        public TomcatRuntimeConfiguration()
        {
            doc = new XmlDocument();

            if (File.Exists(Constants.TomcatRuntimeConfigurationFileName))
            {
                doc.Load(Constants.TomcatRuntimeConfigurationFileName);
            }
            else
            {
                XmlElement root = doc.CreateElement(Constants.TAG_TOMCATRUNTIMES);
                doc.AppendChild(root);
                doc.Save(Constants.TomcatRuntimeConfigurationFileName);
            }
        }

        public void Save()
        {
            if (doc != null)
                doc.Save(Constants.TomcatRuntimeConfigurationFileName);
        }

        public ArrayList GetTomcatRuntimeNames()
        {
            ArrayList arrNames = new ArrayList();

            if (doc != null)
            {
                XmlNodeList nodelist = doc.GetElementsByTagName(Constants.TAG_TOMCATRUNTIME);

                if (nodelist != null)
                {
                    foreach (XmlElement xe in nodelist)
                    {
                        arrNames.Add(xe.GetAttribute(Constants.ATT_TOMCATRUNTIMENAME));
                    }
                }
            }

            return arrNames;
        }

        public void AppendTomcatRuntime(string strName, string strDesc, string strZip, string strHome, string strPort, string strSetEnv)
        {
            XmlNode root = doc.SelectSingleNode(Constants.TAG_TOMCATRUNTIMES);

            if (root != null)
            {
                //
                XmlElement xeNew = doc.CreateElement(Constants.TAG_TOMCATRUNTIME);

                //
                xeNew.SetAttribute(Constants.ATT_TOMCATRUNTIMENAME, strName);
                xeNew.SetAttribute(Constants.ATT_TOMCATRUNTIMEDESCRIPTION, strDesc);
                xeNew.SetAttribute(Constants.ATT_TOMCATPACKAGE, strZip);
                xeNew.SetAttribute(Constants.ATT_TOMCATHOME, strHome);
                xeNew.SetAttribute(Constants.ATT_TOMCATPORT, strPort);
                xeNew.SetAttribute(Constants.ATT_SETENVFORTHINGWORX, strSetEnv);

                //
                root.AppendChild(xeNew);

                //
                Save();
            }
        }

        public void RemoveTomcatRuntime(string strName)
        {
            if (doc == null) return;

            XmlNodeList nodelist = doc.GetElementsByTagName(Constants.TAG_TOMCATRUNTIME);

            if (nodelist != null)
            {
                for (int i = nodelist.Count - 1; i >= 0; i--)
                {
                    XmlNode node = nodelist[i];
                    if (node.Attributes[Constants.ATT_TOMCATRUNTIMENAME] != null && node.Attributes[Constants.ATT_TOMCATRUNTIMENAME].Value == strName)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
            }

            //
            Save();
        }

        public string GetTomcatHomeByName(string strTomcatRuntimeName)
        {
            if (doc == null) return "";
            string ret = "";

            XmlNodeList nodelist = doc.GetElementsByTagName(Constants.TAG_TOMCATRUNTIME);

            if (nodelist != null)
            {
                for (int i = nodelist.Count - 1; i >= 0; i--)
                {
                    XmlNode node = nodelist[i];
                    if (node.Attributes[Constants.ATT_TOMCATRUNTIMENAME] != null && node.Attributes[Constants.ATT_TOMCATRUNTIMENAME].Value == strTomcatRuntimeName)
                    {
                        ret = node.Attributes[Constants.ATT_TOMCATHOME].Value;
                    }
                }
            }

            return ret;
        }

        public bool IsExist(string strTomcatRuntimeName)
        {
            if (doc == null) return false;
            bool ret = false;

            XmlNodeList nodelist = doc.GetElementsByTagName(Constants.TAG_TOMCATRUNTIME);

            if (nodelist != null)
            {
                foreach (XmlNode node in nodelist)
                {
                    if (node.Attributes[Constants.ATT_TOMCATRUNTIMENAME] != null
                        && node.Attributes[Constants.ATT_TOMCATRUNTIMENAME].Value == strTomcatRuntimeName)
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }
    }
}
