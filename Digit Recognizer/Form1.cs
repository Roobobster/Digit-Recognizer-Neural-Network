using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ANN;

namespace Digit_Recognizer
{
    public partial class Form1 : Form
    {
        NeuralNetwork ann;
        DigitFetcher digitFetcher;

        string weightSaveLocation = @"C:\Users\Robert\Desktop\Digit Recognition\Digit Recognizer\Digit Recognizer\Saved Weights\";
        string loadedWeights = @"C:\Users\Robert\Desktop\Digit Recognition\Digit Recognizer\Digit Recognizer\Saved Weights\03 02 2019 11 31.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            digitFetcher = new DigitFetcher();
            digitFetcher.OpenFileReaders();
            ann = new NeuralNetwork(28*28, 28+28 , 10, 0.1, 3);

            ann.LoadWeights(loadedWeights);
            int brightness = int.Parse(txtBrightness.Text);
            displayWieghts( brightness);

            drawingPanel1.PointSize = 21;
            largeDrawingPanel.PointSize = 24;
    
        }


        private void displayWieghts(int brightness)
        {
            Bitmap[] weightVisuals = WeightVisualiser.GenerateWeightVisuals(ann, brightness);



            pictureBox1.Image = new Bitmap(weightVisuals[0], 140, 140);
            pictureBox2.Image = new Bitmap(weightVisuals[1], 140, 140);
            pictureBox3.Image = new Bitmap(weightVisuals[2], 140, 140);
            pictureBox4.Image = new Bitmap(weightVisuals[3], 140, 140);
            pictureBox5.Image = new Bitmap(weightVisuals[4], 140, 140);
            pictureBox6.Image = new Bitmap(weightVisuals[5], 140, 140);
            pictureBox7.Image = new Bitmap(weightVisuals[6], 140, 140);
            pictureBox8.Image = new Bitmap(weightVisuals[7], 140, 140);
            pictureBox9.Image = new Bitmap(weightVisuals[8], 140, 140);
            pictureBox10.Image = new Bitmap(weightVisuals[9], 140, 140);

            Application.DoEvents();
        }

        


        private void BeginTraining(int batchSize)
        {
            

            double[][] inputMatrix = null;
            double[][] targetMatrix = null;
        
            GenerateDataMatrix(batchSize, ref inputMatrix, ref targetMatrix);

            ann.TrainNetwork(inputMatrix, targetMatrix, 0.2); 
            displayWieghts(int.Parse(txtBrightness.Text));


        }

