using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace MWGUI
{
  public partial class MWSetup : Form
  {
    //Commands
    const int MSP_IDENT = 100;
    const int MSP_STATUS = 101;
    const int MSP_RAW_IMU = 102;
    const int MSP_SERVO = 103;
    const int MSP_MOTOR = 104;
    const int MSP_RC = 105;
    const int MSP_RAW_GPS = 106;
    const int MSP_COMP_GPS = 107;
    const int MSP_ATTITUDE = 108;
    const int MSP_ALTITUDE = 109;
    const int MSP_BAT = 110;
    const int MSP_RC_TUNING = 111;
    const int MSP_PID = 112;
    const int MSP_BOX = 113;
    const int MSP_MISC = 114;
    const int MSP_MOTOR_PINS = 115;
    const int MSP_BOXNAMES = 116;
    const int MSP_PIDNAMES = 117;
    const int MSP_WP = 118;


    const int MSP_SET_RAW_RC = 200;
    const int MSP_SET_RAW_GPS = 201;
    const int MSP_SET_PID = 202;
    const int MSP_SET_BOX = 203;
    const int MSP_SET_RC_TUNING = 204;
    const int MSP_ACC_CALIBRATION = 205;
    const int MSP_MAG_CALIBRATION = 206;
    const int MSP_SET_MISC = 207;
    const int MSP_RESET_CONF = 208;
    const int MSP_SET_WP = 209;

    const int MSP_EEPROM_WRITE = 250;
    const int MSP_DEBUG = 254;

    static int iPidItems = 10;                                //number if Pid items (const definition)

    static byte c_state = IDLE;
    const byte IDLE = 0;
    static byte offset = 0;
    static byte dataSize = 0;
    static byte checksum = 0;
    static byte cmd;
    static int serial_error_count = 0;
    static int serial_packet_count = 0;

    static Boolean err_rcvd = false;
    const byte HEADER_START = 1;
    const byte HEADER_M = 2;
    const byte HEADER_ARROW = 3;
    const byte HEADER_SIZE = 4;
    const byte HEADER_CMD = 5;
    const byte HEADER_ERR = 6;

    enum CopterType { Tri = 1, QuadP, QuadX, BI, Gimbal, Y6, Hex6, FlyWing, Y4, Hex6X, Octo8Coax, Octo8P, Octo8X, Airplane, Heli120, Heli90, Vtail };

    public byte[] inBuf = new byte[300];
    //public bool dataReceived = false;
    //int cyklus = 0;

    static bool isConnected = false;                        //is port connected or not ?
    string[] sSerialSpeeds = { "115200", "57600", "38400", "19200", "9600" };

    static mw_data_gui mw_gui;
    static mw_settings mw_params;
    static GUI_settings gui_settings;
    int command = 0;

    static int iCheckBoxItems = 19;                          //number of checkboxItems (readed from optionsconfig.xml

    //PID values
    static PID[] Pid;

    //AUX
    //static AUX[] Aux;

    static byte pidIndex;


    bool isNeedUpdatePIDPanel = false;
    bool isNeedUpdateInfoPanel = false;
    bool isNeedUpdateAuxPanel = false;

    public MWSetup()
    {
      InitializeComponent();
      PictureButton button = new PictureButton();
      button.Parent = this;
      button.Bounds = new Rectangle(10, 220, 150, 250);
      button.ForeColor = Color.White;
      button.BackgroundImage = MakeBitmap(Color.Blue, button.Width, button.Height);
      button.PressedImage = MakeBitmap(Color.LightBlue, button.Width, button.Height);
      button.Text = "click me";
    }
    Bitmap MakeBitmap(Color color, int width, int height)
    {
      Bitmap bmp = new Bitmap(width, height);
      Graphics g = Graphics.FromImage(bmp);
      g.FillRectangle(new SolidBrush(color), 0, 0, bmp.Width, bmp.Height);
      g.DrawEllipse(new Pen(Color.DarkGray), 3, 3, width - 6, height - 6);
      g.Dispose();

      return bmp;
    }


    private void Form1_Load(object sender, EventArgs e)
    {
      //Setup timers
      //timer_realtime.Tick += new EventHandler(timer_realtime_Tick);
      //**timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
      //timer_realtime.Enabled = true;
      //**timer_realtime.Stop();
      //tabPage2.Hide();
      //tabPage3.Hide();
      Pid = new PID[10];          //Max 20 PID values if we have more then we will ignore it

      for (int i = 0; i < iPidItems; i++)
      {
        Pid[i] = new PID();
      }

      //Aux = new AUX[iCheckBoxItems];

      //for (int i = 0; i < iCheckBoxItems; i++)
      //{
      //  Aux[i] = new AUX();
      //}

      gui_settings = new GUI_settings();

      mw_gui = new mw_data_gui(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);
      mw_params = new mw_settings(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);


      //TODO - read values from settings file
      Pid[0].Pprec = 10;
      Pid[1].Pprec = 10;
      Pid[2].Pprec = 10;
      Pid[3].Pprec = 10;
      Pid[4].Pprec = 100;
      Pid[5].Pprec = 10;
      Pid[6].Pprec = 10;
      Pid[7].Pprec = 10;
      Pid[8].Pprec = 10;
      Pid[9].Pprec = 10;

      Pid[0].Iprec = 1000;
      Pid[1].Iprec = 1000;
      Pid[2].Iprec = 1000;
      Pid[3].Iprec = 1000;
      Pid[4].Iprec = 100;
      Pid[5].Iprec = 100;
      Pid[6].Iprec = 100;
      Pid[7].Iprec = 100;
      Pid[8].Iprec = 100;
      Pid[9].Iprec = 100;

      Pid[0].Dprec = 1;
      Pid[1].Dprec = 1;
      Pid[2].Dprec = 1;
      Pid[3].Dprec = 1;
      Pid[4].Dprec = 1;
      Pid[5].Dprec = 1000;
      Pid[6].Dprec = 1000;
      Pid[7].Dprec = 1;
      Pid[8].Dprec = 1;
      Pid[9].Dprec = 1;

      Pid[0].name = "Roll";
      Pid[1].name = "Pitch";
      Pid[2].name = "Yaw";
      Pid[3].name = "Altitude";
      Pid[4].name = "PosHold";
      Pid[5].name = "PosHoldRate";
      Pid[6].name = "Navigation Rate";
      Pid[7].name = "Level";
      Pid[8].name = "Mag";
      Pid[9].name = "";

      Pid[0].description = "Roll Rate control";
      Pid[1].description = "Pitch Rate control";
      Pid[2].description = "Yaw Rate control";
      Pid[3].description = "Altitude hold control";
      Pid[4].description = "Position Hold control";
      Pid[5].description = "Position Hold Rate control";
      Pid[6].description = "Navigation Rate control";
      Pid[7].description = "Autolevel control";
      Pid[8].description = "Heading hold control";
      Pid[9].description = "Velocity control for Altitude hold";
      
      Pid[0].Pmin = 0;
      Pid[1].Pmin = 0;
      Pid[2].Pmin = 0;
      Pid[3].Pmin = 0;
      Pid[4].Pmin = 0;
      Pid[5].Pmin = 0;
      Pid[6].Pmin = 0;
      Pid[7].Pmin = 0;
      Pid[8].Pmin = 0;
      Pid[9].Pmin = 0;
      
      Pid[0].Pmax = 20.0m;
      Pid[1].Pmax = 20.0m;
      Pid[2].Pmax = 20.0m;
      Pid[3].Pmax = 20.0m;
      Pid[4].Pmax = 2.54m;
      Pid[5].Pmax = 20.0m;
      Pid[6].Pmax = 20.0m;
      Pid[7].Pmax = 20.0m;
      Pid[8].Pmax = 20.0m;
      Pid[9].Pmax = 20.0m;

      Pid[0].Imin = 0;
      Pid[1].Imin = 0;
      Pid[2].Imin = 0;
      Pid[3].Imin = 0;
      Pid[4].Imin = 0;
      Pid[5].Imin = 0;
      Pid[6].Imin = 0;
      Pid[7].Imin = 0;
      Pid[8].Imin = 0;
      Pid[9].Imin = 0;
      
      Pid[0].Imax = 0.250m;
      Pid[1].Imax = 0.250m;
      Pid[2].Imax = 0.250m;
      Pid[3].Imax = 0.250m;
      Pid[4].Imax = 2.54m;
      Pid[5].Imax = 2.54m;
      Pid[6].Imax = 2.54m;
      Pid[7].Imax = 2.54m;
      Pid[8].Imax = 2.54m;
      Pid[9].Imax = 2.54m;
      
      Pid[0].Dmin = 0;
      Pid[1].Dmin = 0;
      Pid[2].Dmin = 0;
      Pid[3].Dmin = 0;
      Pid[4].Dmin = 0;
      Pid[5].Dmin = 0;
      Pid[6].Dmin = 0;
      Pid[7].Dmin = 0;
      Pid[8].Dmin = 0;
      Pid[9].Dmin = 0;
      
      Pid[0].Dmax = 100;
      Pid[1].Dmax = 100;
      Pid[2].Dmax = 100;
      Pid[3].Dmax = 100;
      Pid[4].Dmax = 100;
      Pid[5].Dmax = 0.254m;
      Pid[6].Dmax = 0.254m;
      Pid[7].Dmax = 100;
      Pid[8].Dmax = 100;
      Pid[9].Dmax = 100;

      Pid[0].Pdef = 33;
      Pid[0].Idef = 30;
      Pid[0].Ddef = 23;
      Pid[1].Pdef = 33;
      Pid[1].Idef = 30;
      Pid[1].Ddef = 23;
      Pid[2].Pdef = 68;
      Pid[2].Idef = 45;
      Pid[2].Ddef = 0;
      Pid[3].Pdef = 64;
      Pid[3].Idef = 25;
      Pid[3].Ddef = 24;
      Pid[4].Pdef = 11;
      Pid[4].Idef = 0;
      //Pid[4].Ddef = 0;
      Pid[5].Pdef = 20;
      Pid[5].Idef = 8;
      Pid[5].Ddef = 45;
      Pid[6].Pdef = 14;
      Pid[6].Idef = 20;
      Pid[6].Ddef = 80;
      Pid[7].Pdef = 90;
      Pid[7].Idef = 10;
      Pid[7].Ddef = 100;
      Pid[8].Pdef = 40;
      //Pid[8].Idef = 0;
      //Pid[8].Ddef = 0;

      mw_gui.AUXName[0] = "ARM";
      mw_gui.AUXName[1] = "ANGLE";
      mw_gui.AUXName[2]= "HORIZON";
      mw_gui.AUXName[3]= "BARO";
      mw_gui.AUXName[4]= "VARIO";
      mw_gui.AUXName[5]= "MAG";
      mw_gui.AUXName[6]= "HEADFREE";
      mw_gui.AUXName[7]= "HEADADJ";
      mw_gui.AUXName[8]= "CAMSTAB";
      mw_gui.AUXName[9]= "CAMTRIG";
      mw_gui.AUXName[10]= "GPS HOME";
      mw_gui.AUXName[11]= "GPS HOLD";
      mw_gui.AUXName[12]= "PASSTHRU";
      mw_gui.AUXName[13]= "BEEPER";
      mw_gui.AUXName[14]= "LEDMAX";
      mw_gui.AUXName[15]= "LEDLOW";
      mw_gui.AUXName[16]= "LLIGHTS";
      mw_gui.AUXName[17]= "CALIB";
      mw_gui.AUXName[18] = "GOVERNOR";

      labelAUX0.Text = mw_gui.AUXName[0];
      labelAUX1.Text = mw_gui.AUXName[1];
      labelAUX2.Text = mw_gui.AUXName[2];
      labelAUX3.Text = mw_gui.AUXName[3];
      labelAUX5.Text = mw_gui.AUXName[5];
      labelAUX6.Text = mw_gui.AUXName[6];
      labelAUX7.Text = mw_gui.AUXName[7];

      //Quick hack to get pid names to mw_params untill redo the structures
      for (int i = 0; i < iPidItems; i++)
      {
        mw_params.pidnames[i] = Pid[i].name;
      }

      serial_ports_enumerate();
      foreach (string speed in sSerialSpeeds)
      {
        cb_serial_speed.Items.Add(speed);
      }
      cb_serial_speed.SelectedItem = "115200";

      if (cb_serial_port.Items.Count == 0)
      {
        b_connect.Enabled = false;          //Nos serial port, disable connect
      }
    }

    private void serial_ports_enumerate()
    {
      //Enumerate all serial ports
      b_connect.Enabled = true;           //Enable the connect button

      string[] ports = SerialPort.GetPortNames();
      cb_serial_port.Items.Clear();
      foreach (string port in ports)
      {
        cb_serial_port.Items.Add(port);
      }

      //if prefered port is not available then select the first one 
      if (cb_serial_port.Text == "")
      {
        if (cb_serial_port.Items.Count > 0) { cb_serial_port.SelectedIndex = 0; }
      }

      //Disable connect button if there is no selected com port
      if (cb_serial_port.Items.Count == 0) { b_connect.Enabled = false; }

      cb_serial_port.SelectedItem = "COM2";

    }

    private void serialConnect()
    {
      //go to first screen when connect
      //if (tabMain.SelectedIndex == 4) { tabMain.SelectedIndex = 0; }

      if (serialPort1.IsOpen)              //Disconnect
      {
        b_connect.Text = "Connect";
        timer1.Enabled = false;
        //b_connect.Image = Properties.Resources.connect;
        isConnected = false;
        serialPort1.Close();
        labelInfo.Text = string.Empty;

      }
      else                               //Connect
      {

        if (cb_serial_port.Text == "") { return; }  //if no port selected then do nothin' at connect
        //Assume that the selection in the combobox for port is still valid
        serialPort1.PortName = cb_serial_port.Text;
        serialPort1.BaudRate = int.Parse(cb_serial_speed.Text);
        try
        {
          serialPort1.Open();
        }
        catch (Exception ex)
        {
          //WRONG, it seems that the combobox selection pointed to a port which is no longer available
          //**MessageBox.Show(this, "Please check that your USB cable is still connected.\r\nAfter you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error);
          labelTextLastMessage.Text = ex.Message;
          //serial_ports_enumerate();
          //return; //Exit without connecting;
        }
        //Set button text and status
        b_connect.Text = "Disconnect";
        //**b_connect.Image = Properties.Resources.disconnect;
        isConnected = true;

        //Enable buttons that are not working here
        /*b_reset.Enabled = true;
        b_cal_acc.Enabled = true;
        b_cal_mag.Enabled = true;
        b_read_settings.Enabled = true;
        b_write_settings.Enabled = true;
        
        */
        timer1.Enabled = true;

        //bOptions_needs_refresh = true;
        MSPquery(MSP_IDENT);
        MSPquery(MSP_PID);
        MSPquery(MSP_RC_TUNING);
        MSPquery(MSP_IDENT);
        MSPquery(MSP_BOX);
        MSPquery(MSP_MISC);

        isNeedUpdateInfoPanel = true;

      }
    }

    private void b_connect_Click(object sender, EventArgs e)
    {
      serialConnect();
    }


    private void MSPquery(int command)
    {
      byte c = 0;
      byte[] o;
      o = new byte[10];
      // with checksum 
      o[0] = (byte)'$';
      o[1] = (byte)'M';
      o[2] = (byte)'<';
      o[3] = (byte)0; c ^= o[3];       //no payload 
      o[4] = (byte)command; c ^= o[4];
      o[5] = (byte)c;
      serialPort1.Write(o, 0, 6);
      this.command = command;
    }

    private void FormMain_Closing(object sender, CancelEventArgs e)
    {
      if (serialPort1.IsOpen)
        serialPort1.Close();
    }

    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      SerialPort sp = (SerialPort)sender;
      byte c;

      if (sp.IsOpen)
      {
        //Just process what is received.
        while (sp.BytesToRead > 0)
        {
          c = (byte)sp.ReadByte();
          switch (c_state)
          {
            case IDLE:
              c_state = (c == '$') ? HEADER_START : IDLE;
              break;
            case HEADER_START:
              c_state = (c == 'M') ? HEADER_M : IDLE;
              break;

            case HEADER_M:
              if (c == '>')
              {
                c_state = HEADER_ARROW;
              }
              else if (c == '!')
              {
                c_state = HEADER_ERR;
              }
              else
              {
                c_state = IDLE;
              }
              break;

            case HEADER_ARROW:
            case HEADER_ERR:
              /* is this an error message? */
              err_rcvd = (c_state == HEADER_ERR);        /* now we are expecting the payload size */
              dataSize = c;
              /* reset index variables */
              offset = 0;
              checksum = 0;
              checksum ^= c;
              c_state = HEADER_SIZE;
              if (dataSize > 100) { c_state = IDLE; }

              break;
            case HEADER_SIZE:
              cmd = c;
              checksum ^= c;
              c_state = HEADER_CMD;
              break;
            case HEADER_CMD:
              if (offset < dataSize)
              {
                checksum ^= c;
                inBuf[offset++] = c;
              }
              else
              {

                /* compare calculated and transferred checksum */
                if (checksum == c)
                {
                  if (err_rcvd)
                  {
                    // Console.WriteLine("Copter did not understand request type " + err_rcvd);
                  }
                  else
                  {
                    /* we got a valid response packet, evaluate it */
                    serial_packet_count++;
                    evaluate_command(cmd);
                  }
                }
                else
                {

                  serial_error_count++;

                }
                c_state = IDLE;
              }
              break;
          }
        }

      }
      else   //port not opened, (it could happen when U disconnect the usb cable while connected
      {
        //bSerialError = true; //do nothing
        //return;
      }
    }


    private void evaluate_command(byte cmd)
    {
      byte ptr;

      labelTextLastMessage.Invoke(new EventHandler(delegate
      {
        labelTextLastMessage.Text = cmd.ToString();
      }));

      switch (cmd)
      {
        case MSP_IDENT:
          ptr = 0;
          mw_gui.version = (byte)inBuf[ptr++];
          mw_gui.multiType = (byte)inBuf[ptr];
          mw_gui.protocol_version = (byte)inBuf[ptr++];
          mw_gui.capability = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
          break;
        case MSP_STATUS:
          ptr = 0;
          //mw_gui.cycleTime = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.i2cErrors = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.present = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.mode = BitConverter.ToUInt32(inBuf, ptr); ptr += 4;
          break;
        case MSP_RAW_IMU:
          ptr = 0;
          //mw_gui.ax = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.ay = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.az = BitConverter.ToInt16(inBuf, ptr); ptr += 2;

          //mw_gui.gx = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
          //mw_gui.gy = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
          //mw_gui.gz = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;

          //mw_gui.magx = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
          //mw_gui.magy = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
          //mw_gui.magz = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
          break;
        case MSP_SERVO:
          ptr = 0;
          for (int i = 0; i < 8; i++)
          {
            //mw_gui.servos[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          }
          break;
        case MSP_MOTOR:
          ptr = 0;
          for (int i = 0; i < 8; i++)
          {
            //mw_gui.motors[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          }
          break;
        case MSP_RC:
          ptr = 0;
          mw_gui.rcRoll = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcPitch = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcYaw = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcThrottle = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcAux1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcAux2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcAux3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          mw_gui.rcAux4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_RAW_GPS:
          ptr = 0;
          //mw_gui.GPS_fix = (byte)inBuf[ptr++];
          //mw_gui.GPS_numSat = (byte)inBuf[ptr++];
          //mw_gui.GPS_latitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
          //mw_gui.GPS_longitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
          //mw_gui.GPS_altitude = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.GPS_speed = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_COMP_GPS:
          ptr = 0;
          //mw_gui.GPS_distanceToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.GPS_directionToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.GPS_update = (byte)inBuf[ptr++];
          break;
        case MSP_ATTITUDE:
          ptr = 0;
          //mw_gui.angx = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
          //mw_gui.angy = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
          //mw_gui.heading = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_ALTITUDE:
          ptr = 0;
          //mw_gui.baro = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
          break;
        case MSP_BAT:
          ptr = 0;
          //mw_gui.vBat = (byte)inBuf[ptr++];
          //mw_gui.pMeterSum = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_RC_TUNING:
          ptr = 0;
          mw_gui.rcRate = (byte)inBuf[ptr++];
          mw_gui.rcExpo = (byte)inBuf[ptr++];
          mw_gui.RollPitchRate = (byte)inBuf[ptr++];
          mw_gui.YawRate = (byte)inBuf[ptr++];
          mw_gui.DynThrPID = (byte)inBuf[ptr++];
          mw_gui.ThrottleMID = (byte)inBuf[ptr++];
          mw_gui.ThrottleEXPO = (byte)inBuf[ptr++];
          break;
        case MSP_PID:
          ptr = 0;
          for (int i = 0; i < iPidItems; i++)
          {
            mw_gui.pidP[i] = (byte)inBuf[ptr++];
            mw_gui.pidI[i] = (byte)inBuf[ptr++];
            mw_gui.pidD[i] = (byte)inBuf[ptr++];
            isNeedUpdatePIDPanel = true;
          }
          break;
        case MSP_BOX:
          ptr = 0;
          for (int i = 0; i < iCheckBoxItems; i++)
          {
            mw_gui.activation[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          }
          isNeedUpdateAuxPanel = true;
          break;
        case MSP_MISC:
          ptr = 0;
          //mw_gui.powerTrigger = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_DEBUG:
          ptr = 0;
          //mw_gui.debug1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.debug2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.debug3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          //mw_gui.debug4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          break;
        case MSP_WP:
          ptr = 0;
          byte wp_no = (byte)inBuf[ptr++];
          if (wp_no == 0)
          {
            //mw_gui.GPS_home_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
            //mw_gui.GPS_home_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
            //mw_gui.GPS_home_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
            //flag comes here but not care
          }
          if (wp_no == 16)
          {
            //mw_gui.GPS_poshold_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
            //mw_gui.GPS_poshold_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
            //mw_gui.GPS_poshold_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
          }
          break;

      }
    }



    private void bRead_Click(object sender, EventArgs e)
    {
      if (isConnected)
      {
        MSPquery(MSP_PID);
        MSPquery(MSP_RC_TUNING);
        //MSPquery(MSP_IDENT);
        MSPquery(MSP_BOX);
        //MSPquery(MSP_MISC);
      }
    }

    private void bWrite_Click(object sender, EventArgs e)
    {
      timer1.Enabled = false;
      update_params();
      mw_params.write_settings(serialPort1);
      timer1.Enabled = true;
    }

    private void update_params()
    {
      for (int i = 0; i < iPidItems; i++)
      {
        mw_params.pidP[i] = mw_gui.pidP[i];
        mw_params.pidI[i] = mw_gui.pidI[i];
        mw_params.pidD[i] = mw_gui.pidD[i];
      }

      mw_params.RollPitchRate = (byte)(Convert.ToDouble(RollPitchRate.Text) * 100);
      mw_params.YawRate = (byte)(Convert.ToDouble(YawRate.Text) * 100);
      mw_params.DynThrPID = (byte)(Convert.ToDouble(ThrPIDAtt.Text) * 100);

      mw_params.rcExpo = (byte)(Convert.ToDouble(RCExpo.Text) * 100);
      mw_params.rcRate = (byte)(Convert.ToDouble(RCRate.Text) * 100);
      //mw_params.ThrottleMID = (byte)(TMID.Value * 100);
      //mw_params.ThrottleEXPO = (byte)(nTEXPO.Value * 100);

      //mw_params.PowerTrigger = (int)nPAlarm.Value;

       mw_params.activation[0] = 0;
       if (checkBoxAUX0L.Checked) mw_params.activation[0]  = 1;
       if (checkBoxAUX0M.Checked) mw_params.activation[0] += 2;
       if (checkBoxAUX0H.Checked) mw_params.activation[0] += 4;
       mw_params.activation[1] = 0;
       if (checkBoxAUX1L.Checked) mw_params.activation[1]  = 1;
       if (checkBoxAUX1M.Checked) mw_params.activation[1] += 2;
       if (checkBoxAUX1H.Checked) mw_params.activation[1] += 4;
       mw_params.activation[2] = 0;
       if (checkBoxAUX2L.Checked) mw_params.activation[2]  = 1;
       if (checkBoxAUX2M.Checked) mw_params.activation[2] += 2;
       if (checkBoxAUX2H.Checked) mw_params.activation[2] += 4;
       mw_params.activation[3] = 0;
       if (checkBoxAUX3L.Checked) mw_params.activation[3]  = 1;
       if (checkBoxAUX3M.Checked) mw_params.activation[3] += 2;
       if (checkBoxAUX3H.Checked) mw_params.activation[3] += 4;
       mw_params.activation[5] = 0;
       if (checkBoxAUX5L.Checked) mw_params.activation[5]  = 1;
       if (checkBoxAUX5M.Checked) mw_params.activation[5] += 2;
       if (checkBoxAUX5H.Checked) mw_params.activation[5] += 4;
       mw_params.activation[6] = 0;
       if (checkBoxAUX6L.Checked) mw_params.activation[6]  = 1;
       if (checkBoxAUX6M.Checked) mw_params.activation[6] += 2;
       if (checkBoxAUX6H.Checked) mw_params.activation[6] += 4;
       mw_params.activation[7] = 0;
       if (checkBoxAUX7L.Checked) mw_params.activation[7]  = 1;
       if (checkBoxAUX7M.Checked) mw_params.activation[7] += 2;
       if (checkBoxAUX7H.Checked) mw_params.activation[7] += 4;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (isNeedUpdatePIDPanel)
      {
        isNeedUpdatePIDPanel = !isNeedUpdatePIDPanel;
        update_pid_panel();
      }
      if (isNeedUpdateInfoPanel)
      {
        isNeedUpdateInfoPanel = !isNeedUpdateInfoPanel;
        update_info_panel();
      }
      if (isNeedUpdateAuxPanel)
      {
        isNeedUpdateAuxPanel = !isNeedUpdateAuxPanel;
        update_aux_panel();
      }
    }

    private void update_pid_panel()
    {
      //fill out PID values from mw_gui. structure

      PRoll.Text = ((decimal)mw_gui.pidP[0] / (decimal)Pid[0].Pprec).ToString("F1");
      IRoll.Text = ((decimal)mw_gui.pidI[0] / (decimal)Pid[0].Iprec).ToString("F3");
      DRoll.Text = ((decimal)mw_gui.pidD[0] / (decimal)Pid[0].Dprec).ToString("F0");

      PPitch.Text = ((decimal)mw_gui.pidP[1] / (decimal)Pid[1].Pprec).ToString("F1");
      IPitch.Text = ((decimal)mw_gui.pidI[1] / (decimal)Pid[1].Iprec).ToString("F3");
      DPitch.Text = ((decimal)mw_gui.pidD[1] / (decimal)Pid[1].Dprec).ToString("F0");

      PYaw.Text = ((decimal)mw_gui.pidP[2] / (decimal)Pid[2].Pprec).ToString("F1");
      IYaw.Text = ((decimal)mw_gui.pidI[2] / (decimal)Pid[2].Iprec).ToString("F3");
      DYaw.Text = ((decimal)mw_gui.pidD[2] / (decimal)Pid[2].Dprec).ToString("F0");

      PAlt.Text = ((decimal)mw_gui.pidP[3] / (decimal)Pid[3].Pprec).ToString("F1");
      IAlt.Text = ((decimal)mw_gui.pidI[3] / (decimal)Pid[3].Iprec).ToString("F3");
      DAlt.Text = ((decimal)mw_gui.pidD[3] / (decimal)Pid[3].Dprec).ToString("F0");

      PLevel.Text = ((decimal)mw_gui.pidP[7] / (decimal)Pid[7].Pprec).ToString("F1");
      ILevel.Text = ((decimal)mw_gui.pidI[7] / (decimal)Pid[7].Iprec).ToString("F2");
      DLevel.Text = ((decimal)mw_gui.pidD[7] / (decimal)Pid[7].Dprec).ToString("F0");

      PMag.Text = ((decimal)mw_gui.pidP[8] / (decimal)Pid[8].Pprec).ToString("F1");

      /*PVelocity.Text = ((decimal)mw_gui.pidP[9] / (decimal)Pid[9].Pprec).ToString("F1");
      IVelocity.Text = ((decimal)mw_gui.pidI[9] / (decimal)Pid[9].Iprec).ToString("F2");
      DVelocity.Text = ((decimal)mw_gui.pidD[9] / (decimal)Pid[9].Dprec).ToString("F0");
      */
      RCExpo.Text = ((decimal)mw_gui.rcExpo / 100).ToString("F2");
      RCRate.Text = ((decimal)mw_gui.rcRate / 100).ToString("F2");
      RollPitchRate.Text = ((decimal)mw_gui.RollPitchRate / 100).ToString("F2");
      YawRate.Text = ((decimal)mw_gui.YawRate / 100).ToString("F2");
      ThrPIDAtt.Text = ((decimal)mw_gui.DynThrPID / 100).ToString("F2");

      ThrMID.Text = ((decimal)mw_gui.ThrottleEXPO / 100).ToString("F2");
      ThrEXPO.Text = ((decimal)mw_gui.ThrottleMID / 100).ToString("F2");

      /*      for (int i = 0; i < iPidItems; i++)
            {
              if (Pid[i].Pshown) { Pid[i].Pfield.Value = (decimal)mw_gui.pidP[i] / Pid[i].Pprec; Pid[i].Pfield.BackColor = Color.White; }
              if (Pid[i].Ishown) { Pid[i].Ifield.Value = (decimal)mw_gui.pidI[i] / Pid[i].Iprec; Pid[i].Ifield.BackColor = Color.White; }
              if (Pid[i].Dshown) { Pid[i].Dfield.Value = (decimal)mw_gui.pidD[i] / Pid[i].Dprec; Pid[i].Dfield.BackColor = Color.White; }

            }

            nRATE_rp.Value = (decimal)mw_gui.RollPitchRate / 100;
            nRATE_rp.BackColor = Color.White;
            nRATE_yaw.Value = (decimal)mw_gui.YawRate / 100;
            nRATE_yaw.BackColor = Color.White;
            nRATE_tpid.Value = (decimal)mw_gui.DynThrPID / 100;
            nRATE_tpid.BackColor = Color.White;

            trackbar_RC_Expo.Value = mw_gui.rcExpo;
            nRCExpo.Value = (decimal)mw_gui.rcExpo / 100;
            nRCExpo.BackColor = Color.White;
            trackbar_RC_Rate.Value = mw_gui.rcRate;
            nRCRate.Value = (decimal)mw_gui.rcRate / 100;
            nRCRate.BackColor = Color.White;

            rc_expo_control1.SetRCExpoParameters((double)mw_gui.rcRate / 100, (double)mw_gui.rcExpo / 100);

            nTEXPO.Value = (decimal)mw_gui.ThrottleEXPO / 100;
            nTEXPO.BackColor = Color.White;
            trackBar_T_EXPO.Value = mw_gui.ThrottleEXPO;
            nTMID.Value = (decimal)mw_gui.ThrottleMID / 100;
            nTMID.BackColor = Color.White;
            trackBar_T_MID.Value = mw_gui.ThrottleMID;
            throttle_expo_control1.SetRCExpoParameters((double)mw_gui.ThrottleMID / 100, (double)mw_gui.ThrottleEXPO / 100, mw_gui.rcThrottle);

            nPAlarm.Value = mw_gui.powerTrigger;
            nPAlarm.BackColor = Color.White;
            */


    }


    private void update_info_panel()
    {
      labelInfo.Text = "INFO";
      labelInfo.Text += "\nVersion:" + mw_gui.version.ToString();
      labelInfo.Text += "\nMultitype:" + mw_gui.multiType;
      labelInfo.Text += "\nGUI version:" + mw_gui.protocol_version;
      labelInfo.Text += "\nGUI capability:" + mw_gui.capability;
    }

    private void update_aux_panel()
    {
      checkBoxAUX0L.Checked = (mw_gui.activation[0] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX0M.Checked = (mw_gui.activation[0] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX0H.Checked = (mw_gui.activation[0] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX1L.Checked = (mw_gui.activation[1] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX1M.Checked = (mw_gui.activation[1] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX1H.Checked = (mw_gui.activation[1] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX2L.Checked = (mw_gui.activation[2] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX2M.Checked = (mw_gui.activation[2] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX2H.Checked = (mw_gui.activation[2] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX3L.Checked = (mw_gui.activation[3] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX3M.Checked = (mw_gui.activation[3] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX3H.Checked = (mw_gui.activation[3] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX5L.Checked = (mw_gui.activation[5] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX5M.Checked = (mw_gui.activation[5] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX5H.Checked = (mw_gui.activation[5] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX6L.Checked = (mw_gui.activation[6] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX6M.Checked = (mw_gui.activation[6] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX6H.Checked = (mw_gui.activation[6] & (1 << 2)) == 0 ? false : true;
      checkBoxAUX7L.Checked = (mw_gui.activation[7] & (1 << 0)) == 0 ? false : true;
      checkBoxAUX7M.Checked = (mw_gui.activation[7] & (1 << 1)) == 0 ? false : true;
      checkBoxAUX7H.Checked = (mw_gui.activation[7] & (1 << 2)) == 0 ? false : true;
    }

    private void end_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void panel_Click(object sender, EventArgs e)
    {
      Panel p = (Panel)sender;
      if (p.Name == "panelRoll")
      {
        label19.Text = "Roll";
        setP.Text = PRoll.Text;
        setI.Text = IRoll.Text;
        setD.Text = DRoll.Text;
        pidIndex = 0;
      }
      if (p.Name == "panelPitch")
      {
        label19.Text = "Pitch";
        setP.Text = PPitch.Text;
        setI.Text = IPitch.Text;
        setD.Text = DPitch.Text;
        pidIndex = 1;
      }
      if (p.Name == "panelYaw")
      {
        label19.Text = "Yaw";
        setP.Text = PYaw.Text;
        setI.Text = IYaw.Text;
        setD.Text = DYaw.Text;
        pidIndex = 2;
      }
      if (p.Name == "panelAlt")
      {
        label19.Text = "Altitude";
        setP.Text = PAlt.Text;
        setI.Text = IAlt.Text;
        setD.Text = DAlt.Text;
        pidIndex = 3;
      }
      if (p.Name == "panelPosHold")
      {
        pidIndex = 4;
      }
      if (p.Name == "panelPosHoldRate")
      {
        pidIndex = 5;
      }
      if (p.Name == "panelNavigationRate")
      {
        pidIndex = 6;
      }

      if (p.Name == "panelLevel")
      {
        label19.Text = "Level";
        setP.Text = PLevel.Text;
        setI.Text = ILevel.Text;
        setD.Text = DLevel.Text;
        pidIndex = 7;
      }
      if (p.Name == "panelMag")
      {
        label19.Text = "Mag";
        setP.Text = PMag.Text;
        pidIndex = 8;
      }
      /*if (p.Name == "panelVel")
      {
        label19.Text = "Velocity";
        setP.Text = PVelocity.Text;
        setI.Text = IVelocity.Text;
        setD.Text = DVelocity.Text;
        pidIndex = 9;
      }
      */

      tabControl1.SelectedIndex = 3;
    }

    private void buttonSetPid_Click(object sender, EventArgs e)
    {
      mw_gui.pidP[pidIndex] = (byte)double.Parse(setP.Text.Replace(".", ","));
      mw_gui.pidI[pidIndex] = (byte)double.Parse(setI.Text.Replace(".", ","));
      mw_gui.pidD[pidIndex] = (byte)double.Parse(setD.Text.Replace(".", ","));
      tabControl1.SelectedIndex = 1;
      update_pid_panel();
    }

    private void plusP_Click(object sender, EventArgs e)
    {
      if (setP.Text == string.Empty)
        setP.Text = "0";
      setP.Text = (Convert.ToDouble(setP.Text) + (1.0 / Pid[pidIndex].Pprec)).ToString();
      //TODO omezeni rozsahu
    }

    private void minusP_Click(object sender, EventArgs e)
    {
      setP.Text = (Convert.ToDouble(setP.Text) - (1.0 / Pid[pidIndex].Pprec)).ToString();
      //TODO omezeni rozsahu
    }

    private void plusI_Click(object sender, EventArgs e)
    {
      if (setI.Text == string.Empty)
        setI.Text = "0";
      setI.Text = (Convert.ToDouble(setI.Text) + (1.0 / Pid[pidIndex].Iprec)).ToString();
      //TODO omezeni rozsahu
    }

    private void minusI_Click(object sender, EventArgs e)
    {
      setI.Text = (Convert.ToDouble(setI.Text) - (1.0 / Pid[pidIndex].Iprec)).ToString();
      //TODO omezeni rozsahu
    }

    private void plusD_Click(object sender, EventArgs e)
    {
      if (setD.Text == string.Empty)
        setD.Text = "0";
      setD.Text = (Convert.ToDouble(setD.Text) + (1.0 / Pid[pidIndex].Dprec)).ToString();
      //TODO omezeni rozsahu

    }

    private void minusD_Click(object sender, EventArgs e)
    {
      setD.Text = (Convert.ToDouble(setD.Text) - (1.0 / Pid[pidIndex].Dprec)).ToString();
      //TODO omezeni rozsahu

    }


    private void buttonSetDefaults_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < iPidItems; i++)
      {
        mw_gui.pidP[i] = Pid[i].Pdef;
        mw_gui.pidI[i] = Pid[i].Idef;
        mw_gui.pidD[i] = Pid[i].Ddef;
      }
      mw_gui.DynThrPID = mw_gui.DynThrPIDDef;
      mw_gui.RollPitchRate = mw_gui.RollPitchRateDef;
      mw_gui.YawRate = mw_gui.YawRateDef;
      update_pid_panel();
    }

    //Roll
    private void PRoll_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 0, "P");
    }

    private void IRoll_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 0, "I");
    }

    private void DRoll_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 0, "D");
    }

    //Pitch
    private void PPitch_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 1, "P");
    }

    private void IPitch_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 1, "I");
    }

    private void DPitch_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 1, "D");
    }

    //Yaw
    private void PYaw_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 2, "P");
    }

    private void IYaw_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 2, "I");
    }

    private void DYaw_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 2, "D");
    }

    //Altitude
    private void PAlt_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 3, "P");
    }

    private void IAlt_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 3, "I");
    }

    private void DAlt_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 3, "D");
    }

    /*Pid[4].name = "PosHold";
    Pid[5].name = "PosHoldRate";
    Pid[6].name = "Navigation Rate";
    */
    //Level
    private void PLevel_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 7, "P");
    }

    private void ILevel_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 7, "I");
    }

    private void DLevel_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 7, "D");
    }

    //Mag
    private void PMag_TextChanged(object sender, EventArgs e)
    {
      textPIDChange(sender, 8, "P");
    }

    //Pid[9].name = "Velocity";


    private void textPIDChange(object sender, int pid, string part)
    {
      try
      {
        Label tb = (Label)sender;
        if (tb.Text.Length > 0 && !string.IsNullOrEmpty(tb.Text))
        {
          if (part == "P")
//          Pid[pid].P = (byte)double.Parse(tb.Text.Replace(".", ","));
            mw_gui.pidP[pid] = (byte)double.Parse(tb.Text.Replace(".", ","));
          if (part == "I")
//            Pid[pid].I = (byte)double.Parse(tb.Text.Replace(".", ","));
            mw_gui.pidI[pid] = (byte)double.Parse(tb.Text.Replace(".", ","));
          if (part == "D")
//            Pid[pid].D = (byte)double.Parse(tb.Text.Replace(".", ","));
            mw_gui.pidD[pid] = (byte)double.Parse(tb.Text.Replace(".", ","));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedIndex = 1;
    }
  }
}