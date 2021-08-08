using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Digit_Recognizer
{
    class CentreFinder
    {


        public static int[] GetImageCentrePoint(Bitmap panelImage)
        {
            int imageCentrePoint = panelImage.Width / 2;
            int[] centrePoint = new int[2];
            centrePoint[0] = imageCentrePoint;
            centrePoint[1] = imageCentrePoint;

            return centrePoint;

        }


        public static int[] GetDigitCentrePoint(Bitmap panelImage)
        {
            int xStart = GetDigitStartXIndex(panelImage);
            int xEnd = GetDigitEndXIndex(panelImage);

            int yStart = GetDigitStartYIndex(panelImage);
            int yEnd = GetDigitEndYIndex(panelImage);

            int xMid = CalculateMid(xStart, xEnd);
            int yMid = CalculateMid(yStart, yEnd);

            int[] midPoint = new int[2];
            midPoint[0] = xMid;
            midPoint[1] = yMid;

            return midPoint;
        }


        //Gets the mid point of two points passed to the function
        private static int CalculateMid(int startIndex, int endIndex)
        {
            int midIndex = (endIndex + startIndex) / 2;
            return midIndex;
        }

        //Gets the start of the digit with respect to the width
        public static int GetDigitEndXIndex(Bitmap panelImage)
        {
            int imageWidth = panelImage.Width;
            int imageHeight = panelImage.Height;

            int endIndex = 0;
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    int pixelValue = panelImage.GetPixel(x, y).R;
                    if (pixelValue != 0)
                    {
                        if (endIndex < x)
                        {
                            endIndex = x;
                        }
                    }
                }
            }

            return endIndex;
        }


        //Gets the end of the digit with respect to the width
        public static int GetDigitStartXIndex(Bitmap panelImage)
        {
            int imageWidth = panelImage.Width;
            int imageHeight = panelImage.Height;

            int startIndex = imageWidth;
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    int pixelValue = panelImage.GetPixel(x, y).R;
                    if (pixelValue != 0)
                    {

                        if (startIndex > x)
                        {
                            startIndex = x;
                        }
                    }
                }
            }

            return startIndex;
        }


        //Gets the start of the digit with respect to the height
        public static int GetDigitEndYIndex(Bitmap panelImage)
        {
            int imageWidth = panelImage.Width;
            int imageHeight = panelImage.Height;

            int endIndex = 0;
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    int pixelValue = panelImage.GetPixel(x, y).R;
                    if (pixelValue != 0)
                    {
                        if (endIndex < y)
                        {
                            endIndex = y;
                        }
                    }
                }
            }

            return endIndex;
        }


        //Gets the end of the digit with respect to the height
        public static int GetDigitStartYIndex(Bitmap panelImage)
        {
            int imageWidth = panelImage.Width;
            int imageHeight = panelImage.Height;

            int startIndex = 999999;
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    int pixelValue = panelImage.GetPixel(x, y).R;
                    if (pixelValue != 0)
                    {

                        if (startIndex > y)
                        {
                            startIndex = y;
                        }
                    }
                }
            }

            return startIndex;
        }




    }
}
