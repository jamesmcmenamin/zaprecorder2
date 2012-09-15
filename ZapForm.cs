﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

// TODO - Blackspot notes

namespace ZapRecorder2
{

    delegate void HotkeyHandler();

    public partial class ZapMainForm : Form
    {
        public static List<string> hotspotsList, mailboxList, repairList, blackspotsList;
        public Thread backgroundThread, recordingThread;
        public WoWPoint oldLocation = new WoWPoint(0, 0, 0);
        public bool isRecording = false;
        public bool chatMessage = true;

        public ZapMainForm()
        {
            InitializeComponent();

            hotspotsList = new List<string>();
            mailboxList = new List<string>();
            repairList = new List<string>();
            blackspotsList = new List<string>();

            backgroundThread = new Thread(new ThreadStart(BackgroundPulse));
            backgroundThread.IsBackground = true;
            backgroundThread.Start();


            LoadSettings();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            txtLog.TextChanged += new EventHandler(txtLog_TextChanged);
            onTop.CheckedChanged += new EventHandler(onTop_CheckedChanged);

            ((Control)this.tabTest).Enabled = false;


            //Lua.Events.AttachEvent("MODIFIER_STATE_CHANGED", HandleModifierStateChanged);
            //ZapLog("Registered RControl as hotkey with LUA");
            //ShowWoWChatMessage("Registered HOTKEY for stuff");
            //bool myBool = Hotkeys.RegisterHotkey("Log Waypoint", WriteSomething, Keys.LControlKey);

            //ShowWoWChatMessage("Registered hotkeys for Zaprecorder2");

            /*
            Lua.Events.AttachEvent("MODIFIER_STATE_CHANGED", HandleModifierStateChanged);
            Log("Registered RControl as hotkey with LUA");

            //Keys[] registeredHotkey = new Keys[1] { Keys.LControlKey };

            Action hotkeyDelegate = HandleZapHotkey;
            
             */
            //ZapLog("Hotkey registration: " + myBool.ToString());
            //ZapLog("Stop me here");

            //Keys[] comboKey = new Keys[1];
            //comboKey[0] = ;

            //Action ZapCallback = () => HandleZapHotkey();
            //ZapCallback.Invoke(); // Successfully prints to log

            try
            {
                Action ZapCallback = this.HandleZapHotkey;

                Hotkeys.SetWindowHandle(StyxWoW.Memory.Process.MainWindowHandle);

                bool TestResult = Hotkeys.RegisterHotkey("Test Hotkey", ZapCallback, Keys.LControlKey);

                ZapLog("Registered LControl as a hotkey with HB");
            }
            catch (Exception ex)
            {
                ZapException(ex, "Setting hotkeys");
            }

        }

        private void HandleZapHotkey()
        {
            ZapLog("LControl Pressed from Hotkey class!");
        }

        public void HandleModifierStateChanged(object sender, LuaEventArgs args)
        {

            ZapLog("Modifier handler fired");
            // Args[1] says that the key is being pressed and not released
            if (Convert.ToInt32(args.Args[1]) == 1)
            {
                if(args.Args[0].ToString() == "LCTRL") {
                    //ToggleRecording();
                    ZapLog("Got LCTRL");
                }
                else if (args.Args[0].ToString() == "LSHIFT")
                {
                    //AddHotspot();
                    ZapLog("Got LCTRL");
                }
                else
                {
                    ZapLog("Received unexecpted modifier: " + args.Args[0].ToString());
                }
            }
        }

        public void AddHotspot()
        {
            
            hotspotsList.Add(getHotspot());
            UpdateHotspotList();
        }