        private void AddErrors()
        {
            ErrorChart.Series["Errors"].Points.Clear();
            int outputCount = 10;
            int[] errors = ann.ReturnErrors();
            int totalError = 0;
            for (int i = 0; i < outputCount; i++)
            {
                totalError += errors[i];
                ErrorChart.Series["Errors"].Points.AddXY(i, errors[i]);
                
            }
            chrtTotalError.Series["Errors"].Points.Add(totalError);
        }
        //Generates matrix of the input and targets with the different batches. 
        private void GenerateDataMatrix(int batchSize, ref double[][] inputMatrix, ref double[][] targetMatrix)
        {
            inputMatrix = new double[batchSize][];
            targetMatrix = new double[batchSize][];
          
            for (int batch = 0; batch < batchSize; batch++)
            {
                double[] inputVector = null;
                double[] targetVector = null;
                digitFetcher.GetNextMNISTDigit(ref inputVector, ref targetVector);
                inputMatrix[batch] = inputVector;
                targetMatrix[batch] = targetVector;
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int counter = 0;
         
            for (int i = 0; i < 100000; i++)
            {
                int batchSize = int.Parse(txtBatchSize.Text);
                if (counter == 60000)
                {
                    digitFetcher.CloseFileReader();
                    digitFetcher.OpenFileReaders();
                    counter = 0;
                    string fileName = DateTime.Now.ToString("MM/dd/yyyy H:mm");
                    fileName = fileName.Replace('/', ' ');
                    fileName = fileName.Replace(':', ' ');
                    ann.SaveWeights( weightSaveLocation + fileName +".txt");
                }
                BeginTraining(batchSize);
                AddErrors();
                Application.DoEvents();
                counter += 100;
           
      
            }
        }

        private int IdentifyImage(Bitmap imageToRecognize)
        {
            //It scales the digit and then centres it so you don't even need to centre it before hand.
            imageToRecognize = DigitScaler.ApplyScaleToImage(imageToRecognize, 0.7f);

            //Scales the image down
            //Bitmap scaledImage = new Bitmap(imageToRecognize, new Size(28, 28));
            //Scales it back up so that it adds anti analising like the database digits have 
            Bitmap scaledImage = new Bitmap(imageToRecognize, new Size(280, 280));
            pictureBox1.Image = scaledImage;

            //Scales the image back down to 28x28 so that they now have the anti analsing but scaled down to 28x28
            scaledImage = new Bitmap(scaledImage, new Size(28, 28));

            double[] inputVector = null;
            double[] targetVector = null;

            byte[][] image = digitFetcher.GetNextMNISTDigit(ref inputVector, ref targetVector);
            int counter = 0;
            //for (int y = 0; y < 28; y++)
            //{
            //    for (int x = 0; x < 28; x++)
            //    {
            //        scaledImage.SetPixel(x, y, Color.FromArgb((int)(inputVector[counter] * 255), (int)(inputVector[counter] * 255), (int)(inputVector[counter] * 255)));
            //        counter++;
            //    }
            //}

            //scaledImage = new Bitmap(scaledImage, new Size(280, 280));
            //pictureBox1.Image = scaledImage;
            inputVector = new double[28 * 28];

            counter = 0;
            for (int y = 0; y < 28; y++)
            {

                for (int x = 0; x < 28; x++)
                {

                    inputVector[counter] = scaledImage.GetPixel(x, y).R / 1f;
                    counter++;
                }
            }
            double[] outputVector = new double[10];
            outputVector = ann.RunNetwork(inputVector, 0);

            int greatestIndex = 0;


            int outputCount = outputVector.Length;

            //Loops for every output and finds the output with the highest value
            for (int output = 0; output < outputCount; output++)
            {
                double greatestValue = outputVector[greatestIndex];
                double nextValue = outputVector[output];
                if (greatestValue < nextValue)
                {
                    greatestIndex = output;
                }
            }

            return greatestIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Bitmap digitImage = drawingPanel1.ImageOnPanel;
            int networkClassification = IdentifyImage(digitImage);
            label1.Text = networkClassification.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawingPanel1.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chrtRandom_Click(object sender, EventArgs e)
        {

        }

        private void chrtTotalError_Click(object sender, EventArgs e)
        {

        }

        private void IdentifyMultiple_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "";
            CollectDigitsOnScreen();
            
        }

        private void CollectDigitsOnScreen()
        {
            //Gets image of the drawing panel
            Bitmap largeDrawing = largeDrawingPanel.ImageOnPanel;
            Bitmap rescaledImage = new Bitmap(largeDrawing, largeDrawing.Width /2, largeDrawingPanel.Height /2 );

            //Groups all the points on the screen that are near each other in seperate groups ( lists of list of points)
            List<List<int[]>> imageGroups = PixelGrouper.GenerateGroupedInterestPoints(rescaledImage);
            //Turns the list of list of points into bitmap images that correspond to that group.
            Bitmap[] groupImages = DigitGenerator.GenerateBitmapsWithGroups(imageGroups);

            foreach (Bitmap tempImage in groupImages)
            {
                pictureBox1.Image = tempImage;

                string networkClassification = IdentifyImage(tempImage).ToString();
                label1.Text = networkClassification;
                lblNumber.Text += networkClassification;
                MessageBox.Show("Next");
            }

        }

        private void btnClearLarge_Click(object sender, EventArgs e)
        {
            largeDrawingPanel.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnMedium.BackColor = Color.Gray;

            btnSmall.BackColor = Color.Blue;

            largeDrawingPanel.PointSize = 10;
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {

            btnMedium.BackColor = Color.Blue;

            btnSmall.BackColor = Color.Gray;       

            largeDrawingPanel.PointSize = 20;
        }


    }
}
