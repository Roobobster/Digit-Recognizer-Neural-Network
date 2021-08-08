using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Digit_Recognizer
{
    class DigitFetcher
    {
        FileStream fsLabels;
        FileStream fsImages;

        BinaryReader brLabels;
        BinaryReader brImages;



        public void OpenFileReaders()
        {
            fsLabels = new FileStream(@"F:\EPQ\HandWritten Digits\Training Set Labels\train-labels.idx1-ubyte", FileMode.Open); // test labels
            fsImages = new FileStream(@"F:\EPQ\HandWritten Digits\Training Set Images\train-images.idx3-ubyte", FileMode.Open); // test images
            brLabels = new BinaryReader(fsLabels);
            brImages = new BinaryReader(fsImages);
            int magic1 = brImages.ReadInt32(); // discard
            int numImages = brImages.ReadInt32();
            int numRows = brImages.ReadInt32();
            int numCols = brImages.ReadInt32();

            int magicLabel = brLabels.ReadInt32();
            int numLabels = brLabels.ReadInt32();
        }

        public void CloseFileReader()
        {
            fsLabels.Close();
            fsImages.Close();
            brImages.Close();
            brLabels.Close();

        }

        public byte[][] GetNextMNISTDigit(ref double[] inputVector, ref double[] targetVector)
        {

            //Initialises the pixel image array.
            byte[][] pixels = new byte[28][];
            for (int i = 0; i < pixels.Length; ++i)
                pixels[i] = new byte[28];


            int index = 0;
            inputVector = new double[784];

            //Loops for every x pixel
            for (int j = 0; j < 28; ++j)
            {
                //Loops for every y pixel
                for (int i = 0; i < 28; ++i)
                {
                    //Reads the next pixel
                    byte b = brImages.ReadByte();
                    pixels[j][i] = b;

                    inputVector[index] = b / 255.0;
                    //Keeps track of the index for the inputVector
                    index++;
                }
            }



            byte lbl = brLabels.ReadByte();


            //Creates a target vector that has 0 for all the digits it's not supposed to be and 1 for the digit it is supposed to be.
            targetVector = new double[10];
            for (int i = 0; i < 10; i++)
            {
                targetVector[i] = 0;
            }
            targetVector[lbl] = 1;

            //Turns the 28x28 digit into a class that has the pixels and label with it
            DigitImage dImage = new DigitImage(pixels, lbl);

            //Turns the image into an image using only characters with the number underneath the digit image.
            return pixels;


        }


    }

    public class DigitImage
    {
        public byte[][] pixels;
        public byte label;

        public DigitImage(byte[][] pixels,
          byte label)
        {
            this.pixels = new byte[28][];
            for (int i = 0; i < this.pixels.Length; ++i)
                this.pixels[i] = new byte[28];

            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    this.pixels[i][j] = pixels[i][j];

            this.label = label;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    if (this.pixels[i][j] == 0)
                        s += " "; // white
                    else if (this.pixels[i][j] == 255)
                        s += "O"; // black
                    else
                        s += "."; // gray
                }
                s += "\n";
            }
            s += this.label.ToString();
            return s;
        } // ToString

    }
}
