using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace testSerial
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      SerialPort sp = (SerialPort)sender;
      string indata = sp.ReadExisting();
      serialPort1.WriteLine("Test prijmu na COM2");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      serialPort1.Open();
      serialPort1.WriteLine("Test odesilani na COM2");

    }
  }
}