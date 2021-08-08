using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    public static class DataCollectionInitialiser
    {


        //Initialises the PreviousValues array so that it has the correct format for the new batch size and everything is reset to 0.
        static public double[][][] CreatePreviousValuesArray(IUnit[][] Units,  int batchSize)
        {

            double[][][] PreviousValues = new double[batchSize][][];
            //Loops for every batch Index
            for (int batch = 0; batch < batchSize; batch++)
            {

                int layerCount = Units.Length;
                PreviousValues[batch] = new double[layerCount][];

                //Initialises Target array so that it is the same size as the number of outupts.
                int outputCount = Units[layerCount - 1].Length;
                //Loops for every layer in the network
                for (int layer = 0; layer < layerCount; layer++)
                {
                    int unitCount = Units[layer].Length;
                    PreviousValues[batch][layer] = new double[unitCount];
                    //Loops for every unit in the network and initialises their previous output to be 0. 
                    for (int unit = 0; unit < unitCount; unit++)
                    {
                        PreviousValues[batch][layer][unit] = 0;
                    }
                }
            }

            return PreviousValues;
        }

    }
}
