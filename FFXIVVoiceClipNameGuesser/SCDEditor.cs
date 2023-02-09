using FFXIVVoicePackCreator.SoundData;
using NAudio.Vorbis;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;
using System.Xml.Linq;
using VfxEditor.ScdFormat;
using static FFBardMusicPlayer.FFXIV.FFXIVHook;

namespace FFXIVVoicePackCreator {
    public partial class SCDEditor : Form {
        private Form form;
        public Form Form { get => form; set => form = value; }
        ScdFile scdFile;
        private WasapiOut output;
        private WaveOutEvent outputWave;

        public SCDEditor() {
            InitializeComponent();
        }

        private void originalSCD_OnFileSelected(object sender, EventArgs e) {
            OpenSCD();
        }

        private void OpenSCD() {
            audioDataList.Items.Clear();
            using (FileStream fileStream = new FileStream(originalSCD.FilePath.Text, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fileStream)) {
                    scdFile = new ScdFile(reader);
                }
            }
            int i = 0;
            foreach (ScdAudioEntry entry in scdFile.Audio) {
                if (entry.Format != SscfWaveFormat.Empty) {
                    audioDataList.Items.Add(new AudioReplacementItem(i, entry, ""));
                }
                i++;
            }
        }

        public void PlaySound(string fileName) {
            if (File.Exists(fileName)) {
                if (outputWave != null) {
                    outputWave.Stop();
                }
                outputWave = new WaveOutEvent();
                if (fileName.EndsWith(".ogg")) {
                    using (var player = new VorbisWaveReader(fileName)) {
                        outputWave.Init(player);
                        outputWave.Play();
                        while (outputWave.PlaybackState == PlaybackState.Playing) {
                            Thread.Sleep(200);
                            Application.DoEvents();
                        }
                    }
                } else {
                    using (var player = new AudioFileReader(fileName)) {
                        outputWave.Init(player);
                        outputWave.Play();
                        while (outputWave.PlaybackState == PlaybackState.Playing) {
                            Thread.Sleep(200);
                            Application.DoEvents();
                        }
                    }
                }
            }
        }
        public void PlaySoundWave(WaveStream data) {
            if (output != null) {
                output.Stop();
            }
            output = new WasapiOut();
            using (var player = new WaveChannel32(WaveFormatConversionStream.CreatePcmStream(data))) {
                output.Init(player);
                output.Play();
                while (output.PlaybackState == PlaybackState.Playing) {
                    Thread.Sleep(200);
                    Application.DoEvents();
                }
            }
        }
        public void PlaySoundOgg(WaveStream data) {
            if (output != null) {
                output.Stop();
            }
            output = new WasapiOut();
            output.Init(data);
            output.Play();
            while (output.PlaybackState == PlaybackState.Playing) {
                Thread.Sleep(200);
                Application.DoEvents();
            }
        }
        private void audioDataList_DoubleClick(object sender, EventArgs e) {
            AudioReplacementItem replacementItem = audioDataList.SelectedItem as AudioReplacementItem;
            if (!string.IsNullOrEmpty(replacementItem.ReplacementFile)) {
                PlaySound(replacementItem.ReplacementFile);
            } else {
                switch (replacementItem.ScdAudioEntry.Format) {
                    case SscfWaveFormat.MsAdPcm:
                    case SscfWaveFormat.Pcm:
                        PlaySoundWave(replacementItem.ScdAudioEntry.Data.GetStream());
                        break;
                    case SscfWaveFormat.Vorbis:
                        PlaySoundOgg(replacementItem.ScdAudioEntry.Data.GetStream());
                        break;
                }
            }
        }

        private void SCDEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (output != null) {
                output.Stop();
            }
        }

        private void stopPlaybackButton_Click(object sender, EventArgs e) {
            if (output != null) {
                output.Stop();
            }
            if(outputWave != null) {
                outputWave.Stop();
            }
        }

        public void RefreshAudioList() {
            for (int i = 0; i < audioDataList.Items.Count; i++) {
                audioDataList.Items[i] = audioDataList.Items[i];
            }
        }

        private void replaceButton_Click(object sender, EventArgs e) {
            if (audioDataList.SelectedItem != null) {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.RMI;*.MKV;*.flac;*.ogg;";
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    AudioReplacementItem replacementItem = audioDataList.SelectedItem as AudioReplacementItem;
                    replacementItem.ReplacementFile = openFileDialog.FileName;
                    RefreshAudioList();
                }
            } else {
                MessageBox.Show("Please Select An Index To Replace", Text);
            }
        }

        private void clearButton_Click(object sender, EventArgs e) {
            if (audioDataList.SelectedItem != null) {
                AudioReplacementItem replacementItem = audioDataList.SelectedItem as AudioReplacementItem;
                replacementItem.ReplacementFile = null;
                RefreshAudioList();
            } else {
                MessageBox.Show("Please Select An Index To Clear", Text);
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e) {
            foreach (AudioReplacementItem audioReplacementItem in audioDataList.Items) {
                audioReplacementItem.ReplacementFile = "";
            }
            RefreshAudioList();
        }

        private void generateButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(outputSCD.FilePath.Text)) {
                foreach (AudioReplacementItem entry in audioDataList.Items) {
                    if (!string.IsNullOrEmpty(entry.ReplacementFile)) {
                        form.TopMost = true;
                        TopMost = true;
                        string tempPath = "";
                        switch (entry.ScdAudioEntry.Format) {
                            case SscfWaveFormat.MsAdPcm:
                                tempPath = Path.Combine(Path.GetDirectoryName(entry.ReplacementFile), Guid.NewGuid() + ".wav");
                                Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + entry.ReplacementFile + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + tempPath + @""""}");
                                break;
                            case SscfWaveFormat.Vorbis:
                                tempPath = Path.Combine(Path.GetDirectoryName(entry.ReplacementFile), Guid.NewGuid() + ".ogg");
                                Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + entry.ReplacementFile + @""""} -c:a libvorbis -ar: 44100 {@"""" + tempPath + @""""}");
                                break;
                        }
                        while (SCDGenerator.IsFileLocked(tempPath)) { };
                        scdFile.Import(tempPath, entry.ScdAudioEntry);
                        File.Delete(tempPath);
                        form.TopMost = false;
                        TopMost = false;
                    } else {
                        scdFile.Replace(scdFile.Audio[entry.Index], entry.ScdAudioEntry);
                    }
                }
                using (FileStream exportStream = new FileStream(outputSCD.FilePath.Text, FileMode.Create, FileAccess.Write)) {
                    using (BinaryWriter writer = new BinaryWriter(exportStream)) {
                        scdFile.Write(writer);
                    }
                }
                MessageBox.Show("SCD Exported!", Text);
            } else {
                MessageBox.Show("Please Select An Output", Text);
            }
        }

        private void SCDEditor_Load(object sender, EventArgs e) {
            AutoScaleDimensions = new SizeF(96, 96);
        }
    }
}
