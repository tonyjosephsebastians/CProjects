using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FtpHelper
{
    public partial class Form1 : Form
    {
        [DllImport("FtpUploader.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool SetUpload([MarshalAs(UnmanagedType.LPWStr)]string FilePath, [MarshalAs(UnmanagedType.LPWStr)] string FileName, [MarshalAs(UnmanagedType.LPWStr)]string FTP_Server, [MarshalAs(UnmanagedType.LPWStr)]string Username, [MarshalAs(UnmanagedType.LPWStr)] string password);
        public static extern bool Uploader([MarshalAs(UnmanagedType.LPWStr)]string FilePath, [MarshalAs(UnmanagedType.LPWStr)] string FileName, [MarshalAs(UnmanagedType.LPWStr)]string FTP_Server, [MarshalAs(UnmanagedType.LPWStr)]string Username, [MarshalAs(UnmanagedType.LPWStr)] string password);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "FTP_Client";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            string Filename = "";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                Filename = Path.GetFileName(fdlg.FileName);
                string Filepath = fdlg.FileName;
                string fileserver = textBox1.Text;
                string username = textBox2.Text;
                string password = textBox3.Text;
                // bool upload = SetUpload(Filename, Filename, textBox1.Text.tost, textBox2.Text, textBox3.Text);
                bool upload = Uploader(Filename, Filepath, fileserver, username, password);

                if (upload == false)
                {
                    string message = "Upload Failed";
                    string title = "FTP_CLIENT";
                    MessageBox.Show(message, title);
                }
                else
                {
                    string message = "Upload Success";
                    string title = "FTP_CLIENT";
                    MessageBox.Show(message, title);
                }
            }
        }

    }
}
