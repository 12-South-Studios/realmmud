using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using log4net;

namespace Realm.Build.Tool
{
    public static class GlobalsGenerator
    {
        static GlobalsGenerator() { }

        private static readonly ILog Log = LogManager.GetLogger(typeof (GlobalsGenerator));
        private static string SqlConnectionString;

        static void Main(string[] args)
        {
            try
            {
                var db = false;
                var packageName = string.Empty;
                int i;
                var writeStringArrays = false;
                var globalsFiles = new List<string>();
                var xmlFiles = new List<string>();

                for (i = 0; i < args.Length; i++)
                {
                    if (args[i].Equals("-db"))
                    {
                        db = true;
                    }
                    else if (args[i].Equals("-xmlfile"))
                    {
                        xmlFiles.Add(args[i + 1]);
                        i++;
                    }
                    else if (args[i].Equals("-writeStringArrays"))
                    {
                        writeStringArrays = true;
                    }
                    else if (args[i].Equals("-output"))
                    {
                        globalsFiles.Add(args[i + 1]);
                        i++;
                    }
                    else if (args[i].Equals("-namespace"))
                    {
                        packageName = args[i + 1];
                        i++;
                    }
                }

                SqlConnectionString = DatabaseUtils.GetSqlConnectionString(
                    ConfigurationManager.AppSettings["Server"],
                    ConfigurationManager.AppSettings["Database"],
                    ConfigurationManager.AppSettings["Username"],
                    ConfigurationManager.AppSettings["Password"]);

                Run(db, xmlFiles, packageName, writeStringArrays, globalsFiles);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                Environment.Exit(0);
            }
        }

        private static void Run(bool db, IEnumerable<string> xmlFiles, string packageName, 
            bool writeStringArrays, IList<string> globalsFiles)
        {
            int i;
            var writers = new IConstantWriter[globalsFiles.Count];
            for (i = 0; i < globalsFiles.Count; i++)
            {
                writers[i] = new GenericConstantWriter(SqlConnectionString, globalsFiles[i], writeStringArrays);
                writers[i].WriteHeader(packageName);
            }

            // Write constants from the database.
            if (db)
            {
                WriteDbConstants(writers);
            }

            foreach (var xmlFile in xmlFiles.Where(xmlFile => !string.IsNullOrEmpty(xmlFile)))
            {
                //WriteXMLConstants(writers, xmlFile);
            }

            for (i = 0; i < writers.Length; i++)
            {
                writers[i].WriteFooter(packageName);
                writers[i].Close();
            }
        }

