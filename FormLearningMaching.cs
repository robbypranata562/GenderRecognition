using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenderRecognition
{
    public partial class FormLearningMaching : Form
    {
        Image _img;
        public FormLearningMaching(Image img)
        {
            _img = img;
            InitializeComponent();
        }

        public FormLearningMaching()
        {
            InitializeComponent();
        }

        private void FormLearningMaching_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = _img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\Foto");
                if (genderCB.Text == "Pria")
                {
                    var LastNumber = di.GetFiles("*.jpg")
                    .Where(file => Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name)) <= 1000000)
                    .Select(file => file.Name).LastOrDefault();
                    int number = Convert.ToInt32(Path.GetFileNameWithoutExtension(LastNumber)) + 1;
                    pictureBox1.Image.Save(Application.StartupPath + "\\Foto\\" + number.ToString() + ".jpg");
                }
                else
                {
                    var LastNumber = di.GetFiles("*.jpg")
                    .Where(file => Convert.ToInt32(Path.GetFileNameWithoutExtension(file.Name)) >= 1000000)
                    .Select(file => file.Name).LastOrDefault();
                    int number = Convert.ToInt32(Path.GetFileNameWithoutExtension(LastNumber)) + 1;
                    pictureBox1.Image.Save(Application.StartupPath + "\\Foto\\" + number + ".jpg");

                }
                MessageBox.Show("Success Add Data");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
