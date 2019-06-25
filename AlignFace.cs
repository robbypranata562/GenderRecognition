using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderRecognition
{
    public static class AlignFace
    {
        public static Image<Gray, byte> AlignEyes(Image<Gray, byte> Image)
        {
            //Rectangle[] eyes = EyeClassifier.DetectMultiScale(image, 1.4, 0, new Size(1, 1), new Size(50, 50));
            try
            {
                int height = Image.Height / 2;
                Rectangle rect = new Rectangle(0, 0, Image.Width, height);
                Image<Gray, byte> upper_face = Image.Convert<Gray, byte>();
                //MCvAvgComp[][] Right_Eye = upper_face.DetectHaarCascade(haar_righteye, 1.4, 4, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(4, 4));
                //MCvAvgComp[][] Left_Eye = upper_face.DetectHaarCascade(haar_lefteye, 1.4, 4, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(4, 4));
                using (CudaCascadeClassifier eye = new CudaCascadeClassifier("haarcascade_eye_tree_eyeglasses.xml"))
                {
                    using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(Image))
                    using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                    using (GpuMat region = new GpuMat())
                    {
                        eye.DetectMultiScale(gpuGray,region);
                        Rectangle[] eyeRegion = eye.Convert(region);

                    }
                       
                }
            }
            catch
            {

            }
            return Image;
        }
    }
}
