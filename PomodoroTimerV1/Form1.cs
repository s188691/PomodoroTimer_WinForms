using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroTimerV1
{
    public partial class Form1 : Form
    {

        public float workTime, breakTime;
        public bool timerStarted = false;
        public bool workOn = true;
        public bool workOff = false;
        public TimeSpan time;
        
        public Form1()
        {
            InitializeComponent();
            workTime = 10;
            breakTime = 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimerButton(timerStarted);
            timerStarted = true;
            ButtonsVisibility(true, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimerButton(timerStarted);
            timerStarted = false;
            ButtonsVisibility(false, true);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerStarted == true && workOn == true)
            {
                workTime--;
                time = TimeSpan.FromSeconds(workTime);
                label1.Text = time.ToString("mm':'ss");
                label3.Text = "Work time";
            } else if (timerStarted == true && workOff == true)
            {
                breakTime--;
                time = TimeSpan.FromSeconds(breakTime);
                label1.Text = breakTime.ToString("mm':'ss");
                label3.Text = "Break time ^^";
            }

            if (breakTime == 0)
            {
                workOff = false;
                workOn = true;
                timer1.Stop();
                timerStarted = false;
                breakTime = 5;
                label1.Text = workTime.ToString(); // To be changed
                ButtonsVisibility(false, true); // To be changed
            }

            if (workTime == 0)
            {
                workOn = false;
                workOff = true;
                timer1.Stop();
                timerStarted = false;
                workTime = 10; //Reset time function to be replaced
                label1.Text = breakTime.ToString();
                ButtonsVisibility(false, true); // To be changed
            }
        }

        public void TimerButton(bool button)
        {
            if (button == false)
            {
                timer1.Start();
            }

            if (button == true)
            {
                timer1.Stop();
            }
        }

        public void ButtonsVisibility(bool one, bool two)
        {
            button1.Visible = one;
            button2.Visible = two;
        }
    }
}
