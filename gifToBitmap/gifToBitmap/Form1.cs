using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace gifToBitmap
{
    public partial class Form1 : Form
    {
        int length = 0;
        int height;
        int width;
        List<string> lines = new List<string>();
        int threshold = 127;
        string fileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\barak\Downloads",
                Title = "Choose a gif file",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "gif",
                RestoreDirectory = true,
            };

            if(opf.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = opf.FileName;
                fileName += opf.SafeFileName.Substring(0, opf.SafeFileName.Length - 4);
            }

        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            Image gif = Image.FromFile(textBoxFile.Text);
            List<Image> imgs = new List<Image>();
            int len = gif.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);

            for(int i=0; i<len; i++)
            {
                gif.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, i);
                imgs.Add(new Bitmap(gif));
            }

            string root = @"C:\Desktop\frames";
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            int j = 0;
            foreach (Bitmap i in imgs)
            {
                width = i.Width;
                height = i.Height;

                if(width > height)
                {
                    int ratio = width / 64;
                    width = 64;
                    height = height / ratio;
                }
                else if(height > width)
                {
                    int ratio = height / 32;
                    height = 32;
                    width = width / ratio;
                }
                else
                {
                    height = 32;
                    width = 32;
                }

                Bitmap resized = new Bitmap(i, new Size(width, height));

                Graphics g = Graphics.FromImage(resized);
                g.DrawImage(resized, Point.Empty);

                resized.Save(@"C:\Desktop\frames\frame" + j++ + ".bmp");
                length++;
            }
             

            ProcessStartInfo info = new ProcessStartInfo
            {
                Arguments = root,
                FileName = "explorer.exe"
            };

            Process.Start(info);

            pictureBoxGif.Enabled = true;
            pictureBoxGif.ImageLocation = @"C:\Desktop\frames\frame0.bmp";
            trackBarThreshold.Enabled = true;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string path = @"C:\Desktop\frames";

            if (Directory.Exists(path))
            {
                bool white = true;
                

                lines.Add("#include \"SSD1306_minimal.h\"\n");
                lines.Add("#include <TinyWireM.h>\n");
                lines.Add("SSD1306_Mini oled;\n\n\n");
                
                for (int h = 0; h < length; h++)
                {
                    string file = path + "\\frame" + h + ".bmp";

                    string hex = "";
                    Bitmap bmp = (Bitmap)Bitmap.FromFile(file);

                    if (bmp.GetPixel(0, 0).R < threshold)
                        white = false;

                    for (int k = 0; k < height / 8; k++)
                    {
                        for (int i = 0; i < width; i++)
                        {
                            int sum = 0;
                            for (int j = 7; j >= 0; j--)
                            {
                                Color color = bmp.GetPixel(i, k * 8 + j);
                                
                                if (color.R <= threshold && white)
                                {
                                    sum |= 1;
                                }
                                    
                                if (color.R > threshold && !white)
                                {
                                    sum |= 1;
                                }
                                    
                                    
                                if (j != 0) sum = sum << 1;
                            }
                            hex += "0x" + sum.ToString("X") + ",";
                        }
                    }
                    hex = hex.Remove(hex.Length - 1, 1);
                    hex += "\n";

                    string frame = "const unsigned char frame" + h + "[] PROGMEM = {\n" + hex + "};\n";
                    lines.Add(frame + "\n");
                }

                lines.Add("void setup(){\n");
                lines.Add("\tTinyWireM.begin();\n");
                lines.Add("\toled.init(0x3c);");
                lines.Add("\toled.clear();\n}");

                lines.Add("void loop(){\n");

                for (int i=0; i<length; i++)
                {
                    int moveToW = (128 - width) / 2;
                    int moveToH = height / 16;
                    lines.Add("\toled.drawImage(frame" + i + ", " + moveToW + ", " + moveToH + ", " + width + ", " + height / 8 + ");\n");
                    lines.Add("\tdelay(20);\n\n");
                }

                lines.Add("}");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = @"C:\Desktop\frames";

            pictureBoxGif.Image = null;

            if (Directory.Exists(path))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(path, true);
            }
                
        }

        private async void buttonGenerateFile_Click(object sender, EventArgs e)
        {
            string path = @"C:\Desktop\Arduino_files";

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string folder = path + "\\" + fileName;

            Directory.CreateDirectory(folder);

            string file = fileName + ".ino";

            path = Path.Combine(folder, file);

            if (!File.Exists(path))
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    foreach(string s in lines)
                    {
                        sw.WriteLine(s);
                    }
                }
            }

            ProcessStartInfo info = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe"
            };

            Process.Start(info);
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            threshold = trackBarThreshold.Value;
            Bitmap bmp = new Bitmap(width, height);
            Bitmap frame = (Bitmap)Bitmap.FromFile(@"C:\Desktop\frames\frame0.bmp");

            for (int i=0; i<width; i++)
            {
                for(int j=0; j<height; j++)
                {
                    Color c = frame.GetPixel(i, j);
                    if(c.R < threshold)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                        bmp.SetPixel(i, j, Color.White);
                }
            }

            pictureBoxGif.Image = bmp;
        }
    }
}