        public void AddHotspot(int index)
        {
            hotspotsList.Insert(index,getHotspot());
            UpdateHotspotList();
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
        public void ZapLog(string msg)
        {
            txtLog.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + msg + Environment.NewLine;
        }

        public void ZapException(Exception ex)
        {
            txtLog.Text += "[" + DateTime.Now.ToLongTimeString() + "] [ERROR] - " + ex.Message + Environment.NewLine;
        }

        public void ZapException(Exception ex, string exLocation)
        {
            txtLog.Text += "[" + DateTime.Now.ToLongTimeString() + "] [ERROR in " + exLocation + "] - " + ex.Message + Environment.NewLine;
        }

        public void ShowWoWChatMessage(string message)
        {
            //if (chatMessage == true)
            //{
                Lua.DoString("getglobal(\"ChatFrame1\"):AddMessage(\"|cff2dbbc4ZapRecorder2: |cffffffff " + message + "\",0, 0, 0, 0);");
            //}

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

            #region Chat Messages

            if (chkChatMessage.Checked)
            {
                ZapRecorder2.Properties.Settings.Default.chatMessages = true;
            }
            else
            {
                ZapRecorder2.Properties.Settings.Default.chatMessages = false;
            }

            #endregion

            #region MinimumDurability

            ZapRecorder2.Properties.Settings.Default.minimumDurability = txtMinDurability.Text;

            #endregion

            #region MinimumFreeBagSlots

            ZapRecorder2.Properties.Settings.Default.minimumFreeBagSlots = txtMinFreeBagSlots.Text;

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
            ZapLog("Settings saved");
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

            #region Chat Messages
            if (ZapRecorder2.Properties.Settings.Default.chatMessages == true)
            {
                chkChatMessage.Checked = true;
                chatMessage = true;
            }
            else
            {
                chkChatMessage.Checked = false;
                chatMessage = false;
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

            txtMinDurability.Text = ZapRecorder2.Properties.Settings.Default.minimumDurability;

            #endregion

            #region MinimumFreeBagSlots

            txtMinFreeBagSlots.Text = ZapRecorder2.Properties.Settings.Default.minimumFreeBagSlots;

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

            ZapLog("Settings loaded");
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

        // So far just updates labels.. Necessary?
        public void BackgroundPulse()
        {
            ZapLog("Background thread started");

            while (true)
            {
                Thread.Sleep(50);

                try
                {
                    lblBlackspots.Text = "Blackspots: " + blackspotsList.Count().ToString();
                    lblVendors.Text = "Vendors: " + repairList.Count().ToString();
                    lblHotspots.Text = "Hotspots: " + hotspotsList.Count().ToString();
                    lblMailboxes.Text = "Mailboxes: " + mailboxList.Count().ToString();
                    // Do not attempt to update location. Frequent calls WILL crash HB
                }
                catch (Exception ex)
                {
                    // REMOVEME
                    ZapException(ex, "BackgroundPulse");
                }
            }
        }

        private void addBlackspotButton_Click(object sender, EventArgs e)
        {

        }

        private void clearBlackspotsButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Clear all blackspots?", this.Text) == true)
            {
                blackspotsList.Clear();
            }
        }

        private void clearHotspotsButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Clear all hotspots?", this.Text) == true)
            {
                hotspotsList.Clear();
            }
        }

        private void addMailboxButton_Click(object sender, EventArgs e)
        {

        }

        private void clearMailboxesButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Clear all mailboxes?", this.Text) == true)
            {
                mailboxList.Clear();
            }
        }

        private void addVendorsButton_Click(object sender, EventArgs e)
        {

        }

        private void btnClearHotspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to clear all hotspots?", this.Text) == true)
            {
                hotspotsList.Clear();
                UpdateHotspotList();
            }
        }

        public void RecordingPulse()
        {
            try {
                while (isRecording)
                {
                    if (HasMovedNeedsHotspot())
                    {
                        /*if (playSound.Checked == true)
                        {
                            PlaySound("bloop.wav");
                        }
                        */

                        ZapLog("Adding: " + getHotspot());
                    
                    
                        oldLocation = new WoWPoint(ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z);
                    
                        AddHotspot();
                        hotspotsList.Add(getHotspot());

                        // Delay according to recording time
                        Thread.Sleep(Convert.ToInt32(recordingTimeTextbox.Text));
                    }
                    else
                    {
                        // Hasn't moved enough for hotspot. Check again in 100ms
                        Thread.Sleep(100);
                    }
                }
            } catch(Exception ex) {
                ZapException(ex,"RecordingPulse");
            }
        }

        public bool HasMovedNeedsHotspot()
        {
            try
            {
                return (ObjectManager.Me.Location.Distance(oldLocation) > Convert.ToInt32(addIfMovedTextbox.Text));
            }
            catch (Exception ex)
            {
                ZapException(ex, "HasMovedNeedsHotspot");
                return false;
            }
        }

        public bool MessageBoxHelper(string text, string title)
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

