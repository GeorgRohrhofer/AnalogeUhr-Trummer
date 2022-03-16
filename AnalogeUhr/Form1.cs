using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogeUhr
{
    public partial class Form1 : Form
    {
        private int SecondAngle = 90; //0 Grad ist bei 3 Uhr
        private int MinuteAngle = 90;
        private Thread clock_thread;

        private int client_height;
        private int client_width;

        public int second = 0;
        public int minute = 0;

        public int zwischenzeit_minute = 0;
        public int zwischenzeit_second = 0;

        public bool live_digital_view = true;

        public diagDigital diag_Dig = new diagDigital();

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.diag_Dig.ZwischenZeitEvent += toggle_zwischenzeit;
            this.diag_Dig.StartStopEvent += StartStop;
            this.reposition_dialog();

            this.client_height = ClientSize.Height + this.menuStrip1.Height;
            this.client_width = ClientSize.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int angle = 0;
            int Radius = 0;
            if (this.client_height < this.client_width)
                Radius = (this.client_height - 125) / 2;
            else if (this.client_height > this.client_width)
                Radius = (this.client_width - 125) / 2;

            e.Graphics.FillEllipse(Brushes.Black, this.client_width / 2-3, this.client_height / 2-3, 6, 6);

            while (angle < 360)
            {
                int dx = (int)Math.Round(Radius * Math.Cos(angle * (Math.PI / 180)));
                int dy = (int)Math.Round(Radius * Math.Sin(angle * (Math.PI / 180)));

                Point p = new Point((this.client_width / 2) + dx, (this.client_height / 2) - dy, angle);

                p.Paint(e.Graphics);

                angle += 30;
            }

            int Seconddx = (int)Math.Round(Radius * Math.Cos(SecondAngle * (Math.PI / 180)));
            int Seconddy = (int)Math.Round(Radius * Math.Sin(SecondAngle * (Math.PI / 180)));

            e.Graphics.DrawLine(new Pen(Brushes.Black, 2), this.client_width / 2, this.client_height / 2, (this.client_width / 2) + Seconddx, (this.client_height / 2) - Seconddy);

            int Minutedx = (int)Math.Round((Radius-10) * Math.Cos(MinuteAngle * (Math.PI / 180)));
            int Minutedy = (int)Math.Round((Radius-10) * Math.Sin(MinuteAngle * (Math.PI / 180)));

            e.Graphics.DrawLine(new Pen(Brushes.Black, 2), ClientSize.Width / 2, this.client_height / 2, (ClientSize.Width / 2) + Minutedx, (this.client_height / 2) - Minutedy);

            this.diag_Dig.set_minute(this.zwischenzeit_minute);
            this.diag_Dig.set_second(this.zwischenzeit_second);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            this.diag_Dig.toggle_start();
            if(btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                clock_thread = new Thread(new ThreadStart(run));
                clock_thread.Start();

                this.btn_zwischenzeit.Enabled = true;
            }

            else if (btnStartStop.Text == "Stop")
            {
                btnStartStop.Text = "Start";
                this.clock_thread.Abort(); //Wirft zwar eine System.Threading.ThreadAbortException, behebt aber auch den Fehler, dass die Uhr schneller läuft wenn man schnell mehrmals auf den Start-Knopf drückt
                btn_zwischenzeit.Enabled = false;
            }


        }

        public void run()
        {
            while(btnStartStop.Text == "Stop")
            {
                this.SecondAngle -= 6;
                if(this.SecondAngle == 0)
                {
                    this.SecondAngle = 360;
                }

                if(this.second == 59)
                {
                    MinuteAngle -= 6;
                    if (MinuteAngle == 0)
                    {
                        MinuteAngle = 360;
                    }
                    minute += 1;
                    this.second = -1;
                }
                this.second += 1;

                if (this.live_digital_view)
                {
                    this.zwischenzeit_minute = minute;
                    this.zwischenzeit_second = second;
                }
                Invalidate();
                Thread.Sleep(1000);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.client_height = ClientSize.Height + this.menuStrip1.Height;
            this.client_width = ClientSize.Width;
            Invalidate();
            this.reposition_dialog();
        }

        private void btn_zwischenzeit_Click(object sender, EventArgs e)
        {
            this.set_Zwischenzeit();
            this.diag_Dig.toggle_zwischenzeit();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void digitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.digitalToolStripMenuItem.Checked)
            {
                this.diag_Dig.Visible = true;
                this.reposition_dialog();
            }
            else
            {
                this.diag_Dig.Visible = false;
                this.btn_zwischenzeit.Enabled = false;
            }
        }

        private void reposition_dialog()
        {
            this.diag_Dig.Left = this.Left + this.Width;
            this.diag_Dig.Top = this.Top + this.Height / 2 - this.diag_Dig.Height / 2;
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            this.reposition_dialog();
        }

        public void set_Zwischenzeit()
        {
            if (this.live_digital_view)
                this.live_digital_view = false;
            else
                this.live_digital_view = true;
        }

        public void StartStop()
        {
            this.btnStartStop.PerformClick();
        }

        public void toggle_zwischenzeit()
        {
            this.btn_zwischenzeit.Checked = !this.btn_zwischenzeit.Checked;
            this.set_Zwischenzeit();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.btnStartStop.Text == "Stop")
                this.btnStartStop.PerformClick();
        }
    }
}
