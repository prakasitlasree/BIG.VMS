﻿using System;
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

namespace BIG.VMS.PRESENT.Forms.Master
{
    public partial class CameraSelection : Form
    {
        private Capture cam;
        IntPtr m_ip = IntPtr.Zero;
        WebCam webcam;
        public CameraSelection()
        {
            InitializeComponent();
        }

        private void CameraSelection_Load(object sender, EventArgs e)
        {
            const int VIDEODEVICE = 1; // zero based index of video capture device to use
            const int VIDEOWIDTH = 640; // Depends on video device caps
            const int VIDEOHEIGHT = 480; // Depends on video device caps
            const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device

            if (cam != null)
            {
                cam.Dispose();
            }
            cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, imgVideo);

        }


        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cam == null)
                {
                    const int VIDEODEVICE = 1; // zero based index of video capture device to use
                    const int VIDEOWIDTH = 640; // Depends on video device caps
                    const int VIDEOHEIGHT = 480; // Depends on video device caps
                    const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device
                    cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, imgVideo);
                }
                // Release any previous buffer
                if (m_ip != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(m_ip);
                    m_ip = IntPtr.Zero;
                }

                // capture image
                m_ip = cam.Click();
                Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

                // If the image is upsidedown
                b.RotateFlip(RotateFlipType.RotateNoneFlipY);

                imgCurrentImage.Image = b;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}