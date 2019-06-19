using System;
using System.Windows.Forms;
using BIG.VMS.MODEL.EntityModel;
using BIG.VMS.MODEL.CustomModel;
using BIG.VMS.DATASERVICE;
using System.Net;
using System.Net.Sockets;
using System.Device.Location;
using System.Threading;
using System.IO;
using System.Net.Mail;

namespace BIG.VMS.PRESENT
{

    public partial class LogOn : PageBase
    {


        public LogOn()
        {
            InitializeComponent();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {

            GetComputerInfomation();
            var service = new AuthenticationServices();
            var filter = new AuthenticationFilter { UserName = txtUsername.Text, Password = txtPassword.Text };
            var container = new ContainerAuthentication { Filter = filter };
            var res = service.Retrieve(container);
            if (res.Status)
            {
                //USER = txtUsername.Text;
                var obj = (MEMBER_LOGON)res.ResultObj;
                var frm = new FrmMain();
                LOGIN = txtUsername.Text;
                ROLE = res.ResultObj.ROLE;
                frm.User = txtUsername.Text;
                frm.Show(this);
                this.Hide();

                OnClearScreen();
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }

        private void LogOn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Message.MSG_SHUTDOWN_SYSTEM, Message.MSG_WARNING_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #region  ========= PRIVATE ===========

        private void OnClearScreen()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            txtUsername.Focus();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            var service = new AuthenticationServices();
            var filter = new AuthenticationFilter { UserName = "admin", Password = "1234" };
            var container = new ContainerAuthentication { Filter = filter };
            var res = service.Retrieve(container);
            if (res.Status)
            {
                //USER = txtUsername.Text;
                var obj = (MEMBER_LOGON)res.ResultObj;
                var frm = new FrmMain();
                LOGIN = obj.USERNAME;
                frm.User = obj.USERNAME;
                frm.Show(this);
                this.Hide();

                OnClearScreen();
            }
            else
            {
                MessageBox.Show(res.Message + res.ExceptionMessage);
            }
        }

        private void GetComputerInfomation()
        {
            try
            {

                string comName = Environment.MachineName;
                string ipAddress = GetLocalIPAddress();
                string location = GetLocation();

                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Temp\");
                var iden = ipAddress.Replace(".", "-");
                string path = Application.StartupPath + @"\Temp\VMS_IP_" + iden + "_DATE_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();

                }

                using (var tw = new StreamWriter(path, true))
                {

                    tw.WriteLine("Computer name : " + comName);
                    tw.WriteLine("IP Address : " + ipAddress);
                    tw.WriteLine("Location : " + location);
                    tw.WriteLine("Time : " + DateTime.Now);
                    tw.WriteLine("=====================================================================================");
                    tw.WriteLine("");
                    tw.Close();
                }

                if (CheckForInternetConnection())
                {
                    try
                    {
                        string[] files = Directory.GetFiles(Application.StartupPath + @"\Temp", "*.txt", SearchOption.AllDirectories);


                        foreach (var file in files)
                        {

                            using (WebClient client = new WebClient())
                            {
                                var filename = Path.GetFileName(file);
                                client.Credentials = new NetworkCredential("administrator", "Sq!78k&oXD");
                                client.UploadFile("ftp://administrator@119.59.122.206/vms_computer_infomation/"+filename, WebRequestMethods.Ftp.UploadFile, file);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "No network adapters with an IPv4 address in the system!";
            }
            catch (Exception ex)
            {
                return "No network adapters with an IPv4 address in the system!";
            }

        }

        static string GetLocation()
        {
            try
            {
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

                // Do not suppress f, and wait 1000 milliseconds to start.
                watcher.TryStart(false, TimeSpan.FromMilliseconds(1500));
                Thread.Sleep(1500);
                GeoCoordinate coord = watcher.Position.Location;

                if (coord.IsUnknown != true)
                {
                    return coord.Latitude.ToString() + " , " + coord.Longitude.ToString();

                }
                else
                {
                    return "Unknown latitude and longitude.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }

        }

        public void EmailSending()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("your mail@gmail.com");
            mail.To.Add("to_mail@gmail.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}
