//Author: Joshua Elmer
//Author's email: joshuaelmer@fullerton.edu
//Course: CPSC223N
//Assignment number: 2
//Title: Traffic Light
//Date last updated: 10/11/2020 (mm/dd/yyyy)

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class trafficlightuserinterface : Form
{
   private Label welcome = new Label();
   private Button startbutton = new Button();
   private Button exitbutton = new Button();
   private Button pausebutton = new Button();
   private Button ratebutton = new Button();
   private Panel headerpanel = new Panel();
   private Panel controlpanel = new Panel();
   private Size maximumtrafficlightinterfacesize = new Size(1024,800);
   private Size minimumtrafficlightinterfacesize = new Size(1024,800);


   private static System.Timers.Timer my_clock = new System.Timers.Timer();
   private const int ballpenwidth = 3;
   private Pen ballpointpen = new Pen(Color.Black,ballpenwidth);


   private enum Light {Red,Green,Yellow};
   Light current = Light.Red;
   int pause_counter = 0;
   int speed = 2;


   public trafficlightuserinterface()  //Constructor
  {//Set the size of the user interface box.
   MaximumSize = maximumtrafficlightinterfacesize;
   MinimumSize = minimumtrafficlightinterfacesize;
   //Initialize text strings
   Text = "Traffic Light";
   welcome.Text = "Traffic Light by Joshua Elmer";
   startbutton.Text = "Start";
   pausebutton.Text = "Pause";
   ratebutton.Text = "Slow";
   exitbutton.Text = "Exit";

   //Set sizes
   welcome.Size = new Size(800,44);
   startbutton.Size = new Size(120,60);
   pausebutton.Size = new Size(120,60);
   ratebutton.Size = new Size(120,60);
   exitbutton.Size = new Size(120,60);
   headerpanel.Size = new Size(1024,200);
   controlpanel.Size = new Size(1024,200);

   //Set colors
   headerpanel.BackColor = Color.MediumTurquoise;
   controlpanel.BackColor = Color.Gold;
   startbutton.BackColor = Color.Red;
   pausebutton.BackColor = Color.Red;
   ratebutton.BackColor = Color.Red;
   exitbutton.BackColor = Color.Red;
   BackColor = Color.Black;
   //Set fonts
   welcome.Font = new Font("Times New Roman",26,FontStyle.Regular);
   startbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
   pausebutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
   ratebutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
   exitbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);

   //Set locations
   headerpanel.Location = new Point(0,0);
   welcome.Location = new Point(300,26);
   startbutton.Location = new Point(150,50);
   ratebutton.Location = new Point(350,50);
   pausebutton.Location = new Point(550,50);
   exitbutton.Location = new Point(750,50);
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
   controlpanel.Controls.Add(ratebutton);
   controlpanel.Controls.Add(exitbutton);

   //Register the event handler.  In this case each button has an event handler, but no other
   //controls have event handlers.
   startbutton.Click += new EventHandler(startclock);
   pausebutton.Click += new EventHandler(pauseandresume);
   ratebutton.Click += new EventHandler(changerate);
   exitbutton.Click += new EventHandler(stoprun);

 }//End of constructor Converteruserinterface



   protected override void OnPaint(PaintEventArgs ee)
     { Graphics graph = ee.Graphics;
       graph.DrawEllipse(ballpointpen,500,220,100,100);
       graph.DrawEllipse(ballpointpen,500,330,100,100);
       graph.DrawEllipse(ballpointpen,500,440,100,100);
       switch(current)
       {
         case Light.Red:
            graph.FillEllipse(Brushes.Red,500,220,100,100);
            graph.FillEllipse(Brushes.Gray,500,330,100,100);
            graph.FillEllipse(Brushes.Gray,500,440,100,100);
            break;
         case Light.Green:
            graph.FillEllipse(Brushes.Gray,500,220,100,100);
            graph.FillEllipse(Brushes.Gray,500,330,100,100);
            graph.FillEllipse(Brushes.Green,500,440,100,100);
            break;
         case Light.Yellow:
            graph.FillEllipse(Brushes.Gray,500,220,100,100);
            graph.FillEllipse(Brushes.Yellow,500,330,100,100);
            graph.FillEllipse(Brushes.Gray,500,440,100,100);
            break;
      }//End of switch.
        base.OnPaint(ee);
    }//End of OnPaint

   protected void traffic_light(Object sender,ElapsedEventArgs events)
   {
     switch(current)
     {
      case Light.Red:
                    if (speed == 1) {
                     my_clock.Interval = (int)3000;
                    } else {
                      my_clock.Interval = (int)6000;
                    }
                     current = Light.Green;
                     break;
      case Light.Green:
                    if (speed == 1) {
                        my_clock.Interval = (int)1000;
                      } else {
                        my_clock.Interval = (int)2000;
                      }
                     current = Light.Yellow;
                     break;
      case Light.Yellow:
                        if (speed == 1) {
                          my_clock.Interval = (int)4000;
                        } else {
                          my_clock.Interval = (int)8000;
                        }
                      current = Light.Red;
                     break;
     }
    Invalidate();
    }


    protected void startclock(Object sender,EventArgs events)
    {
      current = Light.Red;
      my_clock.Enabled = true;
      my_clock.Interval = (int)8000;
      my_clock.Elapsed += new ElapsedEventHandler(traffic_light);
      Invalidate();
    }


    protected void pauseandresume(Object sender,EventArgs events)
    { if (pause_counter == 0)
      {
        my_clock.Enabled = false;
        pause_counter ++;
        pausebutton.Text = "Resume";
      }
      else
      {
        my_clock.Enabled = true;
        pause_counter --;
        pausebutton.Text = "Pause";
      }
      Invalidate();
    }


    protected void changerate(Object sender,EventArgs events)
    {
      if (speed == 2)
      {
        speed --;
        ratebutton.Text = "Fast";
      }
      else
      {
        speed ++;
        ratebutton.Text = "Slow";
      }
      Invalidate();
    }



   protected void stoprun(Object sender,EventArgs events)
   {  System.Console.WriteLine("This program will end execution.");
      Close();
   }

}//End of class trafficlightuserinterface
