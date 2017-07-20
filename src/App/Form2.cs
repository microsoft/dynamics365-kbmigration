//------------------------------------------- START OF LICENSE -----------------------------------------
//KB articles migration tool 1.0
//Copyright(c) Microsoft Corporation
//All rights reserved.
//MIT License
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------- END OF LICENSE ------------------------------------------




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
//using Microsoft.Xrm.Client;
using System.IO;
using System.Threading;
// This namespace comes from assembly System.DirectoryServices.AccountManagement
//using System.DirectoryServices.AccountManagement;
// These namespaces come from assembly System.ServiceModel
using System.ServiceModel;
// These namespaces are found in the Microsoft.Crm.Sdk.Proxy.dll assembly
using Microsoft.Crm.Sdk.Messages;
// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly

using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

using Microsoft.Xrm.Sdk.Discovery;
// These namespaces are found in the Microsoft.Xrm.Client.dll assembly

//using Microsoft.Xrm.Client.Services;
//using System.Web.Services.Protocols;
using System.Runtime.Serialization;

using System.Windows.Forms;


using Microsoft.Xrm.Tooling.Connector;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public int totalcount { get; set; }
        public int countlmigrated { get; set; }
        public int countskip { get; set; }
        public int countfail { get; set; }
        public Form2()
        {
            InitializeComponent();
            

        }

        private void getcustfields_Click(object sender, EventArgs e)
        {
            //Retrieve all custom fields from Articles entity and give the option to include it on the migration

            RetrieveEntityRequest lclAEntityMetaDataRequest = new RetrieveEntityRequest();

            RetrieveEntityResponse lclEntityMetaDataResponse = null;

            lclAEntityMetaDataRequest.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes;

            lclAEntityMetaDataRequest.LogicalName = "kbarticle";

            lclEntityMetaDataResponse = (RetrieveEntityResponse)Form1.sdk.Execute(lclAEntityMetaDataRequest);
            Console.WriteLine("Found the following custom fields. Please select which should moved");
            foreach (AttributeMetadata currentEntity in lclEntityMetaDataResponse.EntityMetadata.Attributes)
            {
                if (currentEntity.IsCustomAttribute == true)
                {
                    Custfieldslistbox.Items.Add(currentEntity.LogicalName.ToString());
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Migratekbs_Click(object sender, EventArgs e)
        {
            totalcount = 0;
            countlmigrated = 0;
            countskip = 0;
            listBox1.Items.Clear();
            listBox1.Items.Add("Start: "+ DateTime.Now.ToString());
            //Entity knowledgearticle = new Entity("knowledgearticle");



            // Configure the query for KBarticle entity and retrieve the first 5000 records

            QueryExpression query = new QueryExpression { EntityName = "kbarticle", ColumnSet = new ColumnSet(true) };
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 3);
            query.NoLock = true;
            query.PageInfo = new PagingInfo();
            query.PageInfo.Count = 5;
            query.PageInfo.PageNumber = 1;
            query.PageInfo.PagingCookie = null;
            EntityCollection kbarticle = Form1.sdk.RetrieveMultiple(query);


            //Verify and create the first 5000 articles
            foreach (var count in kbarticle.Entities)
            {
                CreateArticles(count);
            }

            //Verify and create + 5000 records
            while (kbarticle.MoreRecords)
            {

                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = kbarticle.PagingCookie;
                kbarticle = Form1.sdk.RetrieveMultiple(query);
                foreach (var count in kbarticle.Entities)
                {
                    CreateArticles(count);
                }
                
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
            listBox1.Items.Add("End: " + DateTime.Now.ToString());
            listBox1.Items.Add(totalcount + "Articles migrated");
            Refresh();

        }

        private void CreateArticles(Entity kb)
        {
            
            Entity knowledgeArticle = new Entity("knowledgearticle");

                // Query for articles that may already exist on ISH to prevent duplicates or exceptions
                QueryExpression query2 = new QueryExpression
                {
                    EntityName = "knowledgearticle",
                    ColumnSet = new ColumnSet(new string[] { "articlepublicnumber" })

                };
                query2.NoLock = true;
                EntityCollection knowledge = Form1.sdk.RetrieveMultiple(query2);
                query2.Criteria = new FilterExpression();
                query2.Criteria.AddCondition("articlepublicnumber", ConditionOperator.Equal, kb["number"]);
                EntityCollection kbmngarticle = Form1.sdk.RetrieveMultiple(query2);


                //Retrieving Article Template

                Entity template = Form1.sdk.Retrieve("kbarticletemplate", ((EntityReference)kb["kbarticletemplateid"]).Id, new ColumnSet(true));

                if (kbmngarticle.Entities.Count == 0 && template != null)
                {

                    if (kb.Attributes.Contains("number")) { knowledgeArticle["articlepublicnumber"] = kb["number"]; };

                    //Remove the real content from the old xml format and replace unrecognizable xml tags with html
                    //check if old content is not null and set the value to match field on new entity (ISH)
                    if (kb.Attributes.Contains("articlexml") && template.Contains("structurexml"))
                    {

                        //This is following the GetStaticHTML definition that is used by Dynamics 365
                        string text = kb["articlexml"].ToString();

                        string structurexml = template["structurexml"].ToString();
                        string formatxml = template["formatxml"].ToString();

                        String combinedXml = String.Format(CultureInfo.InvariantCulture, "<combinedxml>{0}{1}</combinedxml>", text, structurexml);

                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.IgnoreWhitespace = true;

                        XmlDocument xmlDoc = new XmlDocument();

                        using (StringReader reader = new StringReader(combinedXml))
                        {
                            using (XmlReader xmlReader = XmlReader.Create(reader, settings))
                            {
                                xmlDoc.XmlResolver = null;
                                xmlDoc.Load(xmlReader);

                                xmlReader.Close();
                            }
                        }

                        XsltArgumentList argList = new XsltArgumentList();
                        argList.AddParam("title", "", kb["title"]);
                        argList.AddParam("number", "", kb["number"]);

                        XPathDocument xpTemplate = new XPathDocument(new StringReader(formatxml));
                        XslCompiledTransform xsl = new XslCompiledTransform();
                        xsl.Load(xpTemplate, null, null);


                        StringWriter transformedData = new StringWriter(CultureInfo.InvariantCulture);
                        xsl.Transform(xmlDoc, argList, transformedData);


                        knowledgeArticle["content"] = transformedData.ToString();

                    }

                //Identify which custom fields are selected for migration and Map with the same field name on knowledgearticle entity
                if (Custfieldslistbox.CheckedItems.Count != 0)
                    {
                   
                        string cusfield = "";
                        for (int x = 0; x <= Custfieldslistbox.CheckedItems.Count - 1; x++)
                        {
                            cusfield = Custfieldslistbox.CheckedItems[x].ToString();
                            if (kb.Attributes.Contains(cusfield)) { knowledgeArticle[cusfield] = kb[cusfield]; };
                        }
                      
                    }


                //Map required fields between kbarticles and knowledgearticle entities
                    if (kb.Attributes.Contains("description")) { knowledgeArticle["description"] = kb["description"]; };
                    if (kb.Attributes.Contains("importsequencenumber")) { knowledgeArticle["importsequencenumber"] = kb["importsequencenumber"]; };
                    if (kb.Attributes.Contains("keywords")) { knowledgeArticle["keywords"] = kb["keywords"]; };
                    if (kb.Attributes.Contains("createdon")) { knowledgeArticle["overriddencreatedon"] = kb["createdon"]; };
                    if (kb.Attributes.Contains("subjectid")) { knowledgeArticle["subjectid"] = kb["subjectid"]; };

                //       if (kb.Attributes.Contains("statecode")) { knowledgeArticle["statecode"] = kb["statecode"]; };

                if (kb.Attributes.Contains("title")) { knowledgeArticle["title"] = kb["title"]; };

                try
                {
                    //Create the article on ISH and retrieve the new guid
                    Guid knowledgeArticleId = Form1.sdk.Create(knowledgeArticle);

                    //Aprove article
                    Entity myKnowledgeArticle = new Entity("knowledgearticle", (knowledgeArticleId));
                    myKnowledgeArticle.Attributes.Add("statecode", new OptionSetValue(1));
                    Form1.sdk.Update(myKnowledgeArticle);
                    myKnowledgeArticle["statecode"] = new OptionSetValue(3);
                    Form1.sdk.Update(myKnowledgeArticle);

                    //Update log and refresh listbox
                    listBox1.Items.Add(kb["number"] + " | KB Article Created");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    Refresh();
                    countlmigrated++;
                    migratearticle.Text = countlmigrated.ToString();
                    totalcount++;
                }
                catch (Exception ex)
                {
                    //Update log and refresh listbox
                    listBox1.Items.Add(kb["number"] + " | Failed: " + ex);
                    countfail++;
                    failedarticle.Text = countfail.ToString();
                    countfail++;
                    Refresh();
                    return;
                }

                }
                else
                {
                //Update log and refresh listbox
                    listBox1.Items.Add(kb["number"] + " | KB Article already exists");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    countskip++;
                    skiparticle.Text = countskip.ToString();
                    Refresh();

                }

               
           // }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void migratearticle_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportlog_Click(object sender, EventArgs e)
        {
            //Save log to user documents
            string sPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"savelog.txt");
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
            MessageBox.Show("Log saved!");
            

        }
    }
}
