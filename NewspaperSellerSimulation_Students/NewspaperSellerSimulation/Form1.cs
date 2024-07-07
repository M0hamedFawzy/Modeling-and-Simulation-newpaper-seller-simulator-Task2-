using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        bool flag = false;
        private Form currentChildForm;
        private readonly Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            initialStateClockAnimation();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();

            clockAnimation();
        }

        //system layout re-defines
        // 0.timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            // get the current time
            DateTime currentTime = DateTime.Now;
            // format the time as a string
            string timeString = currentTime.ToString("h:mm:ss");
            // format the date as a string
            string dateString = currentTime.ToString("ddd, MMM d yyyy");
            // update the label control with the time and date strings
            timeLabel.Text = $"{timeString}";
        }


        // 1. drag the from from custon navBar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += Form1_KeyDown;
        }
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }



        // 2.define new buttons for exit - maximize - minimize
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // 3. create child form open functionality
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }




        // 4.buttons Functionality
        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new loadFile());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            flag = SharedData.checkIfSimulationIsPerformed;
            if (flag)
            {
                openChildForm(new simulationTable());
            }
            else
            {
                openChildForm(new wrong());
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            flag = SharedData.checkIfSimulationIsPerformed;
            if (flag)
            {
                openChildForm(new performanceMeasures());
            }
            else
            {
                openChildForm(new wrong());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            flag = SharedData.checkIfSimulationIsPerformed;
            if (flag)
            {
                openChildForm(new profitGraph());
            }
            else
            {
                openChildForm(new wrong());
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebatTransition.Start();
        }
        private void cube1_Click(object sender, EventArgs e)
        {
            cubeT1.Start();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            cubeT1.Start();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            cubeT3.Start();
        }
        private void cube3_Click(object sender, EventArgs e)
        {
            cubeT3.Start();
        }

        private void cube2_Click(object sender, EventArgs e)
        {
            cubeT2.Start();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            cubeT2.Start();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            cubeT4.Start();
        }

        private void cube4_Click(object sender, EventArgs e)
        {
            cubeT4.Start();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }




        // 5.side menu transition animation
        bool sidebar = false;
        private void sidebatTransition_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width <= 43)
                {
                    sidebar = false;
                    sidebatTransition.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width >= 200)
                {
                    sidebar = true;
                    sidebatTransition.Stop();
                }
            }
        }

        bool cube1_click = false;
        private void cubeT1_Tick(object sender, EventArgs e)
        {
            if (cube1_click)
            {
                cube1.Width -= 15;
                cube1.Height -= 15;
                if(cube1.Width <= 70 && cube1.Height <= 70)
                {
                    cube1_click = false;
                    cubeT1.Stop();
                }
            }
            else
            {
                cube1.Width += 15;
                cube1.Height += 15;
                if (cube1.Width >= 330 && cube1.Height >= 330)
                {
                    cube1_click = true;
                    cubeT1.Stop();
                }
            }
        }

        bool cube2_click = false;
        private void cubeT2_Tick(object sender, EventArgs e)
        {
            if (cube2_click)
            {
                cube2.Width -= 15;
                cube2.Height -= 15;
                if (cube2.Width <= 70 && cube2.Height <= 70)
                {
                    cube2_click = false;
                    cubeT2.Stop();
                }
            }
            else
            {
                cube2.Width += 15;
                cube2.Height += 15;
                if (cube2.Width >= 370 && cube2.Height >= 370)
                {
                    cube2_click = true;
                    cubeT2.Stop();
                }
            }
        }

        bool cube3_click = false;
        private void cubeT3_Tick(object sender, EventArgs e)
        {
            if (cube3_click)
            {
                cube3.Width -= 15;
                cube3.Height -= 15;
                if (cube3.Width <= 70 && cube3.Height <= 70)
                {
                    cube3_click = false;
                    cubeT3.Stop();
                }
            }
            else
            {
                cube3.Width += 15;
                cube3.Height += 15;
                if (cube3.Width >= 370 && cube3.Height >= 300)
                {
                    cube3_click = true;
                    cubeT3.Stop();
                }
            }
        }


        bool cube4_click = false;
        private void cubeT4_Tick(object sender, EventArgs e)
        {
            if (cube4_click)
            {
                cube4.Width -= 15;
                cube4.Height -= 15;
                if (cube4.Width <= 70 && cube4.Height <= 70)
                {
                    cube4_click = false;
                    cubeT4.Stop();
                }
            }
            else
            {
                cube4.Width += 15;
                cube4.Height += 15;
                if (cube4.Width >= 370 && cube4.Height >= 370)
                {
                    cube4_click = true;
                    cubeT4.Stop();
                }
            }
        }

        // 6. Animations

        private void initialStateClockAnimation()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private async void clockAnimation()
        {
            while (true)
            {
                await Task.Delay(1000);
                c5_activate();

                await Task.Delay(1000);
                c6_activate();

                await Task.Delay(1000);
                c7_activate();

                await Task.Delay(1000);
                c8_activate();

                await Task.Delay(1000);
                c1_activate();

                await Task.Delay(1000);
                c2_activate();

                await Task.Delay(1000);
                c3_activate();

                await Task.Delay(1000);
                c4_activate();
            }
        }
        private void c1_activate()
        {
            c1.Visible = true;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c2_activate()
        {
            c1.Visible = false;
            c2.Visible = true;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c3_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = true;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c4_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = true;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c5_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = true;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c6_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = true;
            c7.Visible = false;
            c8.Visible = false;
        }
        private void c7_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = true;
            c8.Visible = false;
        }
        private void c8_activate()
        {
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
            c6.Visible = false;
            c7.Visible = false;
            c8.Visible = true;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void childFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void c4_Click(object sender, EventArgs e)
        {

        }

        private void c5_Click(object sender, EventArgs e)
        {

        }

        private void c6_Click(object sender, EventArgs e)
        {

        }

        private void c7_Click(object sender, EventArgs e)
        {

        }

        private void c8_Click(object sender, EventArgs e)
        {

        }

        private void c1_Click(object sender, EventArgs e)
        {

        }

        private void c2_Click(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> motivations = new List<string>
{
    "You're unstoppable. Keep shining! (づ｡◕‿‿◕｡)づ",
    "Dream big, darling! Embrace each day. (づ｡◕‿‿◕｡)づ",
    "Smile often. You're amazing! (づ｡◕‿‿◕｡)づ",
    "Believe in yourself. Magic happens. (づ｡◕‿‿◕｡)づ",
    "You're a star. Keep sparkling! (づ｡◕‿‿◕｡)づ",
    "Stay positive. You're loved. (づ｡◕‿‿◕｡)づ",
    "Radiate kindness. Shine bright. (づ｡◕‿‿◕｡)づ",
    "Seize the day. You're golden! (づ｡◕‿‿◕｡)づ",
    "Be fearless. Embrace joy. (づ｡◕‿‿◕｡)づ",
    "Love yourself. You're enough. (づ｡◕‿‿◕｡)づ",
    "Chase dreams. You're unstoppable. (づ｡◕‿‿◕｡)づ",
    "Create magic. You're extraordinary. (づ｡◕‿‿◕｡)づ",
    "Spread joy. You're a delight! (づ｡◕‿‿◕｡)づ",
    "Embrace joy. You're a rainbow. (づ｡◕‿‿◕｡)づ",
    "Shine on, darling. You're radiant! (づ｡◕‿‿◕｡)づ",
    "Live boldly. You're fearless. (づ｡◕‿‿◕｡)づ",
    "Celebrate life. You're vibrant! (づ｡◕‿‿◕｡)づ",
    "Sparkle always. You're a gem. (づ｡◕‿‿◕｡)づ",
    "Be kind. You're a blessing. (づ｡◕‿‿◕｡)づ",
    "Dance through life. You're magic. (づ｡◕‿‿◕｡)づ",
    "You're unique. Shine on! (づ｡◕‿‿◕｡)づ",
    "Follow your heart. You're brave. (づ｡◕‿‿◕｡)づ",
    "Radiate love. You're sunshine. (づ｡◕‿‿◕｡)づ",
    "Dream fearlessly. You're bold. (づ｡◕‿‿◕｡)づ",
    "You're a masterpiece. Cherish yourself. (づ｡◕‿‿◕｡)づ",
    "Dream boldly. You're extraordinary. (づ｡◕‿‿◕｡)づ",
    "Spread joy. You're a delight! (づ｡◕‿‿◕｡)づ",
    "You're a treasure. Shine bright. (づ｡◕‿‿◕｡)づ",
    "Embrace possibilities. You're limitless. (づ｡◕‿‿◕｡)づ",
    "Follow your bliss. You're joy. (づ｡◕‿‿◕｡)づ",
    "You're a star. Keep sparkling! (づ｡◕‿‿◕｡)づ",
    "Believe in yourself. Magic happens. (づ｡◕‿‿◕｡)づ",
    "Stay positive. You're loved. (づ｡◕‿‿◕｡)づ",
    "Radiate kindness. Shine bright. (づ｡◕‿‿◕｡)づ",
    "Seize the day. You're golden! (づ｡◕‿‿◕｡)づ",
    "Be fearless. Embrace joy. (づ｡◕‿‿◕｡)づ",
    "Love yourself. You're enough. (づ｡◕‿‿◕｡)づ",
    "Chase dreams. You're unstoppable. (づ｡◕‿‿◕｡)づ",
    "Create magic. You're extraordinary. (づ｡◕‿‿◕｡)づ",
    "Spread joy. You're a delight! (づ｡◕‿‿◕｡)づ",
};



            
            int index = rnd.Next(1, 40);
            string message = motivations[index -1];
            MessageBox.Show(message);
        }

        private void cube1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void cube3_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
