using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using System.Globalization;
using System.Threading;
using Styx.Pathing;
using Styx.Helpers;
using System.IO;
using System.Media;

namespace ZapRecorder2
{
    public partial class ZapMainForm : Form
    {
        public static List<string> hotspotsList, mailboxList, vendorsList, blackspotsList;
        public Thread backgroundThread, recordingThread;
        public WoWPoint oldLocation = new WoWPoint(0, 0, 0);
        public bool isRecording = false;

        public ZapMainForm()
        {
            InitializeComponent();

            hotspotsList = new List<string>();
            mailboxList = new List<string>();
            vendorsList = new List<string>();
            blackspotsList = new List<string>();

            backgroundThread = new Thread(new ThreadStart(BackgroundPulse));
            backgroundThread.IsBackground = true;
            backgroundThread.Start();


            LoadSettings();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            txtLog.TextChanged += new EventHandler(txtLog_TextChanged);
            onTop.CheckedChanged += new EventHandler(onTop_CheckedChanged);



            Log("Initializing completed");
        }

        public void onTop_CheckedChanged(object sender, EventArgs arg)
        {
            if (onTop.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        /*
         * Sound temporarily disabled
        public void PlaySound(string fileName)
        {
            new SoundPlayer(Utilities.AssemblyDirectory + "\\Plugins\\ZapGB2Recorder\\Sound\\" + fileName).Play();
        }
         * 
         * */
        //Writes to the log
        public void Log(string msg)
        {
            txtLog.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + msg + Environment.NewLine;
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
            txtLog.Refresh();
        }

        //Saves the settings
        public void SaveSettings()
        {
            //Setting sell settings

            #region SellBlue

            if (sellBlue.Checked == true)
            {
                ZapRecorder2.Properties.Settings.Default.sellBlue = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.sellBlue = false;
            }

            #endregion

            #region SellGreen
            if (sellGreen.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.sellGreen = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.sellGreen = false;
            }
            #endregion

            #region SellGrey
            if (sellGrey.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.sellGrey = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.sellGrey = false;
            }
            #endregion

            #region SellPurple
            if (sellPurple.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.sellPurple = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.sellPurple = false;
            }
            #endregion

            #region SellWhite
            if (sellWhite.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.sellWhite = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.sellWhite = false;
            }
            #endregion

            //Setting mail settings

            #region MailBlue

            if (mailBlue.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.mailBlue = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.mailBlue = false;
            }

            #endregion

            #region MailGreen

            if (mailGreen.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.mailGreen = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.mailGreen = false;
            }

            #endregion

            #region MailGrey

            if (mailGrey.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.mailGrey = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.mailGrey = false;
            }

            #endregion

            #region MailPurple

            if (mailPurple.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.mailPurple = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.mailPurple = false;
            }

            #endregion

            #region MailWhite

            if (mailWhite.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.mailWhite = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.mailWhite = false;
            }

            #endregion

            //Setting misc settings

            #region PlaySound

            if (playSound.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.playSound = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.playSound = false;
            }

            #endregion

            #region OnTop

            if (onTop.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.onTop = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.onTop = false;
            }

            #endregion

            #region MinimumDurability

            ZapRecorder2.Properties.Settings.Default.minimumDurability = minDurabilityTextbox.Text;

            #endregion

            #region MinimumFreeBagSlots

            ZapRecorder2.Properties.Settings.Default.minimumFreeBagSlots = minBagSlotTextbox.Text;

            #endregion

            #region RecordingSleepTime

            ZapRecorder2.Properties.Settings.Default.recorderSleepTime = recordingTimeTextbox.Text;

            #endregion

            #region AddIfMoved

            ZapRecorder2.Properties.Settings.Default.addIfMoved = addIfMovedTextbox.Text;

            #endregion

            #region BlackspotRadius

            ZapRecorder2.Properties.Settings.Default.blackspotRadius = Convert.ToInt32(numericUpDown1.Value);

            #endregion


            ZapRecorder2.Properties.Settings.Default.Save();
            Log("Settings saved");
        }

        //Loads the settings
        public void LoadSettings()
        {
            //Load sell settings

            #region SellBlue
            if (ZapRecorder2.Properties.Settings.Default.sellBlue == true)
            {
                sellBlue.Checked = true;
            }
            else
            {
                sellBlue.Checked = false;
            }
            #endregion

            #region SellGreen
            if (ZapRecorder2.Properties.Settings.Default.sellGreen == true)
            {
                sellGreen.Checked = true;
            }
            else
            {
                sellGreen.Checked = false;
            }
            #endregion

            #region SellGrey
            if (ZapRecorder2.Properties.Settings.Default.sellGrey == true)
            {
                sellGrey.Checked = true;
            }
            else
            {
                sellGrey.Checked = false;
            }
            #endregion

            #region SellPurple
            if (ZapRecorder2.Properties.Settings.Default.sellPurple == true)
            {
                sellPurple.Checked = true;
            }
            else
            {
                sellPurple.Checked = false;
            }
            #endregion

            #region SellWhite
            if (ZapRecorder2.Properties.Settings.Default.sellWhite == true)
            {
                sellWhite.Checked = true;
            }
            else
            {
                sellWhite.Checked = false;
            }
            #endregion

            //Load mail settings

            #region MailBlue
            if (ZapRecorder2.Properties.Settings.Default.mailBlue == true)
            {
                mailBlue.Checked = true;
            }
            else
            {
                mailBlue.Checked = false;
            }
            #endregion

            #region MailGreen
            if (ZapRecorder2.Properties.Settings.Default.mailGreen == true)
            {
                mailGreen.Checked = true;
            }
            else
            {
                mailGreen.Checked = false;
            }
            #endregion

            #region MailGrey
            if (ZapRecorder2.Properties.Settings.Default.mailGrey == true)
            {
                mailGrey.Checked = true;
            }
            else
            {
                mailGrey.Checked = false;
            }
            #endregion

            #region MailPurple
            if (ZapRecorder2.Properties.Settings.Default.mailPurple == true)
            {
                mailPurple.Checked = true;
            }
            else
            {
                mailPurple.Checked = false;
            }
            #endregion

            #region MailWhite
            if (ZapRecorder2.Properties.Settings.Default.mailWhite == true)
            {
                mailWhite.Checked = true;
            }
            else
            {
                mailWhite.Checked = false;
            }
            #endregion

            //Load misc settings

            #region PlaySound
            if (ZapRecorder2.Properties.Settings.Default.playSound == true)
            {
                playSound.Checked = true;
            }
            else
            {
                playSound.Checked = false;
            }
            #endregion

            #region OnTop
            if (ZapRecorder2.Properties.Settings.Default.onTop == true)
            {
                onTop.Checked = true;
                this.TopMost = true;
            }
            else
            {
                onTop.Checked = false;
            }
            #endregion

            #region MinimumDurability

            minDurabilityTextbox.Text = ZapRecorder2.Properties.Settings.Default.minimumDurability;

            #endregion

            #region MinimumFreeBagSlots

            minBagSlotTextbox.Text = ZapRecorder2.Properties.Settings.Default.minimumFreeBagSlots;

            #endregion

            #region RecordingSleepTime

            recordingTimeTextbox.Text = ZapRecorder2.Properties.Settings.Default.recorderSleepTime;

            #endregion

            #region AddIfMoved

            addIfMovedTextbox.Text = ZapRecorder2.Properties.Settings.Default.addIfMoved;

            #endregion

            #region BlackspotRadius

            numericUpDown1.Value = ZapRecorder2.Properties.Settings.Default.blackspotRadius;

            #endregion

            Log("Settings loaded");
        }

        //Saves the settings when a setting is changed under the setting tab
        public void SettingsChanged(object sender, EventArgs arg)
        {
            SaveSettings();
        }

        //On form closing
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hide the form when it's closing instead of closing it!
            ZapPlugin.isHidden = true;
            SaveSettings();
            e.Cancel = true;
            this.Hide();
        }

        //Thread to update the labels and shizzle in the background
        public void BackgroundPulse()
        {
            Log("Background thread started");

            while (true)
            {
                Thread.Sleep(50);

                lblBlackspots.Text = "Blackspots: " + blackspotsList.Count().ToString();
                lblVendors.Text = "Vendors: " + vendorsList.Count().ToString();
                lblHotspots.Text = "Hotspots: " + hotspotsList.Count().ToString();
                lblMailboxes.Text = "Mailboxes: " + mailboxList.Count().ToString();
                //lblLocation.Text = ObjectManager.Me.Location.X + "X, " + ObjectManager.Me.Location.Y + "Y";
            }
        }

        private void addBlackspotButton_Click(object sender, EventArgs e)
        {

        }

        private void clearBlackspotsButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Clear all blackspots?", this.Text) == true)
            {
                blackspotsList.Clear();
            }
        }

