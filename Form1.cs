using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using DdsFileTypePlus;
using ImageMagick;
using PaintDotNet;
using SoulsFormats;

// ReSharper disable UnusedMember.Local

namespace IconAutomatorPro;

public partial class Form1 : Form
{
    private const string version = "1.8";
    private static string gameModFolderPath = "";
    private static string layoutFilesBndPath = "";
    private static string iconSheetsTpfPath = "";
    private static string hdIconsBhdPath = "";
    private static string hdIconsBdtPath = "";
    private static string knowledgeFolderPath = "";
    private static BND4 layoutFilesBnd = new();
    private static TPF iconSheetsTpf = new();
    private static XElement? layoutFile;
    private static string[] iconImagePaths = { };
    private static IMagickImage<ushort> iconSheet = new MagickImage();
    private static bool isGameDS3;
    private static bool wantsIconSheet;
    private static bool wantsHdIcons;

    public Form1()
    {
        InitializeComponent();
        SetVersionString();
        CenterToScreen();
    }

    private void SetVersionString()
    {
        versionStr.Text += $@" {version}";
    }

    private static void ShowInformationDialog(string str)
    {
        MessageBox.Show(str, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static bool IsValidIconSheet(string iconSheetName)
    {
        return iconSheetName.Contains("_Icon_") || iconSheetName.Contains("_Status_") || iconSheetName.Contains("Preset");
    }

    private void GetAllIconSheetEntries()
    {
        iconSheetSelector.Items.Clear();
        iconSheetsTpf = TPF.Read(iconSheetsTpfPath);
        foreach (TPF.Texture sheet in iconSheetsTpf.Textures.Where(sheet => IsValidIconSheet(sheet.Name)))
            iconSheetSelector.Items.Add(Path.GetFileNameWithoutExtension(sheet.Name));
        if (!isGameDS3) layoutFilesBnd = BND4.Read(layoutFilesBndPath);
        useExistingSheetRadioButton.Checked = true;
        iconSheetSelector.SelectedIndex = isGameDS3 ? 9 : 5;
        iconPaddingNumBox.Value = isGameDS3 ? 0 : 3;
        maxIconsPerRowColNumBox.Value = 1;
        iconsWidthNumBox.Value = 160;
        iconsHeightNumBox.Value = 160;
        rowNumBox.Value = 1;
        columnNumBox.Value = 1;
        manualInsertLocationCheckbox.Checked = true;
        iconSheetCheckbox.Checked = true;
        hdIconsCheckbox.Checked = true;
        insertVerticallyCheckbox.Checked = !isGameDS3;
        insertVerticallyCheckbox.Enabled = !isGameDS3;
        manualInsertLocationCheckbox.Checked = isGameDS3;
        manualInsertLocationCheckbox.Enabled = !isGameDS3;
        postEffectsListBox.Nodes[0].Checked = true;
        postEffectsListBox.Nodes[0].Nodes[0].Checked = !isGameDS3;
    }

    private void BrowseIconImagesButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Filter = @"DDS File (*.dds)|*.dds",
            Title = @"Select Icon DDS Images",
            Multiselect = true
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        iconImagePaths = dialog.FileNames;
        iconImagesFolderPathLabel.Text = Path.GetDirectoryName(iconImagePaths[0]);
        if (iconImagePaths.Length == 0)
        {
            ShowInformationDialog("No icon images have been specified for use in automation.");
            return;
        }
        GetAllIconSheetEntries();
        ToggleAutomationControls(true);
    }

    private async Task WriteHDIcons()
    {
        statusLabel.Invoke(() => statusLabel.Text = @"Writing HD icons...");
        BXF4? hdIconsBhd = new();
        if (!isGameDS3)
        {
            hdIconsBhd = BXF4.Read(hdIconsBhdPath, hdIconsBdtPath);
            string backupHdIconsBhdPath = $"{hdIconsBhdPath}.bak";
            string backupHdIconsBtdPath = $"{hdIconsBdtPath}.bak";
            if (!File.Exists(backupHdIconsBhdPath))
                hdIconsBhd.Write(backupHdIconsBhdPath, backupHdIconsBtdPath);
        }
        foreach (string iconImagePath in iconImagePaths)
        {
            byte[] ddsBytes = await File.ReadAllBytesAsync(iconImagePath);
            DDS dds = new(ddsBytes);
            byte formatByte = 107;
            try
            {
                formatByte = (byte)Enum.Parse(typeof(TextureFormats), dds.header10.dxgiFormat.ToString());
            }
            catch { }
            string iconName = Path.GetFileNameWithoutExtension(iconImagePath);
            TPF iconTpf = new() { Compression = isGameDS3 ? DCX.Type.DCX_DFLT_10000_44_9 : DCX.Type.DCX_KRAK };
            IMagickImage<ushort> newHdIconImage = MagickImage.FromBase64(Convert.ToBase64String(ddsBytes));
            newHdIconImage = AddIconShadow(newHdIconImage);
            if (isGameDS3) newHdIconImage.Resize(512, 512);
            else newHdIconImage.Resize(1024, 1024);
            newHdIconImage.Sharpen();
            iconTpf.Textures.Add(new TPF.Texture(iconName, formatByte, 0x00, ConvertMagickImageToDDS(newHdIconImage)));
            if (isGameDS3) iconTpf.Write($"{knowledgeFolderPath}\\{iconName.ToLower()}.tpf.dcx");
            else
            {
                string iconEntryName = $"00_Solo\\{iconName}.tpf.dcx";
                BinderFile iconEntry = new(Binder.FileFlags.Flag1, hdIconsBhd.Files.Count, iconEntryName, iconTpf.Write());
                hdIconsBhd.Files.Add(iconEntry);
            }
        }
        if (!isGameDS3) hdIconsBhd.Write(hdIconsBhdPath, hdIconsBdtPath);
    }

    private static int GetIconIDFromName(string iconName)
    {
        int startIndex = iconName.LastIndexOf("_", StringComparison.Ordinal);
        int endIndex = iconName.IndexOf(".", StringComparison.Ordinal);
        if (startIndex == -1 || endIndex == -1) return -1;
        int.TryParse(iconName.Substring(startIndex + 1, endIndex - (startIndex + 1)), out int id);
        if (id == 0) return -1;
        return id;
    }

    private IMagickImage<ushort> AddIconShadow(IMagickImage<ushort> iconImage)
    {
        if (!postEffectsListBox.Nodes[0].Checked) return iconImage;
        bool useERStyle = postEffectsListBox.Nodes[0].Nodes[0].Checked;
        IMagickImage<ushort> shadowImage = iconImage.Clone();
        if (!useERStyle)
        {
            shadowImage.Resize(new Percentage(0), new Percentage(30));
            shadowImage.BackgroundColor = MagickColors.Transparent;
            shadowImage.Shear(8, 0);
        }
        shadowImage.Colorize(MagickColors.Black, new Percentage(100));
        shadowImage.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, 0.45);
        if (useERStyle)
        {
            double blurAmount = 0.00625 * shadowImage.Width;
            shadowImage.Blur(blurAmount, blurAmount);
            iconImage.Composite(shadowImage, (int)(shadowImage.Width * 0.03), (int)(shadowImage.Height * 0.01), CompositeOperator.DstOver);
        }
        else
        {
            shadowImage.Sharpen(1, 5);
            iconImage.Composite(shadowImage, Gravity.Southwest, 0, (int)(shadowImage.Height * 0.30), CompositeOperator.DstOver);
        }
        return iconImage;
    }

