using BlockChain;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airdrop
{
    public partial class FormSettings : Form
    {

        TransactionContext transactionContext;
        string key = "PicaPicaPicachu!";
        public FormSettings()
        {
            InitializeComponent();
        }


        public void Set_transactionContext(ref TransactionContext _transactionContext)
        {
            transactionContext = _transactionContext;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Settings settings = transactionContext.Settings.FirstOrDefault<Settings>();
           

           

            if (settings != null)
            {
                transactionContext.Entry(settings).State = EntityState.Detached;
                textBoxAddress.Text = settings.Address;
                textBoxPrivateKey.Text = AesOperation.DecryptString(key,settings.PrivateKey);
                textBoxContract.Text = settings.Contract;
                textBoxConnections.Text = AesOperation.DecryptString(key, settings.ConnectionString);
               
               
            }
           


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool empty = false;
                Settings settingstemp = transactionContext.Settings.FirstOrDefault<Settings>();
                if (settingstemp == null)
                {
                    settingstemp = new Settings();
                    empty = true;
                }
                else
                {
                    transactionContext.Entry(settingstemp).State = EntityState.Detached;
                }

                settingstemp.Address = textBoxAddress.Text;
                settingstemp.PrivateKey = textBoxPrivateKey.Text;
                settingstemp.Contract = textBoxContract.Text;
                settingstemp.ConnectionString = textBoxConnections.Text;
                settingstemp.PrivateKey = AesOperation.EncryptString(key, textBoxPrivateKey.Text);
                settingstemp.ConnectionString = AesOperation.EncryptString(key, textBoxConnections.Text);

               
                
                if (!empty)
                {
                    transactionContext.Settings.Remove(settingstemp);
                    transactionContext.SaveChanges();
                }

                transactionContext.Settings.Add(settingstemp);
                transactionContext.SaveChanges();
                MessageBox.Show("Saved settings", "Configuration data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Address = textBoxAddress.Text;
            settings.Contract = textBoxContract.Text;
            settings.PrivateKey = textBoxPrivateKey.Text;
            settings.ConnectionString = textBoxConnections.Text;


            if (string.IsNullOrEmpty(settings.ConnectionString))
            {
                MessageBox.Show("Please fill your connnection string first", "Incomplete information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Connection test = new Connection(settings.ConnectionString, settings.PrivateKey, settings.Contract);
            string message;
            string tittle = "Testing parameters";
            decimal balance = await test.TBalance(settings.Address);

            if (balance == 0)
            {
                message = "No token balance, check your configuration";
                MessageBox.Show(message, tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (balance > 0)
            {
                message = "successful connection";
                MessageBox.Show(message, tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
    }
}
