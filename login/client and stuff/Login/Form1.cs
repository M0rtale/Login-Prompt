using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
            string PathName,
            StringBuilder VolumeNameBuffer,
            UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber,
            ref UInt32 MaximumComponentLength,
            ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer,
            UInt32 FileSystemNameSize);
        private string hwidget()
        {
            string drive_letter = "C";
            drive_letter = drive_letter.Substring(0, 1) + ":\\";

            uint serial_number = 0;
            uint max_component_length = 0;
            StringBuilder sb_volume_name = new StringBuilder(255);
            UInt32 file_system_flags = new UInt32();
            StringBuilder sb_file_system_name = new StringBuilder(255);

            GetVolumeInformation(drive_letter, sb_volume_name, (UInt32)sb_volume_name.Capacity, ref serial_number, ref max_component_length, ref file_system_flags, sb_file_system_name, (UInt32)sb_file_system_name.Capacity);

            long curPC = serial_number;

            return curPC.ToString();
        }

        private string convets(string input)
        {
            WebClient Client = new WebClient();

            NameValueCollection postData = new NameValueCollection()
       {
              { "conversion", input },  //order: {"parameter name", "parameter value"}
       };
            string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/Converter.php", postData));
            return pagesource;
        }

        private string activate(string input)
        {
            WebClient Client = new WebClient();

            NameValueCollection postData = new NameValueCollection()
       {
              { "action", "activate" },  //order: {"parameter name", "parameter value"}
              { "key", input },  //order: {"parameter name", "parameter value"}
              { "hwid", hwidget() },  //order: {"parameter name", "parameter value"}
       };
            string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/TiKa.php", postData));
            return pagesource;
        }

        private string resethwid(string input)
        {
            WebClient Client = new WebClient();

            NameValueCollection postData = new NameValueCollection()
       {
              { "action", "resethwid" },  //order: {"parameter name", "parameter value"}
              { "key", input },  //order: {"parameter name", "parameter value"}
              { "hwid", hwidget() },  //order: {"parameter name", "parameter value"}
       };
            string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/TiKa.php", postData));
            return pagesource;
        }

        private string login(string input)
        {
            WebClient Client = new WebClient();

            NameValueCollection postData = new NameValueCollection()
       {
              { "action", "login" },  //order: {"parameter name", "parameter value"}
              { "key", input },  //order: {"parameter name", "parameter value"}
              { "hwid", hwidget() },  //order: {"parameter name", "parameter value"}
       };
            string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/TiKa.php", postData));
            return pagesource;
        }

        private string getTime(string input)
        {
            WebClient Client = new WebClient();

            NameValueCollection postData = new NameValueCollection()
       {
              { "action", "getTime" },  //order: {"parameter name", "parameter value"}
              { "key", input },  //order: {"parameter name", "parameter value"}
              { "hwid", hwidget() },  //order: {"parameter name", "parameter value"}
       };
            string pagesource = Encoding.ASCII.GetString(Client.UploadValues("http://1.1.1.1/pSoftwareUffYa/TiKa.php", postData));
            return pagesource;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("C:\\DSG", "");
            }
            catch(System.UnauthorizedAccessException erros)
            {
                MessageBox.Show("Please Run as Administrator!");
                Close();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("C:\\DSG", "");
            }
            catch (System.UnauthorizedAccessException erros)
            {
                MessageBox.Show("Please Run as Administrator!");
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output = activate(textBox1.Text);

            if (output == "Cipher495")
                MessageBox.Show("Success！");
            if (output == "Cipher214")
                MessageBox.Show("Key Has Been Already Activated");
            if (output == "Cipher312")
                MessageBox.Show("Key Doesn't Exist");
        }

        private void passed(string key) // inject server, inject hack
        {
            //Do stuff here

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // login
        {
            string output = login(textBox1.Text);

            if (output == "Cipher999")
            {
                MessageBox.Show("Wrong HWID");
                return;
            }
            else if(output == "Cipher312")
            {
                MessageBox.Show("Key Doesn't Exist!");
                return;
            }
            else if(output == "Cipher888")
            {
                MessageBox.Show("Key Expired or didn't activate!");
                return;
            }
            else if(output == "Cipher666")
            {
                MessageBox.Show("Success!");
                passed(output);
                return;
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string output = resethwid(textBox1.Text);
            if(output == "Cipher153")
            {
                MessageBox.Show("HWID unbound success!");
            }
            else if (output == "Cipher312")
            {
                MessageBox.Show("Key Doesn't Exist");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string output = getTime(textBox1.Text);
            if(output == "Cipher888")
                MessageBox.Show("Expired...");
            else if (output == "Cipher312")
            {
                MessageBox.Show("Key Doesn't Exist!");
                return;
            }
            else
                MessageBox.Show(output);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