    private void AddIconToIconSheet(int layoutEntryCounter, int x, int y, int width, int height)
    {
        byte[] newIconImageBytes = File.ReadAllBytes(iconImagePaths[iconImagePaths.Length - layoutEntryCounter - 1]);
        IMagickImage<ushort> newIconImage = MagickImage.FromBase64(Convert.ToBase64String(newIconImageBytes));
        newIconImage.Resize(width, height);
        newIconImage.Sharpen();
        newIconImage = AddIconShadow(newIconImage);
        if (x >= iconSheet.Width || x + width >= iconSheet.Width)
            iconSheet.Extent(iconSheet.Width + width, iconSheet.Height, MagickColors.Transparent);
        else if (y >= iconSheet.Height || y + height >= iconSheet.Height)
            iconSheet.Extent(iconSheet.Width, iconSheet.Height + height, MagickColors.Transparent);
        iconSheet.Composite(newIconImage, x, y, CompositeOperator.Replace);
    }

    private static byte[] ConvertMagickImageToDDS(IMagickImage image)
    {
        MemoryStream ogDdsStream = new();
        image.Write(ogDdsStream, MagickFormat.Dds);
        Surface ddsSurface = DdsFile.Load(ogDdsStream.ToArray());
        MemoryStream recomDdsStream = new();
        DdsFile.Save(recomDdsStream, DdsFileFormat.BC7, DdsErrorMetric.Perceptual, BC7CompressionSpeed.Fast,
            false, false, ResamplingAlgorithm.Bicubic, ddsSurface, null);
        return recomDdsStream.ToArray();
    }

