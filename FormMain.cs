using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Microsoft.WindowsAPICodePack.Dialogs;
using ClosedXML.Excel;
using System.Drawing.Imaging;
using LinqToExcel;
using System.Diagnostics;

namespace GenderRecognition
{
    public partial class FormMain : Form
    {
        public class sourceFolderModel
        {
            public bool isChecked { get; set; }
            public string name { get; set; }
            public byte[] Image { get; set; }
            public string gender { get; set; }
            public string Path { get; set; }
        }

        public class sourceExcelModel
        {
            public bool isChecked { get; set; }
            public string name { get; set; }
            public string Update { get; set; }
            public string URL { get; set; }
            public Image Image { get; set; }
            public string gender { get; set; }
        }

        EigenFaceRecognizer facess;
        string selectedFolder = "";
        string selectedFile = "";
        string _folderDownload = "";
        string _lastDirectory = "";
        string _methodCheckGender = "";
        DataTable dataTable;
        List<sourceFolderModel> sourceFolderModels = new List<sourceFolderModel>();
        List<sourceExcelModel> sourceExcelModels = new List<sourceExcelModel>();
        List<sourceExcelModel> newSource;
        int rowSelected = 0;
        bool IsFullDownload = false;
        public FormMain()
        {
            InitializeComponent();
        }

        #region "Learn"
        public void learnAsync()
        {
            Learn();
        }

        private void Learn()
        {
            var database_male = Application.StartupPath + "/Foto/";
            if (Directory.Exists(database_male))
            {
                int fileCount = Directory.GetFiles(database_male, "*.jpg", SearchOption.AllDirectories).Length;
                if (fileCount > 0)
                {
                    var faceImages = new Mat[fileCount];
                    var faceLabels = new int[fileCount];
                    DirectoryInfo d = new DirectoryInfo(database_male);
                    FileInfo[] Files = d.GetFiles("*.jpg");
                    int i = 0;
                    foreach (FileInfo file in Files)
                    {
                        Mat imgMat = new Mat(database_male + "\\" + file.Name, ImreadModes.Grayscale);
                        CvInvoke.Resize(imgMat, imgMat, new Size(48, 48), 0, 0, Inter.Linear);
                        faceImages[i] = imgMat;
                        int number = Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name));
                        if (number <= 1000000)
                        {
                            faceLabels[i] = 1; //pria
                        }
                        else
                        {
                            faceLabels[i] = 0; //wanita
                        }
                        
                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                    facess.Write(Application.StartupPath + "\\FaceTrained.xml");
                }
            }
        }

