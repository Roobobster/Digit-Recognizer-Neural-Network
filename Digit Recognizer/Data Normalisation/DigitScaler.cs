using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Digit_Recognizer
{
    public static class DigitScaler
    {



        public static Bitmap ApplyScaleToImage(Bitmap translatedImage, float digitToBackgroundRatio)
        {
            Bitmap scaledDigit = ScaleDigit(translatedImage, digitToBackgroundRatio);
            Bitmap offSetScaledImage = new Bitmap(DigitTranslator.ClearBitMap(translatedImage));

            int width = scaledDigit.Width;
            int height = scaledDigit.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    offSetScaledImage.SetPixel(x, y, scaledDigit.GetPixel(x, y));
                }
            }

            Bitmap scaledImage = new Bitmap(DigitTranslator.CentreDigit(offSetScaledImage));

            return scaledImage;

        }
        private static Bitmap ScaleDigit(Bitmap translatedImage, float digitToBackgroundRatio)
        {

            float scale = CalculateScale(translatedImage, digitToBackgroundRatio);
            Bitmap digitImage = GetDigitFromImage(translatedImage);
            int newWidth = (int) (digitImage.Width * scale);
            int newHeight = (int)(digitImage.Height * scale);

            Bitmap scaledDigitImage = new Bitmap(digitImage, newWidth, newHeight);

            return scaledDigitImage;
            
        }

        private static Bitmap GetDigitFromImage(Bitmap translatedImage)
        {
            int digitWidth = CalculateDigitWidth(translatedImage);
            int digitHeight = CalculateDigitHeight(translatedImage);

            int yStart = CentreFinder.GetDigitStartYIndex(translatedImage);
            int yEnd = CentreFinder.GetDigitEndYIndex(translatedImage);

            int xStart = CentreFinder.GetDigitStartXIndex(translatedImage);
            int xEnd = CentreFinder.GetDigitEndXIndex(translatedImage);

            Bitmap digitimage = new Bitmap(DigitTranslator.ClearBitMap(translatedImage), digitWidth, digitHeight);

            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = yStart; y <= yEnd; y++)
                {
                    int xIndex = x - xStart;
                    int yIndex = y - yStart;
                    digitimage.SetPixel(xIndex, yIndex, translatedImage.GetPixel(x, y));
                }
            }

            return digitimage;
        }

        //Calcualtes the needed scale to be applied to get a desired digit to background ratio.
        private static float CalculateScale(Bitmap translatedImage, float digitToBackgroundRatio)
        {
            int[] centre = CentreFinder.GetImageCentrePoint(translatedImage);

            int digitWidth = CalculateDigitWidth(translatedImage);
            int digitHeight = CalculateDigitHeight(translatedImage);

            int wantedDimension = (int) ( translatedImage.Width * digitToBackgroundRatio);
            float scale = 0;


            if (digitWidth > digitHeight)
            {
                scale = (float)wantedDimension / digitWidth;
            }
            else
            {
                scale = (float)wantedDimension / digitHeight;
            }

            

            return scale;
        }


        //Calculates the height of the digit in the image
        private static int CalculateDigitHeight(Bitmap translatedImage)
        {
            int yStart = CentreFinder.GetDigitStartYIndex(translatedImage);
            int yEnd = CentreFinder.GetDigitEndYIndex(translatedImage);


            int digitHeight = yEnd - yStart + 1;

            return digitHeight;
        }


        //Calculates the width of the digit in the image. 
        private static int CalculateDigitWidth(Bitmap translatedImage)
        {
            int xStart = CentreFinder.GetDigitStartXIndex(translatedImage);
            int xEnd = CentreFinder.GetDigitEndXIndex(translatedImage);

            int digitWidth = xEnd - xStart + 1;

            return digitWidth;
        }
    }
}
