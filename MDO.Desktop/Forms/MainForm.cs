using MDO.Desktop.Models;
using MDO.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDO.Desktop.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseService _dbService;
        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            
             var apiClient = new DatabaseApiClient(baseUrl);
            _dbService = new DatabaseService(apiClient);
        }

        private async void btn_Connect_Click(object sender, EventArgs e)
        {
            panel_databaseInfo.Enabled = false;
            var dto = new DatabaseConnectionDto
            {
                ServerName = txt_ServerName.Text,
                DatabaseName = txt_DatabaseName.Text,
                UserName = txt_UserName.Text,
                Password = txt_Password.Text
            };

            var result = await _dbService.ConnectAsync(dto);

            ResultProcess(result);

        }

        private async void btn_GetVersion_Click(object sender, EventArgs e)
        {
            var result = await _dbService.GetVersionAsync();
            ResultProcess(result);
        }

        private async void btn_Disconnect_Click(object sender, EventArgs e)
        {
            var result = await _dbService.DisconnectAsync();
            ResultProcess(result);
            panel_databaseInfo.Enabled = true;
        }

        private void ResultProcess (ApiResponse<string> result)
        {
            if (result.Code == (int)HttpStatusCode.OK)
            {
                AppendLine(result.Data);
            }
            else if (result.Errors != null && result.Errors.Any())
            {
                var sb = new StringBuilder();

                AppendLine("****" + result.Message);

                foreach (var field in result.Errors)
                {
                    foreach (var error in field.Value)
                    {
                        sb.AppendLine($"{field.Key}: {error}");
                    }
                }

                AppendLine(sb.ToString());

            }
            else
            {
                AppendLine("****" + result.Message);
            }

           
        }

        void AppendLine(string text)
        {
            txt_Result.AppendText(text + Environment.NewLine);
            txt_Result.SelectionStart = txt_Result.Text.Length;
            txt_Result.ScrollToCaret();
        }
    }

    
    }
