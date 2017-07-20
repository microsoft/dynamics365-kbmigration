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
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;

using Microsoft.Xrm.Tooling.Connector;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static IOrganizationService sdk;
        Form2 secondForm = new Form2();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            loginfail.Visible = false;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //Authentication process with validation
            // If connected open another form to copy acticles
            loginfail.Visible = true;
            loginfail.Text = "Connecting...";
            while (true)
                { 
            
                String connstring = "Url = " + URLINSTANCE.Text + "; UserName=" + usertextBox.Text + "; Password=" + pswtextBox.Text + "; authtype=Office365";
            CrmServiceClient conn = new CrmServiceClient(connstring);
            sdk = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                if (conn.OrganizationServiceProxy==null)
                        {
                    loginfail.ForeColor = System.Drawing.Color.DarkRed;
                    loginfail.Text = "Login Failure!Please Check URL and credentials and try again.";
                    loginfail.Visible = true;
                    break;
                }
                else
                {
                    loginfail.Visible = true;
                    loginfail.Text = "Connected!";
                    secondForm.Show();
                }
                break;
            } 


        }

        private void URLINSTANCE_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loginfail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
