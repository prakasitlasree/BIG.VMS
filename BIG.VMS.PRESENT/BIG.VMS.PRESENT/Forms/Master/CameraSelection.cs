using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

using AForge.Video;
using AForge.Video.DirectShow;

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class CameraSelection : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;


        public Image CAMERA { get; set; }
        public CameraSelection()
        {
            InitializeComponent();
        }

        private void CameraSelection_Load(object sender, EventArgs e)
        {
            
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count != 0)
                {
                    // add all devices to combo
                    foreach (FilterInfo device in videoDevices)
                    {
                        //devicesCombo.Items.Add(device.Name);
                    }

                     
                        videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                        EnumeratedSupportedFrameSizes(videoDevice);
                   
                    if (videoDevice != null)
                    {
                        if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                        {
                            videoDevice.VideoResolution = videoCapabilities[videoResolutionsCombo.SelectedIndex];
                        }

                        if ((snapshotCapabilities != null) && (snapshotCapabilities.Length != 0))
                        {
                            videoDevice.ProvideSnapshots = true;
                            videoDevice.SnapshotResolution = snapshotCapabilities[snapshotResolutionsCombo.SelectedIndex];
                            videoDevice.SnapshotFrame += new NewFrameEventHandler(videoDevice_SnapshotFrame);
                        }

                       
                        videoSourcePlayer.VideoSource = videoDevice;
                        videoSourcePlayer.Start();
                    }
                }
                else
                {
                    MessageBox.Show("No DirectShow devices found");
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((videoDevice != null))
                {
                    videoDevice.SimulateTrigger();
                }

            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void CameraSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        #region ==== Method =====

        private void Disconnect()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice.ProvideSnapshots)
                {
                    videoDevice.SnapshotFrame -= new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                 
            }
        }

        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Frame.Size);

            ShowSnapshot((Bitmap)eventArgs.Frame.Clone());
        }

        private void ShowSnapshot(Bitmap snapshot)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(ShowSnapshot), snapshot);
            }
            else
            {
                Bitmap old = (Bitmap)imgCurrentImage.Image;
                imgCurrentImage.Image = snapshot;
                CAMERA = imgCurrentImage.Image;
            }
        }

        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            videoResolutionsCombo.Items.Clear();
            snapshotResolutionsCombo.Items.Clear();

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;
                snapshotCapabilities = videoDevice.SnapshotCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    videoResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                foreach (VideoCapabilities capabilty in snapshotCapabilities)
                {
                    snapshotResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (videoCapabilities.Length == 0)
                {
                    videoResolutionsCombo.Items.Add("Not supported");
                }
                if (snapshotCapabilities.Length == 0)
                {
                    snapshotResolutionsCombo.Items.Add("Not supported");
                }

                videoResolutionsCombo.SelectedIndex = 0;
                snapshotResolutionsCombo.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}