        private void LearnMale()
        {
            var database_male = Application.StartupPath + "/Foto/Male";
            if (Directory.Exists(database_male))
            {
                int fileCount = Directory.GetFiles(database_male, "*.jpg", SearchOption.AllDirectories).Length;
                if (fileCount > 0)
                {
                    var faceImages = new Mat[fileCount];
                    var faceLabels = new int[fileCount];
                    DirectoryInfo d = new DirectoryInfo(database_male);
                    FileInfo[] Files = d.GetFiles("*.jpg");
                    int i = 0;
                    foreach (FileInfo file in Files)
                    {
                        Mat imgMat = new Mat(database_male + "\\" + file.Name, ImreadModes.Grayscale);
                        CvInvoke.Resize(imgMat, imgMat, new Size(48, 48), 0, 0, Inter.Linear);
                        faceImages[i] = imgMat;
                        faceLabels[i] = 1;
                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                }
            }
        }
        private void LearnFemale()
        {
            var database_female = Application.StartupPath + "/Foto/Female";
            if (Directory.Exists(database_female))
            {
                int fileCount = Directory.GetFiles(database_female, "*.jpg", SearchOption.AllDirectories).Length;
                if (fileCount > 0)
                {
                    var faceImages = new Mat[fileCount];
                    var faceLabels = new int[fileCount];
                    DirectoryInfo d = new DirectoryInfo(database_female);
                    FileInfo[] Files = d.GetFiles("*.jpg");
                    int i = 0;
                    foreach (FileInfo file in Files)
                    {
                        Mat imgMat = new Mat(database_female + "\\" + file.Name, ImreadModes.Grayscale);
                        CvInvoke.Resize(imgMat, imgMat, new Size(48, 48), 0, 0, Inter.Linear);
                        faceImages[i] = imgMat;
                        faceLabels[i] = 0;
                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                }
            }
        }
        #endregion
        #region "ReadData"
        public async void readExcelAsync(string filePath)
        {
            IsFullDownload = true;
            foreach (var _data in sourceExcelModels)
            {
                if (File.Exists(_folderDownload + "\\" + _data.name + ".jpg"))
                {
                    if (File.ReadAllBytes(_folderDownload + "\\" + _data.name + ".jpg").Length > 0)
                    {
                        _data.Image = Image.FromFile(_folderDownload + "\\" + _data.name + ".jpg");
                        _data.gender = await CheckGender(_folderDownload + "\\" + _data.name + ".jpg");
                    }
                }
                    
            }
        }
        public async Task downloadImageAsync(string filePath)
        {
            var _baseName = Path.GetFileNameWithoutExtension(filePath);
            var source = new ExcelQueryFactory(filePath);
            try
            {
                sourceExcelModels = (from x in source.Worksheet()

                                     select new sourceExcelModel()
                                     {
                                         isChecked = false,
                                         name = x["Number"],
                                         Update = x["Update"],
                                         URL = x["Url"],
                                         Image = null,
                                         gender = ""
                                     }).ToList();
            }
            catch (Exception LinqEx)
            {
                if (LinqEx.Message.Contains("Sheet1"))
                {
                    MessageBox.Show("Please Change Name Sheeet To Sheet1");
                    return;
                }

            }

            _folderDownload = @"D:\" + _baseName;
            System.IO.Directory.CreateDirectory(_folderDownload);
            foreach (var _data in sourceExcelModels)
            {
                var webClient = new WebClient();
                if (!String.IsNullOrEmpty(_data.URL))
                {
                    try
                    {
                        await webClient.DownloadFileTaskAsync(new Uri(_data.URL), _folderDownload + "\\" + _data.name + ".jpg");

                    }
                    catch (WebException Ex)
                    {
                        var a = Ex.Message.ToString();
                        continue;
                    }
                }
            }
        }
        public async void readFolderAsync(string folderPath)
        {
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            dataTable = new DataTable();
            int fileCount = Directory.GetFiles(folderPath, "*.jpg", SearchOption.AllDirectories).Length;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (fileCount > 0)
            {
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Image", typeof(Image));
                DirectoryInfo d = new DirectoryInfo(folderPath);
                FileInfo[] Files = d.GetFiles("*.jpg");
                sourceFolderModels = (
                from ic in Files
                select new sourceFolderModel()
                {
                    isChecked = false,
                    name = Path.GetFileNameWithoutExtension(ic.Name),
                    Image = File.ReadAllBytes(selectedFolder + "\\" + ic),
                    gender = "",
                    Path = selectedFolder + "\\" + ic

                }
                ).ToList();
                if (_methodCheckGender == "Automatic")
                {
                    foreach (var item in sourceFolderModels)
                    {
                        item.gender = await CheckGender(selectedFolder + "\\" + item.name + ".jpg");
                    }
                }

            }
            watch.Stop();
            MessageBox.Show("Take Time : " + (watch.ElapsedMilliseconds / 1000).ToString() + " (Seconds)");
        }
        #endregion
        #region "Export"
        public static Stream ToStream(Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sheet1");
            int index = 2;
            if (folderRB.Checked)
            {
                dgSourceFolder.EndEdit();
                //foreach (var item in sourceFolderModels.Where(x=>x.gender == comboBox1.Text))
                //{
                //    ws.Cell("A" + index).Value = item.name;
                //    ws.Cell("B" + index).Value = item.gender;
                //    index++;
                //}
                ws.Cell("A1").Value = "Number";
                ws.Cell("B1").Value = "Gender";
                foreach (DataGridViewRow item in dgSourceFolder.Rows)
                {
                    if (item.Cells[0].Value.ToString() == "True")
                    {
                        ws.Cell("A" + index).Value = item.Cells[1].Value.ToString();
                        ws.Cell("B" + index).Value = item.Cells[3].Value.ToString();
                        index++;
                    }
                    
                }
            }
            
            else
            {
                ws.Cell("A1").Value = "Number";
                ws.Cell("B1").Value = "Update";
                ws.Cell("C1").Value = "Gender";
                dgSourceExcel.EndEdit();
                foreach (DataGridViewRow item in dgSourceExcel.Rows)
                {
                    if (item.Cells[0].Value.ToString() == "True")
                    {
                        ws.Cell("A" + index).Value = item.Cells[1].Value.ToString();
                        ws.Cell("B" + index).Value = item.Cells[2].Value.ToString();
                        ws.Cell("C" + index).Value = item.Cells[5].Value.ToString();
                        index++;
                    }

                }
            }

            ws.Columns().AdjustToContents();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"D:\";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Excel |*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FilterIndex = 2;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data Has Been Saved");
            }
            
        }
        #endregion
        #region "Check Gender"
        private async Task <string> CheckGender(string filePath)
        {
            Image<Bgr, byte> imgInput = new Image<Bgr, byte>(filePath);
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            DetectFace.Detect(
              imgInput, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);
            foreach (Rectangle face in faces)
                CvInvoke.Rectangle(imgInput, face, new Bgr(Color.Red).MCvScalar, 2);
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(imgInput, eye, new Bgr(Color.Blue).MCvScalar, 2);
            CvInvoke.CvtColor(imgInput, imgInput, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);
            CvInvoke.Resize(imgInput, imgInput, new Size(48, 48), 0, 0, Inter.Linear);
            EigenFaceRecognizer.PredictionResult predictedLabel = facess.Predict(imgInput);
            if (faces.Count() == 1)
            {
                if (predictedLabel.Label == 0)
                {
                    return "Wanita";
                }
                else if (predictedLabel.Label == 1)
                {
                    return "Pria";
                }
                else
                {
                    return "Please Train Me!!";
                }
            }
            else if (faces.Count() > 0)
            {
                return "N/A";
            }
            else
            {
                return "N/A Because No Face Detection";
            }

        }
        #endregion
        #region "Event"
        private async void importBTN_ClickAsync(object sender, EventArgs e)
        {
            dgSourceFolder.AutoGenerateColumns = false;
            if (folderRB.Checked)
            {
                if (!String.IsNullOrEmpty(_methodCheckGender))
                {
                    CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                    dialog.InitialDirectory = selectedFolder == "" ? "C:\\Users" : selectedFolder;
                    dialog.IsFolderPicker = true;
                    dialog.RestoreDirectory = false;
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        selectedFolder = dialog.FileName;
                        sourceFolderBG.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Method Check Gender");
                }

            }
            else if (importRB.Checked)
            {
                if (!String.IsNullOrEmpty(_methodCheckGender))
                {
                    OpenFileDialog theDialog = new OpenFileDialog();
                    theDialog.Title = "Open Text File";
                    theDialog.Filter = "Files (xls,xlsx)|*.xls;*.xlsx";
                    theDialog.InitialDirectory = Application.StartupPath;
                    if (theDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFile = theDialog.FileName;
                        await downloadImageAsync(selectedFile);
                        sourceExcelBG.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Method Check Gender");
                }

            }
            else
            {
                MessageBox.Show("Please Choose Source First");
            }

        }
        private async void bunifuFlatButton1_ClickAsync(object sender, EventArgs e)
        {
            if (folderRB.Checked)
            {
                foreach (var item in sourceFolderModels)
                {
                    item.gender = await CheckGender(selectedFolder + "\\" + item.name + ".jpg");
                }
            }
            else if (importRB.Checked)
            {
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgSourceFolder.Columns.Add(imageCol);
                DataGridViewTextBoxColumn GenderCol = new DataGridViewTextBoxColumn();
                dgSourceFolder.Columns.Add(GenderCol);
                foreach (DataGridViewRow item in dgSourceFolder.Rows)
                {
                    string url = item.Cells[2].Value.ToString();
                    string filename = item.Cells[0].Value.ToString();
                    using (var webClient = new WebClient())
                    {
                        try
                        {
                            await webClient.DownloadFileTaskAsync(new Uri(url), @"D:\temp\" + filename + ".jpg");
                            item.Cells[3].Value = Image.FromFile(@"D:\temp\" + filename + ".jpg");
                            item.Cells[4].Value = CheckGender(@"D:\temp\" + filename + ".jpg");
                        }
                        catch (WebException wex)
                        {

                            if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                            {
                                continue;
                            }
                        }


                    }
                }
                MessageBox.Show("Finish Load URL");
            }
        }
        private async void FormMain_LoadAsync(object sender, EventArgs e)
        {
            dgSourceExcel.Visible = false;
            dgSourceFolder.Visible = false;
            facess = new EigenFaceRecognizer(48, double.PositiveInfinity);
            learnAsync();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (folderRB.Checked)
            {
                //dgSourceFolder.DataSource = null;
                switch (comboBox1.SelectedItem.ToString().Trim())
                {
                    case "All":
                        dgSourceFolder.DataSource = sourceFolderModels.ToList();
                        break;

                    case "Pria":
                        dgSourceFolder.DataSource = sourceFolderModels.Where(x => x.gender == "Pria").ToList();
                        break;
                    case "Wanita":
                        List<sourceFolderModel> _sourceFolderModels = sourceFolderModels.Where(x => x.gender == "Wanita").ToList();
                        dgSourceFolder.DataSource = _sourceFolderModels;
                        break;
                    case "Kelompok":
                        dgSourceFolder.DataSource = sourceFolderModels.Where(x => x.gender == "Kelompok").ToList();
                        break;
                    default:
                        dgSourceFolder.DataSource = sourceFolderModels.Where(x => x.gender == "N/A").ToList();
                        break;
                }
            }
            else
            {
                //dgSourceExcel.DataSource = null;
                switch (comboBox1.SelectedItem.ToString().Trim())
                {
                    case "All":
                        dgSourceExcel.DataSource = sourceExcelModels.ToList();
                        break;

                    case "Pria":
                        dgSourceExcel.DataSource = sourceExcelModels.Where(x => x.gender == "Pria").ToList();
                        break;
                    case "Wanita":
                        
                        dgSourceExcel.DataSource = sourceExcelModels.Where(x => x.gender == "Wanita").ToList(); ;
                        break;
                    case "Kelompok":
                        dgSourceExcel.DataSource = sourceExcelModels.Where(x => x.gender == "Kelompok").ToList();
                        break;
                    default:
                        dgSourceExcel.DataSource = sourceExcelModels.Where(x => x.gender == "N/A").ToList();
                        break;
                }
            }

        }
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (folderRB.Checked)
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    foreach (DataGridViewRow item in dgSourceFolder.Rows)
                    {
                        item.Cells[0].Value = true;
                    }
                }
                else
                {
                    foreach (DataGridViewRow item in dgSourceFolder.Rows)
                    {
                        item.Cells[0].Value = false;
                    }
                }
            }
            else if (importRB.Checked)
            {
                if (bunifuCheckbox1.Checked == true)
                {
                    foreach (DataGridViewRow item in dgSourceExcel.Rows)
                    {
                        item.Cells[0].Value = true;
                    }
                }
                else
                {
                    foreach (DataGridViewRow item in dgSourceExcel.Rows)
                    {
                        item.Cells[0].Value = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("No Data");
            }

        }
        #endregion
        #region "backgroundWorker"
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            readFolderAsync(selectedFolder);
        }

        private async void sourceExcelBG_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
       
            readExcelAsync(selectedFile);
        }

        private void sourceExcelBG_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Load Data From Excel Finish");
            if (IsFullDownload)
            {
                dgSourceExcel.DataSource = sourceExcelModels;
                dgSourceExcel.Visible = true;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Load Data From Folder Finish");
            dgSourceFolder.DataSource = sourceFolderModels;
            dgSourceFolder.Visible = true;
        }
        #endregion

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Learn();
            MessageBox.Show("Success Refresh Database");
        }

