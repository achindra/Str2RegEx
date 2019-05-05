using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Str2RegEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class DistributionList
        {
            public string Line { get; set; }
            public uint Frequency { get; set; }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            MineThroughText(openFileDialog1.FileName, "");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            rtbOpenFile.Text = "";
            rtbRegEx.Text = "";
            lblCluster.Text = lblFrequency.Text = lblHash.Text = ":";
            openFileDialog1.ShowDialog();
        }

        private string ConvertRegEx(string Token)
        {
            Token.Trim();

            if (Regex.Match(Token, @"^[\d]{2}[:][\d]{2}[:][\d]{2}").Success)
                return "Time";
            //dd/mm/yyyy
            else if (Regex.Match(Token, @"^\b(0?[1-9]|[12][0-9]|3[01])[- /.](0?[1-9]|1[012])[- /.](19|20)?[0-9]{2}\b").Success)
                return "Date";
            //mm/dd/yyyy
            else if (Regex.Match(Token, @"^\b(0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])[- /.](19|20)?[0-9]{2}\b").Success)
                return "Date";
            //yyyy-mm-dd
            else if (Regex.Match(Token, @"^\b(19|20)?[0-9]{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])\b").Success)
                return "Date";
            //else if (Regex.Match(Token, @"^[\d]{4}[-][\d]{2}[-][\d]{2}$").Success)
            //    return "Date";
            //else if (Regex.Match(Token.ToLower(), @"^[^@]*([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12})").Success)
            else if (Regex.Match(Token, @"^\b[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}\b").Success)
                return "GUID";
            //else if (Regex.Match(Token, @"\b([A-Za-z0-9]+(-[A-Za-z0-9]+)*\.)+[A-Za-z]{2,}\b").Success)
            //else if (Regex.Match(Token, @"([A-Z0-9a-z_-]+[\.][A-Z0-9a-z_-]{2,6})$").Success)
            else if (Regex.Match(Token, @"^([0-9A-Fa-f])\:([0-9A-Fa-f])").Success)
                return "PID:TID";
            else if (Regex.Match(Token, @"^[0-9A-Za-z_-~]*(\.[0-9A-Za-z_-~]{2,6})$").Success)
                return "File";
            else if (Regex.Match(Token, @"([a-zA-Z]\:)(\\[^\\/:~*?<>|]*(?<![ ]))*(\.[A-Z0-9a-z_-]{2,6})$").Success)
                return "FilePath";
            else if (Regex.Match(Token, @"([a-zA-Z]\:\\)([^\\/:~*?<>|]*(?<![ ]))*").Success)
                return "Path";
            else if (Regex.Match(Token, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}\b").Success)
                return "EMail";
            else if (Regex.Match(Token, @"\b[a-f0-9A-F]{2}([-:]?)(?:[a-f0-9A-F]{2}\1){4}[a-f0-9A-F]{2}\b").Success)
                return "MAC";
            else if (Regex.Match(Token, @"\b0[xX][0-9a-fA-F]+\b").Success)
                return "Hex";
            //else if (Regex.Match(Token, @"/([1-9][0-9]*)/").Success)
            //    return "Num";
            // +/-num.num (int and float)
            else if (Regex.Match(Token, @"^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$").Success)
                return "IPv4";
            else if (Regex.Match(Token, @"^[-+]?\b[0-9]*\.?[0-9]+\b").Success)
                return "Num";
            //else if (Regex.Match(Token, @"0[xX][A-Fa-f0-9]+").Success)
            //    return "Hex";
            else if (Regex.Match(Token, @"^[A-Z]+").Success) //^[A-Z_]");
                return "CAP";
            else if (Regex.Match(Token, @"[a-zA-Z_]").Success)
                return "Text";
            else if (Regex.Match(Token, @"^[a-zA-Z0-9]").Success)
                return "AlphaNum";

            return Token;
        }

        private void MineThroughText(string FilePath, string Cluster)
        {
            StreamReader Reader = new StreamReader(FilePath);
            uint LineCounters = 0;
            List<DistributionList> DistList = new List<DistributionList>();

            if ("" == txtLinesToSample.Text.Trim())
                txtLinesToSample.Text = "100";

            while (!Reader.EndOfStream && LineCounters < Convert.ToInt32(txtLinesToSample.Text))
            {
                string pattern = "";
                string LinePattern = "";
                string strText = "";
                string[] tokens;

                // read line
                strText = Reader.ReadLine();
                LineCounters++;
                rtbOpenFile.Text = rtbOpenFile.Text + "\n" + strText;

                // string to token
                tokens = strText.Split(new Char[] { ' ', ',', '\t' });

                // Find pattern in each token
                foreach (string token in tokens)
                {
                    if (token != "")
                    {
                        string tempPattern = ConvertRegEx(token);

                        if (pattern != "Text")
                        {
                            pattern = tempPattern;
                            LinePattern = LinePattern + " " + pattern;
                        }
                        else if (tempPattern != "Text")
                        {
                            pattern = tempPattern;
                            LinePattern = LinePattern + " " + pattern;
                        }
                    }
                }

                rtbRegEx.Text = rtbRegEx.Text + "\n" + LinePattern;
                DistributionList Line = DistList.Find(
                    delegate(DistributionList DL)
                    {
                        return DL.Line == LinePattern;
                    }
                );

                if (Line != null)
                {
                    Line.Frequency++;
                }
                else
                {
                    DistributionList Item = new DistributionList();
                    Item.Line = LinePattern;
                    Item.Frequency = 1;
                    DistList.Add(Item);
                }

            }
            Reader.Close();

            rtbPattern.Text = rtbFrequency.Text = "";
            //DistList.Sort();
            foreach (DistributionList T in DistList)
            {
                rtbPattern.Text = rtbPattern.Text + "\n" + T.Line;// +"::" + T.Frequency;
                rtbFrequency.Text = rtbFrequency.Text + "\n" + T.Line +"::" + T.Frequency;
            }

            string hash; 
            string fhash;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(rtbFrequency.Text))
                ).Replace("-", String.Empty);
            }

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                fhash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(rtbPattern.Text))
                ).Replace("-", String.Empty);
            }

            //Check DB
            SqlCeConnection Conn = new SqlCeConnection(@"Data Source=C:\Users\achinbha\SkyDrive\Code-Project\Str2RegEx\Str2RegEx\Sampler.sdf");
            Conn.Open();
            SqlCeCommand Command = new SqlCeCommand("Select * from SampleDB WHERE Hash='"+hash+"'", Conn);
            SqlCeDataReader DataReader = Command.ExecuteReader();

            //If pattern exist in DB, update its frequency
            // Else insert to DB
            if(DataReader.Read())
            {
                lblCluster.Text= "Cluster: "+ DataReader.GetString(0);
                lblHash.Text = "Hash: " + DataReader.GetString(1);
                lblFrequency.Text = "Frequency: " + DataReader[2].ToString();

                SqlCeDataAdapter Adapter = new SqlCeDataAdapter(Command);
                Adapter.UpdateCommand = new SqlCeCommand("UPDATE SampleDB SET Frequency=" + (Convert.ToInt32(DataReader[2].ToString()) + 1) + "WHERE Hash = '"+hash+"'", Conn);
                Adapter.UpdateCommand.ExecuteNonQuery();
            }
            else
            {
                lblCluster.Text = "Cluster: " + Cluster;
                lblHash.Text = "Hash: " + hash;

                //
                // TODO:
                // Check with user for Cluster name if not provided
                //
                SqlCeDataAdapter Adapter = new SqlCeDataAdapter(Command);
                Adapter.UpdateCommand = new SqlCeCommand("Insert into SampleDB (Cluster, Hash, Frequency, Stack) Values ('"+Cluster+"', '"+hash+"', 0, '')", Conn);
                lblFrequency.Text = "Frequency: " + Adapter.UpdateCommand.ExecuteNonQuery();
            }
            dataGridView1.Refresh();
            DataReader.Close();
            Conn.Close();

            bool flag = false;

            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == hash)
                {
                    dataGridView1.ClearSelection();
                    flag = true;
                    int Frequency = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    Frequency = Frequency+1;
                    dataGridView1.Rows[i].Cells[2].Value = Frequency;
                    dataGridView1.Rows[i].Selected = true;
                    break;
                }
            }

            if (flag == false)
            {
                //dataGridView1.Rows.Add(hash, 0, Cluster,"");
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'samplerDataSet.SampleDB' table. You can move, or remove it, as needed.
            this.sampleDBTableAdapter.Fill(this.samplerDataSet.SampleDB);
            
        }

        private void Populate(String DirPath, String Cluster)
        {
            DirectoryInfo Di = new DirectoryInfo(DirPath);

            try
            {
                DirectoryInfo[] DirList = Di.GetDirectories();
                FileInfo[] FileList = Di.GetFiles(@"*.log");

                foreach (FileInfo Fi in FileList)
                    MineThroughText(Fi.FullName, Cluster);

                foreach (DirectoryInfo Dr in DirList)
                    Populate(Dr.FullName, Cluster);
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnTrain.Enabled = checkBox1.Checked;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            //Populate(@"\\automata\Logs\Sampling\Cluster", "Cluster");
            Populate(@"\\automata\Logs\Sampling\NetLogon", "NetLogon");
        }
    }
}
