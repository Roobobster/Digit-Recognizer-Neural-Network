using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    public static class BiasChangeArrayInitialiser
    {
        static public double[][] CreateBiasArray(IUnit[][] Units)
        {
            //Creates a empty bias change array that will store the bias changes that are to be made from backpropergation.
            double[][] BiasChanges = null;

            int layerCount = Units.Length;
            int outputCount = Units[layerCount - 1].Length;
            int inputCount = Units[0].Length;
            int hiddenUnitCount = Units[1].Length;

            BiasChanges = InitialiseBiasLayer(BiasChanges, layerCount);
            BiasChanges = InitialiseBiasInputLayer(BiasChanges, inputCount);
            BiasChanges = IntialiseBiasHiddenLayers( Units, BiasChanges, hiddenUnitCount );
            BiasChanges = IntialiseBiasOutputLayer(Units, BiasChanges,  outputCount);

            return BiasChanges;
        }

      

        //Creates an 2D array of Bias
        static private double[][] InitialiseBiasLayer(double[][] BiasChanges, int layerCount)
        {
            BiasChanges = new double[layerCount][];
            return BiasChanges;
        }


        //Initialises the Structure but it will never fill the input layer with actual units.
        static private double[][] InitialiseBiasInputLayer(double[][] BiasChanges, int inputCount)
        {

            BiasChanges[0] = new double[inputCount];
            return BiasChanges;
        }


        //Initialises all the units in a specified layer.
        static private double[][] InitialiseUnitsInLayer(IUnit[][] Units, double[][] BiasChanges, int layerIndex, int unitCount)
        {
            int weightCount = Units[layerIndex - 1].Length;
            for (int unit = 0; unit < unitCount; unit++)
            {
                BiasChanges[layerIndex][unit] = 0;

            }

            return BiasChanges;
        }



        //Intialises all of the hidden layers.
        static private double[][] IntialiseBiasHiddenLayers(IUnit[][] Units, double[][] BiasChanges, int hiddenUnitCount)
        {

            int hiddenLayerCount = Units.Length - 2;
            int hiddenStartIndex = 1;
            for (int layer = hiddenStartIndex; layer <= hiddenLayerCount; layer++)
            {


                BiasChanges[layer] = new double[hiddenUnitCount];
                BiasChanges = InitialiseUnitsInLayer(Units, BiasChanges, layer, hiddenUnitCount);

            }
            return BiasChanges;
        }

        //Intialises all of the ouput layers.
        static private double[][] IntialiseBiasOutputLayer(IUnit[][] Units, double[][] BiasChanges, int outputCount)
        {
            int outputIndex = Units.Length - 1;
            //Gets the number of units in the previous stage (Equal to the weights for each unit in the next layer).

            BiasChanges[outputIndex] = new double[outputCount];
            BiasChanges = InitialiseUnitsInLayer(Units, BiasChanges, outputIndex, outputCount);

            return BiasChanges;
        }

       
    }
}