    private static void WriteIconSheetTpf(string iconSheetName, int iconSheetEntryIndex)
    {
        if (iconSheetEntryIndex == iconSheetsTpf.Textures.Count)
        {
            string lastIconSheetEntry = JsonSerializer.Serialize(iconSheetsTpf.Textures[^1]);
            iconSheetsTpf.Textures.Add(JsonSerializer.Deserialize<TPF.Texture>(lastIconSheetEntry));
        }
        iconSheetsTpf.Textures[iconSheetEntryIndex].Name = iconSheetName;
        iconSheetsTpf.Textures[iconSheetEntryIndex].Bytes = ConvertMagickImageToDDS(iconSheet);
        iconSheetsTpf.Write(iconSheetsTpfPath);
    }

    private void BackupIconSheetTpf()
    {
        string backupIconSheetsTpfPath = iconSheetsTpfPath.Replace(".dcx", ".dcx.bak");
        if (File.Exists(backupIconSheetsTpfPath)) return;
        statusLabel.Invoke(() => statusLabel.Text = @"Creating backup of common TPF...");
        iconSheetsTpf.Write(backupIconSheetsTpfPath);
    }

    private static int ReadIconSheetTpf(string iconSheetName)
    {
        TPF.Texture? iconSheetEntry = iconSheetsTpf.FirstOrDefault(i => i.Name.Contains(iconSheetName));
        if (iconSheetEntry == null)
        {
            ShowInformationDialog($"The icon sheet entry, {iconSheetName}, could not be found.");
            return -1;
        }
        int iconSheetEntryIndex = iconSheetsTpf.Textures.IndexOf(iconSheetEntry);
        string iconSheetBase64 = Convert.ToBase64String(iconSheetEntry.Bytes);
        iconSheet = MagickImage.FromBase64(iconSheetBase64);
        return iconSheetEntryIndex;
    }

    private static int ReadLayoutFile(string iconSheetName)
    {
        if (isGameDS3) return -1;
        string backupLayoutFilesBndPath = layoutFilesBndPath.Replace(".dcx", ".dcx.bak");
        if (!File.Exists(backupLayoutFilesBndPath)) layoutFilesBnd.Write(backupLayoutFilesBndPath);
        BinderFile? layoutFileEntry = layoutFilesBnd.Files.FirstOrDefault(i => i.Name.Contains(iconSheetName));
        if (layoutFileEntry == null)
        {
            ShowInformationDialog($"The layout file entry, {iconSheetName}, could not be found.");
            return -1;
        }
        int layoutFileEntryIndex = layoutFilesBnd.Files.IndexOf(layoutFileEntry);
        string layoutFileStr = Encoding.UTF8.GetString(layoutFileEntry.Bytes);
        layoutFile = XDocument.Parse(layoutFileStr).Root;
        if (layoutFile != null) return layoutFileEntryIndex;
        ShowInformationDialog($"The layout file, ${iconSheetName}, could not be parsed.");
        return -1;
    }

