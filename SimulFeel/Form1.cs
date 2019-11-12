using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buttplug.Client;
using Buttplug.Core;
using Buttplug.Core.Messages;
using Buttplug.Client.Connectors.WebsocketConnector;

namespace SimulFeel
{

    public partial class Form1 : Form
    {
        uint moveSpeed = 0;
        uint movePosition = 0;
        uint currentPosition = 0;
        uint delayTime = 0;
        double vistimer = 0;
        double vispercent = 0;
        int visprogress = 0;
        uint running = 0;
        uint running2 = 0;
        uint running3 = 0;
        uint repeat = 1;
        uint repeat2 = 1;
        uint repeat3 = 1;
        uint stopped = 1;
        uint stopped2 = 1;
        uint stopped3 = 1;
        uint movePositionReal = 0;
        int randomProfile;

        public Buttplug.Client.ButtplugClient client = new ButtplugClient("SimulFeel", new ButtplugWebsocketConnector(new Uri("ws://localhost:12345/buttplug")));
        public Buttplug.Client.ButtplugClientDevice device;

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Not ready";
        }

        async Task SendCommand()
        {

            if (!(string.IsNullOrEmpty(textMin.Text)) && !(string.IsNullOrEmpty(textMax.Text)))
            {
                if (!(((Convert.ToInt32(textMin.Text) >= 0) && (Convert.ToInt32(textMin.Text) <= 99)) &&
                    ((Convert.ToInt32(textMax.Text) >= 0) && (Convert.ToInt32(textMax.Text) <= 99))))
                {
                    textMin.Text = "49";
                    textMax.Text = "99";
                }

            movePositionReal = Convert.ToUInt32(((((Convert.ToDouble(textMax.Text) - Convert.ToDouble(textMin.Text)) / 100) * movePosition) + Convert.ToDouble(textMin.Text)));

            //Console.WriteLine($"MoveSpeed={moveSpeed}, MovePosition={movePosition}, MovePositionReal={movePositionReal}, Sending={moveSpeed},{movePosition}, Delay={delayTime}ms");
            label1.Text = $"MoveSpeed={moveSpeed}, MovePosition={movePositionReal}, Sending={moveSpeed},{movePosition}, Delay={delayTime}ms";

            vistimer = 0;
            timer2.Enabled = true;

            if (checkBox1.Checked == true)
            {
                if (client.Connected == true)
                {
                    try
                    {
                        
                        await device.SendFleshlightLaunchFW12Cmd(moveSpeed, movePositionReal);
                    }
                    catch (ButtplugDeviceException bpExc)
                    {
                        Console.WriteLine(bpExc);
                    }
                }
                else
                {
                    toolStripStatusLabel2.Text = "Failed";
                }
            }

            await Task.Delay(TimeSpan.FromMilliseconds(delayTime));
            timer2.Enabled = false;
            }
        }

        private async void ConnectToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {

            try
            {
                toolStripStatusLabel1.Text = "Trying to connect to Intiface";
                await client.ConnectAsync();
                toolStripStatusLabel1.Text = "Connected to Intiface";
                connectToolStripMenuItem.Enabled = false;
                scanToolStripMenuItem.Enabled = true;
            }
            catch (ButtplugClientConnectorException)
            {
                toolStripStatusLabel1.Text = "Can't connect to Intiface!";
                return;
            }
            catch (ButtplugHandshakeException)
            {
                toolStripStatusLabel1.Text = "Handshake issue with Intiface, version issue?";
                return;
            }
        }

