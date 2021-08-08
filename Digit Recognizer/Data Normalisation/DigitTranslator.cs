using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   


namespace Digit_Recognizer
{
    class DigitTranslator
    {
        private static int[] CalculateMidTranslation(Bitmap panelImage)
        {
            int[] imageCentre = CentreFinder.GetImageCentrePoint(panelImage);
            int[] digitCentre = CentreFinder.GetDigitCentrePoint(panelImage);

            int[] translation = new int[2];

            for (int i = 0; i < 2; i++)
            {
                translation[i] = imageCentre[i] - digitCentre[i];
            }

            return translation;

        }

        public static Bitmap CentreDigit(Bitmap panelImage)
        {
            int[] translation = CalculateMidTranslation(panelImage);

  
            Bitmap newImage = ClearBitMap(panelImage);

            int dimensions = panelImage.Width;
            
            for (int x = 0; x < dimensions; x++)
            {
                for (int y = 0; y < dimensions; y++)
                {
                    if (x + translation[0] >= 0  && x + translation[0] < dimensions && y + translation[1] >= 0 && y + translation[1] < dimensions)
                    {
                        Color pixelTranslated = panelImage.GetPixel(x, y);

                        int xTraslationPoint = x + translation[0];
                        int yTranslationPoint = y + translation[1];
                            
                        newImage.SetPixel(xTraslationPoint, yTranslationPoint, pixelTranslated);
       
                    }
                    
                }
            }


            return newImage;

        }

        public static Bitmap ClearBitMap(Bitmap panelImage)
        {

            Bitmap tempImage = new Bitmap(panelImage);
            //The width and height will be equal
            int dimension = panelImage.Width;
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    //Sets image to full black
                    tempImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                }
            }

            return tempImage;
        }
    }

}
