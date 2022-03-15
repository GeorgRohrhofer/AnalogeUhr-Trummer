using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogeUhr
{

    public delegate void StartStop();
    public delegate void ZwischenZeit();
    public partial class diagDigital : Form
    {
        public event StartStop StartStopEvent;
        public event ZwischenZeit ZwischenZeitEvent;

        private Color button_color;

        public diagDigital()
        {
            InitializeComponent();
            button_color = this.btn_zwischenzeit.BackColor;
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            StartStopEvent();
        }

        private void btn_zwischenzeit_Click(object sender, EventArgs e)
        {
            ZwischenZeitEvent();
        }

        public void set_minute(int minute)
        {
            this.txt_minute.Text = minute.ToString();
        }

        public void set_second(int second)
        {
            this.txt_second.Text = second.ToString();
        }

        public void toggle_start()
        {
            if(this.btn_StartStop.Text == "Start")
            {
                this.btn_StartStop.Text = "Stop";
                this.btn_zwischenzeit.Enabled = true;
            }
            else
            {
                this.btn_StartStop.Text = "Start";
                this.btn_zwischenzeit.Enabled = false;
            }
        }

        public void toggle_zwischenzeit()
        {
            if (this.btn_zwischenzeit.BackColor != Color.LightCoral)
                this.btn_zwischenzeit.BackColor = Color.LightCoral;
            else
                this.btn_zwischenzeit.BackColor = this.button_color;
        }
    }
}
