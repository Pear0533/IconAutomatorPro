using System.Globalization;
using System.Text;
using System.Xml.Linq;
using DdsFileTypePlus;
using ImageMagick;
using PaintDotNet;
using SoulsFormats;

// ReSharper disable UnusedMember.Local

namespace IconAutomatorPro;

public partial class Form1 : Form
{
    private static string gameModFolderPath = "";
    private static string layoutFilesBndPath = "";
    private static string iconSheetsTpfPath = "";
    private static string hdIconsBhdPath = "";
    private static string hdIconsBdtPath = "";
    private static BND4 layoutFilesBnd = new();
    private static TPF iconSheetsTpf = new();
    private static XElement? layoutFile;
    private static string[] iconImagePaths = { };
    private static IMagickImage<ushort> iconSheet = new MagickImage();
    private const string version = "1.3";

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

    private void GetAllLayoutFileEntries()
    {
        if (File.Exists(layoutFilesBndPath) && BND4.Is(layoutFilesBndPath))
        {
            layoutFilesBnd = BND4.Read(layoutFilesBndPath);
            layoutFileSelector.Items.Clear();
            foreach (BinderFile layoutFileEntry in layoutFilesBnd.Files.Where(i => i.Name.Contains("Icon") || i.Name.Contains("Status")))
                layoutFileSelector.Items.Add(Path.GetFileNameWithoutExtension(layoutFileEntry.Name));
            layoutFileSelector.SelectedIndex = layoutFileSelector.Items.IndexOf("SB_Icon_03");
            iconPaddingNumBox.Value = 3;
            maxNumRowsNumBox.Value = 43;
            iconsWidthNumBox.Value = 160;
            iconsHeightNumBox.Value = 160;
        }
        else
        {
            ShowInformationDialog("Could not detect the layout files BND file.");
            Environment.Exit(1);
        }
    }

