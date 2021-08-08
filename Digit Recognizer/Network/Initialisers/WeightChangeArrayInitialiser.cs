using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    public static class WeightChangeArrayInitialiser
    {
        static public double[][][] CreateWeightChangeArrays( IUnit[][] Units)
        {
            double[][][] weightChanges = null;

            int layerCount = Units.Length;
            int outputCount = Units[layerCount - 1].Length;
            int inputCount = Units[0].Length;
            int hiddenUnitCount = Units[1].Length;


            weightChanges = InitialiseWeightStructure(weightChanges, layerCount);
            weightChanges = InitialiseWeightInputLayer(weightChanges, inputCount);
            weightChanges = IntialiseHiddenLayers(Units, weightChanges,  hiddenUnitCount);
            weightChanges = IntialiseOutputLayer(Units, weightChanges,  outputCount);

            return weightChanges;
        }



        //Creates a struture of Units that simulates layers of a network with arrays.
        static private double[][][] InitialiseWeightStructure(double[][][] weightChanges, int layerCount)
        {

            weightChanges = new double[layerCount][][];
            return weightChanges;
        }


        //Initialises the Structure but it will never fill the input layer with actual units.
        static private double[][][] InitialiseWeightInputLayer(double[][][] weightChanges, int inputCount)
        {

            weightChanges[0] = new double[inputCount][];
            return weightChanges;
        }


        //Initialises all the units in a specified layer.
        static private double[][][] InitialiseUnitsInLayer( IUnit[][] Units, double[][][] weightChanges, int layerIndex, int unitCount, bool isOutput = false)
        {
            int weightCount = Units[layerIndex - 1].Length;
            for (int unit = 0; unit < unitCount; unit++)
            {

                weightChanges[layerIndex][unit] = new double[weightCount];

                weightChanges = InitialiseWeightChangeValues(weightChanges, layerIndex, unit, weightCount);
            }

            return weightChanges;
        }

        //Sets all the weights changes initially to 0.
        static private double[][][] InitialiseWeightChangeValues(double[][][] weightChanges, int layerIndex, int unitIndex, int weightCount)
        {
            for (int weight = 0; weight < weightCount; weight++)
            {
                weightChanges[layerIndex][unitIndex][weight] = 0;
            }
            return weightChanges;
        }

        //Intialises all of the hidden layers.
        static private double[][][] IntialiseHiddenLayers( IUnit[][] Units, double[][][] weightChanges,  int hiddenUnitCount)
        {

            int hiddenLayerCount = Units.Length - 2;
            int hiddenStartIndex = 1;
            for (int layer = hiddenStartIndex; layer <= hiddenLayerCount; layer++)
            {

                weightChanges[layer] = new double[hiddenUnitCount][];

                weightChanges = InitialiseUnitsInLayer( Units, weightChanges, layer, hiddenUnitCount);

            }

            return weightChanges;
        }

        //Intialises all of the ouput layers.
        static private double[][][] IntialiseOutputLayer(IUnit[][] Units, double[][][] weightChanges, int outputCount)
        {
            int outputIndex = Units.Length - 1;
            //Gets the number of units in the previous stage (Equal to the weights for each unit in the next layer).
            int weightCount = Units[outputIndex - 1].Length;


            weightChanges[outputIndex] = new double[outputCount][];

            weightChanges = InitialiseUnitsInLayer( Units, weightChanges, outputIndex, outputCount, true);

            return weightChanges;
        }

    }
}
