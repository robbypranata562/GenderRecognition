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
using Emgu.CV.Util;
using System.IO;
using System.Xml.Linq;
namespace GenderRecognition
{
    public partial class Form1 : Form
    {
        FisherFaceRecognizer facess;
        public Form1()
        {
            InitializeComponent();
        }

        void learnAsync()
        {
            //Learn();
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
                        CvInvoke.Resize(imgMat, imgMat, new Size(24, 24), 0, 0, Inter.Linear);
                        faceImages[i] = imgMat;
                        int number = Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name));
                        if (number <= 1000000)
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
                    facess.Write(Application.StartupPath + "\\Train.yml");
                }
            }
        }
        private string LearnMale()
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
                        CvInvoke.Resize(imgMat, imgMat, new Size(24, 24), 0, 0, Inter.Linear);
                        faceImages[i] = imgMat;
                        faceLabels[i] = 1;
                        i++;
                    }
                    facess.Train(faceImages, faceLabels);
                }
            }
            return "Database Male Has Been Loaded";
        }
        private string LearnFemale()
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
                        CvInvoke.Resize(imgMat, imgMat, new Size(24, 24), 0, 0, Inter.Linear);
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
                    //imgInput = imgInput.Rotate(-20,new Bgr(Color.Gray));
                    DetectFace.Detect(
                      imgInput, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
                      faces, eyes,
                      out detectionTime);
                    //imgInput.Rotate()
                    foreach (Rectangle face in faces)
                        CvInvoke.Rectangle(imgInput, face, new Bgr(Color.Red).MCvScalar, 2);
                    foreach (Rectangle eye in eyes)
                        CvInvoke.Rectangle(imgInput, eye, new Bgr(Color.Blue).MCvScalar, 2);
                    if (eyes.Count >  1)
                    {
                        int Eye0Y = (eyes[0].Y + (eyes[0].Height / 2));
                        int Eye1Y = (eyes[1].Y + (eyes[1].Height / 2));
                        List<Point> pt = new List<Point>();
                        pt.Add(new Point(
                                eyes[0].X + (eyes[0].Width / 2),
                                eyes[0].Y + (eyes[0].Height / 2)));
                        pt.Add(new Point(
                                eyes[1].X + (eyes[1].Width / 2),
                                eyes[1].Y + (eyes[1].Height / 2)));
                        pt.Add(new Point(
                                eyes[0].X + (eyes[0].Width / 2),
                                (Eye0Y > Eye1Y) ? Eye0Y : Eye1Y
                                ));
                        imgInput.DrawPolyline(pt.ToArray(), false, new Bgr(Color.LightBlue), 2);
                        double triangleHeight = (Eye0Y > Eye1Y) ? Eye0Y - Eye1Y : Eye1Y - Eye0Y;
                        double triangleWidth = eyes[1].X - eyes[0].X;
                        double t = triangleHeight / triangleWidth;

                        double angleRad = Math.Atan(t);
                        double angleDegrees = angleRad * 180 / Math.PI;
                        angleDegrees *= Eye0Y > Eye1Y ? 1 : -1;
                        imgInput.Rotate(angleDegrees, new Bgr(Color.Gray) , true);

                        Image<Bgr, Byte> buffer_im = imgInput;
                        buffer_im.ROI = faces[0];

                        Image<Bgr, Byte> cropped_im = buffer_im.Copy();

                        #region "New"
                        string[] list = new string[2];
                        list[0] = "Pria";
                        list[1] = "Wanita";
                        string[] listAge = new string[19];
                        listAge[0] = "(0-5)";
                        listAge[1] = "(6-10)";
                        listAge[2] = "(11-15)";
                        listAge[3] = "(16-20)";
                        listAge[4] = "(21-25)";
                        listAge[5] = "(26-30)";
                        listAge[6] = "(31-35)";
                        listAge[7] = "(36-40)";
                        listAge[8] = "(41-45)";
                        listAge[9] = "(46-50)";
                        listAge[10] = "(51-55)";
                        listAge[11] = "(56-60)";
                        listAge[12] = "(61-65)";
                        listAge[13] = "(70-75)";
                        listAge[14] = "(81-85)";
                        listAge[15] = "(86-90)";
                        listAge[16] = "(91-95)";
                        listAge[17] = "(96-100)";
                        listAge[18] = "(100-~)";
                        Emgu.CV.Dnn.Net net = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe(Application.StartupPath + "\\gender_net.prototxt", Application.StartupPath + "\\gender_net.caffemodel");
                        Emgu.CV.Dnn.Net AgeNet = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe(Application.StartupPath + "\\age_net.prototxt", Application.StartupPath + "\\age_net.caffemodel");

                        MCvScalar MODEL_MEAN_VALUES = new MCvScalar(78.4263377603, 87.7689143744, 114.895847746);
                        Mat blob = Emgu.CV.Dnn.DnnInvoke.BlobFromImage(cropped_im, 1, new Size(227, 227), MODEL_MEAN_VALUES, false);
                        net.SetInput(blob);
                        AgeNet.SetInput(blob);
                        List<float> data = new List<float>();
                        Mat genderPreds = net.Forward();
                        Mat agePreds = AgeNet.Forward();

                        int genderId = 0;
                        double genderProb = 0;
                        getMaxClass(ref genderPreds, ref genderId, ref genderProb);
                        string gender = list[genderId];

                        int ageId = 0;
                        double ageProb = 0;
                        getMaxClass(ref agePreds, ref ageId, ref ageProb);
                        string age = listAge[ageId];


                        if (faces.Count() == 1)
                        {
                            var a = gender;
                        }
                        else if (faces.Count() > 0)
                        {
                            gender = "Kelompok";
                        }
                        else
                        {
                            gender = "N/A";
                        }
                        CvInvoke.PutText(imgInput, gender, new Point(100, 50), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);
                        CvInvoke.PutText(imgInput, age, new Point(90, 40), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);

                        #endregion
                        ImageViewer imageViewer = new ImageViewer();
                        imageViewer.Image = imgInput;
                        imageViewer.ShowDialog();
                    }
                    else
                    {
                        #region "New"
                        string[] list = new string[2];
                        list[0] = "Pria";
                        list[1] = "Wanita";
                        string[] listAge = new string[19];
                        listAge[0] = "(0-5)";
                        listAge[1] = "(6-10)";
                        listAge[2] = "(11-15)";
                        listAge[3] = "(16-20)";
                        listAge[4] = "(21-25)";
                        listAge[5] = "(26-30)";
                        listAge[6] = "(31-35)";
                        listAge[7] = "(36-40)";
                        listAge[8] = "(41-45)";
                        listAge[9] = "(46-50)";
                        listAge[10] = "(51-55)";
                        listAge[11] = "(56-60)";
                        listAge[12] = "(61-65)";
                        listAge[13] = "(70-75)";
                        listAge[14] = "(81-85)";
                        listAge[15] = "(86-90)";
                        listAge[16] = "(91-95)";
                        listAge[17] = "(96-100)";
                        listAge[18] = "(100-~)";
                        Emgu.CV.Dnn.Net net = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe(Application.StartupPath + "\\gender_net.prototxt", Application.StartupPath + "\\gender_net.caffemodel");
                        Emgu.CV.Dnn.Net AgeNet = Emgu.CV.Dnn.DnnInvoke.ReadNetFromCaffe(Application.StartupPath + "\\age_net.prototxt", Application.StartupPath + "\\age_net.caffemodel");

                        MCvScalar MODEL_MEAN_VALUES = new MCvScalar(78.4263377603, 87.7689143744, 114.895847746);
                        Mat blob = Emgu.CV.Dnn.DnnInvoke.BlobFromImage(imgInput, 1, new Size(227, 227), MODEL_MEAN_VALUES, false);
                        net.SetInput(blob);
                        AgeNet.SetInput(blob);
                        List<float> data = new List<float>();
                        Mat genderPreds = net.Forward();
                        Mat agePreds = AgeNet.Forward();

                        int genderId = 0;
                        double genderProb = 0;
                        getMaxClass(ref genderPreds, ref genderId, ref genderProb);
                        string gender = list[genderId];

                        int ageId = 0;
                        double ageProb = 0;
                        getMaxClass(ref agePreds, ref ageId, ref ageProb);
                        string age = listAge[ageId];


                        if (faces.Count() == 1)
                        {
                            var a = gender;
                        }
                        else if (faces.Count() > 0)
                        {
                            gender = "Kelompok";
                        }
                        else
                        {
                            gender = "N/A";
                        }
                        CvInvoke.PutText(imgInput, gender, new Point(100, 50), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);
                        CvInvoke.PutText(imgInput, age, new Point(90, 40), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);

                        #endregion
                        ImageViewer imageViewer = new ImageViewer();
                        imageViewer.Image = imgInput;
                        imageViewer.ShowDialog();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //throw;
            }
            
        }

        void getMaxClass(ref Mat probBlob, ref int classId, ref double classProb)
        {
            Mat probMat = probBlob.Reshape(1, 1); //reshape the blob to 1x1000 matrix
            Point classNumber = new Point();
            var tmp = new Point();
            double tmpdouble = 0;
            CvInvoke.MinMaxLoc(probMat, ref tmpdouble, ref classProb, ref tmp, ref classNumber);
            classId = classNumber.X;
        }

        private object max_element(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FaceRecognizer face = new FisherFaceRecognizer(0, 3500);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            facess = new FisherFaceRecognizer(0, 3000);
            learnAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