    private void BrowseIconImagesButton_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = @"DDS File (*.dds)|*.dds", Multiselect = true };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        iconImagePaths = dialog.FileNames;
        iconImagesFolderPathLabel.Text = Path.GetDirectoryName(iconImagePaths[0]);
        if (iconImagePaths.Length == 0)
        {
            ShowInformationDialog("No icon images have been specified for use in automation.");
            return;
        }
        GetAllLayoutFileEntries();
        ToggleAutomationControls(true);
    }

    private async Task WriteHDIconsBHD()
    {
        if (!File.Exists(hdIconsBhdPath) || !BXF4.IsBHD(hdIconsBhdPath))
        {
            ShowInformationDialog("Could not detect the HD icons BHD file.");
            return;
        }
        statusLabel.Invoke(() => statusLabel.Text = @"Writing 00_Solo BHD...");
        BXF4 hdIconsBhd = BXF4.Read(hdIconsBhdPath, hdIconsBdtPath);
        var backupHdIconsBhdPath = $"{hdIconsBhdPath}.bak";
        var backupHdIconsBtdPath = $"{hdIconsBdtPath}.bak";
        if (!File.Exists(backupHdIconsBhdPath))
            hdIconsBhd.Write(backupHdIconsBhdPath, backupHdIconsBtdPath);
        foreach (string iconImagePath in iconImagePaths)
        {
            byte[] ddsBytes = await File.ReadAllBytesAsync(iconImagePath);
            var dds = new DDS(ddsBytes);
            byte formatByte = 107;
            try
            {
                formatByte = (byte)Enum.Parse(typeof(TextureFormats), dds.header10.dxgiFormat.ToString());
            }
            catch { }
            string iconName = Path.GetFileNameWithoutExtension(iconImagePath);
            var iconTpf = new TPF { Compression = DCX.Type.DCX_KRAK };
            iconTpf.Textures.Add(new TPF.Texture(iconName, formatByte, 0x00, ddsBytes));
            var iconEntryName = $"00_Solo\\{iconName}.tpf.dcx";
            var iconEntry = new BinderFile(Binder.FileFlags.Flag1, hdIconsBhd.Files.Count, iconEntryName, iconTpf.Write());
            hdIconsBhd.Files.Add(iconEntry);
        }
        hdIconsBhd.Write(hdIconsBhdPath, hdIconsBdtPath);
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

    private static void AddIconToIconSheet(int layoutEntryCounter, int x, int y, int width, int height)
    {
        byte[] newIconImageBytes = File.ReadAllBytes(iconImagePaths[iconImagePaths.Length - layoutEntryCounter - 1]);
        IMagickImage<ushort> newIconImage = MagickImage.FromBase64(Convert.ToBase64String(newIconImageBytes));
        newIconImage.Resize(width, height);
        newIconImage.Sharpen();
        iconSheet.Composite(newIconImage, x, y, CompositeOperator.Replace);
    }

    private static void WriteIconSheet(int iconSheetEntryIndex)
    {
        var ogIconSheetDdsStream = new MemoryStream();
        iconSheet.Write(ogIconSheetDdsStream, MagickFormat.Dds);
        Surface iconSheetDdsSurface = DdsFile.Load(ogIconSheetDdsStream.ToArray());
        var recomIconSheetDdsStream = new MemoryStream();
        DdsFile.Save(recomIconSheetDdsStream, DdsFileFormat.BC7, DdsErrorMetric.Perceptual, BC7CompressionSpeed.Fast, false, false, ResamplingAlgorithm.Bicubic,
            iconSheetDdsSurface, null);
        iconSheetsTpf.Textures[iconSheetEntryIndex].Bytes = recomIconSheetDdsStream.ToArray();
        iconSheetsTpf.Write(iconSheetsTpfPath);
    }

    private int ReadIconSheet(string selectedLayoutFileName)
    {
        if (!File.Exists(iconSheetsTpfPath) || !TPF.Is(iconSheetsTpfPath)) return -1;
        iconSheetsTpf = TPF.Read(iconSheetsTpfPath);
        string backupIconSheetsTpfPath = iconSheetsTpfPath.Replace(".dcx", ".dcx.bak");
        if (!File.Exists(backupIconSheetsTpfPath))
        {
            statusLabel.Invoke(() => statusLabel.Text = @"Creating backup of common TPF...");
            iconSheetsTpf.Write(backupIconSheetsTpfPath);
        }
        TPF.Texture? iconSheetEntry = iconSheetsTpf.FirstOrDefault(i => i.Name.Contains(selectedLayoutFileName));
        if (iconSheetEntry == null)
        {
            ShowInformationDialog($"The icon sheet entry, {selectedLayoutFileName}, could not be found.");
            return -1;
        }
        int iconSheetEntryIndex = iconSheetsTpf.Textures.IndexOf(iconSheetEntry);
        string iconSheetBase64 = Convert.ToBase64String(iconSheetEntry.Bytes);
        iconSheet = MagickImage.FromBase64(iconSheetBase64);
        return iconSheetEntryIndex;
    }

    private void WriteLayoutFile(string selectedLayoutFileName, int padding, int maxNumRows)
    {
        int iconSheetEntryIndex = ReadIconSheet(selectedLayoutFileName);
        if (iconSheetEntryIndex == -1) return;
        string backupLayoutFilesBndPath = layoutFilesBndPath.Replace(".dcx", ".dcx.bak");
        if (!File.Exists(backupLayoutFilesBndPath)) layoutFilesBnd.Write(backupLayoutFilesBndPath);
        statusLabel.Invoke(() => statusLabel.Text = $@"Writing {selectedLayoutFileName}...");
        BinderFile? layoutFileEntry = layoutFilesBnd.Files.FirstOrDefault(i => i.Name.Contains(selectedLayoutFileName));
        if (layoutFileEntry == null)
        {
            ShowInformationDialog($"The layout file entry, {selectedLayoutFileName}, could not be found.");
            return;
        }
        int layoutFileEntryIndex = layoutFilesBnd.Files.IndexOf(layoutFileEntry);
        string layoutFileStr = Encoding.UTF8.GetString(layoutFileEntry.Bytes);
        layoutFile = XDocument.Parse(layoutFileStr).Root;
        if (layoutFile == null)
        {
            ShowInformationDialog($"The layout file, ${selectedLayoutFileName}, could not be parsed.");
            return;
        }
        var lastEntry = (XElement)layoutFile.Nodes().OrderBy(i =>
            int.Parse(((XElement)i).Attribute("x")?.Value.ToString()!)).ThenBy(i =>
            int.Parse(((XElement)i).Attribute("y")?.Value.ToString()!)).LastOrDefault()!;
        int lastEntryX = int.Parse(lastEntry.Attribute("x")?.Value!);
        int lastEntryY = int.Parse(lastEntry.Attribute("y")?.Value!);
        int.TryParse(iconsWidthNumBox.Value.ToString(CultureInfo.InvariantCulture), out int iconsWidth);
        int.TryParse(iconsHeightNumBox.Value.ToString(CultureInfo.InvariantCulture), out int iconsHeight);
        if (iconsWidth == 0) iconsWidth = 160;
        if (iconsHeight == 0) iconsHeight = 160;
        iconsWidth += padding;
        iconsHeight += padding;
        int newEntryCount = iconImagePaths.Length;
        while (newEntryCount > 0)
        {
            newEntryCount--;
            string newEntryName = Path.GetFileName(iconImagePaths[^(newEntryCount + 1)]);
            var newEntry = new XElement(lastEntry);
            int newEntryId = GetIconIDFromName(newEntryName);
            lastEntryY += iconsHeight;
            if (lastEntryY / iconsHeight >= maxNumRows)
            {
                lastEntryY = 0;
                lastEntryX += iconsWidth;
            }
            newEntry.Attribute("name")!.Value = $"MENU_ItemIcon_{newEntryId}.png";
            newEntry.Attribute("y")!.Value = lastEntryY.ToString();
            newEntry.Attribute("x")!.Value = lastEntryX.ToString();
            layoutFile.Add(newEntry);

            AddIconToIconSheet(newEntryCount, lastEntryX, lastEntryY, iconsWidth, iconsHeight);
        }
        layoutFilesBnd.Files[layoutFileEntryIndex].Bytes = Encoding.UTF8.GetBytes(layoutFile.ToString());
        layoutFilesBnd.Write(layoutFilesBndPath);
        WriteIconSheet(iconSheetEntryIndex);
    }

    private void ToggleAutomationControls(bool wantsEnabled)
    {
        gameModFolderGroupBox.Invoke(() => gameModFolderGroupBox.Enabled = wantsEnabled);
        iconImagesGroupBox.Invoke(() => iconImagesGroupBox.Enabled = wantsEnabled);
        layoutFileGroupBox.Invoke(() => layoutFileGroupBox.Enabled = wantsEnabled);
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
        var selectedLayoutFileName = layoutFileSelector.SelectedItem.ToString();
        if (selectedLayoutFileName == null)
        {
            ShowInformationDialog("No layout file has been specified in the automation setup.");
            return;
        }
        await Task.Run(async () =>
        {
            if (!VerifyIconImagesIntegrity()) return;
            ToggleAutomationControls(false);
            statusLabel.Invoke(() => statusLabel.Visible = true);
            WriteLayoutFile(selectedLayoutFileName, (int)iconPaddingNumBox.Value, (int)maxNumRowsNumBox.Value);
            await WriteHDIconsBHD();
            statusLabel.Invoke(() => statusLabel.Text = @"Automation complete!");
            await Task.Delay(2000);
            statusLabel.Invoke(() => statusLabel.Visible = false);
            ToggleAutomationControls(true);
        });
    }

    private void BrowseGameModFolderButton_Click(object sender, EventArgs e)
    {
        var dialog = new FolderBrowserDialog
        {
            Description = @"Open ([Game/Mod Folder]/menu/hi)",
            UseDescriptionForTitle = true
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        gameModFolderPath = dialog.SelectedPath;
        layoutFilesBndPath = $"{gameModFolderPath}\\01_common.sblytbnd.dcx";
        iconSheetsTpfPath = $"{gameModFolderPath}\\01_common.tpf.dcx";
        hdIconsBhdPath = $"{gameModFolderPath}\\00_solo.tpfbhd";
        hdIconsBdtPath = hdIconsBhdPath.Replace(".tpfbhd", ".tpfbdt");
        if (!File.Exists(layoutFilesBndPath))
        {
            ShowInformationDialog("The layout files BND is missing from the folder.");
            return;
        }
        if (!File.Exists(iconSheetsTpfPath))
        {
            ShowInformationDialog("The icon sheets TPF is missing from the folder.");
            return;
        }
        if (!File.Exists(hdIconsBhdPath))
        {
            ShowInformationDialog("The 00_Solo BHD is missing from the folder.");
            return;
        }
        if (!File.Exists(hdIconsBdtPath))
        {
            ShowInformationDialog("The 00_Solo BDT is missing from the folder.");
            return;
        }
        gameModFolderPathLabel.Text = dialog.SelectedPath;
        iconImagesGroupBox.Enabled = true;
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