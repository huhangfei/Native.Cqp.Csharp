using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Native.Csharp.App.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void sendRecordBtn_Click(object sender, EventArgs e)
        {
            string path = recordPathText.Text;
            SendAllGroup(Common.CqApi.CqCode_Record(path));
        }

        private void sendTxtBtn_Click(object sender, EventArgs e)
        {
            string msg = messageText.Text;
            SendAllGroup(msg);
        }

        private int[] GetAllId()
        {
            string ids = groupIdText.Text;

            return ids.Split(',').Select(x=>int.Parse(x)).ToArray();
        }

        private void SendAllGroup(string msg)
        {
            try
            {
                int[] ids = GetAllId();
                foreach (int id in ids)
                {
                    Common.CqApi.SendGroupMessage(id, msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