        public bool MessageBoxHelper(string text, string title,MessageBoxButtons boxButtons)
        {
            DialogResult dialog = MessageBox.Show(text, title, boxButtons, MessageBoxIcon.Question);

            if ((dialog == DialogResult.Yes) || (dialog == DialogResult.OK))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MessageBoxHelper(string text, string title, MessageBoxButtons boxButtons, MessageBoxIcon boxIcon)
        {
            DialogResult dialog = MessageBox.Show(text, title, boxButtons, boxIcon);

            if ((dialog == DialogResult.Yes) || (dialog == DialogResult.OK))
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
            ToggleRecording();
            
        }

        public void ToggleRecording()
        {
            if (isRecording)
            {
                // Stop the recording
                isRecording = false;
                btnRecording.Text = "Start Recording";
                btnRecording.ForeColor = Color.Black;
                ShowWoWChatMessage("Recording stopped!");
                ZapLog("Recording stopped!");
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

                    ShowWoWChatMessage("Recording started!");
                    ZapLog("Recording started!");
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

                try
                {
                    dlgSaveFile.InitialDirectory = Utilities.AssemblyDirectory;

                    if (dlgSaveFile.ShowDialog() == DialogResult.OK)
                    {
                        ZapLog("Received a save to location of: " + dlgSaveFile.FileName);

                        string path = dlgSaveFile.FileName;

                        StreamWriter writer = new StreamWriter(path);
                        ZapLog("Writing profile: " + path);

                        //BEGINNING OF THE PROFILE WRITING
                        writer.WriteLine("<HBProfile>");
                        writer.WriteLine("<Name>" + ObjectManager.Me.ZoneText + "</Name>");
                        writer.WriteLine("<MinDurability>" + txtMinDurability.Text + "</MinDurability>");
                        writer.WriteLine("<MinFreeBagSlots>" + txtMinFreeBagSlots.Text + "</MinFreeBagSlots>");
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

                        foreach (string vend in repairList)
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


                        ZapLog("Profile writing completed!");
                    }
                    else
                    {
                        // User cancelled Save Dialog
                    }

                }
                catch (Exception ex)
                {
                    ZapException(ex, "SaveProfile");
                }
            }
            else
            {
                MessageBox.Show("You dont have any hotspots to save!");
            }
        }

        private void AddBlackspot()
        {
            try
            {
                string tempBlackspot = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Blackspot X=\"{0}\" Y=\"{1}\" Z=\"{2}\" Radius=\"{3}\" />", ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z, numericUpDown1.Value.ToString());
                blackspotsList.Add(tempBlackspot);
                UpdateBlackspotList();
            }
            catch (Exception ex)
            {
                ZapException(ex, "AddBlackspot");
            }
        }