        private void clearHotspotsButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Clear all hotspots?", this.Text) == true)
            {
                hotspotsList.Clear();
            }
        }

        private void addMailboxButton_Click(object sender, EventArgs e)
        {

        }

        private void clearMailboxesButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Clear all mailboxes?", this.Text) == true)
            {
                mailboxList.Clear();
            }
        }

        private void addVendorsButton_Click(object sender, EventArgs e)
        {

        }

        private void btnClearHotspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to clear all hotspots?", this.Text) == true)
            {
                hotspotsList.Clear();
                UpdateHotspotList();
            }
        }

        public void RecordingPulse()
        {
            while (isRecording)
            {
                if (notTheSame())
                {
                    /*if (playSound.Checked == true)
                    {
                        PlaySound("bloop.wav");
                    }
                    */
                    Log("Adding: " + getHotspot());
                    hotspotsList.Add(getHotspot());

                    oldLocation = new WoWPoint(ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z);
                    //
                    //Change recording sleep time!
                    Thread.Sleep(Convert.ToInt32(recordingTimeTextbox.Text));

                    UpdateHotspotList();
                }
                else
                {
                    string temp = distanceToMove().ToString().Split(',')[0] + " yards";
                    Thread.Sleep(100);
                }
            }
        }

        public double distanceToMove()
        {
            return Convert.ToInt32(addIfMovedTextbox.Text) - ObjectManager.Me.WorldLocation.Distance(oldLocation);
        }

        public bool notTheSame()
        {
            return (ObjectManager.Me.Location.Distance(oldLocation) > Convert.ToInt32(addIfMovedTextbox.Text));
        }

        public bool MessageBoxHelp(string text, string title)
        {
            DialogResult dialog = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getHotspot()
        {
            return string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Hotspot X=\"{0}\" Y=\"{1}\" Z=\"{2}\" />", ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z);
        }

        private void btnRecording_Click(object sender, EventArgs e)
        {

            if (isRecording)
            {
                // Stop the recording
                isRecording = false;
                btnRecording.Text = "Start Recording";
                btnRecording.ForeColor = Color.Black;
            }
            else
            {
                try
                {
                    //We're not recording, so lets start!
                    isRecording = true;
                    recordingThread = new Thread(new ThreadStart(RecordingPulse));
                    recordingThread.IsBackground = true;
                    recordingThread.Start();

                    btnRecording.Text = "Stop Recording";
                    btnRecording.ForeColor = Color.Red;
                    //recordLabel.Text = "Recording: Yes";
                }
                catch
                {

                }
            }
        }

        public void SaveProfile()
        {
            if(hotspotsList.Count() >= 1)
            {

                dlgSaveFile.InitialDirectory = Utilities.AssemblyDirectory;

                if (dlgSaveFile.ShowDialog() == DialogResult.OK)
                {
                    Log("Received a save to location of: " + dlgSaveFile.FileName);

                    string path = dlgSaveFile.FileName;

                    StreamWriter writer = new StreamWriter(path);
                    Log("Writing profile: " + path);

                    //BEGINNING OF THE PROFILE WRITING
                    writer.WriteLine("<HBProfile>");
                    writer.WriteLine("<Name>" + ObjectManager.Me.ZoneText + "</Name>");
                    writer.WriteLine("<MinDurability>" + minDurabilityTextbox.Text + "</MinDurability>");
                    writer.WriteLine("<MinFreeBagSlots>" + minBagSlotTextbox.Text + "</MinFreeBagSlots>");
                    writer.WriteLine("");

                    writer.WriteLine("<MinLevel>1</MinLevel>");
                    writer.WriteLine("<MaxLevel>86</MaxLevel>");
                    writer.WriteLine("<Factions>99999</Factions>");
                    writer.WriteLine("");


                    #region Mail
                    if (mailGrey.Checked == true)
                    {
                        writer.WriteLine("<MailGrey>true</MailGrey>");
                    }
                    else
                    {
                        writer.WriteLine("<MailGrey>false</MailGrey>");
                    }

                    if (mailWhite.Checked == true)
                    {
                        writer.WriteLine("<MailWhite>true</MailWhite>");
                    }
                    else
                    {
                        writer.WriteLine("<MailWhite>false</MailWhite>");
                    }

                    if (mailGreen.Checked == true)
                    {
                        writer.WriteLine("<MailGreen>true</MailGreen>");
                    }
                    else
                    {
                        writer.WriteLine("<MailGreen>false</MailGreen>");
                    }

                    if (mailBlue.Checked == true)
                    {
                        writer.WriteLine("<MailBlue>true</MailBlue>");
                    }
                    else
                    {
                        writer.WriteLine("<MailBlue>false</MailBlue>");
                    }

                    if (mailPurple.Checked == true)
                    {
                        writer.WriteLine("<MailPurple>true</MailPurple>");
                    }
                    else
                    {
                        writer.WriteLine("<MailPurple>false</MailPurple>");
                    }
                    #endregion

                    writer.WriteLine("");

                    #region SellOptions

                    if (sellGrey.Checked == true)
                    {
                        writer.WriteLine("<SellGrey>true</SellGrey>");
                    }
                    else
                    {
                        writer.WriteLine("<SellGrey>false</SellGrey>");
                    }

                    if (sellWhite.Checked == true)
                    {
                        writer.WriteLine("<SellWhite>true</SellWhite>");
                    }
                    else
                    {
                        writer.WriteLine("<SellWhite>false</SellWhite>");
                    }

                    if (sellGreen.Checked == true)
                    {
                        writer.WriteLine("<SellGreen>true</SellGreen>");
                    }
                    else
                    {
                        writer.WriteLine("<SellGreen>false</SellGreen>");
                    }

                    if (sellBlue.Checked == true)
                    {
                        writer.WriteLine("<SellBlue>true</SellBlue>");
                    }
                    else
                    {
                        writer.WriteLine("<SellBlue>false</SellBlue>");
                    }

                    if (sellPurple.Checked == true)
                    {
                        writer.WriteLine("<SellPurple>true</SellPurple>");
                    }
                    else
                    {
                        writer.WriteLine("<SellPurple>false</SellPurple>");
                    }

                    #endregion

                    writer.WriteLine("");

                    #region Misc

                    writer.WriteLine("<Vendors>");

                    foreach (string vend in vendorsList)
                        writer.WriteLine(vend);

                    writer.WriteLine("</Vendors>");
                    writer.WriteLine("");

                    writer.WriteLine("<Mailboxes>");

                    foreach (string mail in mailboxList)
                        writer.WriteLine(mail);

                    writer.WriteLine("</Mailboxes>");
                    writer.WriteLine("");


                    writer.WriteLine("<Blackspots>");

                    foreach (string black in blackspotsList)
                        writer.WriteLine(black);

                    writer.WriteLine("</Blackspots>");
                    writer.WriteLine("");

                    writer.WriteLine("<Hotspots>");

                    //HOTSPOTS
                    foreach (string loc in hotspotsList)
                        writer.WriteLine(loc);


                    #endregion

                    writer.WriteLine("</Hotspots>");
                    writer.WriteLine("</HBProfile>");
                    writer.Close();


                    Log("Profile writing completed!");
                }
                else
                {
                    // User cancelled Save Dialog
                }


            }
            else
            {
                MessageBox.Show("You dont have any hotspots to save!");
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnAddBlackspot_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you standing in the middle of the blackspot and have choosen the prefered radius?\nCurrent radius = " + numericUpDown1.Value.ToString(), this.Text) == true)
            {
                string tempBlackspot = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Blackspot X=\"{0}\" Y=\"{1}\" Z=\"{2}\" Radius=\"{3}\" />", ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z, numericUpDown1.Value.ToString());
                Log("Added: " + tempBlackspot);
                blackspotsList.Add(tempBlackspot);
                UpdateBlackspotList();
            }
        }

        private void btnAddMailbox_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you standing next to a mailbox?", this.Text) == true)
            {
                string tempMailbox = "<Mailbox" + getHotspot().Replace("<Hotspot", "");
                Log("Adding: " + tempMailbox);
                mailboxList.Add(tempMailbox);
                UpdateMailboxList();
            }
        }

        private void btnAddRepair_Click(object sender, EventArgs e)
        {
            //IsRepairMerchant
            if (ObjectManager.Me.GotTarget == true)
            {
                if (ObjectManager.Me.CurrentTarget.IsRepairMerchant == true)
                {
                    string tempVendor = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Vendor Name=\"{0}\" Entry=\"{1}\" Type=\"{2}\" X=\"{3}\" Y=\"{4}\" Z=\"{5}\" />",
                        ObjectManager.Me.CurrentTarget.Name, ObjectManager.Me.CurrentTarget.Entry.ToString(), "Repair", ObjectManager.Me.CurrentTarget.X.ToString(), ObjectManager.Me.CurrentTarget.Y.ToString(),
                        ObjectManager.Me.CurrentTarget.Z.ToString());

                    if (MessageBoxHelp("Do you want to add this repair NPC?\n\n" + tempVendor, this.Text) == true)
                    {
                        Log("Adding: " + tempVendor);
                        vendorsList.Add(tempVendor);
                        UpdateRepairList();
                    }
                }
                else
                {
                    Log(ObjectManager.Me.CurrentTarget.Name + " is not a repair NPC");
                    MessageBox.Show(ObjectManager.Me.CurrentTarget.Name + " is not a repair NPC");
                }
            }
            else if (ObjectManager.Me.GotTarget != true)
            {
                MessageBox.Show("You do not have a target");
            }
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void btnClearEverything_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to clear everything from this profile?", this.Text) == true)
            {
                hotspotsList.Clear();
                blackspotsList.Clear();
                mailboxList.Clear();
                vendorsList.Clear();

                Log("Cleared everything from the current profile");
            }
        }

        private void btnClearAllMailboxes_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Clear all mailboxes?", this.Text) == true)
            {
                mailboxList.Clear();
                UpdateMailboxList();
            }
        }

        private void btnClearBlackspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to clear all blackspots?", this.Text) == true)
            {
                blackspotsList.Clear();
            }

            UpdateBlackspotList();
        }

        private void btnClearAllRepair_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Clear all vendors?", this.Text) == true)
            {
                vendorsList.Clear();
            }

            UpdateRepairList();
        }

        public void UpdateHotspotList()
        {
            listHotspots.Items.Clear();

            foreach (string q in hotspotsList)
            {
                listHotspots.Items.Add(q);
            }
        }

        public void UpdateBlackspotList()
        {
            listBlackspots.Items.Clear();

            foreach (string q in blackspotsList)
            {
                listBlackspots.Items.Add(q);
            }
        }

        public void UpdateRepairList()
        {
            listRepair.Items.Clear();

            foreach (string q in vendorsList)
            {
                listRepair.Items.Add(q);
            }
        }

        public void UpdateMailboxList()
        {
            listMailboxes.Items.Clear();

            foreach (string q in mailboxList)
            {
                listMailboxes.Items.Add(q);
            }
        }

        private void btnClearSelectedHotspots_Click(object sender, EventArgs e)
        {
            if (listHotspots.SelectedItems.Count > 0)
            {
                if (MessageBoxHelp("Remove selected hotspot?\n\n" + listHotspots.SelectedItem.ToString(), this.Text) == true)
                {
                    ZapMainForm.hotspotsList.Remove(listHotspots.SelectedItem.ToString());
                    UpdateHotspotList();
                }
            }
        }

        private void btnClearSelectedBlackspot_Click(object sender, EventArgs e)
        {
            if (listBlackspots.SelectedItems.Count > 0)
            {
                if (MessageBoxHelp("Are you sure you wish to remove the selected blackspot?\n\n" + listBlackspots.SelectedItem.ToString(), this.Text) == true)
                {
                    blackspotsList.Remove(listBlackspots.SelectedItem.ToString());
                    UpdateBlackspotList();
                }
            }
        }

        private void btnClearSelectedRepair_Click(object sender, EventArgs e)
        {
            if (listRepair.SelectedItems.Count > 0)
            {
                if (MessageBoxHelp("Remove selected vendor?\n\n" + listRepair.SelectedItem.ToString(), this.Text) == true)
                {
                    vendorsList.Remove(listRepair.SelectedItem.ToString());
                    UpdateRepairList();
                }
            }
        }

        private void btnClearSelectedMailboxes_Click(object sender, EventArgs e)
        {
            if (listMailboxes.SelectedItems.Count > 0)
            {
                if (MessageBoxHelp("Remove selected mailbox?\n\n" + listMailboxes.SelectedItem.ToString(), this.Text) == true)
                {
                    mailboxList.Remove(listMailboxes.SelectedItem.ToString());
                    UpdateMailboxList();
                }
            }
        }

        private void btnAddBlackspot2_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you standing in the middle of the blackspot and have choosen the prefered radius?\nCurrent radius = " + numericUpDown1.Value.ToString(), this.Text) == true)
            {
                string tempBlackspot = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Blackspot X=\"{0}\" Y=\"{1}\" Z=\"{2}\" Radius=\"{3}\" />", ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z, numericUpDown1.Value.ToString());
                Log("Added: " + tempBlackspot);
                blackspotsList.Add(tempBlackspot);
                UpdateBlackspotList();
            }
        }

        private void btnAddMailbox2_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you standing next to a mailbox?", this.Text) == true)
            {
                string tempMailbox = "<Mailbox" + getHotspot().Replace("<Hotspot", "");
                Log("Adding: " + tempMailbox);
                mailboxList.Add(tempMailbox);
                UpdateMailboxList();
            }
        }

        // Merge this with other add repair
        private void btnAddRepair2_Click(object sender, EventArgs e)
        {
            //IsRepairMerchant
            if (ObjectManager.Me.GotTarget == true)
            {
                if (ObjectManager.Me.CurrentTarget.IsRepairMerchant == true)
                {
                    string tempVendor = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Vendor Name=\"{0}\" Entry=\"{1}\" Type=\"{2}\" X=\"{3}\" Y=\"{4}\" Z=\"{5}\" />",
                        ObjectManager.Me.CurrentTarget.Name, ObjectManager.Me.CurrentTarget.Entry.ToString(), "Repair", ObjectManager.Me.CurrentTarget.X.ToString(), ObjectManager.Me.CurrentTarget.Y.ToString(),
                        ObjectManager.Me.CurrentTarget.Z.ToString());

                    if (MessageBoxHelp("Do you want to add this NPC as a vendor?\n\n" + tempVendor, this.Text) == true)
                    {
                        Log("Adding: " + tempVendor);
                        vendorsList.Add(tempVendor);
                        UpdateRepairList();
                    }
                }
                else
                {
                    Log(ObjectManager.Me.CurrentTarget.Name + " is not an RepairMerchant");
                    MessageBox.Show(ObjectManager.Me.CurrentTarget.Name + " is not an RepairMerchant");
                }
            }
            else if (ObjectManager.Me.GotTarget != true)
            {
                MessageBox.Show("You dont have any target!");
            }
        }

        private void btnReverseHotspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to reverse all hotspots?", this.Text) == true)
            {
                hotspotsList.Reverse();
                UpdateHotspotList();
                Log("Reversed hotspots");
            }
        }

        private void btnLoadHotspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to load hotspots from an existing profile? \n\n Please note that this will DELETE all existing hotspots!", this.Text) == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                DialogResult results = new DialogResult();

                results = dialog.ShowDialog();

                if (results == DialogResult.OK)
                {
                    hotspotsList.Clear();
                    UpdateHotspotList();

                    string tempLine;

                    StreamReader file = new System.IO.StreamReader(@dialog.FileName);
                    while ((tempLine = file.ReadLine()) != null)
                    {
                        if (tempLine.Contains("<Hotspot "))
                        {
                            if(!hotspotsList.Contains(tempLine))
                            {
                                hotspotsList.Add(tempLine);
                            }
                        }
                    }

                    UpdateHotspotList();
                    Log("Loaded hotspots from profile");
                }
            }
        }

        private void btnLoadBlackspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to load blackspots from an existing profile?", this.Text) == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                DialogResult results = new DialogResult();

                results = dialog.ShowDialog();

                if (results == DialogResult.OK)
                {
                    string tempLine;

                    StreamReader file = new System.IO.StreamReader(@dialog.FileName);
                    while ((tempLine = file.ReadLine()) != null)
                    {
                        if (tempLine.Contains("<Blackspot "))
                        {
                            if (!blackspotsList.Contains(tempLine))
                            {
                                blackspotsList.Add(tempLine);
                            }
                        }
                    }

                    UpdateBlackspotList();
                    Log("Loaded blackspots from profile");
                }
            }
        }

        private void btnLoadRepair_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to load repair vendors from an existing profile?", this.Text) == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                DialogResult results = new DialogResult();

                results = dialog.ShowDialog();

                if (results == DialogResult.OK)
                {
                    string tempLine;

                    StreamReader file = new System.IO.StreamReader(@dialog.FileName);
                    while ((tempLine = file.ReadLine()) != null)
                    {
                        if (tempLine.Contains("<Vendor "))
                        {
                            if (!vendorsList.Contains(tempLine))
                            {
                                vendorsList.Add(tempLine);
                            }
                        }
                    }

                    UpdateRepairList();
                    Log("Loaded vendors from profile");
                }
            }
        }

        private void btnLoadMailboxes_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelp("Are you sure you wish to load mailboxes from an existing profile?", this.Text) == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                DialogResult results = new DialogResult();

                results = dialog.ShowDialog();

                if (results == DialogResult.OK)
                {
                    string tempLine;

                    StreamReader file = new System.IO.StreamReader(@dialog.FileName);
                    while ((tempLine = file.ReadLine()) != null)
                    {
                        if (tempLine.Contains("<Mailbox "))
                        {
                            if (!mailboxList.Contains(tempLine))
                            {
                                mailboxList.Add(tempLine);
                            }
                        }
                    }

                    UpdateMailboxList();
                    Log("Loaded mailboxes from profile");
                }
            }
        }

        private void btnLocRefresh_Click(object sender, EventArgs e)
        {
            lblLocation.Text = "X = " + ObjectManager.Me.Location.X + ", Y = " + ObjectManager.Me.Location.Y + ", Z = " + ObjectManager.Me.Location.Z;
        }



    }
}
