namespace MWGUI
{
  partial class MWSetup
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.timer1 = new System.Windows.Forms.Timer();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.panel3 = new System.Windows.Forms.Panel();
      this.PYaw = new System.Windows.Forms.Label();
      this.IYaw = new System.Windows.Forms.Label();
      this.DYaw = new System.Windows.Forms.Label();
      this.YawRate = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.PPitch = new System.Windows.Forms.Label();
      this.IPitch = new System.Windows.Forms.Label();
      this.DPitch = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.PRoll = new System.Windows.Forms.Label();
      this.IRoll = new System.Windows.Forms.Label();
      this.DRoll = new System.Windows.Forms.Label();
      this.RollPitchRate = new System.Windows.Forms.Label();
      this.bWrite = new System.Windows.Forms.Button();
      this.label26 = new System.Windows.Forms.Label();
      this.ThrPIDAtt = new System.Windows.Forms.Label();
      this.RCRate = new System.Windows.Forms.Label();
      this.RCExpo = new System.Windows.Forms.Label();
      this.DVelocity = new System.Windows.Forms.Label();
      this.IVelocity = new System.Windows.Forms.Label();
      this.PVelocity = new System.Windows.Forms.Label();
      this.PMag = new System.Windows.Forms.Label();
      this.DLevel = new System.Windows.Forms.Label();
      this.ILevel = new System.Windows.Forms.Label();
      this.PLevel = new System.Windows.Forms.Label();
      this.DAlt = new System.Windows.Forms.Label();
      this.IAlt = new System.Windows.Forms.Label();
      this.PAlt = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.bRead = new System.Windows.Forms.Button();
      this.labelTextLastMessage = new System.Windows.Forms.Label();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.cb_serial_speed = new System.Windows.Forms.ComboBox();
      this.label15 = new System.Windows.Forms.Label();
      this.cb_serial_port = new System.Windows.Forms.ComboBox();
      this.label14 = new System.Windows.Forms.Label();
      this.b_connect = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.setRate = new System.Windows.Forms.TextBox();
      this.label20 = new System.Windows.Forms.Label();
      this.button8 = new System.Windows.Forms.Button();
      this.setD = new System.Windows.Forms.TextBox();
      this.minusD = new System.Windows.Forms.Button();
      this.plusD = new System.Windows.Forms.Button();
      this.setI = new System.Windows.Forms.TextBox();
      this.minusI = new System.Windows.Forms.Button();
      this.plusI = new System.Windows.Forms.Button();
      this.setP = new System.Windows.Forms.TextBox();
      this.minusP = new System.Windows.Forms.Button();
      this.plusP = new System.Windows.Forms.Button();
      this.label19 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
      this.tabPage2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.menuItem1);
      this.mainMenu1.MenuItems.Add(this.menuItem2);
      // 
      // menuItem1
      // 
      this.menuItem1.Text = "Menu";
      // 
      // menuItem2
      // 
      this.menuItem2.Text = "Konec";
      this.menuItem2.Click += new System.EventHandler(this.end_Click);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.Color.Black;
      this.tabPage2.Controls.Add(this.panel3);
      this.tabPage2.Controls.Add(this.panel2);
      this.tabPage2.Controls.Add(this.panel1);
      this.tabPage2.Controls.Add(this.bWrite);
      this.tabPage2.Controls.Add(this.label26);
      this.tabPage2.Controls.Add(this.ThrPIDAtt);
      this.tabPage2.Controls.Add(this.RCRate);
      this.tabPage2.Controls.Add(this.RCExpo);
      this.tabPage2.Controls.Add(this.DVelocity);
      this.tabPage2.Controls.Add(this.IVelocity);
      this.tabPage2.Controls.Add(this.PVelocity);
      this.tabPage2.Controls.Add(this.PMag);
      this.tabPage2.Controls.Add(this.DLevel);
      this.tabPage2.Controls.Add(this.ILevel);
      this.tabPage2.Controls.Add(this.PLevel);
      this.tabPage2.Controls.Add(this.DAlt);
      this.tabPage2.Controls.Add(this.IAlt);
      this.tabPage2.Controls.Add(this.PAlt);
      this.tabPage2.Controls.Add(this.label9);
      this.tabPage2.Controls.Add(this.label8);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.label13);
      this.tabPage2.Controls.Add(this.label12);
      this.tabPage2.Controls.Add(this.label11);
      this.tabPage2.Controls.Add(this.label10);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Controls.Add(this.bRead);
      this.tabPage2.Controls.Add(this.labelTextLastMessage);
      this.tabPage2.Location = new System.Drawing.Point(0, 0);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(240, 317);
      this.tabPage2.Text = "PID";
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.Black;
      this.panel3.Controls.Add(this.PYaw);
      this.panel3.Controls.Add(this.IYaw);
      this.panel3.Controls.Add(this.DYaw);
      this.panel3.Controls.Add(this.YawRate);
      this.panel3.Controls.Add(this.label3);
      this.panel3.Location = new System.Drawing.Point(12, 126);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(224, 20);
      this.panel3.Click += new System.EventHandler(this.panel3_Click);
      // 
      // PYaw
      // 
      this.PYaw.BackColor = System.Drawing.Color.White;
      this.PYaw.Location = new System.Drawing.Point(44, 0);
      this.PYaw.Name = "PYaw";
      this.PYaw.Size = new System.Drawing.Size(33, 20);
      // 
      // IYaw
      // 
      this.IYaw.BackColor = System.Drawing.Color.White;
      this.IYaw.Location = new System.Drawing.Point(81, 0);
      this.IYaw.Name = "IYaw";
      this.IYaw.Size = new System.Drawing.Size(41, 20);
      // 
      // DYaw
      // 
      this.DYaw.BackColor = System.Drawing.Color.White;
      this.DYaw.Location = new System.Drawing.Point(126, 0);
      this.DYaw.Name = "DYaw";
      this.DYaw.Size = new System.Drawing.Size(41, 20);
      // 
      // YawRate
      // 
      this.YawRate.BackColor = System.Drawing.Color.White;
      this.YawRate.Location = new System.Drawing.Point(173, 0);
      this.YawRate.Name = "YawRate";
      this.YawRate.Size = new System.Drawing.Size(41, 20);
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.Color.Black;
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(3, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 17);
      this.label3.Text = "Yaw";
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Black;
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.PPitch);
      this.panel2.Controls.Add(this.IPitch);
      this.panel2.Controls.Add(this.DPitch);
      this.panel2.Location = new System.Drawing.Point(18, 106);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(217, 20);
      this.panel2.Click += new System.EventHandler(this.panel2_Click);
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.Color.Black;
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 15);
      this.label2.Text = "Pitch";
      // 
      // PPitch
      // 
      this.PPitch.BackColor = System.Drawing.Color.White;
      this.PPitch.Location = new System.Drawing.Point(38, 0);
      this.PPitch.Name = "PPitch";
      this.PPitch.Size = new System.Drawing.Size(33, 20);
      // 
      // IPitch
      // 
      this.IPitch.BackColor = System.Drawing.Color.White;
      this.IPitch.Location = new System.Drawing.Point(75, 0);
      this.IPitch.Name = "IPitch";
      this.IPitch.Size = new System.Drawing.Size(41, 20);
      // 
      // DPitch
      // 
      this.DPitch.BackColor = System.Drawing.Color.White;
      this.DPitch.Location = new System.Drawing.Point(120, 0);
      this.DPitch.Name = "DPitch";
      this.DPitch.Size = new System.Drawing.Size(41, 20);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.Black;
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.PRoll);
      this.panel1.Controls.Add(this.IRoll);
      this.panel1.Controls.Add(this.DRoll);
      this.panel1.Controls.Add(this.RollPitchRate);
      this.panel1.Location = new System.Drawing.Point(18, 86);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(218, 20);
      this.panel1.Click += new System.EventHandler(this.panel1_Click);
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Black;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 17);
      this.label1.Text = "Roll";
      // 
      // PRoll
      // 
      this.PRoll.BackColor = System.Drawing.Color.White;
      this.PRoll.Location = new System.Drawing.Point(38, 0);
      this.PRoll.Name = "PRoll";
      this.PRoll.Size = new System.Drawing.Size(33, 20);
      // 
      // IRoll
      // 
      this.IRoll.BackColor = System.Drawing.Color.White;
      this.IRoll.Location = new System.Drawing.Point(75, 0);
      this.IRoll.Name = "IRoll";
      this.IRoll.Size = new System.Drawing.Size(41, 20);
      // 
      // DRoll
      // 
      this.DRoll.BackColor = System.Drawing.Color.White;
      this.DRoll.Location = new System.Drawing.Point(120, 0);
      this.DRoll.Name = "DRoll";
      this.DRoll.Size = new System.Drawing.Size(41, 20);
      // 
      // RollPitchRate
      // 
      this.RollPitchRate.BackColor = System.Drawing.Color.White;
      this.RollPitchRate.Location = new System.Drawing.Point(167, 0);
      this.RollPitchRate.Name = "RollPitchRate";
      this.RollPitchRate.Size = new System.Drawing.Size(41, 20);
      // 
      // bWrite
      // 
      this.bWrite.BackColor = System.Drawing.Color.White;
      this.bWrite.ForeColor = System.Drawing.Color.Black;
      this.bWrite.Location = new System.Drawing.Point(129, 7);
      this.bWrite.Name = "bWrite";
      this.bWrite.Size = new System.Drawing.Size(103, 48);
      this.bWrite.TabIndex = 174;
      this.bWrite.Text = "Write";
      this.bWrite.Click += new System.EventHandler(this.bWrite_Click);
      // 
      // label26
      // 
      this.label26.BackColor = System.Drawing.Color.Black;
      this.label26.ForeColor = System.Drawing.Color.White;
      this.label26.Location = new System.Drawing.Point(101, 247);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(88, 20);
      this.label26.Text = "Thr.PID ATT";
      // 
      // ThrPIDAtt
      // 
      this.ThrPIDAtt.BackColor = System.Drawing.Color.White;
      this.ThrPIDAtt.Location = new System.Drawing.Point(191, 249);
      this.ThrPIDAtt.Name = "ThrPIDAtt";
      this.ThrPIDAtt.Size = new System.Drawing.Size(41, 20);
      // 
      // RCRate
      // 
      this.RCRate.BackColor = System.Drawing.Color.White;
      this.RCRate.Location = new System.Drawing.Point(62, 249);
      this.RCRate.Name = "RCRate";
      this.RCRate.Size = new System.Drawing.Size(33, 20);
      // 
      // RCExpo
      // 
      this.RCExpo.BackColor = System.Drawing.Color.White;
      this.RCExpo.Location = new System.Drawing.Point(62, 229);
      this.RCExpo.Name = "RCExpo";
      this.RCExpo.Size = new System.Drawing.Size(33, 20);
      // 
      // DVelocity
      // 
      this.DVelocity.BackColor = System.Drawing.Color.White;
      this.DVelocity.Location = new System.Drawing.Point(144, 209);
      this.DVelocity.Name = "DVelocity";
      this.DVelocity.Size = new System.Drawing.Size(41, 20);
      // 
      // IVelocity
      // 
      this.IVelocity.BackColor = System.Drawing.Color.White;
      this.IVelocity.Location = new System.Drawing.Point(99, 209);
      this.IVelocity.Name = "IVelocity";
      this.IVelocity.Size = new System.Drawing.Size(41, 20);
      // 
      // PVelocity
      // 
      this.PVelocity.BackColor = System.Drawing.Color.White;
      this.PVelocity.Location = new System.Drawing.Point(62, 209);
      this.PVelocity.Name = "PVelocity";
      this.PVelocity.Size = new System.Drawing.Size(33, 20);
      // 
      // PMag
      // 
      this.PMag.BackColor = System.Drawing.Color.White;
      this.PMag.Location = new System.Drawing.Point(62, 189);
      this.PMag.Name = "PMag";
      this.PMag.Size = new System.Drawing.Size(33, 20);
      // 
      // DLevel
      // 
      this.DLevel.BackColor = System.Drawing.Color.White;
      this.DLevel.Location = new System.Drawing.Point(144, 169);
      this.DLevel.Name = "DLevel";
      this.DLevel.Size = new System.Drawing.Size(41, 20);
      // 
      // ILevel
      // 
      this.ILevel.BackColor = System.Drawing.Color.White;
      this.ILevel.Location = new System.Drawing.Point(99, 169);
      this.ILevel.Name = "ILevel";
      this.ILevel.Size = new System.Drawing.Size(41, 20);
      // 
      // PLevel
      // 
      this.PLevel.BackColor = System.Drawing.Color.White;
      this.PLevel.Location = new System.Drawing.Point(62, 169);
      this.PLevel.Name = "PLevel";
      this.PLevel.Size = new System.Drawing.Size(33, 20);
      // 
      // DAlt
      // 
      this.DAlt.BackColor = System.Drawing.Color.White;
      this.DAlt.Location = new System.Drawing.Point(144, 149);
      this.DAlt.Name = "DAlt";
      this.DAlt.Size = new System.Drawing.Size(41, 20);
      // 
      // IAlt
      // 
      this.IAlt.BackColor = System.Drawing.Color.White;
      this.IAlt.Location = new System.Drawing.Point(99, 149);
      this.IAlt.Name = "IAlt";
      this.IAlt.Size = new System.Drawing.Size(41, 20);
      // 
      // PAlt
      // 
      this.PAlt.BackColor = System.Drawing.Color.White;
      this.PAlt.Location = new System.Drawing.Point(62, 149);
      this.PAlt.Name = "PAlt";
      this.PAlt.Size = new System.Drawing.Size(33, 20);
      // 
      // label9
      // 
      this.label9.ForeColor = System.Drawing.Color.White;
      this.label9.Location = new System.Drawing.Point(99, 69);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 20);
      this.label9.Text = "I";
      this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label8
      // 
      this.label8.ForeColor = System.Drawing.Color.White;
      this.label8.Location = new System.Drawing.Point(62, 69);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(33, 20);
      this.label8.Text = "P";
      this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label7
      // 
      this.label7.BackColor = System.Drawing.Color.Black;
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new System.Drawing.Point(10, 209);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 20);
      this.label7.Text = "Vel.";
      // 
      // label6
      // 
      this.label6.BackColor = System.Drawing.Color.Black;
      this.label6.ForeColor = System.Drawing.Color.White;
      this.label6.Location = new System.Drawing.Point(10, 189);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(38, 20);
      this.label6.Text = "Mag.";
      // 
      // label5
      // 
      this.label5.BackColor = System.Drawing.Color.Black;
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new System.Drawing.Point(10, 169);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(38, 20);
      this.label5.Text = "Level";
      // 
      // label13
      // 
      this.label13.BackColor = System.Drawing.Color.Black;
      this.label13.ForeColor = System.Drawing.Color.White;
      this.label13.Location = new System.Drawing.Point(191, 69);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(41, 20);
      this.label13.Text = "Rate";
      this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label12
      // 
      this.label12.BackColor = System.Drawing.Color.Black;
      this.label12.ForeColor = System.Drawing.Color.White;
      this.label12.Location = new System.Drawing.Point(9, 249);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(65, 20);
      this.label12.Text = "RC Rate";
      // 
      // label11
      // 
      this.label11.BackColor = System.Drawing.Color.Black;
      this.label11.ForeColor = System.Drawing.Color.White;
      this.label11.Location = new System.Drawing.Point(10, 229);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(64, 20);
      this.label11.Text = "RC Exp.";
      // 
      // label10
      // 
      this.label10.ForeColor = System.Drawing.Color.White;
      this.label10.Location = new System.Drawing.Point(144, 69);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(41, 20);
      this.label10.Text = "D";
      this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.Black;
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(10, 149);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(38, 20);
      this.label4.Text = "Alt.";
      // 
      // bRead
      // 
      this.bRead.BackColor = System.Drawing.Color.White;
      this.bRead.ForeColor = System.Drawing.Color.Black;
      this.bRead.Location = new System.Drawing.Point(7, 7);
      this.bRead.Name = "bRead";
      this.bRead.Size = new System.Drawing.Size(103, 48);
      this.bRead.TabIndex = 134;
      this.bRead.Text = "Read";
      this.bRead.Click += new System.EventHandler(this.bRead_Click);
      // 
      // labelTextLastMessage
      // 
      this.labelTextLastMessage.ForeColor = System.Drawing.Color.Red;
      this.labelTextLastMessage.Location = new System.Drawing.Point(3, 280);
      this.labelTextLastMessage.Name = "labelTextLastMessage";
      this.labelTextLastMessage.Size = new System.Drawing.Size(233, 42);
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.Color.Black;
      this.tabPage1.Controls.Add(this.cb_serial_speed);
      this.tabPage1.Controls.Add(this.label15);
      this.tabPage1.Controls.Add(this.cb_serial_port);
      this.tabPage1.Controls.Add(this.label14);
      this.tabPage1.Controls.Add(this.b_connect);
      this.tabPage1.Controls.Add(this.button1);
      this.tabPage1.Location = new System.Drawing.Point(0, 0);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(240, 317);
      this.tabPage1.Text = "Main";
      // 
      // cb_serial_speed
      // 
      this.cb_serial_speed.Location = new System.Drawing.Point(163, 7);
      this.cb_serial_speed.Name = "cb_serial_speed";
      this.cb_serial_speed.Size = new System.Drawing.Size(60, 21);
      this.cb_serial_speed.TabIndex = 73;
      // 
      // label15
      // 
      this.label15.ForeColor = System.Drawing.Color.White;
      this.label15.Location = new System.Drawing.Point(125, 9);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(50, 20);
      this.label15.Text = "Baud";
      // 
      // cb_serial_port
      // 
      this.cb_serial_port.Location = new System.Drawing.Point(39, 7);
      this.cb_serial_port.Name = "cb_serial_port";
      this.cb_serial_port.Size = new System.Drawing.Size(71, 21);
      this.cb_serial_port.TabIndex = 72;
      // 
      // label14
      // 
      this.label14.ForeColor = System.Drawing.Color.White;
      this.label14.Location = new System.Drawing.Point(6, 8);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(45, 20);
      this.label14.Text = "Port";
      // 
      // b_connect
      // 
      this.b_connect.BackColor = System.Drawing.Color.White;
      this.b_connect.Location = new System.Drawing.Point(3, 34);
      this.b_connect.Name = "b_connect";
      this.b_connect.Size = new System.Drawing.Size(234, 172);
      this.b_connect.TabIndex = 71;
      this.b_connect.Text = "Connect";
      this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(3, 212);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(234, 107);
      this.button1.TabIndex = 70;
      this.button1.Text = "Konec";
      this.button1.Click += new System.EventHandler(this.end_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(240, 345);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage3
      // 
      this.tabPage3.BackColor = System.Drawing.Color.Black;
      this.tabPage3.Controls.Add(this.button2);
      this.tabPage3.Controls.Add(this.button3);
      this.tabPage3.Controls.Add(this.setRate);
      this.tabPage3.Controls.Add(this.label20);
      this.tabPage3.Controls.Add(this.button8);
      this.tabPage3.Controls.Add(this.setD);
      this.tabPage3.Controls.Add(this.minusD);
      this.tabPage3.Controls.Add(this.plusD);
      this.tabPage3.Controls.Add(this.setI);
      this.tabPage3.Controls.Add(this.minusI);
      this.tabPage3.Controls.Add(this.plusI);
      this.tabPage3.Controls.Add(this.setP);
      this.tabPage3.Controls.Add(this.minusP);
      this.tabPage3.Controls.Add(this.plusP);
      this.tabPage3.Controls.Add(this.label19);
      this.tabPage3.Controls.Add(this.label18);
      this.tabPage3.Controls.Add(this.label17);
      this.tabPage3.Controls.Add(this.label16);
      this.tabPage3.Location = new System.Drawing.Point(0, 0);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(240, 317);
      this.tabPage3.Text = "Set";
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.White;
      this.button2.ForeColor = System.Drawing.Color.Black;
      this.button2.Location = new System.Drawing.Point(185, 237);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(35, 35);
      this.button2.TabIndex = 22;
      this.button2.Text = "-";
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.Color.White;
      this.button3.ForeColor = System.Drawing.Color.Black;
      this.button3.Location = new System.Drawing.Point(185, 196);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(35, 35);
      this.button3.TabIndex = 21;
      this.button3.Text = "+";
      // 
      // setRate
      // 
      this.setRate.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
      this.setRate.Location = new System.Drawing.Point(99, 198);
      this.setRate.Name = "setRate";
      this.setRate.Size = new System.Drawing.Size(80, 35);
      this.setRate.TabIndex = 20;
      this.setRate.Text = "23";
      // 
      // label20
      // 
      this.label20.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
      this.label20.ForeColor = System.Drawing.Color.White;
      this.label20.Location = new System.Drawing.Point(7, 198);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(86, 43);
      this.label20.Text = "Rate";
      this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // button8
      // 
      this.button8.BackColor = System.Drawing.Color.White;
      this.button8.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
      this.button8.ForeColor = System.Drawing.Color.Black;
      this.button8.Location = new System.Drawing.Point(82, 249);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(72, 50);
      this.button8.TabIndex = 13;
      this.button8.Text = "Set";
      this.button8.Click += new System.EventHandler(this.button8_Click);
      // 
      // setD
      // 
      this.setD.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
      this.setD.Location = new System.Drawing.Point(43, 155);
      this.setD.Name = "setD";
      this.setD.Size = new System.Drawing.Size(80, 35);
      this.setD.TabIndex = 11;
      this.setD.Text = "23";
      // 
      // minusD
      // 
      this.minusD.BackColor = System.Drawing.Color.White;
      this.minusD.ForeColor = System.Drawing.Color.Black;
      this.minusD.Location = new System.Drawing.Point(170, 155);
      this.minusD.Name = "minusD";
      this.minusD.Size = new System.Drawing.Size(35, 35);
      this.minusD.TabIndex = 12;
      this.minusD.Text = "-";
      this.minusD.Click += new System.EventHandler(this.minusD_Click);
      // 
      // plusD
      // 
      this.plusD.BackColor = System.Drawing.Color.White;
      this.plusD.ForeColor = System.Drawing.Color.Black;
      this.plusD.Location = new System.Drawing.Point(129, 155);
      this.plusD.Name = "plusD";
      this.plusD.Size = new System.Drawing.Size(35, 35);
      this.plusD.TabIndex = 10;
      this.plusD.Text = "+";
      this.plusD.Click += new System.EventHandler(this.plusD_Click);
      // 
      // setI
      // 
      this.setI.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
      this.setI.Location = new System.Drawing.Point(43, 106);
      this.setI.Name = "setI";
      this.setI.Size = new System.Drawing.Size(80, 35);
      this.setI.TabIndex = 8;
      this.setI.Text = "0.023";
      // 
      // minusI
      // 
      this.minusI.BackColor = System.Drawing.Color.White;
      this.minusI.ForeColor = System.Drawing.Color.Black;
      this.minusI.Location = new System.Drawing.Point(170, 106);
      this.minusI.Name = "minusI";
      this.minusI.Size = new System.Drawing.Size(35, 35);
      this.minusI.TabIndex = 9;
      this.minusI.Text = "-";
      this.minusI.Click += new System.EventHandler(this.minusI_Click);
      // 
      // plusI
      // 
      this.plusI.BackColor = System.Drawing.Color.White;
      this.plusI.ForeColor = System.Drawing.Color.Black;
      this.plusI.Location = new System.Drawing.Point(129, 106);
      this.plusI.Name = "plusI";
      this.plusI.Size = new System.Drawing.Size(35, 35);
      this.plusI.TabIndex = 7;
      this.plusI.Text = "+";
      this.plusI.Click += new System.EventHandler(this.plusI_Click);
      // 
      // setP
      // 
      this.setP.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
      this.setP.Location = new System.Drawing.Point(43, 58);
      this.setP.Name = "setP";
      this.setP.Size = new System.Drawing.Size(80, 35);
      this.setP.TabIndex = 5;
      this.setP.Text = "3.3";
      // 
      // minusP
      // 
      this.minusP.BackColor = System.Drawing.Color.White;
      this.minusP.ForeColor = System.Drawing.Color.Black;
      this.minusP.Location = new System.Drawing.Point(170, 58);
      this.minusP.Name = "minusP";
      this.minusP.Size = new System.Drawing.Size(35, 35);
      this.minusP.TabIndex = 6;
      this.minusP.Text = "-";
      this.minusP.Click += new System.EventHandler(this.minusP_Click);
      // 
      // plusP
      // 
      this.plusP.BackColor = System.Drawing.Color.White;
      this.plusP.ForeColor = System.Drawing.Color.Black;
      this.plusP.Location = new System.Drawing.Point(129, 58);
      this.plusP.Name = "plusP";
      this.plusP.Size = new System.Drawing.Size(35, 35);
      this.plusP.TabIndex = 4;
      this.plusP.Text = "+";
      this.plusP.Click += new System.EventHandler(this.plusP_Click);
      // 
      // label19
      // 
      this.label19.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
      this.label19.ForeColor = System.Drawing.Color.White;
      this.label19.Location = new System.Drawing.Point(43, 8);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(159, 50);
      this.label19.Text = "Roll";
      this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label18
      // 
      this.label18.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
      this.label18.ForeColor = System.Drawing.Color.White;
      this.label18.Location = new System.Drawing.Point(11, 155);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(31, 43);
      this.label18.Text = "D";
      this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label17
      // 
      this.label17.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
      this.label17.ForeColor = System.Drawing.Color.White;
      this.label17.Location = new System.Drawing.Point(11, 106);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(31, 43);
      this.label17.Text = "I";
      this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label16
      // 
      this.label16.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
      this.label16.ForeColor = System.Drawing.Color.White;
      this.label16.Location = new System.Drawing.Point(11, 58);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(31, 35);
      this.label16.Text = "P";
      this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // MWSetup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(240, 345);
      this.Controls.Add(this.tabControl1);
      this.Menu = this.mainMenu1;
      this.Name = "MWSetup";
      this.Text = "MWSetup";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
      this.tabPage2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.IO.Ports.SerialPort serialPort1;
    private System.Windows.Forms.Button b_connect;
    private System.Windows.Forms.ComboBox cb_serial_port;
    private System.Windows.Forms.ComboBox cb_serial_speed;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label ThrPIDAtt;
    private System.Windows.Forms.Label YawRate;
    private System.Windows.Forms.Label RollPitchRate;
    private System.Windows.Forms.Label RCRate;
    private System.Windows.Forms.Label RCExpo;
    private System.Windows.Forms.Label DVelocity;
    private System.Windows.Forms.Label IVelocity;
    private System.Windows.Forms.Label PVelocity;
    private System.Windows.Forms.Label PMag;
    private System.Windows.Forms.Label DLevel;
    private System.Windows.Forms.Label ILevel;
    private System.Windows.Forms.Label PLevel;
    private System.Windows.Forms.Label DAlt;
    private System.Windows.Forms.Label IAlt;
    private System.Windows.Forms.Label PAlt;
    private System.Windows.Forms.Label DYaw;
    private System.Windows.Forms.Label IYaw;
    private System.Windows.Forms.Label PYaw;
    private System.Windows.Forms.Label DPitch;
    private System.Windows.Forms.Label IPitch;
    private System.Windows.Forms.Label PPitch;
    private System.Windows.Forms.Label DRoll;
    private System.Windows.Forms.Label IRoll;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label PRoll;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button bRead;
    private System.Windows.Forms.Label labelTextLastMessage;
    private System.Windows.Forms.Button bWrite;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Button plusP;
    private System.Windows.Forms.TextBox setD;
    private System.Windows.Forms.Button minusD;
    private System.Windows.Forms.Button plusD;
    private System.Windows.Forms.TextBox setI;
    private System.Windows.Forms.Button minusI;
    private System.Windows.Forms.Button plusI;
    private System.Windows.Forms.TextBox setP;
    private System.Windows.Forms.Button minusP;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.TextBox setRate;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Panel panel3;

  }
}