        private static void WriteDbConstants(IList<IConstantWriter> writers) 
        {
            var dal = new RealmDal(SqlConnectionString);

            foreach (var constantsTable in dal.Globals)
            {
                var group = new ConstantGroup();
                group.ConstantSource = "RealmStatic." + constantsTable.TableName;
                group.ConstantName = constantsTable.ConstantName;
                group.Comment = constantsTable.Comment;
                group.IsEnum = constantsTable.IsEnum;
                group.Prefix = constantsTable.Prefix;
                group.HasFlagsAttribute = constantsTable.HasFlagsAttribute;
                group.SuppressCA1008 = constantsTable.SuppressCA1008;
 
                group.AddRange(dal.GetConstants(constantsTable.TableName,
                                                !string.IsNullOrEmpty(constantsTable.AdditionalWhere)
                                                ? Convert.ToInt32(constantsTable.AdditionalWhere) : 0));
                
                if (group.Values == null || group.Values.Count == 0)
                    continue;

                int i;
                for (i = 0; i < writers.Count(); i++)
                {
                    writers[i].WriteGroupHeader(group);
                    if (group.IsEnum)
                    {
                        writers[i].WriteEnums(group);
                    }
                    else
                    {
                        writers[i].WriteConstants(group);
                    }
                    writers[i].WriteGroupFooter(group);
                }
            }
        }

/*
    private static void writeXMLConstants(IConstantWriter[] writers, String xmlFilename) throws Exception {
        try {
            File file = new File(xmlFilename);
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            Document doc = db.parse(file);
            doc.getDocumentElement().normalize();
            NodeList nodeList = doc.getChildNodes();
            nodeList = nodeList.item(0).getChildNodes();

            ConstantGroup group = new ConstantGroup();
            group.mConstantSource = "globals.xml";

            int i;
            for (i = 0; i < nodeList.getLength(); i++) {
                Node childNode = nodeList.item(i);
                if (childNode.getNodeType() == Node.ELEMENT_NODE) {
                    writeXMLGroup(writers, group, (Element)childNode);
                    group = null;
                }
                else if (childNode.getNodeType() == Node.COMMENT_NODE) {
                    Comment comment = (Comment)childNode;
                    group.mComment = comment.getData();
                }
                if (group == null) {
                    group = new ConstantGroup();
                }
            }

        }
        catch (org.xml.sax.SAXException ex) {
            ex.printStackTrace();
        }
        catch (javax.xml.parsers.ParserConfigurationException ex) {
            ex.printStackTrace();
        }
    }

    private static void writeXMLGroup(IConstantWriter[] writers, ConstantGroup group, Element groupNode) throws Exception {
        String type = groupNode.getAttribute("type");
        if (type == null) return;

        if (type.compareTo("constant") == 0) {
            group.mIsEnum = false;
        }
        else if (type.compareTo("enum") == 0) {
            group.mIsEnum = true;
        }
        writeXMLGroupImpl(writers, group, groupNode);
    }

    private static void writeXMLGroupImpl(IConstantWriter[] writers, ConstantGroup constantsTable, Element groupNode) throws Exception {
        NodeList childNodes = groupNode.getChildNodes();
        int i;
        String groupName = groupNode.getAttribute("name");
        if (groupName == null) return;

        constantsTable.mConstantName = groupName;
        constantsTable.mPrefix = groupName;
        constantsTable.mConstantSource = "globals.xml: " + groupName;
        
        ConstantValue cv = new ConstantValue();
        for (i = 0; i < childNodes.getLength(); i++) {
            Node childNode = childNodes.item(i);
            if (childNode.getNodeType() == Node.ELEMENT_NODE) {
                Element child = (Element)childNode;

                if (cv == null) {
                    cv = new ConstantValue();
                }
                cv.mName = child.getAttribute("name");
                cv.mType = child.getAttribute("type");

                if (cv.mName == null || cv.mType == null) continue;

                NodeList grandchildNodes = child.getChildNodes();
                if ((grandchildNodes == null) || (grandchildNodes.getLength() == 0)) {
                    // Error
                }
                else {

                    if (grandchildNodes.getLength() == 1) {
                        Node grandchildNode = grandchildNodes.item(0);
                        if (grandchildNode.getNodeType() == Node.TEXT_NODE) {
                            cv.mValue = grandchildNode.getTextContent();
                        }
                    }
                    else {
                        for(int j=0; j<grandchildNodes.getLength(); j++) {
                            Node grandchildNode = grandchildNodes.item(j);

                            if (grandchildNode.getNodeType() == Node.ELEMENT_NODE) {
                                Element grandchild = (Element)grandchildNode;

                                if (grandchild.getNodeName().equalsIgnoreCase("description")) {
                                    cv.mDescription = grandchild.getTextContent();
                                }
                                else if (grandchild.getNodeName().equalsIgnoreCase("value")) {
                                    cv.mValue = grandchild.getTextContent();
                                }
                            }
                        }
                    }
                }
                constantsTable.mValues.add(cv);
                cv = null;
            }
            else if (childNode.getNodeType() == Node.COMMENT_NODE) {
                Comment comment = (Comment)childNode;
                if (cv == null) {
                    cv = new ConstantValue();
                }
                cv.mDescription = comment.getData();
            }
        }
        for (i = 0; i < writers.length; i++) {
            writers[i].writeGroupHeader(constantsTable);
            if (constantsTable.mIsEnum) {
                writers[i].writeEnums(constantsTable);
            }
            else {
                writers[i].writeConstants(constantsTable);
            }
            writers[i].writeGroupFooter(constantsTable);
        }
    }
 */
    }
}
