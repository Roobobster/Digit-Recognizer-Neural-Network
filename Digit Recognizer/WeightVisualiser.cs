using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using ANN;

namespace Digit_Recognizer
{
    public static class WeightVisualiser
    {

        public static Bitmap[] GenerateWeightVisuals(NeuralNetwork neuralNetwork, int brightness)
        {
           
            IUnit[][] networkUnits = neuralNetwork.ReturnUnits();


            double[][][] learnedFeatures = CalculateFinalFeatures(networkUnits);
            int featureCount = learnedFeatures.Length;

            Bitmap[] weightVisuals = new Bitmap[featureCount];

            //Gets the dimensions of the learned features which is x,y of the input image ( image is square so x = y)
            int dimension = learnedFeatures[0].Length;
            for (int feature = 0; feature < featureCount; feature++)
            {
                weightVisuals[feature] = new Bitmap(dimension, dimension);
                for (int x = 0; x < dimension; x++)
                {
                    for (int y = 0; y < dimension; y++)
                    {
                        double red = 0;
                        double blue = 0;
                        double featureValue = learnedFeatures[feature][x][y] * brightness;
                        //double pixelFeatureValue = 1 - Math.Exp(- featureValue);


                        //Makes all the negative weights red and all the positive weights blue.
                        if (featureValue < 0)
                        {
                            red = featureValue * -1;
                            red = (1 / (1 + Math.Exp(-red*1.5 + 4))) * 255;
                        }
                        else
                        {
                            blue = featureValue;
                            blue = (1 / (1 + Math.Exp(-blue*1.5 + 4))) * 255;
                        }




                        //(int)blue + (int)red) / 2, ((int)blue + (int)red) / 2,((int)blue + (int)red) / 2 )

                        weightVisuals[feature].SetPixel(x, y, Color.FromArgb((int)red, (int)0, (int)blue));
                    }
                }
            }

            return weightVisuals;
        }




        private static double[][][] CalculateFinalFeatures(IUnit[][] networkUnits)
        {
            double[][][] learnedFeatures = InitialiseLearnedFeatureArray(networkUnits);
           
            int featureCount = networkUnits[2].Length;


            //This array will hold the features for the new features that are even closer to the final features learned by the classifications.
            double[][][] newLearnedFeatures = null;

            int featureLayerCount = networkUnits.Length - 1;
            for (int layer = 0; layer < featureLayerCount; layer++)
            {
                newLearnedFeatures = new double[featureCount][][];
                //Loops for every feature that this new layer has.
                for (int feature = 0; feature < featureCount; feature++)
                {
                    //The number of weights these features have will be equal to the features in the previous layer.
                    int weightCount = learnedFeatures.Length;
                    


                    //Gets the dimensions of the learned features
                    int dimension = learnedFeatures[0].Length;
                    newLearnedFeatures[feature] = new double[dimension][];
                    for (int x = 0; x < dimension; x++)
                    {

                        newLearnedFeatures[feature][x] = new double[dimension];
                        for (int y = 0; y < dimension; y++)
                        {
                            //Loops for every previous feature.
                            for (int previousFeature = 0; previousFeature < weightCount; previousFeature++)
                            {
                                newLearnedFeatures[feature][x][y] += learnedFeatures[previousFeature][x][y] * networkUnits[layer+1][feature].ReturnWeight(previousFeature);
                            }
                            
                        }
                    }

                    

                }
                learnedFeatures = newLearnedFeatures;
            }
            

            return learnedFeatures;

        }


       



        //Gets all the learned features of the input stream. (Generalised learned features, not unit specific)
        private static double[][][] InitialiseLearnedFeatureArray(IUnit[][] networkUnits)
        {
       

            int featureLayerIndex = 1;
            //Gets the amount of hidden units which is the amount of different learned features it has. 
            int featureCount = networkUnits[1].Length;

            double[][][] learnedFeatures = new double[featureCount][][];

            int loop = 0;
            for (int unit = 0; unit < featureCount; unit++)
            {
                //Gets the dimensions of the input stream (digit image which will be 28x28 for the current database image/network)
                int dimension = 28;
                learnedFeatures[unit] = new double[dimension][];
                for (int x = 0; x < dimension; x++)
                {
                    learnedFeatures[unit][x] = new double[dimension];
                    for (int y = 0; y < dimension; y++)
                    {
                        //Fills the learned features with the specific input feature 
                        learnedFeatures[unit][x][y] = networkUnits[featureLayerIndex][unit].ReturnWeight(x*dimension + y );
        
                    }
                }
            

            }

            return learnedFeatures;

        }


       
    }

}
