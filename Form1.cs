using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GarenaLANGame;

namespace GSpamBot
{
    public partial class Form1 : Form
    {
        Room room;
        Random rand;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                room.sendToChat(textBox1.Text.Trim() + "   {" + rand.Next(100, 999) + "}");
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            room = new Room();
            rand = new Random();
        }
    }
}