        private void dgSourceExcel_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    contextMenuStrip1.Show(dgSourceExcel, dgSourceExcel.PointToClient(Cursor.Position));
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void dgSourceFolder_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowSelected = e.RowIndex;
                dgSourceFolder.Rows[rowSelected].Selected = true;
                if (e.RowIndex != -1)
                {
                    contextMenuStrip1.Show(dgSourceFolder, dgSourceExcel.PointToClient(Cursor.Position));
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void learnMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (folderRB.Checked)
            {
                Image img = Image.FromFile(dgSourceFolder.CurrentRow.Cells[4].Value.ToString());
                FormLearningMaching formLearningMaching = new FormLearningMaching(img);
                formLearningMaching.ShowDialog();
                learnAsync();
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Bitmap img = (Bitmap)dgSourceExcel.CurrentRow.Cells[4].Value;
                img.Save(ms, ImageFormat.Jpeg);
                FormLearningMaching formLearningMaching = new FormLearningMaching(Image.FromStream(ms));
                formLearningMaching.ShowDialog();

            }
            
            
            
        }

        private async void checkGenderToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            if (folderRB.Checked)
            {
                dgSourceFolder.Rows[rowSelected].Cells[3].Value = await CheckGender(dgSourceFolder.Rows[rowSelected].Cells[4].Value.ToString());
            }
            else
            {

            }
        }

        private void automaticRB_CheckedChanged(object sender, EventArgs e)
        {
            _methodCheckGender = "Automatic";
        }

        private void manualRB_CheckedChanged(object sender, EventArgs e)
        {
            _methodCheckGender = "Manual";
        }

        private async void checkGenderBTN_ClickAsync(object sender, EventArgs e)
        {
            MessageBox.Show("Please Make Sure Checklist Data To Use Batch Check Gender");
            dgSourceFolder.EndEdit();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (DataGridViewRow item in dgSourceFolder.Rows)
            {
                if (item.Cells[0].Value.ToString() == "True")
                {
                    if (item.Cells[4].Value.ToString() != "")
                    {
                        item.Cells[3].Value = await CheckGender(item.Cells[4].Value.ToString());
                    }
                }
            }
            MessageBox.Show("Finish Check Gender : " + (watch.ElapsedMilliseconds / 1000).ToString() + " Seconds");
            foreach (DataGridViewRow item in dgSourceFolder.Rows)
            {
                item.Cells[0].Value = false;
            }
        }

        private void lbl_check_Click(object sender, EventArgs e)
        {

        }
    }
}
