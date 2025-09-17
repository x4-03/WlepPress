using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WlepPress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int mmToPx(decimal mm, decimal dpi) => (int)(mm / 25.4m * dpi);

        private List<string> selectedFiles = new List<string>();
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (selectedFiles == null || selectedFiles.Count == 0)
            {
                MessageBox.Show("No files selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int copies = (int)numCopies.Value;
            if (copies < 1) copies = 1;

            // Settings
            decimal dpi = 300m;
            int a4Height = (int)(8.27m * dpi);  // 210 mm
            int a4Width = (int)(11.69m * dpi); // 297 mm

            int stickerHeight = mmToPx(numHeight.Value, dpi);
            int whiteBorder = mmToPx(numBorderInternal.Value, dpi);
            int blackBorder = (int)numBorderExternal.Value;  // in pixels
            int spacing = mmToPx(numSpacing.Value, dpi);
            int margin = mmToPx(numMargin.Value, dpi);

            Color whiteColor = btnColorInternal.BackColor;
            Color blackColor = btnColorExternal.BackColor;

            // Expand files according to copies
            var allImages = new List<string>();
            foreach (var file in selectedFiles)
                for (int i = 0; i < copies; i++)
                    allImages.Add(file);

            int sheetIndex = 1;
            int x = margin, y = margin;

            Bitmap sheet = new Bitmap(a4Width, a4Height);
            sheet.SetResolution((float)dpi, (float)dpi);
            Graphics g = Graphics.FromImage(sheet);
            g.Clear(Color.White);

            string saveDir = Path.GetDirectoryName(selectedFiles[0]);

            foreach (string imgPath in allImages)
            {
                using (Image img = Image.FromFile(imgPath))
                {
                    // Rotate vertical
                    if (img.Height > img.Width)
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Scale to sticker height
                    // stickerHeight = total height including borders
                    int contentHeight = stickerHeight - 2 * (whiteBorder + blackBorder);
                    float scale = (float)contentHeight / img.Height;
                    int targetH = contentHeight;
                    int targetW = (int)(img.Width * scale);

                    int totalW = targetW + 2 * (whiteBorder + blackBorder);
                    int totalH = targetH + 2 * (whiteBorder + blackBorder);

                    // Wrap to next row if needed
                    if (x + totalW + margin > a4Width)
                    {
                        x = margin;
                        y += totalH + spacing;
                    }

                    // New sheet if exceeds page height
                    if (y + totalH + margin > a4Height)
                    {
                        string savePath = Path.Combine(saveDir, $"{selectedFiles[0]}_sheet_{sheetIndex}.png");
                        sheet.Save(savePath, ImageFormat.Png);
                        sheetIndex++;

                        sheet.Dispose();
                        g.Dispose();
                        sheet = new Bitmap(a4Width, a4Height);
                        sheet.SetResolution((float)dpi, (float)dpi);
                        g = Graphics.FromImage(sheet);
                        g.Clear(Color.White);

                        x = margin;
                        y = margin;
                    }

                    // Draw spacing background
                    using (Brush spacingBrush = new SolidBrush(Color.White))
                        g.FillRectangle(spacingBrush, x, y, totalW, totalH);

                    // Draw white border
                    using (Brush wb = new SolidBrush(whiteColor))
                        g.FillRectangle(wb, x + blackBorder, y + blackBorder, totalW - 2 * blackBorder, totalH - 2 * blackBorder);

                    // Draw image
                    g.DrawImage(img, x + whiteBorder + blackBorder, y + whiteBorder + blackBorder, targetW, targetH);

                    // Draw black border
                    using (Pen pen = new Pen(blackColor, blackBorder))
                        g.DrawRectangle(pen, x + blackBorder / 2f, y + blackBorder / 2f, totalW - blackBorder, totalH - blackBorder);

                    x += totalW + spacing;
                }
            }

            // Save last sheet
            string finalPath = Path.Combine(saveDir, $"{selectedFiles[0]}_sheet_{sheetIndex}.png");
            sheet.Save(finalPath, ImageFormat.Png);

            g.Dispose();
            sheet.Dispose();

            MessageBox.Show($"{sheetIndex} sticker sheets generated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Directory.Exists(saveDir)) System.Diagnostics.Process.Start("explorer.exe", saveDir);

        }
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.png;*.jpg;*.jpeg";
                dlg.Multiselect = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    selectedFiles = dlg.FileNames.ToList();
                    txtStickerAmout.Text = selectedFiles.Count.ToString(); // show in textbox
                }
            }
            picPreview.Image = GeneratePreview();
        }

        private void colorPickerBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.FullOpen = true;
                dlg.Color = btn.BackColor;

                if (dlg.ShowDialog() == DialogResult.OK) btn.BackColor = dlg.Color;
            }
            RefreshPreview();
        }

        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            numHeight.Value = 48;
            numBorderInternal.Value = 3;
            numBorderExternal.Value = 1;
            numSpacing.Value = 0;
            numMargin.Value = 5;
            numCopies.Value = 1;

            btnColorInternal.BackColor = Color.FromArgb(255, 255, 255);
            btnColorExternal.BackColor = Color.FromArgb(170, 170, 170);

            selectedFiles.Clear();
            txtStickerAmout.Text = "none";

            RefreshPreview();
        }

        private Bitmap GeneratePreview()
        {
            decimal dpi = 72m; // lower DPI for faster preview
            int previewWidth = (int)(11.69m * dpi);
            int previewHeight = (int)(8.27m * dpi);
            int copies = (int)numCopies.Value;
            if (copies < 1) copies = 1;
            int stickerHeight = mmToPx(numHeight.Value, dpi);
            int whiteBorder = mmToPx(numBorderInternal.Value, dpi);
            int blackBorder = (int)numBorderExternal.Value;
            int spacing = mmToPx(numSpacing.Value, dpi);
            int margin = mmToPx(numMargin.Value, dpi);

            Color whiteColor = btnColorInternal.BackColor;
            Color blackColor = btnColorExternal.BackColor;

            Bitmap sheet = new Bitmap(previewWidth, previewHeight);
            sheet.SetResolution((float)dpi, (float)dpi);
            Graphics g = Graphics.FromImage(sheet);
            g.Clear(Color.White);

            // Take just a few sample images for preview
            var previewFiles = new List<String>();

            foreach (var file in selectedFiles)
                for (int i = 0; i < copies; i++)
                    previewFiles.Add(file);

            if (previewFiles.Count == 0)
            {
                g.DrawString("No preview (no files selected)",
                    this.Font, Brushes.Gray, new PointF(20, 20));
                return sheet;
            }

            int x = margin, y = margin;

            foreach (string imgPath in previewFiles)
            {
                using (Image img = Image.FromFile(imgPath))
                {
                    if (img.Height > img.Width)
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    int contentHeight = stickerHeight - 2 * (whiteBorder + blackBorder);
                    float scale = (float)contentHeight / img.Height;
                    int targetH = contentHeight;
                    int targetW = (int)(img.Width * scale);

                    int totalW = targetW + 2 * (whiteBorder + blackBorder);
                    int totalH = targetH + 2 * (whiteBorder + blackBorder);

                    if (x + totalW + margin > previewWidth)
                    {
                        x = margin;
                        y += totalH + spacing;
                    }

                    if (y + totalH + margin > previewHeight) break;

                    using (Brush wb = new SolidBrush(whiteColor))
                        g.FillRectangle(wb, x + blackBorder, y + blackBorder, totalW - 2 * blackBorder, totalH - 2 * blackBorder);

                    g.DrawImage(img, x + whiteBorder + blackBorder, y + whiteBorder + blackBorder, targetW, targetH);

                    using (Pen pen = new Pen(blackColor, blackBorder))
                        g.DrawRectangle(pen, x + blackBorder / 2f, y + blackBorder / 2f, totalW - blackBorder, totalH - blackBorder);

                    x += totalW + spacing;
                }
            }

            g.Dispose();
            return sheet;
        }

        private void RefreshPreview()
        {
            picPreview.Image?.Dispose();
            picPreview.Image = GeneratePreview();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        private void panelDropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panelDropZone_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Filter images
            var validFiles = droppedFiles.Where(f =>
                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).ToList();

            if (validFiles.Count > 0)
            {
                selectedFiles.AddRange(validFiles);
                txtStickerAmout.Text = selectedFiles.Count.ToString();
                RefreshPreview();
            }
        }

        private void btnPinterestDownload_Click(object sender, EventArgs e)
        {

            string scriptPath = @"download_pins.py";

            using (var logForm = new LogViewerForm("py", scriptPath))
            {
                logForm.ShowDialog(); // blocks Form1 until script finishes/closed
            }
        }
    }

    public partial class LogViewerForm : Form
    {
        private TextBox txtLogs;
        private Process process;

        public LogViewerForm(string pythonPath, string scriptPath)
        {
            Text = "Python Script Logs";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            txtLogs = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 10),
                WordWrap = false
            };

            Controls.Add(txtLogs);

            // Run when form loads
            Load += (s, e) => RunScript(pythonPath, scriptPath);
            FormClosing += (s, e) =>
            {
                if (process != null && !process.HasExited)
                {
                    try { process.Kill(); } catch { }
                }
            };
        }

        private void RunScript(string pythonPath, string scriptPath)
        {
            process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = $"\"{scriptPath}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.OutputDataReceived += (s, e) => AppendLog(e.Data);
            process.ErrorDataReceived += (s, e) => AppendLog(e.Data);

            process.EnableRaisingEvents = true;
            process.Exited += (s, e) =>
            {
                Invoke(new Action(() =>
                {
                    AppendLog("\r\n--- Script finished ---");
                }));
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void AppendLog(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Invoke(new Action(() =>
                {
                    txtLogs.AppendText(text + Environment.NewLine);
                }));
            }
        }
    }
}