        private async void ScanToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {

            void HandleDeviceAdded(object aObj, DeviceAddedEventArgs aArgs)
            {
                Console.WriteLine($"Device connected: {aArgs.Device.Name}");
            }

            client.DeviceAdded += HandleDeviceAdded;

            void HandleDeviceRemoved(object aObj, DeviceRemovedEventArgs aArgs)
            {
                Console.WriteLine($"Device removed: {aArgs.Device.Name}");
            }

            client.DeviceRemoved += HandleDeviceRemoved;

            async Task ScanForDevices()
            {
                Console.WriteLine("Scanning for devices");
                toolStripStatusLabel1.Text = "Scanning for devices";

                await client.StartScanningAsync();

                for (int a = 0; a < 10; a = a + 1)
                {
                    Console.WriteLine(a);
                    await Task.Delay(TimeSpan.FromMilliseconds(1000));
                }

                await client.StopScanningAsync();

                if (client.Devices.Any())
                {
                    toolStripStatusLabel1.Text = "Scanning complete, device(s) found";
                }
                else
                {
                    Console.WriteLine("No devices available. Please scan for a device.");
                    toolStripStatusLabel1.Text = "Scanning complete, no devices found";
                    return;
                }
            }

            if (client.Connected == true)
            {
                await ScanForDevices();

                if (!client.Devices.Any())
                {
                    return;
                }

                Form2 scanForm = new Form2();

                scanForm.listBox1.Items.Clear();

                foreach (var dev in client.Devices)
                {
                    scanForm.listBox1.Items.Add(dev.Name);
                }

                DialogResult dr = scanForm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    toolStripStatusLabel2.Text = "No device";
                    toolStripStatusLabel1.Text = "No device selected";
                    scanForm.Close();
                }
                else if (dr == DialogResult.OK)
                {
                    if (scanForm.getText() != "")
                    {
                        toolStripStatusLabel2.Text = scanForm.getText();
                        device = client.Devices[scanForm.listBox1.SelectedIndex];
                        toolStripStatusLabel1.Text = "Ready";
                    }
                    else
                    {
                        toolStripStatusLabel2.Text = "No device";
                        toolStripStatusLabel1.Text = "No device selected";
                    }
                    scanForm.Close();
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Not connected to Intiface";
                connectToolStripMenuItem.Enabled = true;
                scanToolStripMenuItem.Enabled = false;
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            if (vistimer >= delayTime)
            {
                this.progressBar1.SetProgressNoAnimation(Convert.ToInt32(movePositionReal));
                visprogress = Convert.ToInt32(currentPosition);
            }
            else
            {
                if (vistimer == 0)
                {
                    currentPosition = Convert.ToUInt32(progressBar1.Value);
                }

                vistimer = (vistimer + 40);
                vispercent = (vistimer / (double)delayTime);

                if (movePositionReal > currentPosition)
                {
                    visprogress = Convert.ToInt32(currentPosition + ((movePositionReal-currentPosition) * vispercent));
                }
                else if (movePositionReal < currentPosition)
                {
                    visprogress = Convert.ToInt32(currentPosition - ((currentPosition-movePositionReal) * vispercent));
                }

                if (visprogress > 0 && visprogress < 100)
                {
                    this.progressBar1.SetProgressNoAnimation(Convert.ToInt32(visprogress));
                }
                else
                {
                    this.progressBar1.SetProgressNoAnimation(Convert.ToInt32(movePositionReal));
                }

                //Console.WriteLine($"delayTime={delayTime},vistimer={vistimer},vispercent={vispercent},movePositionReal={movePositionReal},currentPosition={currentPosition},progressBar1={progressBar1.Value},visprogress={visprogress}");
            }

        }

        async Task Stop()
        {
            running = 0;
            toolStripStatusLabel1.Text = "Stopping current profile";

            while (stopped != 1)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1));
            }

            toolStripStatusLabel1.Text = "Ready";
        }

        async Task Stop2()
        {
            running2 = 0;
            toolStripStatusLabel1.Text = "Stopping current profile";

            while (stopped2 != 1)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1));
            }

            repeat = 1;
            toolStripStatusLabel1.Text = "Ready";
        }

        async Task Stop3()
        {
            running3 = 0;
            toolStripStatusLabel1.Text = "Stopping current profile";

            while (stopped3 != 1)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1));
            }

            repeat2 = 1;
            toolStripStatusLabel1.Text = "Ready";
        }

        async Task strokeFull()
        {
            running = 1;
            stopped = 0;

            try
            {
                while (running != 0)
                {
                    if (repeat == 0)
                    {
                        running = 0;
                    }

                    if (trackSpeed.Value == 0) { moveSpeed = 39; delayTime = 500; }
                    else if (trackSpeed.Value == 1) { moveSpeed = 49; delayTime = 400; }
                    else if (trackSpeed.Value == 2) { moveSpeed = 59; delayTime = 300; }
                    else if (trackSpeed.Value == 3) { moveSpeed = 69; delayTime = 200; }

                    movePosition = 0; await SendCommand();
                    movePosition = 99; await SendCommand();
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped = 1;
        }

        async Task strokeTop()
        {
            running = 1;
            stopped = 0;

            try
            {
                while (running != 0)
                {
                    if (repeat == 0)
                    {
                        running = 0;
                    }

                    if (trackSpeed.Value == 0) { moveSpeed = 39; delayTime = 500; }
                    else if (trackSpeed.Value == 1) { moveSpeed = 49; delayTime = 400; }
                    else if (trackSpeed.Value == 2) { moveSpeed = 59; delayTime = 300; }
                    else if (trackSpeed.Value == 3) { moveSpeed = 69; delayTime = 200; }

                    movePosition = 49; await SendCommand();
                    movePosition = 99; await SendCommand();
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped = 1;
        }

        async Task strokeBottom()
        {

        running = 1;
        stopped = 0;

            try
            {
                while (running != 0)
                {
                    if (repeat == 0)
                    {
                        running = 0;
                    }

                    if (trackSpeed.Value == 0) { moveSpeed = 39; delayTime = 500; }
                    else if (trackSpeed.Value == 1) { moveSpeed = 49; delayTime = 400; }
                    else if (trackSpeed.Value == 2) { moveSpeed = 59; delayTime = 300; }
                    else if (trackSpeed.Value == 3) { moveSpeed = 69; delayTime = 200; }

                    movePosition = 0; await SendCommand();
                    movePosition = 49; await SendCommand();
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

                stopped = 1;
        }

        async Task strokeMix1()
        {

            running2 = 1;
            stopped2 = 0;

            try
            {
                while (running2 != 0)
                {
                    if (repeat2 == 0)
                    {
                        running2 = 0;
                    }

                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped2 = 1;
        }

        async Task strokeMix2()
        {

            running2 = 1;
            stopped2 = 0;

            try
            {
                while (running2 != 0)
                {
                    if (repeat2 == 0)
                    {
                        running2 = 0;
                    }

                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeTop();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped2 = 1;
        }

        async Task strokeTease()
        {

            running2 = 1;
            stopped2 = 0;

            try
            {
                while (running2 != 0)
                {
                    if (repeat2 == 0)
                    {
                        running2 = 0;
                    }

                    await strokeBottom();
                    await strokeBottom();
                    await strokeBottom();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();                  
                    await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, 3001)));
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped2 = 1;
        }

        async Task strokeEdge1()
        {

            running2 = 1;
            stopped2 = 0;

            try
            {
                while (running2 != 0)
                {
                    if (repeat2 == 0)
                    {
                        running2 = 0;
                    }

                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, 3001)));
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped2 = 1;
        }

        async Task strokeEdge2()
        {

            running2 = 1;
            stopped2 = 0;

            try
            {
                while (running2 != 0)
                {
                    if (repeat2 == 0)
                    {
                        running2 = 0;
                    }

                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await strokeFull();
                    await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, 3001)));
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped2 = 1;
        }

        async Task strokeAuto()
        {

            running3 = 1;
            stopped3 = 0;

            try
            {
                while (running3 != 0)
                {
                    if (repeat3 == 0)
                    {
                        running3 = 0;
                    }

                    randomProfile = random.Next(1, 6);
                    //Console.WriteLine(randomProfile);

                    if (randomProfile == 1)
                    {
                        toolStripStatusLabel1.Text = "Running profile [Auto - Mix 1]";
                        timer3.Enabled = true;
                        await strokeMix1();
                    }
                    else if (randomProfile == 2)
                    {
                        toolStripStatusLabel1.Text = "Running profile [Auto - Mix 2]";
                        timer3.Enabled = true;
                        await strokeMix2();
                    }
                    else if (randomProfile == 3)
                    {
                        toolStripStatusLabel1.Text = "Running profile [Auto - Tease]";
                        timer3.Enabled = true;
                        await strokeTease();
                    }
                    else if (randomProfile == 4)
                    {
                        toolStripStatusLabel1.Text = "Running profile [Auto - Edge 1]";
                        timer3.Enabled = true;
                        await strokeEdge1();
                    }
                    else if (randomProfile == 5)
                    {
                        toolStripStatusLabel1.Text = "Running profile [Auto - Edge 2]";
                        timer3.Enabled = true;
                        await strokeEdge1();
                    }
                }
            }
            catch
            {
                toolStripStatusLabel2.Text = "Failed";
            }

            stopped3 = 1;
        }

        async Task Testing()
        {

            running = 1;
            stopped = 0;

            while (running != 0)
            {
                movePosition = Convert.ToUInt32(textStart.Text); moveSpeed = Convert.ToUInt32(textSpeed.Text); delayTime = Convert.ToUInt32(textDelay.Text); await SendCommand();
                movePosition = Convert.ToUInt32(textEnd.Text); moveSpeed = Convert.ToUInt32(textSpeed.Text); delayTime = Convert.ToUInt32(textDelay.Text); await SendCommand();
            }

            stopped = 1;
        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Full]";
            await strokeFull();

            button1.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button2_ClickAsync(object sender, EventArgs e)
        {

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

        }

        private async void Button3_ClickAsync(object sender, EventArgs e)
        {
            button3.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Top]";
            await strokeTop();

            button3.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button4_ClickAsync(object sender, EventArgs e)
        {
            button4.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Bottom]";
            await strokeBottom();

            button4.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button5_ClickAsync(object sender, EventArgs e)
        {
            button5.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Mix 1]";
            repeat = 0;

            await strokeMix1();

            button5.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button6_ClickAsync(object sender, EventArgs e)
        {
            button6.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Mix 2]";
            repeat = 0;

            await strokeMix2();

            button6.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button7_ClickAsync(object sender, EventArgs e)
        {
            button7.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Tease]";
            repeat = 0;

            await strokeTease();

            button7.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button8_ClickAsync(object sender, EventArgs e)
        {
            button8.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Edge 1]";
            repeat = 0;

            await strokeEdge1();

            button8.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button11_ClickAsync(object sender, EventArgs e)
        {
            button11.Enabled = false;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Edge 2]";
            repeat = 0;

            await strokeEdge2();

            button11.Enabled = true;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private async void Button9_ClickAsync(object sender, EventArgs e)
        {

            if (!(string.IsNullOrEmpty(textStart.Text)) && !(string.IsNullOrEmpty(textEnd.Text)) &&
                !(string.IsNullOrEmpty(textSpeed.Text)) && !(string.IsNullOrEmpty(textDelay.Text)))
                {
                if ((((Convert.ToInt32(textStart.Text) >= 0) && (Convert.ToInt32(textStart.Text) <= 99)) &&
                    ((Convert.ToInt32(textEnd.Text) >= 0) && (Convert.ToInt32(textEnd.Text) <= 99)) &&
                    ((Convert.ToInt32(textSpeed.Text) >= 0) && (Convert.ToInt32(textSpeed.Text) <= 99)) &&
                    ((Convert.ToInt32(textDelay.Text) >= 100) && (Convert.ToInt32(textDelay.Text) <= 5000))))
                {
                    button9.Enabled = false;
                    textMin.Enabled = false;
                    textMax.Enabled = false;
                    textStart.Enabled = false;
                    textEnd.Enabled = false;
                    textSpeed.Enabled = false;
                    textDelay.Enabled = false;

                    if (running == 1)
                    {
                        await Stop();
                    }

                    if (running2 == 1)
                    {
                        await Stop2();
                    }

                    if (running3 == 1)
                    {
                        await Stop3();
                    }

                    toolStripStatusLabel1.Text = "Running manual profile";
                    await Testing();

                    button9.Enabled = true;
                    textMin.Enabled = true;
                    textMax.Enabled = true;
                    textStart.Enabled = true;
                    textEnd.Enabled = true;
                    textSpeed.Enabled = true;
                    textDelay.Enabled = true;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Manual settings outside valid range";
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Manual settings cannot be blank";
            }

        }

        private async void Button10_ClickAsync(object sender, EventArgs e)
        {
            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }
        }

        private void TrackSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            trackSpeed.Value = (random.Next(0, 4));
        }

        private async void Button12_ClickAsync(object sender, EventArgs e)
        {
            button12.Enabled = false;
            checkBox2.Checked = true;
            textMin.Enabled = false;
            textMax.Enabled = false;

            if (running == 1)
            {
                await Stop();
            }

            if (running2 == 1)
            {
                await Stop2();
            }

            if (running3 == 1)
            {
                await Stop3();
            }

            toolStripStatusLabel1.Text = "Running profile [Auto]";
            repeat = 0;
            repeat2 = 0;

            await strokeAuto();

            button12.Enabled = true;
            checkBox2.Checked = false;
            trackSpeed.Value = 1;
            textMin.Enabled = true;
            textMax.Enabled = true;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer3.Interval = (random.Next(3000, 10001));

            running2 = 0;
            //Console.WriteLine(timer3.Interval);
        }
    }
}