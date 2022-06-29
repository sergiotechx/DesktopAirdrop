using Data.CPU;
using Data.Data;
using Data.Encryption;
using Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airdrop
{
    public partial class FormLogin : Form
    {
        string key = "PicaPicaPicachu!";
        TransactionContext transactionContext;
        Login localDBLogin;
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
      
            transactionContext = new TransactionContext();

            localDBLogin = transactionContext.Login.FirstOrDefault<Login>();
            if (localDBLogin == null)
            {
                labelLicense.Visible = true;
                textBoxLicense.Visible = true;
            }
            else
            {
                labelLicense.Visible = false;
                textBoxLicense.Visible = false;
            }
        }

        private async void buttonOK_Click(object sender, EventArgs e)
        {
            Login tempLogin = new Login();
            try
            {
                if (localDBLogin == null)
                {
                    localDBLogin = new Login();
                    localDBLogin.User = textBoxUser.Text;
                    localDBLogin.Password = AesOperation.EncryptString(key, textBoxPassword.Text);
                    localDBLogin.License = textBoxLicense.Text;

                    Mongo mongo = new Mongo();
                    Login mongoResult = await mongo.Find(localDBLogin);
                    if (mongoResult == null)
                    {
                        MessageBox.Show("Check user name or password or license", "Authentication failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        localDBLogin = null;
                        return;
                    }
                    if (mongoResult.ValidTo < DateTime.Now)
                    {
                        string validTo = mongoResult.ValidTo.ToString("MM/dd/yyyy hh:mm tt");
                        MessageBox.Show($"Program valid until: {validTo}", "License expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        localDBLogin = null;
                        return;
                    }
                    localDBLogin.Id = mongoResult.Id;
                    localDBLogin.User = mongoResult.User;
                    localDBLogin.Password = mongoResult.Password;
                    localDBLogin.License = mongoResult.License;
                    localDBLogin.ValidTo = mongoResult.ValidTo;

                      
                    if (localDBLogin.MachineId == null)
                    {
                        localDBLogin.MachineId = CPU.GetCPU();
                        var SQLiteAddResult = await transactionContext.Login.AddAsync(localDBLogin);
                        var SQLiteAffectedRows = await transactionContext.SaveChangesAsync();
                        var Mongoresult = await mongo.Update(localDBLogin);
                        new FormMain().Show();
                        this.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(localDBLogin.MachineId) && localDBLogin.MachineId == CPU.GetCPU())
                    {
                        var SQLiteAddResult = await transactionContext.Login.AddAsync(localDBLogin);
                        var SQLiteAffectedRows = await transactionContext.SaveChangesAsync();
                        new FormMain().Show();
                        this.Visible = false;
                    }
                    if (localDBLogin.MachineId != CPU.GetCPU())
                    {
                        MessageBox.Show("The program is already installed in other machine", "Machine restriction", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }



                else
                {
                    tempLogin.User = textBoxUser.Text;
                    tempLogin.Password = AesOperation.EncryptString(key, textBoxPassword.Text);
                    tempLogin.License = textBoxLicense.Text;
                    tempLogin.MachineId = CPU.GetCPU();
                    if (!(tempLogin.User == localDBLogin.User && tempLogin.Password == localDBLogin.Password))
                    {
                        MessageBox.Show("Check user name or password", "Authentication failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (tempLogin.MachineId != localDBLogin.MachineId)
                    {
                        MessageBox.Show("This program is not allowed to run in this machine, please call your software provider", "Execution failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (localDBLogin.ValidTo < DateTime.Now)
                    {
                        string validTo = localDBLogin.ValidTo.ToString("MM/dd/yyyy hh:mm tt");
                        MessageBox.Show($"Program valid until: {validTo}", "License expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    new FormMain().Show();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {


            }



        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
