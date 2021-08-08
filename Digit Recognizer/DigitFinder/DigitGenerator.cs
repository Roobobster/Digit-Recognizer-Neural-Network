using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Digit_Recognizer
{
    public static class DigitGenerator
    {
        public static Bitmap[] GenerateBitmapsWithGroups(List<List<int[]>> groupedPointsOfInterest)
        {
            int groupCount = groupedPointsOfInterest.Count;
            Bitmap[] groupImages = new Bitmap[groupCount];
            for (int group = 0; group < groupCount; group++)
            {
                int width = GetGroupWidth(groupedPointsOfInterest[group]);
                int height = GetGroupHeight(groupedPointsOfInterest[group]);

                int dimension;
                if (width > height)
                    dimension = width;
                else
                    dimension = height;

                //Creates a bitmap with the dimensions of the group. 
                groupImages[group] = new Bitmap(dimension, dimension);
                //Fills the images with the points of interest.
                groupImages[group] = FillBitmapWithGroupPixels(groupImages[group], groupedPointsOfInterest[group]);
            }

            return groupImages;

        }

        private static Bitmap FillBitmapWithGroupPixels(Bitmap blankImage, List<int[]> groupOfInterest)
        {
            Bitmap filledImage = new Bitmap(blankImage);
            int width = filledImage.Width;
            int height = filledImage.Height;

            //Loops for every pixel in the image and sets every pixel black
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    filledImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                }
            }

            int pointCount = groupOfInterest.Count;
            int[] offset = GetGroupOffSet(groupOfInterest);
            //Loops for every group point and adds the point to the image.
            for (int pointIndex = 0; pointIndex < pointCount; pointIndex++)
            {
                int x = groupOfInterest[pointIndex][0] - offset[0];
                int y = groupOfInterest[pointIndex][1] - offset[1];

                filledImage.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
            }

            return filledImage;


        }

        private static int[] GetGroupOffSet(List<int[]> groupOfInterest)
        {
            int yStartIndex = 99999;
            int xStartIndex = 99999;

            //Finds the starting x and y coordinates of the image
            foreach (int[] coordinate in groupOfInterest)
            {
                
                int yCoordinate = coordinate[1];

                if (yCoordinate < yStartIndex)
                    yStartIndex = yCoordinate;

                int xCoordinate = coordinate[0];

                if (xCoordinate < xStartIndex)
                    xStartIndex = xCoordinate;

            }

            int[] offset = new int[2];
            offset[0] = xStartIndex;
            offset[1] = yStartIndex;

            return offset;
        }

        //Gets the height of a group
        private static int GetGroupHeight(List<int[]> groupOfInterest)
        {
            int startIndex = 99999;
            int endIndex = -1;
            foreach (int[] coordinate in groupOfInterest)
            {
                int yCoordinate = coordinate[1];

                if (yCoordinate < startIndex)
                    startIndex = yCoordinate;


                if (yCoordinate > endIndex)
                    endIndex = yCoordinate;

            }

            int height = endIndex - startIndex +1;

            return height;

        }


        //Gets the width of the group
        private static int GetGroupWidth(List<int[]> groupOfInterest)
        {
            int startIndex = 99999;
            int endIndex = -1;
            foreach (int[] coordinate in groupOfInterest)
            {
                int xCoordinate = coordinate[0];

                if (xCoordinate < startIndex)
                    startIndex = xCoordinate;
                

                if (xCoordinate > endIndex)
                    endIndex = xCoordinate;
                
            }

            int width = endIndex - startIndex +1 ;

            return width;

        }
    }
}
