using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ErrorMessage
{
    public partial class ErrorMsgFrm
    {
        const string DefaultHeader = "Error";

        private string header;
        private string errorFile;
        private bool isInitialized;
        private ErrorData errorData;

        private void initializeComponent(string header, string errorFile)
        {
            this.header = header;
            this.errorFile = errorFile;

            try
            {
                this.lblHeader.Text =
                    string.IsNullOrEmpty(header) ? DefaultHeader :
                    this.header;

                this.tbErrorMessage.Text =
                    !File.Exists(this.errorFile) ? "File " + this.errorFile + " not found" :
                    File.ReadAllText(this.errorFile);

                ErrorDataHandler.Save(new ErrorData(this.lblHeader.Text, this.errorFile));

                isInitialized = true;
            }
            catch(Exception ex)
            {
                onException(ex);
            }
        }
        private void loadForm()
        {
            try
            {
                if (isInitialized) return;

                errorData = ErrorDataHandler.Load();
                
                this.lblHeader.Text =
                    string.IsNullOrEmpty(errorData.Header) ? DefaultHeader :
                    errorData.Header;

                this.tbErrorMessage.Text =
                    !File.Exists(errorData.ErrorFile) ? "File " + errorData.ErrorFile + " not found" :
                    File.ReadAllText(errorData.ErrorFile);
            }
            catch (Exception ex)
            {
                onException(ex);
            }
        }
        private void reboot()
        {
            Process p = null;
            try
            {
                p = Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 10 -f") { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden });
            }
            catch(Exception ex)
            {
                onException(ex);
            }
            finally
            {
                if (p != null) p.Close();
            }
        }

        private void onException(Exception ex)
        {
            if (string.IsNullOrEmpty(this.lblHeader.Text)) this.lblHeader.Text = DefaultHeader;

            this.tbErrorMessage.Text = ex.ToString();

            isInitialized = true;
        }

    }
}
