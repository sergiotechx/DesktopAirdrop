using BlockChain;
using CsvHelper;
using Data.Data;
using Data.Encryption;
using Data.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airdrop
{
    public partial class FormMain : Form
    {
        Settings settings;
        TransactionContext transactionContext;
        List<Transaction> transactions = new List<Transaction>();
        CancellationTokenSource cancellationTokenSource = null;

        string key = "PicaPicaPicachu!";

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            settings = new Settings();
            transactionContext = new TransactionContext();
            settings = transactionContext.Settings.FirstOrDefault<Settings>();


            if (settings != null)
            {
                transactionContext.Entry(settings).State = EntityState.Detached;
                settings.PrivateKey = AesOperation.DecryptString(key, settings.PrivateKey);
                settings.ConnectionString = AesOperation.DecryptString(key, settings.ConnectionString);
            }

            transactions = transactionContext.Transactions.ToList<Transaction>();
            if (transactions.Count > 0)
            {
                loadcsvToolStripMenuItem.Enabled = false;
                transactions = transactions.OrderBy(tr => tr.Address).ToList();
                transactionBindingSource.DataSource = transactions;
            }
            else
            {
                loadcsvToolStripMenuItem.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    var reader = new StreamReader(filePath);
                    var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var records = csv.GetRecords<Load>();


                    foreach (var record in records)
                    {
                        transactions.Add(new Transaction { Address = record.Address, Qty = record.Qty });
                    }
                    transactions = transactions.OrderBy(tr => tr.Address).ToList();


                    if (transactions.Count > 0)
                    {
                        if (dataGridView.DataSource == null)
                        {

                        }
                        transactionContext.Transactions.AddRange(transactions);
                        transactionContext.SaveChanges();
                        transactionBindingSource.DataSource = transactions;
                        dataGridView.Refresh();
                        loadcsvToolStripMenuItem.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings();
            settings = transactionContext.Settings.FirstOrDefault<Settings>();
            if (settings == null)
            {
                settings = new Settings();
            }

            frmSettings.Set_transactionContext(ref transactionContext);
            frmSettings.ShowDialog(this);

        }

        private async void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;
                MakeAirdrop(token);
            }
            catch (OperationCanceledException ex)
            {
                toolStripButtonPlay.Enabled = true;
            }
        }
        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                    toolStripButtonStop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                toolStripButtonStop.Enabled = true;

            }

        }

        private async void MakeAirdrop(CancellationToken token)
        {
            if (dataGridView.RowCount == 0)
            {
                cancellationTokenSource.Dispose();
                return;
            }

            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = 100;
            toolStripButtonPlay.Enabled = false;
            toolStripProgressBar.Step = 10;
            toolStripProgressBar.Value = 0;
            menuStrip.Enabled = false;
            settings = transactionContext.Settings.FirstOrDefault<Settings>();

            if (settings == null)
            {


                MessageBox.Show("Please fill your settings first", "Incomplete information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripButtonPlay.Enabled = true;
                menuStrip.Enabled = true;
                toolStripProgressBar.Value = 0;
                cancellationTokenSource.Dispose();
                return;
            }
            transactionContext.Entry(settings).State = EntityState.Detached;
            settings.PrivateKey = AesOperation.DecryptString(key, settings.PrivateKey);
            settings.ConnectionString = AesOperation.DecryptString(key, settings.ConnectionString);


            Connection massiveSend = new Connection(settings.ConnectionString, settings.PrivateKey, settings.Contract, settings.ChainId);
            foreach (DataGridViewRow item in dataGridView.Rows)
            {

                if (toolStripProgressBar.Value == 100)
                {

                    toolStripProgressBar.Value = 0;
                }

                if (string.IsNullOrEmpty((string?)item.Cells[2].Value))
                {
                    try
                    {

                        Transaction tempTransaction = new Transaction();
                        item.Cells[2].Value = await massiveSend.SendT((string)item.Cells[0].Value, (decimal)item.Cells[1].Value);
                        transactionContext.SaveChanges();
                        toolStripProgressBar.PerformStep();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        toolStripButtonPlay.Enabled = true;
                        toolStripButtonStop.Enabled = true;
                        menuStrip.Enabled = true;
                        toolStripProgressBar.Value = 0;
                        cancellationTokenSource.Dispose();
                        return;
                    }
                    if (token.IsCancellationRequested)
                    {
                        try
                        {

                            toolStripButtonPlay.Enabled = true;
                            toolStripButtonStop.Enabled = true;
                            menuStrip.Enabled = true;
                            toolStripProgressBar.Value = 0;
                            cancellationTokenSource.Dispose();
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            }

            toolStripButtonPlay.Enabled = true;
            toolStripButtonStop.Enabled = true;
            menuStrip.Enabled = true;
            toolStripProgressBar.Value = 0;
            cancellationTokenSource.Dispose();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);


                    csv.WriteRecords(transactions);
                    csv.Flush();
                    csv.Dispose();
                    MessageBox.Show("Sucessfully exported", "Exporting process", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (transactionBindingSource.Count > 0)
            {
                var response = MessageBox.Show("Are you sure to start a new Airdrop?, the current data will be lose, please export to csv file first!", "Start new Airdrop", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == System.Windows.Forms.DialogResult.Yes)
                {
                    if (transactionContext != null)
                    {
                        try
                        {
                            transactionBindingSource.DataSource = null;
                            transactionContext.Transactions.RemoveRange(transactionContext.Transactions);
                            transactionContext.SaveChanges();
                            transactions.Clear();
                            loadcsvToolStripMenuItem.Enabled = true;
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
