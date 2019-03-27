using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp_client_1
{
    public partial class Form1 : Form
    {
        private static string ftp_address;
        private static string remote_home_path;
        private static string remote_current_path;
        private static string remote_save_path;
        private static string remote_save_text;
        private static bool remote_directory_show_flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ftp_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void local_url_TextChanged(object sender, EventArgs e)
        {

        }

        private void listing_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void listing_button_Click(object sender, EventArgs e)
        {
            remote_directory_show_flag = false;

            if (!listing_box_address.Text.StartsWith("ftp://"))
            {
                ftp_address = "ftp://" + listing_box_address.Text;
            }
            else
            {
                ftp_address = listing_box_address.Text;
            }

            remote_save_path = "";
            local_url.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            remote_url.Text = get_remote_home_path();

            local_directory_show(local_url.Text);
            remote_directory_show(ftp_address);
        }

        private void local_directory_show(string uri)
        {
            if (Directory.Exists(uri))
            {
                local_directory.Items.Clear();

                IEnumerable<string> local_files = Directory.EnumerateFileSystemEntries(uri, "*", SearchOption.TopDirectoryOnly);

                foreach (string s in local_files)
                {
                    string size;
                    string type;
                    string[] local_data;

                    FileInfo fi = null;
                    DirectoryInfo di = null;

                    fi = new FileInfo(s);
                    di = new DirectoryInfo(s);

                    if (fi.Exists)
                    {
                        size = fi.Length.ToString();
                        string[] local_file_sep = fi.Name.Split(new char[] { '.' });

                        if (local_file_sep.Length > 1)
                            type = local_file_sep[local_file_sep.Length - 1];
                        else
                            type = "";

                        local_data = new string[] { fi.Name, fi.LastAccessTime.ToString(), size, type };
                    }
                    else
                    {
                        size = "<DIR>";
                        type = "";
                        local_data = new string[] { di.Name, di.LastAccessTime.ToString(), size, type };
                    }

                    local_directory.Items.Add(new ListViewItem(local_data));
                }

                local_url.Text = uri;
            }
        }

        private void remote_directory_show(string uri)
        {
            NetworkCredential cred = new NetworkCredential("osmc", "osmc");

            if (remote_dir_exists(cred, uri))
            {
                remote_directory.Items.Clear();

                FtpWebResponse response = get_remote_file_list(uri);
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string r;

                while ((r = reader.ReadLine()) != null)
                {

                    string name;
                    string date;
                    string size;
                    string type;
                    string attribute;
                    string owner;

                    string[] split = r.Split(new char[] { ' ', '\t' });
                    split = split.Where(x => x != null).Where(x => x != "").ToArray();

                    Array.Reverse(split);

                    name = split[0];
                    date = split[1] + split[2] + split[3];

                    string[] file_sep = split[0].Split(new char[] { '.' });

                    if (file_sep.Length > 1)
                    {
                        type = file_sep[file_sep.Length - 1];
                    }
                    else
                    {
                        type = "";
                    }

                    attribute = split[8];

                    if (attribute.StartsWith("d"))
                    {
                        size = "<DIR>";
                    }
                    else
                    {
                        size = split[4];
                    }

                    owner = split[6];

                    string[] data = { name, date, size, type, attribute, owner };
                    remote_directory.Items.Add(new ListViewItem(data));
                }

                result_box.Text += "Directory List Complete, status " + response.StatusDescription + "\r\n";

                ftp_address = uri;

                if (remote_directory_show_flag)
                {
                    remote_url.Text = get_remote_current_path(remote_save_text);
                }

                reader.Close();
                response.Close();
            }
        }

        private bool remote_dir_exists(NetworkCredential cred, string uri)
        {
            WebRequest req = WebRequest.Create(uri);
            req.Proxy = null;
            req.Credentials = cred;
            req.Method = WebRequestMethods.Ftp.ListDirectory;

            WebResponse res = null;
            try
            {
                res = req.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    FtpWebResponse r = (FtpWebResponse)e.Response;
                    if (r.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
                throw;
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
            return true;
        }

        private FtpWebResponse get_remote_file_list(string uri)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            result_box.Text = "Connecting...\r\n";
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            request.Credentials = new NetworkCredential("osmc", "osmc");

            return request.GetResponse() as FtpWebResponse;
        }

        private string get_remote_home_path()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_address);
            request.Credentials = new NetworkCredential("osmc", "osmc");
            request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
            request.KeepAlive = false;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            remote_home_path = response.StatusDescription.Substring(5, response.StatusDescription.Length - 8);

            response.Close();

            return remote_home_path;
        }

        private string get_remote_current_path(string path)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_address);
            request.Credentials = new NetworkCredential("osmc", "osmc");
            request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
            request.KeepAlive = false;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            remote_save_path = remote_save_path + "/" + path;
            remote_current_path = remote_home_path + remote_save_path;

            response.Close();

            return remote_current_path;
        }

        private void listing_box_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void local_directory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remote_directory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remote_url_TextChanged(object sender, EventArgs e)
        {

        }

        private void local_contextmenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            Control source = menu.SourceControl;

            if (local_directory.SelectedIndices.Count > 0 && source != null)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void remote_contextmenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            Control source = menu.SourceControl;

            if (remote_directory.SelectedIndices.Count > 0 && source != null)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void download_toolstripmenu_Click(object sender, EventArgs e)
        {
            ListViewItem selected_item = remote_directory.SelectedItems[0] as ListViewItem;

            Uri u = new Uri(ftp_address + "/" + selected_item.Text);
            string down_file = local_url.Text + "\\" + selected_item.Text;

            FtpWebRequest ftp_req = (FtpWebRequest)WebRequest.Create(u);
            ftp_req.Credentials = new NetworkCredential("osmc", "osmc");
            ftp_req.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp_req.KeepAlive = false;
            ftp_req.UseBinary = false;
            ftp_req.UsePassive = false;

            FtpWebResponse ftp_res = (FtpWebResponse)ftp_req.GetResponse();
            Stream res_strm = ftp_res.GetResponseStream();
            FileStream fs = new FileStream(down_file, FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[1024];

            while (true)
            {
                int read_size = res_strm.Read(buffer, 0, buffer.Length);

                if (read_size == 0)
                    break;

                fs.Write(buffer, 0, read_size);
            }

            fs.Close();
            res_strm.Close();

            result_box.Text = ftp_res.StatusCode + ": " + ftp_res.StatusDescription;

            ftp_res.Close();

            local_directory_show(local_url.Text);
        }

        private void upload_toolstripmenu_Click(object sender, EventArgs e)
        {
            ListViewItem selected_item = local_directory.SelectedItems[0] as ListViewItem;

            string up_file = local_url.Text + "\\" + selected_item.Text;
            Uri u = new Uri(ftp_address + "/" + selected_item.Text);

            FtpWebRequest ftp_req = (FtpWebRequest)WebRequest.Create(u);
            ftp_req.Credentials = new NetworkCredential("osmc", "osmc");
            ftp_req.Method = WebRequestMethods.Ftp.UploadFile;
            ftp_req.KeepAlive = false;
            ftp_req.UseBinary = false;
            ftp_req.UsePassive = false;

            Stream req_strm = ftp_req.GetRequestStream();
            FileStream fs = new FileStream(up_file, FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[1024];

            while (true)
            {
                int read_size = fs.Read(buffer, 0, buffer.Length);
                if (read_size == 0)
                    break;
                req_strm.Write(buffer, 0, read_size);
            }

            fs.Close();
            req_strm.Close();

            FtpWebResponse ftp_res = (FtpWebResponse)ftp_req.GetResponse();
            result_box.Text = ftp_res.StatusCode + ": " + ftp_res.StatusDescription;
            ftp_res.Close();

            remote_directory_show(ftp_address);
        }

        private void local_directory_mouse_double_click(object sender, MouseEventArgs e)
        {
            ListView listview = (ListView)sender;
            ListViewItem target_item = listview.FocusedItem;

            local_directory_show(local_url.Text + "\\" + target_item.Text);
        }

        private void remote_directory_mouse_double_click(object sender, MouseEventArgs e)
        {
            remote_directory_show_flag = true;

            ListView listview = (ListView)sender;
            ListViewItem target_item = listview.FocusedItem;

            remote_save_text = target_item.Text;

            remote_directory_show(ftp_address + "/" + target_item.Text + "/");
        }
    }
}
