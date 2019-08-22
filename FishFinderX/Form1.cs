using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FishFinderX
{
    public partial class FishFinder : Form   
    {           
        public FishFinder()
        {
            InitializeComponent();
        }


        Int32           maximum         = 0;
        Int32           position        = 0;
        String          sourcefolder    = "empty";
        String[]        filters         = new String[] { "jpg", "jpeg" };
        String[]        table;
        String[]        files;
        Point[]         points;
        Boolean         markerVisible   = true;

        private void FishFinder_Load(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Height   = this.Height;
            pictureBox.Width    = this.Width;

            labelHelp.Location = new Point(((this.Width / 2) - (labelHelp.Width / 2)), ((this.Height / 2) - (labelHelp.Height / 1)));

            progressBar.Width   = this.Width;
            progressBar.Location = new Point(0, (this.Height - 100));


        }

        private void FishFinder_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta < 1)
            {
                nextImage();
            }
            else
            {
                previousImage();
            }
        }

        private void FishFinder_KeyDown(object sender, KeyEventArgs e)
        {

            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        next100Images();
                        break;
                    case Keys.Left:
                        previous100Images();
                        break;
                    default:
                        break;
                }

            }
            else
            {
                switch (e.KeyCode)
                {

                    case Keys.Escape:
                        Application.Exit();
                        break;

                    case Keys.Right:
                        nextImage();
                        break;

                    case Keys.Left:
                        previousImage();
                        break;

                    case Keys.J:
                        toggleVisibility();
                        break;

                    case Keys.H:
                        labelHelp.Visible = !labelHelp.Visible;
                        break;

                    case Keys.W:
                        writeResults();
                        break;

                    case Keys.M:
                        markerVisible = !markerVisible;
                        pictureBox.Refresh();
                        break;


                    case Keys.O:
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            position = 0;
                            if (files != null)
                            {
                                Array.Clear(files, 0, files.Length);
                                Console.Beep();
                            }
                            
                            sourcefolder = folderBrowserDialog.SelectedPath;
                            files = GetFilesFrom(sourcefolder, filters, false);
                            if (true)
                            {
                                progressBar.Maximum     = files.Length - 1;
                                maximum                 = files.Length;
                                labelMax.Text           = maximum.ToString();

                                points                  = new Point[files.Length];

                                for (int i = 0; i < points.Length; i++)
                                {
                                    points[i].X = -1;
                                    points[i].Y = -1;
                                }

                                updateInterface();

                            }
                            else MessageBox.Show("Filenames do not match expected scheme");

                        }
                        break;

                    default:
                        break;
                }

            }

        }

        private void FishFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to close the programm? \r\nMake sure you saved all data by pressing 'w'! ";
            const string caption = "Close Program";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (files != null)
            {

                Int32 realW = pictureBox.Image.Width;
                Int32 realH = pictureBox.Image.Height;
                Int32 currentW = pictureBox.ClientRectangle.Width;
                Int32 currentH = pictureBox.ClientRectangle.Height;

                Double zoomW = (currentW / (Double)realW);
                Double zoomH = (currentH / (Double)realH);
                Double zoomActual = Math.Min(zoomW, zoomH);
                Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
                Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

                Int32 realX = (Int32)((me.X - padX) / zoomActual);
                Int32 realY = (Int32)((me.Y - padY) / zoomActual);

                points[position].X = realX;
                points[position].Y = realY;

                nextImage();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen redPen = new Pen(Color.Red, 2);
            Pen bluePen = new Pen(Color.Blue, 2);

            // Create location and size of ellipse.
            if (points != null)
            {
                Int32 realW = pictureBox.Image.Width;
                Int32 realH = pictureBox.Image.Height;
                Int32 currentW = pictureBox.ClientRectangle.Width;
                Int32 currentH = pictureBox.ClientRectangle.Height;

                Double zoomW = (currentW / (Double)realW);
                Double zoomH = (currentH / (Double)realH);
                Double zoomActual = Math.Min(zoomW, zoomH);
                Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
                Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

                Int32 realX = (Int32)((points[position].X * zoomActual) + padX);
                Int32 realY = (Int32)((points[position].Y * zoomActual) + padY);

                int x = realX - 8;
                int y = realY - 8;
                int width = 16;
                int height = 16;

                // Draw ellipse to screen.
                if (markerVisible)
                {
                    e.Graphics.DrawEllipse(redPen, x, y, width, height);
                }
            }
        }

        private void MakeDataTableAndDisplay(string MyFilename)
        {
            string fileName = MyFilename;
            // Create new DataTable.
            DataTable MyTable = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, ColumnName
            // and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            MyTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "filename";
            MyTable.Columns.Add(column);

            // Create thrid column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "score";
            MyTable.Columns.Add(column);

            // Create new DataRow objects and add to DataTable.    
            for (int i = 0; i < 10; i++)
            {
                row                 = MyTable.NewRow();
                row["id"]           = i;
                row["filename"]     = fileName;
                row["score"]        = 0;
                MyTable.Rows.Add(row);
            }

        }

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();

            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }

            return filesFound.ToArray();
        }

        public void updateInterface()
        {
            pictureBox.Image    = Image.FromFile(files[position]);
            progressBar.Value   = position;
            labelMin.Text       = (position+1).ToString();

            labelPoints.Text    = points[position].ToString();
            labelFilename.Text  = Path.GetFileNameWithoutExtension(files[position]);
        }

        private void nextImage()
        {
            if (position < maximum - 1)
            {
                position++;
                updateInterface();
            }
            else
            {
                Console.Beep();
            }
        }

        private void next100Images()
        {
            if (position < maximum - 100)
            {
                position = position + 100;
                updateInterface();  
            }
            else
            {
                position = maximum - 1;
                updateInterface();
                Console.Beep();
            }
        }

        private void previousImage()
        {
            if (position > 0)
            {
                position--;
                updateInterface();
            }
            else
            {
                Console.Beep();
            }
        }

        private void previous100Images()
        {
            if (position > 100)
            {
                position = position - 100;
                updateInterface();
            }

            else
            {
                position = 0;
                updateInterface();
                Console.Beep();
            }
        }

        private void toggleVisibility()
        {
            labelFilename.Visible = !labelFilename.Visible;
            labelMin.Visible = !labelMin.Visible;
            labelMax.Visible = !labelMax.Visible;
            progressBar.Visible = !progressBar.Visible;
        }

        private void writeResults()
        {
            Point emptypoint = new Point(-1, -1);
            if (points != null && !Array.Exists(points, element => element.Equals(emptypoint)))
            {
                string outfile      = Path.GetFileNameWithoutExtension(files[0]);
                string outfolder    = Path.GetDirectoryName(files[0]);
                table               = new string[files.Length];

                for (int i = 0; i < files.Length; i++)
                    {
                        table[i] = Path.GetFileNameWithoutExtension(files[i]) + ";" + points[i].X.ToString().PadLeft(4, '0') + ";" + points[i].Y.ToString().PadLeft(4, '0');
                    }

                File.WriteAllLines(outfolder + "\\" + outfile + ".txt", table, Encoding.UTF8);

                MessageBox.Show("Results successfully written to: " + outfolder + "\\" + outfile + ".txt.");
            }

            else
            {
                if (points != null)
                {
                    int x = 0;
                    for (int i = 0; i < points.Length - 1; i++)
                    {
                        if (Point.Equals( points[i] , emptypoint ))
                        {
                            x++;
                        }
                    }

                    Console.Beep();
                    MessageBox.Show(x.ToString() + " pictures have not been rated. First missing value is at index: " + (Array.IndexOf(points, emptypoint)+1).ToString());
                    position = Array.IndexOf(points, emptypoint);
                    updateInterface();
                }
            }
        }
        
    }
}
