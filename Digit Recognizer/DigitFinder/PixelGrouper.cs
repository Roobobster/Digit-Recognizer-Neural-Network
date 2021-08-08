using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   
namespace Digit_Recognizer
{
    public static class PixelGrouper
    {


        //Scans the image and gets all the points of interest aka the points that have drawing on them. 
        private static List<int[]> ScanImage(Bitmap panelDrawing)
        {
            List<int[]> interestPoints = new List<int[]>();

            int imageWidth = panelDrawing.Width;
            int imageHeight = panelDrawing.Height;
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    //Gets the strength of the pixel in terms of the red channel which is the same as the brightness of the pixel since it's white
                    float pixel = panelDrawing.GetPixel(x, y).R;
                    if (pixel != 0)
                    {
                        int[] point = new int[2];
                        point[0] = x;
                        point[1] = y;
                        interestPoints.Add(point);
                    }
                }
            }

            return interestPoints; 
    
        }


        //This generates all the groups from a set of interest points which are essentially the points drawn by the user. 
        public static List<List<int[]>> GenerateGroupedInterestPoints(Bitmap panelDrawing)
        {

            List<int[]> interestPoints = ScanImage(panelDrawing);

            int pointCount = interestPoints.Count;
            

            //Creates a list grouped objects that each have list of the individual interest points that then is a 2D array that is the x and y points
            List<List<int[]>> groupedInterestPoints = new List<List<int[]>>();


            //This group is for the current group that is being made which will then be added to the groupedInterestPoints when it is fully grouped. 
            List<int[]> currentInterestGroup = new List<int[]>();

            int pixelInterestIndex = 0;

            do
            {
                //The current interest group will then be another group which won't have any points at this instance. 
                

                //If there hasn't been any group points yet then it will create the first group at the first point of interest. 
                if (currentInterestGroup.Count == 0)
                {
                    //Sets base pixel
                    currentInterestGroup.Add(interestPoints[pixelInterestIndex]);
                    //Removes pixel point from points of interest as it's already delt with.
                    interestPoints.RemoveAt(pixelInterestIndex);

                }
                else
                {
                    //Gets the currentInterest group which will have a single grouping and then it will then return it will all the other pixels that group with that single pixel. 
                    currentInterestGroup = CollectAllPointsToGroup(ref interestPoints, currentInterestGroup);

                    groupedInterestPoints.Add(new List<int[]>(currentInterestGroup));
                    currentInterestGroup.Clear();


                }
                //It will keep looping until it has no more points to group.
            } while (interestPoints.Count != 0);


            return groupedInterestPoints; 

        }


        //Collects all the points for a single group.
        private static List<int[]> CollectAllPointsToGroup(ref List<int[]> interestPoints, List<int[]> currentInterestGroup )
        {
            //Initialises a list of coordinates that will then be used to detect if there were any more connections to be made.
            List<int[]> pointsToGroup = new List<int[]>();


            int startIndex = 0;
            do
            {
                //Clears the points to group so that it can be used to detect if there are anymore points that have been added and need to be checked to see if anything else needs to be scanned. 
                pointsToGroup.Clear();
                int groupedCount = currentInterestGroup.Count;

                //Loops for every group pixel that hasn't been compared to already. 
                for (int groupIndex = startIndex; groupIndex < groupedCount; groupIndex++)
                {
                    int[] currentPoint = currentInterestGroup[groupIndex];

                    //Adds all the pixels that are next to the group pixel that is being looked at. 
                    pointsToGroup.AddRange(GroupPixels(ref interestPoints, currentPoint));
                    
                    
                }
                currentInterestGroup.AddRange(pointsToGroup);
                //By changing the starting index you are essentially making it so that it doesn't rescan any of the pixels it has already scanned. 
                startIndex = groupedCount;
            //If there are no more points to group then it will mean that 
            } while (pointsToGroup.Count != 0);

            return currentInterestGroup;

        }

        //Collects all the pixels for a single point to be added to the group.
        private static List<int[]> GroupPixels(ref List<int[]> interestPoints, int[] point)
        {
            int pointCount = interestPoints.Count;
            List<int[]> pixelsToGroup = new List<int[]>();
         
            for (int i = 0; i < pointCount; i++)
            {



                double totalDistance = CalculateDistanceFromPixel(point, interestPoints[i]);

                //It will add the pixel to the group if it's in a 1 by 1 radius of the current pixel from that specific group.
                //Essentially it needs to be connected through out the whole image else it will detect it as two seperate images.
                if (totalDistance < Math.Sqrt(1+1))
                {
                    pixelsToGroup.Add(interestPoints[i]);

                    //Since the point of interest is now delt with it is then removed from the list as it won't need to be looked at for futher grouping. 
                    interestPoints.RemoveAt(i);
                    //Since a point has been removed from the list the list will have 1 less index which will shift all the indexes down by one.
                    i--;
                    pointCount--;
                }
            }

            return pixelsToGroup; 
        }

        //Gets the distance between the current pixel and the interest point you are looking at. 
        private static double CalculateDistanceFromPixel(int[] point,int[] interestPoints)
        {
            //Gets the coordinates into seperate variables from the point coordinates array
            int xCoordinate = point[0];
            int yCoordinate = point[1];

            //Gets the coordinates into seperate variablse from the point of interest that the funtion is finding the distance to.
            int xInterestCooridnate = interestPoints[0];
            int yInteresetCoordinate = interestPoints[1];

            //Calculates the distance in the x axis from point of interest.
            int xDistance = xCoordinate - xInterestCooridnate;

            //Calculates the distance in the y axis from the point of interest.
            int yDistance = yCoordinate - yInteresetCoordinate;

            //Pathagoras theorom to be able to find the distance to the pixel.
            double totalDistance = Math.Sqrt(Math.Pow(xDistance, 2.0) + Math.Pow(yDistance, 2.0));


            return totalDistance;
        }
    }
}
