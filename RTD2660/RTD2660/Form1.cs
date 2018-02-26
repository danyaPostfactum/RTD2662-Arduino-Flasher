using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace RTD2660
{
    public partial class Form1 : Form
    {
        SerialPort port;
        public Form1()
        {
            InitializeComponent();

            FillSerialPorts();

            port = new SerialPort();

            // Allow the user to set the appropriate properties.
            port.BaudRate = 115200;
            // Set the read/write timeouts
            port.ReadTimeout = 900;
            port.WriteTimeout = 900;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    buttonOpen.Text = "Open";
                    serialPortcComboBox.Enabled = true;
                    buttonErase.Enabled = false;
                    buttonFlash.Enabled = false;
                    port.Close();
                }
                else
                {
                    port.PortName = (string) serialPortcComboBox.SelectedItem;
                    port.Open();
                    buttonOpen.Text = "Close";
                    serialPortcComboBox.Enabled = false;
                    buttonErase.Enabled = true;
                    buttonFlash.Enabled = true;


                }
            }
            catch (System.SystemException ex)
            {
                debugTextBox.AppendText("Error opening Port\n");
            }

            if (port.IsOpen)
            {
                try
                {
                    char[] cmd = { 'I' };
                    port.Write(cmd, 0, 1);
                    string info = port.ReadLine();
                    debugTextBox.AppendText(info + "\n");
                }
                catch (System.SystemException ex)
                {
                    debugTextBox.AppendText("No device response!\n");
                }
            }
        }

        private void FillSerialPorts()
        {

            foreach (string s in SerialPort.GetPortNames())
            {
                serialPortcComboBox.Items.Add(s);
            }
            serialPortcComboBox.SelectedIndex = serialPortcComboBox.Items.Count - 1;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            char[] cmd = { 'E' };
            port.Write(cmd, 0, 1);
            string info = port.ReadLine();
            debugTextBox.AppendText(info + "\n");
            label2.Visible = true;
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {


            char[] cmd = { 'W' };
            port.Write(cmd, 0, 1);

            byte[] bytes = new byte[256];
            try
            {

                using (FileStream fsSource = new FileStream(openFileDialog1.FileName,
                    FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = 0xFF;
                        }
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, 0, bytes.Length);

                        numBytesRead += n;

                        if (n > 0) n = 1;

                        byte[] b = { (byte)n };
                        port.Write(b, 0, 1);

                        bool error = false;
                        for (int j = 0; j < 8; j++)
                        {
                            port.Write(bytes, j * 32, 32);

                            Thread.Sleep(1);
                            try
                            {
                                char answer = (char)port.ReadChar();
                                error = answer != '1';
                            }
                            catch (System.TimeoutException ex)
                            {
                                error = true;
                            }


                            if (error)
                            {
                                debugTextBox.AppendText(String.Format("Errror at {0}\n", numBytesRead));
                                break;
                            }
                            else
                            {
                                label2.Text = String.Format("Flashed {0} of {1}", numBytesRead, fsSource.Length);
                                progressBar.Value = (numBytesRead * 100 / (int)fsSource.Length);
                            }
                        }
                        if (error)
                            break;
                        Application.DoEvents();

                        //port.Write(bytes, 0, bytes.Length);

                        // Break when the end of the file is reached.

                        //numBytesToRead -= n;
                        if (n == 0)
                            break;
                    }
                    fsSource.Close();
                }
            }
            catch (FileNotFoundException ioEx)
            {
                byte[] b = { 0 };
                port.Write(b, 0, 1);


                char answer = (char)port.ReadChar();
                Console.WriteLine(ioEx.Message);
            }



            string info = port.ReadLine();
            debugTextBox.AppendText(info + "\n");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileInputTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            char[] cmd = { 'C' };
            port.Write(cmd, 0, 1);
            string info = port.ReadLine();
            debugTextBox.AppendText(info + "\n");
        }
    }
}