    private void WriteIconSheet(string iconSheetName, int padding, int maxIconsPerRowCol)
    {
        BackupIconSheetTpf();
        int iconSheetEntryIndex;
        if (generateNewSheetRadioButton.Checked)
        {
            iconSheetEntryIndex = iconSheetsTpf.Textures.Count;
            iconSheet = new MagickImage(MagickColors.Transparent, (int)sheetSizeXNumBox.Value, (int)sheetSizeYNumBox.Value);
        }
        else iconSheetEntryIndex = ReadIconSheetTpf(iconSheetName);
        if (iconSheetEntryIndex == -1) return;
        statusLabel.Invoke(() => statusLabel.Text = $@"Writing {iconSheetName}...");
        int.TryParse(iconsWidthNumBox.Value.ToString(CultureInfo.InvariantCulture), out int iconsWidth);
        int.TryParse(iconsHeightNumBox.Value.ToString(CultureInfo.InvariantCulture), out int iconsHeight);
        if (iconsWidth == 0) iconsWidth = 160;
        if (iconsHeight == 0) iconsHeight = 160;
        int iconsWidthWithPadding = iconsWidth + padding;
        int iconsHeightWithPadding = iconsHeight + padding;
        int newEntryCount = iconImagePaths.Length;
        // TODO: WIP
        /*
        int layoutFileEntryIndex = ReadLayoutFile(iconSheetName);
        XElement lastLayoutEntry = (XElement)layoutFile?.Nodes().OrderBy(i =>
            int.Parse(((XElement)i).Attribute("x")?.Value.ToString()!)).ThenBy(i =>
            int.Parse(((XElement)i).Attribute("y")?.Value.ToString()!)).LastOrDefault()!;
        */
        int lastEntryX = 0, lastEntryY = 0;
        // TODO: WIP
        /*
        if (manualInsertLocationCheckbox.Checked)
        {
            int lastEntryRowNum = (int)rowNumBox.Value;
            int lastEntryColumnNum = (int)columnNumBox.Value;
            lastEntryX = iconsWidthWithPadding * (lastEntryColumnNum - (insertVerticallyCheckbox.Checked ? 0 : 1)) - iconsWidthWithPadding;
            lastEntryY = iconsHeightWithPadding * (lastEntryRowNum - (insertVerticallyCheckbox.Checked ? 1 : 0)) - iconsHeightWithPadding;
        }
        else if (!isGameDS3)
        {
            lastEntryX = int.Parse(lastLayoutEntry.Attribute("x")?.Value!);
            lastEntryY = int.Parse(lastLayoutEntry.Attribute("y")?.Value!);
        }
        string layoutEntryIdentifier = iconSheetName.Contains("Status") ? "MENU_StatusIcon" : "MENU_ItemIcon";
        */
        while (newEntryCount > 0)
        {
            newEntryCount--;
            if (insertVerticallyCheckbox.Checked)
            {
                lastEntryY += iconsHeightWithPadding;
                if (lastEntryY / iconsHeightWithPadding >= maxIconsPerRowCol)
                {
                    lastEntryY = 0;
                    lastEntryX += iconsWidthWithPadding;
                }
            }
            else
            {
                lastEntryX += iconsWidthWithPadding;
                if (lastEntryX / iconsWidthWithPadding >= maxIconsPerRowCol)
                {
                    lastEntryX = 0;
                    lastEntryY += iconsHeightWithPadding;
                }
            }
            // TODO: WIP
            /*
            if (!isGameDS3)
            {
                string newEntryName = Path.GetFileName(iconImagePaths[^(newEntryCount + 1)]);
                XElement newEntry = new(lastLayoutEntry);
                int newEntryId = GetIconIDFromName(newEntryName);
                newEntry.Attribute("name")!.Value = $"{layoutEntryIdentifier}_{newEntryId}.png";
                newEntry.Attribute("y")!.Value = lastEntryY.ToString();
                newEntry.Attribute("x")!.Value = lastEntryX.ToString();
                newEntry.Attribute("width")!.Value = iconsWidth.ToString();
                newEntry.Attribute("height")!.Value = iconsHeight.ToString();
                layoutFile?.Add(newEntry);
            }
            */
            AddIconToIconSheet(newEntryCount, lastEntryX, lastEntryY, iconsWidth, iconsHeight);
        }
        // TODO: WIP
        /*
        if (!isGameDS3)
        {
            layoutFilesBnd.Files[layoutFileEntryIndex].Bytes = Encoding.UTF8.GetBytes(layoutFile?.ToString()!);
            layoutFilesBnd.Write(layoutFilesBndPath);
        }
        */
        WriteIconSheetTpf(iconSheetName, iconSheetEntryIndex);
    }

    private void ToggleAutomationControls(bool wantsEnabled)
    {
        gameModFolderGroupBox.Invoke(() => gameModFolderGroupBox.Enabled = wantsEnabled);
        iconImagesGroupBox.Invoke(() => iconImagesGroupBox.Enabled = wantsEnabled);
        iconsConfigGroupBox.Invoke(() => iconsConfigGroupBox.Enabled = wantsEnabled);
        automateButton.Invoke(() => automateButton.Enabled = wantsEnabled);
    }

    private static bool VerifyIconImagesIntegrity()
    {
        foreach (string iconImagePath in iconImagePaths)
        {
            string iconImageName = Path.GetFileName(iconImagePath);
            int iconImageId = GetIconIDFromName(iconImageName);
            if (iconImageId != -1) continue;
            ShowInformationDialog($"The icon entry, {iconImageName}, has no icon ID."
                + "\n\nAutomation cannot begin unless the file is renamed according to "
                + "this structure: \n\n\"MENU_Knowledge_[IconId].dds\"\n\n...excluding double quotes."
                + "\n\nPlease fix this issue, and then proceed to restart the automation process.");
            return false;
        }
        return true;
    }

