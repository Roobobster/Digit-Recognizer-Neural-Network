using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    static class NetworkIntialiser
    {


        static public IUnit[][] InitialiseNetwork(ref Random rnd,  int layerCount, int inputCount, int hiddenUnitCount, int outputCount, double maxWeight)
        {
            IUnit[][] units = null;
            units = InitialiseStructure( units, layerCount);
            units =InitialiseInputLayer( units, inputCount);
            units =IntialiseHiddenLayers( units, ref rnd, hiddenUnitCount, maxWeight);
            units = IntialiseOutputLayer( units, ref rnd, outputCount, maxWeight);

            return units;
        }
       
        

        //Creates a struture of units that simulates layers of a network with arrays.
        static private IUnit[][] InitialiseStructure( IUnit[][] units, int layerCount)
        {
            units = new IUnit[layerCount][];

            return units;
        }


        //Initialises the Structure but it will never fill the input layer with actual units.
        static private IUnit[][] InitialiseInputLayer( IUnit[][] units, int inputCount)
        {
            units[0] = new IUnit[inputCount];
            return units;
        }


        //Initialises all the units in a specified layer.
        static private IUnit[][] InitialiseunitsInLayer( IUnit[][] units, ref Random rnd, int layerIndex, double maxWeight, int unitCount, bool isOutput = false)
        {
            int weightCount = units[layerIndex - 1].Length;
            for (int unit = 0; unit < unitCount; unit++)
            {
                units[layerIndex][unit] = new SigmoidUnit(maxWeight, weightCount, unit, isOutput, ref rnd);

            }
            return units;
        }

        //Intialises all of the hidden layers.
        static private IUnit[][] IntialiseHiddenLayers( IUnit[][] units,ref Random rnd, int hiddenUnitCount, double maxWeight)
        {

            int hiddenLayerCount = units.Length - 2;
            int hiddenStartIndex = 1;
            for (int layer = hiddenStartIndex; layer <= hiddenLayerCount; layer++)
            {
                units[layer] = new IUnit[hiddenUnitCount];
                units = InitialiseunitsInLayer( units, ref rnd, layer, maxWeight, hiddenUnitCount);

            }
            return units;

        }

        //Intialises all of the ouput layers.
        static private IUnit[][] IntialiseOutputLayer( IUnit[][] units, ref Random rnd, int outputCount, double maxWeight)
        {
            int outputIndex = units.Length - 1;
            //Gets the number of units in the previous stage (Equal to the weights for each unit in the next layer).
            int weightCount = units[outputIndex - 1].Length;

            units[outputIndex] = new IUnit[outputCount];
            units = InitialiseunitsInLayer( units, ref rnd, outputIndex, maxWeight, outputCount, true);

            return units;
        }
    }
}