        private void btnAddBlackspot_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you standing in the middle of the blackspot and have choosen the prefered radius?\nCurrent radius = " + numericUpDown1.Value.ToString(), this.Text) == true)
            {
                AddBlackspot();
                ZapLog("Added blackspot");
                ShowWoWChatMessage("Blackspot added at your location");
            }
        }

        private void btnAddMailbox_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you standing next to a mailbox?", this.Text) == true)
            {
                string tempMailbox = "<Mailbox" + getHotspot().Replace("<Hotspot", "");
                ZapLog("Adding: " + tempMailbox);
                mailboxList.Add(tempMailbox);
                UpdateMailboxList();
                ShowWoWChatMessage("Mailbox added at your location");
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

                    if (MessageBoxHelper("Do you want to add this repair NPC?\n\n" + tempVendor, this.Text) == true)
                    {
                        ZapLog("Adding: " + tempVendor);
                        repairList.Add(tempVendor);
                        UpdateRepairList();
                        ShowWoWChatMessage("Repair vendor added at your location");
                    }
                }
                else
                {
                    ZapLog(ObjectManager.Me.CurrentTarget.Name + " is not a repair NPC");
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
            if (MessageBoxHelper("Are you sure you wish to clear everything from this profile?", this.Text) == true)
            {
                hotspotsList.Clear();
                blackspotsList.Clear();
                mailboxList.Clear();
                repairList.Clear();

                ZapLog("Cleared everything from the current profile");
            }
        }

        private void btnClearAllMailboxes_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Clear all mailboxes?", this.Text) == true)
            {
                mailboxList.Clear();
                UpdateMailboxList();
            }
        }

        private void btnClearBlackspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to clear all blackspots?", this.Text) == true)
            {
                blackspotsList.Clear();
            }

            UpdateBlackspotList();
        }

        private void btnClearAllRepair_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Clear all vendors?", this.Text) == true)
            {
                repairList.Clear();
            }

            UpdateRepairList();
        }

        public void UpdateHotspotList()
        {
            try
            {
                listHotspots.Items.Clear();
                listTestHotspots.Items.Clear();

                foreach (string q in hotspotsList)
                {
                    listHotspots.Items.Add(q);
                    listTestHotspots.Items.Add(q);
                }
            }
            catch (Exception ex)
            {
                ZapException(ex, "UpdateHotspotList");
            }
        }

        public void UpdateBlackspotList()
        {
            try {
                listBlackspots.Items.Clear();

                foreach (string q in blackspotsList)
                {
                    listBlackspots.Items.Add(q);
                }
            }
            catch (Exception ex)
            {
                ZapException(ex, "UpdateBlackspotList");
            }
        }

        public void UpdateRepairList()
        {
            try
            {

                listRepair.Items.Clear();

                foreach (string q in repairList)
                {
                    listRepair.Items.Add(q);
                }
            }
            catch (Exception ex)
            {
                ZapException(ex, "UpdateRepairList");
            }
        }

        public void UpdateMailboxList()
        {
            try
            {
                listMailboxes.Items.Clear();

                foreach (string q in mailboxList)
                {
                    listMailboxes.Items.Add(q);
                }
            }
            catch (Exception ex)
            {
                ZapException(ex, "UpdateMailboxList");
            }
        }

        private void btnClearSelectedHotspots_Click(object sender, EventArgs e)
        {
            if (listHotspots.SelectedItems.Count > 0)
            {
                if (MessageBoxHelper("Remove selected hotspot?\n\n" + listHotspots.SelectedItem.ToString(), this.Text) == true)
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
                if (MessageBoxHelper("Are you sure you wish to remove the selected blackspot?\n\n" + listBlackspots.SelectedItem.ToString(), this.Text) == true)
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
                if (MessageBoxHelper("Remove selected vendor?\n\n" + listRepair.SelectedItem.ToString(), this.Text) == true)
                {
                    repairList.Remove(listRepair.SelectedItem.ToString());
                    UpdateRepairList();
                }
            }
        }

        private void btnClearSelectedMailboxes_Click(object sender, EventArgs e)
        {
            if (listMailboxes.SelectedItems.Count > 0)
            {
                if (MessageBoxHelper("Remove selected mailbox?\n\n" + listMailboxes.SelectedItem.ToString(), this.Text) == true)
                {
                    mailboxList.Remove(listMailboxes.SelectedItem.ToString());
                    UpdateMailboxList();
                }
            }
        }

        private void btnAddBlackspot2_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you standing in the middle of the blackspot and have choosen the prefered radius?\nCurrent radius = " + numericUpDown1.Value.ToString(), this.Text) == true)
            {
                string tempBlackspot = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "<Blackspot X=\"{0}\" Y=\"{1}\" Z=\"{2}\" Radius=\"{3}\" />", ObjectManager.Me.Location.X, ObjectManager.Me.Location.Y, ObjectManager.Me.Location.Z, numericUpDown1.Value.ToString());
                ZapLog("Added: " + tempBlackspot);
                blackspotsList.Add(tempBlackspot);
                UpdateBlackspotList();
                ShowWoWChatMessage("Blackspot added at your location");
            }
        }

        private void btnAddMailbox2_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you standing next to a mailbox?", this.Text) == true)
            {
                string tempMailbox = "<Mailbox" + getHotspot().Replace("<Hotspot", "");
                ZapLog("Adding: " + tempMailbox);
                mailboxList.Add(tempMailbox);
                UpdateMailboxList();
                ShowWoWChatMessage("Mailbox added at your location");
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

                    if (MessageBoxHelper("Do you want to add this NPC as a vendor?\n\n" + tempVendor, this.Text) == true)
                    {
                        ZapLog("Adding: " + tempVendor);
                        repairList.Add(tempVendor);
                        UpdateRepairList();
                        ShowWoWChatMessage("Repair vendor added at your location");
                    }
                }
                else
                {
                    ZapLog(ObjectManager.Me.CurrentTarget.Name + " is not an RepairMerchant");
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
            if (MessageBoxHelper("Are you sure you wish to reverse all hotspots?", this.Text) == true)
            {
                hotspotsList.Reverse();
                UpdateHotspotList();
                ZapLog("Reversed hotspots");
            }
        }

        private void btnLoadHotspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to load hotspots from an existing profile? \n\n Please note that this will DELETE all existing hotspots!", this.Text) == true)
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
                    ZapLog("Loaded hotspots from profile");
                }
            }
        }

        private void btnLoadBlackspots_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to load blackspots from an existing profile?", this.Text) == true)
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
                    ZapLog("Loaded blackspots from profile");
                }
            }
        }

        private void btnLoadRepair_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to load repair vendors from an existing profile?", this.Text) == true)
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
                            if (!repairList.Contains(tempLine))
                            {
                                repairList.Add(tempLine);
                            }
                        }
                    }

                    UpdateRepairList();
                    ZapLog("Loaded vendors from profile");
                }
            }
        }

        private void btnLoadMailboxes_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Are you sure you wish to load mailboxes from an existing profile?", this.Text) == true)
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
                    ZapLog("Loaded mailboxes from profile");
                }
            }
        }

        private void btnLocRefresh_Click(object sender, EventArgs e)
        {
            lblLocation.Text = "X = " + ObjectManager.Me.Location.X + ", Y = " + ObjectManager.Me.Location.Y + ", Z = " + ObjectManager.Me.Location.Z;
        }

        private void btnAddHotspot_Click(object sender, EventArgs e)
        {
            AddHotspot();
            ZapLog("Added " + getHotspot());

        }

        private void chkChatMessage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChatMessage.Checked == true)
            {
                //WoWHelper
                Logging.Write("Turning on chat messages.");
            }
            else
            {
                chatMessage = false;
                ZapLog("Turning off chat messages.");
            }
        }

        private void btnOpenProfile_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper("Loading a profile will replace all current hotspots, settings, etc..\n\n", "Confirm Open Profile",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                DialogResult results = new DialogResult();

                results = dialog.ShowDialog();

                if (results == DialogResult.OK)
                {
                    hotspotsList.Clear();
                    UpdateHotspotList(); 
                    
                    blackspotsList.Clear();
                    UpdateBlackspotList();

                    mailboxList.Clear();
                    UpdateMailboxList();

                    repairList.Clear();
                    UpdateRepairList();

                    ZapLog("Loading profile " + dialog.FileName);

                    

                    string tempLine;

                    StreamReader file = new System.IO.StreamReader(@dialog.FileName);
                    while ((tempLine = file.ReadLine()) != null)
                    {
                        if (tempLine.Contains("<Hotspot "))
                        {
                            if (!hotspotsList.Contains(tempLine))
                            {
                                hotspotsList.Add(tempLine.Trim());
                            }
                        }
                        else if (tempLine.Contains("<Blackspot "))
                        {
                            if (!blackspotsList.Contains(tempLine))
                            {
                                blackspotsList.Add(tempLine.Trim());
                            }
                        }
                        else if (tempLine.Contains("<Mailbox "))
                        {

                            if (!mailboxList.Contains(tempLine))
                            {
                                mailboxList.Add(tempLine.Trim());
                            }
                        }
                        else if (tempLine.Contains("<Vendor ") && tempLine.Contains("Repair"))
                        {

                            if (!repairList.Contains(tempLine))
                            {
                                repairList.Add(tempLine.Trim());
                            }
                        }
                        else if (tempLine.Contains("<Name"))
                        {
                            txtProfileName.Text = getProfileDataString(tempLine, "Name");
                        }
                        else if (tempLine.Contains("<MailGrey"))
                        {
                            mailGrey.Checked = getProfileDataBool(tempLine, "MailGrey");
                        }
                        else if (tempLine.Contains("<MailWhite"))
                        {
                            mailWhite.Checked = getProfileDataBool(tempLine, "MailWhite");
                        }
                        else if (tempLine.Contains("<MailGreen"))
                        {
                            mailGreen.Checked = getProfileDataBool(tempLine, "MailGreen");
                        }
                        else if (tempLine.Contains("<MailBlue"))
                        {
                            mailBlue.Checked = getProfileDataBool(tempLine, "MailBlue");
                        }
                        else if (tempLine.Contains("<MailPurple"))
                        {
                            mailPurple.Checked = getProfileDataBool(tempLine, "MailPurple");
                        }
                        else if (tempLine.Contains("<SellGrey"))
                        {
                            sellGrey.Checked = getProfileDataBool(tempLine, "SellGrey");
                        }
                        else if (tempLine.Contains("<SellWhite"))
                        {
                            sellWhite.Checked = getProfileDataBool(tempLine, "SellWhite");
                        }
                        else if (tempLine.Contains("<SellGreen"))
                        {
                            sellGreen.Checked = getProfileDataBool(tempLine, "SellGreen");
                        }
                        else if (tempLine.Contains("<SellBlue"))
                        {
                            sellBlue.Checked = getProfileDataBool(tempLine, "SellBlue");
                        }
                        else if (tempLine.Contains("<SellPurple"))
                        {
                            sellPurple.Checked = getProfileDataBool(tempLine, "SellPurple");
                        }
                        else if (tempLine.Contains("<MinDurability"))
                        {
                            txtMinDurability.Text = getProfileDataString(tempLine, "MinDurability");
                        }
                        else if (tempLine.Contains("<MinFreeBagSlots"))
                        {
                            txtMinFreeBagSlots.Text = getProfileDataString(tempLine, "MinFreeBagSlots");
                        }
                        else if (tempLine.Contains("<MinLevel"))
                        {
                            txtMinLevel.Text = getProfileDataString(tempLine, "MinLevel");
                        }
                        else if (tempLine.Contains("<MaxLevel"))
                        {
                            txtMaxLevel.Text = getProfileDataString(tempLine, "MaxLevel");
                        }
                        else if (tempLine.Contains("<Factions"))
                        {
                            txtFactions.Text = getProfileDataString(tempLine, "Factions");
                        }
                        

                    }

                    file.Close();

                    //MinDurability
                    //MinFreeBagSlots
                    //MinLevel
                    //MaxLevel
                    //Factions
                    
                    UpdateHotspotList();
                    UpdateBlackspotList();
                    UpdateMailboxList();
                    UpdateRepairList();
                    ZapLog("Profile load complete!");
                }
            }
        }

        private string getProfileDataString(string profileLine, string nodeName)
        {
            return profileLine.Replace("<" + nodeName + ">", "").Replace("</" + nodeName + ">", "").Trim();
        }

        private bool getProfileDataBool(string profileLine, string nodeName)
        {
            return profileLine.Replace("<" + nodeName + ">", "").Replace("</" + nodeName + ">", "").Trim().ToBoolean();
        }

        /* Implement later - regex not testing
         * private string getDataFromProfileElement(string profileLine)
        {
            Match regMatch = Regex.Match(profileLine.Trim(), @"<([A-Za-z0-9\-.]+)>([A-Za-z0-9\-.]+)</([A-Za-z0-9\-.]+)>", RegexOptions.IgnoreCase);

            // Here we check the Match instance.
            if ((regMatch.Success == true))
            {

                return regMatch.Groups[1].Value;

            }
            else
            {
                ZapLog("Unable to load data from " + profileLine); 
                return "";
                
            } 

        }
         * 
         * */

        private WoWPoint getWowPointFromHotspot(string hotspotString)
        {

            try
            {
                WoWPoint returnPoint = new WoWPoint();



                Match xMatch = Regex.Match(hotspotString, @"X=\""([A-Za-z0-9\-.]+)\""", RegexOptions.IgnoreCase);
                Match yMatch = Regex.Match(hotspotString, @"Y=\""([A-Za-z0-9\-.]+)\""", RegexOptions.IgnoreCase);
                Match zMatch = Regex.Match(hotspotString, @"Z=\""([A-Za-z0-9\-.]+)\""", RegexOptions.IgnoreCase);

                // Here we check the Match instance.
                if ((xMatch.Success == true) && (yMatch.Success == true) && (zMatch.Success == true))
                {

                    returnPoint.X = xMatch.Groups[1].Value.ToFloat();
                    returnPoint.Y = yMatch.Groups[1].Value.ToFloat();
                    returnPoint.Z = zMatch.Groups[1].Value.ToFloat();

                    return returnPoint;

                }
                else
                {
                    ZapLog("Error - Unable to parse hotspot from " + hotspotString.Trim());
                    return returnPoint;
                }
            }
            catch (Exception ex)
            {
                ZapException(ex, "GetWoWPointFromHotspot");
                return new WoWPoint(0, 0, 0);
            }

        }

        private float MyDistanceTo(WoWPoint hotspot)
        {

            return ObjectManager.Me.GetPosition().Distance(hotspot);
        }

        private void MoveToPoint(WoWPoint inputPoint)
        {
            try
            {


                ZapLog("Stopping movement to prepare to move to hotspot");
                Styx.WoWInternals.WoWMovement.MoveStop();
                //ZapLog(string.Format(CultureInfo.CreateSpecificCulture("en-US"), "Moving to X=\"{0}\" Y=\"{1}\" Z=\"{2}\"", inputPoint.X, inputPoint.Y, inputPoint.Z));
                
                //if(!Styx.StyxWoW.Me.IsFlying) {
                //    ZapLog("Not yet moving.. mount up!");
                //    Flightor.MountHelper.MountUp();
                //}

                //double targetXLocation = 1234;
                //double targetYLocation = 84;
                //double targetZLocation = -34; 

                int loopCounter = 0;
                int max_loops = 100;
                while (!StyxWoW.Me.ToUnit().IsMoving && (loopCounter < max_loops))
                {
                    Flightor.MoveTo(inputPoint);
                    Thread.Sleep(5);
                    loopCounter++;
                }

                ZapLog("Exited move successful loop after " + loopCounter.ToString() + " tries");
                
                //WoWPoint moveTo = new WoWPoint(targetXLocation, targetYLocation, targetZLocation);
                //Flightor.MoveTo(moveTo);
                
                
            }
            catch (Exception ex)
            {
                ZapException(ex,"MoveToPoint");
            }
        }
        

        

        

        

        

        #region Test Profile Tab
        
        private void btnGoToHotspot_Click(object sender, EventArgs e)
        {
            if(listTestHotspots.Items.Count < 1)
            {
                ZapLog("You do not have any hotspots to go to.");
                return;
            }

            if (listTestHotspots.SelectedItem == null)
            {
                ZapLog("You must select a hotspot to go to it!");
                return;
            }

            WoWPoint hotSpotPoint = getWowPointFromHotspot(listTestHotspots.SelectedItem.ToString());
            MoveToPoint(hotSpotPoint);
            
        }

        private void btnPrevHotspot_Click(object sender, EventArgs e)
        {
            if (listTestHotspots.Items.Count < 1)
            {
                ZapLog("You do not have any hotspots to go to.");
                return;
            }

            if (listTestHotspots.SelectedIndex == 0)
            {
                listTestHotspots.SelectedIndex = (listTestHotspots.Items.Count - 1);
            }
            else
            {
                listTestHotspots.SelectedIndex--;
            }

            WoWPoint hotSpotPoint = getWowPointFromHotspot(listTestHotspots.SelectedItem.ToString());

            MoveToPoint(hotSpotPoint);
        }

        private void btnNextHotspot_Click(object sender, EventArgs e)
        {
            if (listTestHotspots.Items.Count < 1)
            {
                ZapLog("You do not have any hotspots to go to.");
                return;
            }

            if (listTestHotspots.SelectedIndex == (listTestHotspots.Items.Count - 1))
            {
                listTestHotspots.SelectedIndex = 0;
            }
            else
            {
                listTestHotspots.SelectedIndex++;
            }

            WoWPoint hotSpotPoint = getWowPointFromHotspot(listTestHotspots.SelectedItem.ToString());

            MoveToPoint(hotSpotPoint);
            
        }

        private void btnReplaceHotspot_Click(object sender, EventArgs e)
        {
            int storedIndex = listTestHotspots.SelectedIndex;
            hotspotsList[listTestHotspots.SelectedIndex] = getHotspot();
            UpdateHotspotList();

            listTestHotspots.SelectedIndex = storedIndex;
            
        }

        private void btnAddHotspotAtIndex_Click(object sender, EventArgs e)
        {
            AddHotspot(listTestHotspots.SelectedIndex);
        }
        
        private void btnDeleteHotspot_Click(object sender, EventArgs e)
        {
            if (listTestHotspots.Items.Count < 1)
            {
                ZapLog("You do not have any hotspots to go to.");
                return;
            }

            if (listTestHotspots.SelectedItem == null)
            {
                ZapLog("You must select a hotspot to delete");
                return;
            }

            hotspotsList.RemoveAt(listTestHotspots.SelectedIndex);
            UpdateHotspotList();

        }
        
        #endregion

        

        




    }
}
