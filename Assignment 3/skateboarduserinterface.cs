//Author: Joshua Elmer
//Mail: joshuaelmer@csu.fullerton.edu
//Course: CPSC223N
//Assignment number: 3
//Title: Skateboarder
//Date last updated: 10/18/2020 (mm/dd/yyyy)


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class skateboarduserinterface: Form
{private Label welcome = new Label();
 private Label time = new Label();
 private Label timeElapsed = new Label();
 private Button startbutton = new Button();
 private Button pausebutton = new Button();
 private Button exitbutton = new Button();
 private Panel headerpanel = new Panel();
 private Panel controlpanel = new Panel();
 private Size maximumSkateboardInterfaceSize = new Size(1370,700);
 private Size minimumSkateboardInterfaceSize = new Size(1370,700);

 private const double skateboardSpeed = 45.7;
 private const double animationClockSpeed = 45.7;
 private const double delta = skateboardSpeed/animationClockSpeed;
 private const double animationClockInterval = 1000.0/animationClockSpeed;
 int animationClockSpeedInteger = (int)System.Math.Round(animationClockInterval);
 private const double refreshClockSpeed = 24.0;
 private const double refreshClockInterval = 1000.0/refreshClockSpeed;
 int refreshClockSpeedInteger = (int)System.Math.Round(refreshClockInterval);

 private const double radius = 15;
 private double x;
 private double y;

 private double elapsedTime = 0.0;

 public skateboarduserinterface()  //Constructor
   {//Set the size of the user interface box.
    MaximumSize = maximumSkateboardInterfaceSize;
    MinimumSize = minimumSkateboardInterfaceSize;
    //Initialize text strings
    Text = "Skateboard";
    welcome.Text = "Skateboard by Joshua Elmer";
    time.Text = "Elapsed Time (seconds):";
    timeElapsed.Text = "000.00";
    startbutton.Text = "Start";
    pausebutton.Text = "Pause";
    exitbutton.Text = "Exit";

    //Set sizes
    welcome.Size = new Size(800,44);
    time.Size = new Size(220,44);
    timeElapsed.Size = new Size(300,44);
    startbutton.Size = new Size(100,50);
    pausebutton.Size = new Size(100,50);
    exitbutton.Size = new Size(100,50);
    headerpanel.Size = new Size(1370,70);
    controlpanel.Size = new Size(1370,100);

    //Set colors
    headerpanel.BackColor = Color.LightGreen;
    controlpanel.BackColor = Color.Gold;
    startbutton.BackColor = Color.Red;
    pausebutton.BackColor = Color.Red;
    exitbutton.BackColor = Color.Red;
    BackColor = Color.LightBlue;

    //Set fonts
    welcome.Font = new Font("Times New Roman",26,FontStyle.Bold);
    time.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    timeElapsed.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    startbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    pausebutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    exitbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);

    //Set locations
    welcome.Location = new Point(500,18);
    time.Location = new Point(780,40);
    timeElapsed.Location = new Point(650,40);
    startbutton.Location = new Point(50,30);
    pausebutton.Location = new Point(300,30);
    exitbutton.Location = new Point(1200,30);
    headerpanel.Location = new Point(0,0);
    controlpanel.Location = new Point(0,600);

    //Associate the start button with the Enter key of the keyboard
    AcceptButton = startbutton;

    //Add controls to the form
    Controls.Add(headerpanel);
    headerpanel.Controls.Add(welcome);
    Controls.Add(controlpanel);
    controlpanel.Controls.Add(startbutton);
    controlpanel.Controls.Add(pausebutton);
    controlpanel.Controls.Add(exitbutton);
    controlpanel.Controls.Add(time);
    controlpanel.Controls.Add(timeElapsed);
    startbutton.Click += new EventHandler(start);
    pausebutton.Click += new EventHandler(pause);
    exitbutton.Click += new EventHandler(stoprun);

    //Prepare the clocks
    refreshClock.Enabled = false;
    refreshClock.Interval = refreshClockSpeedInteger;
    refreshClock.Elapsed += new ElapsedEventHandler(Refresh_user_interface);
    skateboardClock.Enabled = false;
    skateboardClock.Interval = animationClockSpeedInteger;
    skateboardClock.Elapsed += new ElapsedEventHandler(Update_skateboard_coordinates);

    //Initialize the ball at the starting point: subtract ball's radius so that (x,y) is the upper corner of the ball.
    x = (double)400-radius;
    y = (double)200-radius;

    //Open this user interface window in the center of the display.
    CenterToScreen();

  }//End of constructor trafficUserinterface

  Point A = new Point(400,200);
  Point B = new Point(60,550);
  Point C = new Point(1300,550);

  private static System.Timers.Timer refreshClock = new System.Timers.Timer();
  private static System.Timers.Timer skateboardClock = new System.Timers.Timer();

  bool started = false;

 protected override void OnPaint(PaintEventArgs ee) {
   Graphics graph = ee.Graphics;

   Point[] triangle = {A,B,C}; // creates triangle
   graph.DrawPolygon(Pens.Black,triangle);
   graph.FillPolygon(Brushes.SaddleBrown,triangle);

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
  refreshClock.Enabled = true;
  skateboardClock.Enabled = true;
  if (started == false) {
    started = true;
  }
  Invalidate();
} // End of start

 // pause the traffic light
 protected void pause(Object sender, EventArgs events) {
   System.Console.WriteLine("The animation has been paused.");
   refreshClock.Enabled = false;
   skateboardClock.Enabled = false;
   Invalidate();
 }

 // updates time accumulated
 protected void Refresh_user_interface(System.Object sender, ElapsedEventArgs even)  //See Footnote #2
 {timeElapsed.Text = String.Format("{0:000.00}",elapsedTime);
  Invalidate();
 }//End of Refresh_user_interface

 protected void Update_skateboard_coordinates(System.Object sender, ElapsedEventArgs even) {
   if(System.Math.Abs(x+radius-(double)60)>delta && System.Math.Abs(y+radius-(double)700)>delta) {
     x -= delta;
     y += delta;
   } else {
     refreshClock.Enabled = false;
     skateboardClock.Enabled = false;
     startbutton.Enabled = false;
     pausebutton.Enabled = false;
     System.Console.WriteLine("The program has finished.  You may close the window.");
   }
   elapsedTime += (double)animationClockSpeedInteger/1000.0;
 }// end of Update_skateboard_coordinates

 // closes the program
 protected void stoprun(Object sender, EventArgs events) {
   Close();
 }//End of stoprun

}//End of class skateboarduserinterface