    private async void AutomateButton_Click(object sender, EventArgs e)
    {
        if (!iconSheetCheckbox.Checked && !hdIconsCheckbox.Checked)
        {
            ShowInformationDialog("At least one automation option must be selected (icon sheet and/or HD icons).");
            return;
        }
        string? selectedIconSheetName = useExistingSheetRadioButton.Checked ? iconSheetSelector.SelectedItem.ToString() : sheetNameTextBox.Text;
        if (selectedIconSheetName == null)
        {
            ShowInformationDialog("No icon sheet has been specified in the automation setup.");
            return;
        }
        await Task.Run(async () =>
        {
            if (!VerifyIconImagesIntegrity()) return;
            ToggleAutomationControls(false);
            statusLabel.Invoke(() => statusLabel.Visible = true);
            if (iconSheetCheckbox.Checked) WriteIconSheet(selectedIconSheetName, (int)iconPaddingNumBox.Value, (int)maxIconsPerRowColNumBox.Value);
            if (hdIconsCheckbox.Checked) await WriteHDIcons();
            statusLabel.Invoke(() => statusLabel.Text = @"Automation complete!");
            await Task.Delay(2000);
            statusLabel.Invoke(() => statusLabel.Visible = false);
            ToggleAutomationControls(true);
        });
    }

    private static string[] GetAllFolderFiles(string folderPath, string fileType = "*.*")
    {
        try
        {
            return Directory.GetFiles(folderPath, fileType, SearchOption.AllDirectories);
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }

    private static bool ResourceExists(string path, string dispName)
    {
        bool doesExist = Path.HasExtension(path) && File.Exists(path) || Directory.Exists(path);
        if (!doesExist) ShowInformationDialog($"The {dispName} could not be found.");
        return doesExist;
    }

    private void BrowseGameModFolderButton_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dialog = new()
        {
            Description = @"Open Game/Mod Folder",
            UseDescriptionForTitle = true
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        gameModFolderPath = dialog.SelectedPath;
        string[] gameModFolderFiles = GetAllFolderFiles(gameModFolderPath);
        iconSheetsTpfPath = gameModFolderFiles.FirstOrDefault(i => i.Contains("01_common.tpf")) ?? "";
        knowledgeFolderPath = Path.GetDirectoryName(gameModFolderFiles.FirstOrDefault(i => i.Contains("\\knowledge\\"))) ?? "";
        if (knowledgeFolderPath != "") isGameDS3 = true;
        else
        {
            isGameDS3 = false;
            layoutFilesBndPath = gameModFolderFiles.FirstOrDefault(i => i.Contains("01_common.sblytbnd")) ?? "";
            hdIconsBhdPath = gameModFolderFiles.FirstOrDefault(i => i.Contains("00_solo.tpfbhd")) ?? "";
            hdIconsBdtPath = hdIconsBhdPath.Replace(".tpfbhd", ".tpfbdt");
        }
        if (!ResourceExists(iconSheetsTpfPath, "icon sheets TPF")) return;
        if (!isGameDS3)
        {
            if (!ResourceExists(layoutFilesBndPath, "layout files BND")) return;
            if (!ResourceExists(hdIconsBhdPath, "HD icons BHD")) return;
            if (!ResourceExists(hdIconsBdtPath, "HD icons BDT")) return;
        }
        else if (!ResourceExists(knowledgeFolderPath, "knowledge folder")) return;
        gameModFolderPathLabel.Text = Path.GetDirectoryName(iconSheetsTpfPath);
        if (iconImagePaths.Length == 0) iconImagesGroupBox.Enabled = true;
        else GetAllIconSheetEntries();
    }

    private void ManualInsertLocationCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        insertLocationGroupBox.Enabled = manualInsertLocationCheckbox.Checked;
    }

    private void IconSheetCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        wantsIconSheet = !wantsIconSheet;
        iconSheetGroupBox.Enabled = wantsIconSheet;
    }

    private void HDIconsCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        wantsHdIcons = !wantsHdIcons;
    }

    private void UseExistingSheetRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        iconSheetSelector.Enabled = true;
        newSheetGroupBox.Enabled = false;
    }

    private void GenerateNewSheetRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        iconSheetSelector.Enabled = false;
        newSheetGroupBox.Enabled = true;
    }

    private enum TextureFormats
    {
        DXT1 = 0,
        BC7_UNORM = 107,
        ATI1 = 103,
        ATI2 = 104,
        ATI3 = 103
    }
}