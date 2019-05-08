using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.IO;
using System.Xml.Linq;
namespace GenderRecognition
{
    public partial class Form1 : Form
    {
        EigenFaceRecognizer facess;
        InputArray InputImage;
        InputArray inputLabel;
        
        public Form1()
        {
            InitializeComponent();
        }

        async Task learnAsync()
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
                        if (number <= 50)
                        {
                            faceLabels[i] = 1;
                        }
                        else
                        {
                            faceLabels[i] = 0;
                        }

                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                }
            }
        }
        private async Task<string> LearnMale()
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
            return "Database Male Has Been Loaded";
        }
        private async Task<string> LearnFemale()
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
                        faceLabels[i] = 1;
                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                }
            }
            return "Database Female Has Been Loaded";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> imgInput = new Image<Bgr, byte>(open.FileName);
                    long detectionTime;
                    List<Rectangle> faces = new List<Rectangle>();
                    List<Rectangle> eyes = new List<Rectangle>();
                    List<Rectangle> gender = new List<Rectangle>();




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
                            MessageBox.Show("Wanita");
                        }
                        else if (predictedLabel.Label == 1)
                        {
                            MessageBox.Show("Pria");
                        }
                        else
                        {
                            MessageBox.Show("Please Train Me");
                        }
                    }
                    else if (faces.Count() > 1)
                    {
                        MessageBox.Show("Kelompok");
                    }
                    else
                    {
                        MessageBox.Show("No Face Detected");
                    }


                    ImageViewer imageViewer = new ImageViewer();
                    imageViewer.Image = imgInput;
                    imageViewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            facess = new EigenFaceRecognizer(48, double.PositiveInfinity);
            learnAsync();
        }
    }
}
