using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESI.SymphonyAPI;
using NPlot;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
namespace TopwinLaser2016
{
    public partial class FormMainWindow : Form
    {

        private static Color defaultRadiobuttonForeColor;
        private static Color defaultNumaricUpdownForeColor;
        private static Color SyncedColor = Color.DarkGreen;
        public static Symphony Symphoney { get; set; }
        public static string ApplicationName = "TopwinLaser2016";

        /*声明调用*/
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        

        public FormMainWindow()
        {
            InitializeComponent();
        }

        public static void SetSyncedMode(GroupBox groupBox, bool synced)
        {
            foreach (Control item in groupBox.Controls)
            {
                if (item is RadioButton)
                {
                    if (synced)
                    {
                        item.ForeColor = SyncedColor;
                    }
                    else
                    {
                        item.ForeColor = defaultRadiobuttonForeColor;
                    }
                }
                else if (item is NumericUpDown)
                {
                    if (synced)
                    {
                        item.ForeColor = SyncedColor;
                    }
                    else
                    {
                        item.ForeColor = defaultNumaricUpdownForeColor;
                    }
                }
                else if (item is GroupBox)
                {
                    SetSyncedMode((GroupBox)item, synced);
                }
            }
        }


        private void FormMainWindow_Load(object sender, EventArgs e)
        {
            defaultNumaricUpdownForeColor = Color.Black;
            defaultRadiobuttonForeColor = Color.Black;
            SetControlsEnabled(false);
            InitializeTopwinLaser2016();
        }
        private void SetControlsEnabled(bool initialized)
        {
            foreach (Control tab in tabControl1.Controls)
            {
                //if (tab != tabPageGeneral)
                {
                    tab.Enabled = initialized;
                }
            }
        }
        private void InitializeTopwinLaser2016()
        {
            Symphoney = new Symphony(true);
            ReadInitialData();
            SetControlsEnabled(true);
            InitializeAllTabs();
            Assembly a = typeof(FormMainWindow).Assembly;
            AssemblyName[] arr = a.GetReferencedAssemblies();
            foreach (AssemblyName item in arr)
            {
                if (item.Name == "ESI.SymphonyAPI")
               {
                    //labelAPIVersion.Text = item.Version.ToString();
                    MessageBox.Show("ESI.SymphonyAPI initialized!");
               }
            }
            //groupBoxSettings.Enabled = true;
        }
        private void ReadInitialData()
        {
            //labelFPGAVersion.Text = Symphoney.GetFPGAVersion();
            //labelFirmwareVersion.Text = Symphoney.GetFirmwareVersion();
            //labelSerialNumber.Text = Symphoney.GetSerialNumber();
        }
        private void InitializeAllTabs()
        {
            //userControlDataRecorder.Initialize();
            userControlStage.Initialize();
            userControlGalvo.initialize();
            userControlAxis.Initialize();
            userControlIO.Initialize();
            userControlLaser.Initialize();
            //userControlTasks.Initialize();
        }
        public static void numericUpDownValueChanged(object sender, EventArgs e)
        {
            if ((sender != null) && (sender is NumericUpDown))
            {
                SetNotSyncedNumaricUpdown((NumericUpDown)sender);
            }
        }
        private static void SetNotSyncedNumaricUpdown(NumericUpDown control)
        {
            control.ForeColor = defaultNumaricUpdownForeColor;
        }

        public static void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender != null) && (sender is RadioButton))
            {
                RadioButton radSender = (RadioButton)sender;

                if (radSender.Parent is GroupBox)
                {
                    SetSyncedMode((GroupBox)radSender.Parent, false);
                }
            }
        }
        private void SaveCurrentSettings()
        {
            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(settings.GetType());
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "配置文件|*.xml|加工文件|*.topwin";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                //FileStream fs=new FileStream(sf.FileName,FileMode.Create);
                //serializer.Serialize(fs, settings);
                //fs.Flush();
                //fs.Close();
                switch(sf.FilterIndex)
                {
                    case 1:
                        SymponySettings settings = new SymponySettings();
                        settings.ReadFromSymphony(Symphoney);
                        settings.SavetoXml(sf.FileName);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ApplySettingsFromFile()
        {
            OpenFileDialog of = new OpenFileDialog();
            CWhListContainer m_pListObj =new CWhListContainer();       //实体对象链表
            of.Filter = "配置文件|*.xml|加工文件|*.dxf|加工文件|*.topwin";
            if (of.ShowDialog() == DialogResult.OK)
            {
                switch (of.FilterIndex)
                {
                    case 1:
                        SymponySettings settings = new SymponySettings();
                        try
                        {
                            settings.ReadFromXml(of.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Cannot read data from the specified file", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string errorMessage = settings.SetToSymphony(Symphoney);
                        if (string.IsNullOrEmpty(errorMessage.Trim()))
                        {
                            MessageBox.Show("Operation Sucessful", ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Following errors occuesd in setting the properties" + Environment.NewLine + errorMessage, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        InitializeAllTabs();
                        break;
                    case 2:
                        userControlGraphpaper.ParseDxf(of.FileName, m_pListObj);
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }                
            }
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            ApplySettingsFromFile();
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            SaveCurrentSettings();
        }
    }
}
