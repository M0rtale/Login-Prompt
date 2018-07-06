using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminAddUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "nigger")
            {
                WebClient Client = new WebClient();

                NameValueCollection postData = new NameValueCollection()
       {
              { "key", textBox1.Text },  //order: {"parameter name", "parameter value"}
       };
                string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/ZuoKa.php", postData));
                MessageBox.Show(pagesource);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
