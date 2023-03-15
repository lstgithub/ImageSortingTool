using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ImageSortingApp
{
    public partial class MainWindow : Form
    {
        public static string rootFolder { get; set; }
        public static string dirOne { get; set; }
        public static string dirTwo { get; set; }
        public static string dirThree { get; set; }
        public static string dirFour { get; set; }
        public static string dirFive { get; set; }
        public static int currImg { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void targetImageDir_Click(object sender, EventArgs e)
        {
            HandleFolder(targetImageDir0);
        }

        public void start_Click(object sender, EventArgs e)
        {
            try
            {
                ShowImage(ImageNames().LastOrDefault());
            }
            catch { }
        }

        public static List<string> ImageNames()
        {
            try
            {
                return Directory.GetFiles(rootFolder, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png")).ToList();
            }
            catch
            {
                return null;
            }
        }

        public void ShowImage(string path)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            currImg = ImageNames().IndexOf(path);
            if (path != null)
                try
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(path);
                }
                catch { }
            else
            {
                pictureBox1.Image = null;
                MessageBox.Show("No images!");
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            string key = e.KeyChar.ToString();
            if (key == "1")
            {
                try
                {
                    HandleImage(dirOne);
                }
                catch { }
            }
            if (key == "2")
            {
                try
                {
                    HandleImage(dirTwo);
                }
                catch { }
            }
            if (key == "3")
            {
                try
                {
                    HandleImage(dirThree);
                }
                catch { }
            }
            if (key == "4")
            {
                try
                {
                    HandleImage(dirFour);
                }
                catch { }
            }
            if (key == "5")
            {
                try
                {
                    HandleImage(dirFive);
                }
                catch { }
            }
            if (key == "p")
            {
                try
                {
                    ShowImage(ImageNames()[currImg - 1]);
                }
                catch { }
            }
            if (key == "n")
            {
                try
                {
                    ShowImage(ImageNames()[currImg + 1]);
                }
                catch { }
            }
        }

        public void MoveImage(string destinationLocation)
        {
            try
            {
                string originalPath = ImageNames().LastOrDefault();
                var imageName = originalPath.Split(Convert.ToChar("\\")).Last();
                string destinationPath = destinationLocation + "\\" + imageName;
                File.Move(originalPath, destinationPath);
            }
            catch { }
        }

        public void HandleImage(string destination)
        {
            if (destination != null)
            {
                pictureBox1.Image.Dispose();
                MoveImage(destination);
                ShowImage(ImageNames().LastOrDefault());
            }
        }

        public void HandleFolder(dynamic buttonName)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string s = buttonName.Name;
            var regex = new Regex("[0-9]");
            var match = regex.Match(s);
            var folderNumber = match.Value;
            int i = short.Parse(folderNumber);

            switch (i)
            {
                case 0 when fbd.SelectedPath != null:
                    rootFolder = fbd.SelectedPath;
                    break;
                case 1 when fbd.SelectedPath != null:
                    dirOne = fbd.SelectedPath;
                    break;
                case 2 when fbd.SelectedPath != null:
                    dirTwo = fbd.SelectedPath;
                    break;
                case 3 when fbd.SelectedPath != null:
                    dirThree = fbd.SelectedPath;
                    break;
                case 4 when fbd.SelectedPath != null:
                    dirFour = fbd.SelectedPath;
                    break;
                case 5 when fbd.SelectedPath != null:
                    dirFive = fbd.SelectedPath;
                    break;
            }

            try
            {
                string readableName = fbd.SelectedPath.Split(Convert.ToChar("\\")).Last();
                if (readableName.Length > 0)
                    buttonName.Text = readableName;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandleFolder(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleFolder(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleFolder(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HandleFolder(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HandleFolder(button5);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}