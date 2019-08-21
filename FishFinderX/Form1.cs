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

        Int32             maximum         = 0;
        private Int32   position        = 0;
        public String   sourcefolder    = "empty";
        public String[] filters         = new String[] { "jpg", "jpeg" };
        String[]        table;
        String[]        files;
        Point[]         points;

        private void FishFinder_Load(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Height = this.Height;
            pictureBox.Width = this.Width;

            labelHelp.Text =    "\r\n\talt + F4 / ESC\tquit program\r\n" +
                                "\tH\t\tdisplay this help\r\n" +
                                "\tJ\t\tshow filename and position\r\n" +
                                "\tO\t\topen folder\r\n" +
                                "\tW\t\twrite results to file\r\n" +
                                "\tleft\t\tback one image\r\n" +
                                "\tright\t\tforward one image\r\n" +
                                "\tshift + left\t\tback 100 images\r\n" +
                                "\tshift + right\tforward 100 images\r\n" +
                                "\tclick\t\tlocate fish";
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
                row = MyTable.NewRow();
                row["id"] = i;
                row["filename"] = fileName;
                row["score"] = 0;
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
            pictureBox.Image = Image.FromFile(files[position]);
            progressBar.Value = position;
            labelMin.Text = (position+1).ToString();

            labelPoints.Text = points[position].ToString();
            labelFilename.Text = Path.GetFileNameWithoutExtension(files[position]);
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

    }
}
