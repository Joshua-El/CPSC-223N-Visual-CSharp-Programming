//Author: Joshua Elmer
//Mail: joshuaelmer@csu.fullerton.edu
//Course: CPSC223N
//Assignment number: 4
//Title: Ricochet
//Date last updated: 11/6/2020 (mm/dd/yyyy)


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class ricochetuserinterface: Form
{private Label welcome = new Label();
 private Label coordinates = new Label();
 private Label x_coordinate = new Label();
 private Label y_coordinate = new Label();
 private TextBox x_text = new TextBox();
 private TextBox y_text = new TextBox();
 private TextBox degrees_text = new TextBox();
 private TextBox speed_text = new TextBox();
 private Label degrees = new Label();
 private Label speed = new Label();
 private Button startbutton = new Button();
 private Button newbutton = new Button();
 private Button quitbutton = new Button();
 private Panel headerpanel = new Panel();
 private Panel controlpanel = new Panel();
 private Size maximumRicochetInterfaceSize = new Size(800,700);
 private Size minimumRicochetInterfaceSize = new Size(800,700);

 private const double animationClockSpeed = 45.7;
 private const double animationClockInterval = 1000.0/animationClockSpeed;
 int animationClockSpeedInteger = (int)System.Math.Round(animationClockInterval);
 private const double refreshClockSpeed = 24.0;
 private const double refreshClockInterval = 1000.0/refreshClockSpeed;
 int refreshClockSpeedInteger = (int)System.Math.Round(refreshClockInterval);

 private const double radius = 15;
 private double ball_speed_sec;
 private double ball_speed_tics;
 private double delta_x;
 private double delta_y;
 private double direction;
 private double radians;
 private double x;
 private double y;

 public ricochetuserinterface()  //Constructor
   {//Set the size of the user interface box.
    MaximumSize = maximumRicochetInterfaceSize;
    MinimumSize = minimumRicochetInterfaceSize;
    //Initialize text strings
    Text = "Ricochet";
    welcome.Text = "Ricochet by Joshua Elmer";
    degrees.Text = "Enter direction (degrees)";
    coordinates.Text = "Coordinates of center of ball";
    x_coordinate.Text = "X = ";
    y_coordinate.Text = "Y = ";
    speed.Text = "Enter speed (pixel/second)";
    startbutton.Text = "Start";
    newbutton.Text = "New";
    quitbutton.Text = "Quit";

    //Set sizes
    welcome.Size = new Size(800,50);
    speed.Size = new Size(230,30);
    degrees.Size = new Size(220,30);
    coordinates.Size = new Size(240,30);
    x_coordinate.Size = new Size(30,30);
    x_text.Size = new Size(50,30);
    y_coordinate.Size = new Size(30,30);
    y_text.Size = new Size(50,30);
    degrees_text.Size = new Size(80,30);
    speed_text.Size = new Size(80,30);
    startbutton.Size = new Size(80,30);
    newbutton.Size = new Size(80,30);
    quitbutton.Size = new Size(80,30);
    headerpanel.Size = new Size(800,70);
    controlpanel.Size = new Size(800,150);

    //Set colors
    headerpanel.BackColor = Color.LightGreen;
    controlpanel.BackColor = Color.Gold;
    startbutton.BackColor = Color.Red;
    newbutton.BackColor = Color.Red;
    quitbutton.BackColor = Color.Red;
    BackColor = Color.LightBlue;

    //Set fonts
    welcome.Font = new Font("Times New Roman",26,FontStyle.Bold);
    speed.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    coordinates.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    x_coordinate.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    x_text.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    y_coordinate.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    y_text.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    degrees.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    degrees_text.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    speed_text.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    startbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    newbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    quitbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    speed.TextAlign = ContentAlignment.MiddleCenter;
    degrees.TextAlign = ContentAlignment.MiddleCenter;
    x_coordinate.TextAlign = ContentAlignment.MiddleCenter;
    y_coordinate.TextAlign = ContentAlignment.MiddleCenter;

    //Set locations
    welcome.Location = new Point(200,20);
    speed.Location = new Point(140,30);
    speed_text.Location = new Point(380,30);
    degrees.Location = new Point(470,30);
    degrees_text.Location = new Point(700,30);
    coordinates.Location = new Point(140,90);
    x_coordinate.Location = new Point(420,90);
    x_text.Location = new Point(460,90);
    y_coordinate.Location = new Point(560,90);
    y_text.Location = new Point(600,90);
    startbutton.Location = new Point(20,30);
    newbutton.Location = new Point(20,90);
    quitbutton.Location = new Point(700,90);
    headerpanel.Location = new Point(0,0);
    controlpanel.Location = new Point(0,550);

    //Associate the start button with the Enter key of the keyboard
    AcceptButton = startbutton;

    //Add controls to the form
    Controls.Add(headerpanel);
    headerpanel.Controls.Add(welcome);
    Controls.Add(controlpanel);
    controlpanel.Controls.Add(startbutton);
    controlpanel.Controls.Add(newbutton);
    controlpanel.Controls.Add(quitbutton);
    controlpanel.Controls.Add(speed);
    controlpanel.Controls.Add(degrees);
    controlpanel.Controls.Add(coordinates);
    controlpanel.Controls.Add(x_coordinate);
    controlpanel.Controls.Add(x_text);
    controlpanel.Controls.Add(y_coordinate);
    controlpanel.Controls.Add(y_text);
    controlpanel.Controls.Add(degrees_text);
    controlpanel.Controls.Add(speed_text);

    startbutton.Click += new EventHandler(start);
    newbutton.Click += new EventHandler(reset);
    quitbutton.Click += new EventHandler(stoprun);

    //Prepare the clocks
    refreshClock.Enabled = false;
    refreshClock.Interval = refreshClockSpeedInteger;
    refreshClock.Elapsed += new ElapsedEventHandler(Refresh_user_interface);
    ricochetClock.Enabled = false;
    ricochetClock.Interval = animationClockSpeedInteger;
    ricochetClock.Elapsed += new ElapsedEventHandler(Update_ricochet_coordinates);

    //Initialize the ball at the starting point: subtract ball's radius so that (x,y) is the upper corner of the ball.
    x = (double)400-radius;
    y = (double)275+radius;

    //Open this user interface window in the center of the display.
    CenterToScreen();

  }//End of constructor trafficUserinterfadoublece

  private static System.Timers.Timer refreshClock = new System.Timers.Timer();
  private static System.Timers.Timer ricochetClock = new System.Timers.Timer();

 protected override void OnPaint(PaintEventArgs ee) {
   Graphics graph = ee.Graphics;

   graph.FillEllipse (Brushes.Yellow,
                           (int)System.Math.Round(x),
                           (int)System.Math.Round(y),
                           (int)System.Math.Round(2.0*radius),
                           (int)System.Math.Round(2.0*radius));

   base.OnPaint(ee);
 } // End of Onpaint

 // starts the traffic light
 protected void start(Object sender, EventArgs events) {
  System.Console.WriteLine("The animation has started.");
  ball_speed_sec = Double.Parse(speed_text.Text);
  direction = Double.Parse(degrees_text.Text);
  radians = (direction * (Math.PI)) /180;
  ball_speed_tics = ball_speed_sec / animationClockSpeed;
  delta_x = ball_speed_tics * Math.Cos(radians);
  delta_y = ball_speed_tics * Math.Sin(radians);
  refreshClock.Enabled = true;
  ricochetClock.Enabled = true;
  x_text.Text = String.Format("{000}",x);
  y_text.Text = String.Format("{000}",y);
  Invalidate();
} // End of start

 // reset the ball location
 protected void reset(Object sender, EventArgs events) {
   System.Console.WriteLine("The animation has been reset.");
   refreshClock.Enabled = false;
   ricochetClock.Enabled = false;
   x = (double)400-radius;
   y = (double)275+radius;
   Invalidate();
 }

 // updates time accumulated
 protected void Refresh_user_interface(System.Object sender, ElapsedEventArgs even)  //See Footnote #2
 {x_text.Text = String.Format("{000}",x);
  y_text.Text = String.Format("{000}",y);
  Invalidate();
 }//End of Refresh_user_interface

 protected void Update_ricochet_coordinates(System.Object sender, ElapsedEventArgs even) {
   x += delta_x;
   y -= delta_y;
   if ((int)System.Math.Round(x + radius) >= (800 - radius)){
     delta_x = -delta_x;
   }
   if ((int)System.Math.Round(x - radius) <= (0 + radius)){
     delta_x = -delta_x;
   }
   if ((int)System.Math.Round(y + radius) <= (50 + radius)){
     delta_y = -delta_y;
   }
   if ((int)System.Math.Round(y + radius) >= (550 - radius)){
     delta_y = -delta_y;
   }
 }
// end of Update_ricochet_coordinates

 // closes the program
 protected void stoprun(Object sender, EventArgs events) {
   Close();
 }//End of stoprun

}//End of class ricochetuserinterface
