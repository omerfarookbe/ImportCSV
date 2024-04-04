using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportCSV
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            string initialDirectory = "C:\\"; //Figure out an initial directory from somewhere

            dialogFileImport.InitialDirectory = !Directory.Exists(initialDirectory)
                                                   ? Path.GetPathRoot(Environment.SystemDirectory)
                                                   : initialDirectory;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dialogFileImport.ShowDialog();

        }

        private void dialogFileImport_FileOk(object sender, CancelEventArgs e)
        {
            btnImport.Enabled = false;
            Thread thread = new Thread(new ThreadStart(GetDataTabletFromCSVFile));
            thread.Start();
        }

        private void GetDataTabletFromCSVFile()
        {
            DataTable csvData = new DataTable();
            try
            {
                DataTable tblcsv = new DataTable();
                tblcsv.Columns.Add("column1");
                tblcsv.Columns.Add("column2");
                tblcsv.Columns.Add("column3");
                tblcsv.Columns.Add("column4");
                string CSVFilePath = Path.GetFullPath(dialogFileImport.FileName);
                string ReadCSV = File.ReadAllText(CSVFilePath);
                int i = 0;
                foreach (string csvRow in ReadCSV.Split('\n'))
                {
                    if (i == 0)
                    { i++; continue; }

                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                            count++;
                        }
                    }
                    i++;
                    lblProgress.Invoke((MethodInvoker)(() => lblProgress.Text = "Importing from CSV " + i));
                }
                InsertCSVRecords(tblcsv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnImport.Enabled = true;
                lblProgress.Text = "";
            }
        }

        private void InsertCSVRecords(DataTable csvdt)
        {
            string sqlconn = "connectionstring to sql server";
	    string table_name = "table name in sql server";

            SqlConnection con = new SqlConnection(sqlconn);
            SqlCommand cmd = new SqlCommand($"truncate table {table_name}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            using (SqlConnection destinationCon = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(destinationCon))
                {
                    sqlBulkCopy.BulkCopyTimeout = 3600;
                    sqlBulkCopy.DestinationTableName = table_name;
                    sqlBulkCopy.BatchSize = 10000;
                    sqlBulkCopy.NotifyAfter = 5000;
                    sqlBulkCopy.SqlRowsCopied += (s, e) =>
                    {
                        lblProgress.Invoke((MethodInvoker)(() => lblProgress.Text = "Uploading to SQL " + e.RowsCopied));
                    };
                    destinationCon.Open();
                    sqlBulkCopy.WriteToServer(csvdt);
                }
            }
        }

        private void frmImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
