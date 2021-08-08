using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ANN;

namespace ANN
{
    public class NeuralNetwork
    {
        private Random Rnd;
        private int[] Errors;

        //[Layer][Unit]
        private IUnit[][] Units { get; set; }

        //[Batch][Layer][Unit]
        private double[][][] PreviousValues { get; set; }

        //[Batch][Output]
        private double[][] Targets { get; set; }

        //[Layer][Unit][Weight]
        private double[][][] WeightChanges { get; set; }

        //[Layer][Unit]
        private double[][] BiasChanges { get; set; }


        #region Weights

        public IUnit[][] ReturnUnits()
        {
            return Units;
        }
        public void LoadWeights(string fileAddress)
        {
            StreamReader streamReader = new StreamReader(fileAddress);
            double[][][] loadedWeights = new double[3][][];
            int layerCount = Units.Length;
            for (int layer = 1; layer < layerCount; layer++)
            {
                int unitCount = Units[layer].Length;
                loadedWeights[layer] = new double[unitCount][];
                for (int unit = 0; unit < unitCount; unit++)
                {
                    int weightCount = Units[layer][unit].ReturnWeightCount();
                    loadedWeights[layer][unit] = new double[weightCount];
                    for (int weight = 0; weight < weightCount; weight++)
                    {
                        string weightValue = "";
                        string nextCharacter = "";
                        do
                        {

                            int nextCharacterASCI = streamReader.Read();
                            nextCharacter = ((char)nextCharacterASCI).ToString();

                            weightValue += nextCharacter;



                        } while (nextCharacter != "~");

                        weightValue = weightValue.Remove(weightValue.Length - 1);




                        loadedWeights[layer][unit][weight] = double.Parse(weightValue);

                    }
                    Units[layer][unit].SetWeights(loadedWeights[layer][unit]);
                }
            }

        }


        public void SaveWeights(string fileAddress)
        {

            int layerCount = Units.Length;
            for (int layer = 1; layer < layerCount ; layer++)
            {
                int unitCount = Units[layer].Length;
                for (int unit = 0; unit < unitCount; unit++)
                {
                    string fileString = "";
                    int weightCount = Units[layer][unit].ReturnWeightCount();
                    for (int weight = 0; weight < weightCount; weight++)
                    {
                        double weightValue = Units[layer][unit].ReturnWeight(weight);
                        fileString += weightValue.ToString() + "~";
                    }
                    StreamWriter fileStream = new StreamWriter(fileAddress, true);
                    fileStream.Write(fileString);
                    fileStream.Close();
                }
            }


        }

        #endregion




        public NeuralNetwork(int inputCount, int hiddenUnitCount, int outputCount, double maxWeight, int layerCount)
        {
            Errors = new int[outputCount];
            Rnd = new Random();

            Units = NetworkIntialiser.InitialiseNetwork(ref Rnd, layerCount, inputCount, hiddenUnitCount, outputCount, maxWeight);
            WeightChanges = WeightChangeArrayInitialiser.CreateWeightChangeArrays(Units);
            BiasChanges = BiasChangeArrayInitialiser.CreateBiasArray(Units);
           
            
        }

        


        #region Error Functions

        //This resets the error array which holds all the errors accumulated.
        private void ResetErrors()
        {
            int outputCounter = Errors.Length;
            for (int i = 0; i < outputCounter; i++)
            {
                Errors[i] = 0;
            }
        }

        //This returns the error array so that you can't change the value yourself.
        public int[] ReturnErrors()
        {
            return Errors;
        }

        private void AccumulateErrors(int batchIndex)
        {
            int greatestIndex = 0;

            int layerCount = Units.Length;
            int outputCount = Units[layerCount - 1].Length;

            //Loops for every output and finds the output with the highest value
            for (int output = 0; output < outputCount; output++)
            {
                double greatestValue = PreviousValues[batchIndex][layerCount - 1][greatestIndex];
                double nextValue = PreviousValues[batchIndex][layerCount - 1][output];
                if (greatestValue < nextValue)
                {
                    greatestIndex = output;
                }
            }

            //Target index is initialised as 0 so that is assigned.
            int targetIndex = 0;
            //Loops for every target to find the index of the target.
            for (int target = 0; target < outputCount; target++)
            {
                if (Targets[batchIndex][target] == 1)
                {
                    targetIndex = target;
                }
            }

            //The greatest index is the value that the network is most confident on classifiy.
            if (greatestIndex != targetIndex)
            {
                Errors[targetIndex] += 1;
            }
        }


        #endregion

        private void ResetWeightAndBiasChanges()
        {
            int layerCount = Units.Length;
            for (int layer = 1; layer < layerCount; layer++)
            {
                int unitCount = Units[layer].Length;
                for (int unit = 0; unit < unitCount; unit++)
                {
                    BiasChanges[layer][unit] = 0;
                    int weightCount = Units[layer][unit].ReturnWeightCount();
                    for (int weight = 0; weight < weightCount; weight++)
                    {
                        WeightChanges[layer][unit][weight] = 0;
                    }
                }
            }
        }

        #region Public Functions
        //This will train the network using batches.
        public void TrainNetwork(double[][] inputMatrix, double[][] targetMatrix ,double learnRate)
        {
            ResetWeightAndBiasChanges();
            //Resets the errors just so that they don't include errors from previous training batch.
            ResetErrors();
            Targets = targetMatrix;
            int batchSize = inputMatrix.Length;
            //Initialises preious array so that it has the correct structure to fit the batchSize.
            PreviousValues = DataCollectionInitialiser.CreatePreviousValuesArray(Units, batchSize);
  

            //Loops for every batch
            Parallel.For(0, batchSize, batch =>
            {

                //Gets the input vector for batch
                double[] inputVector = inputMatrix[batch];
                //Runs the network with single batch
                RunNetwork(inputVector, batch);
                //Backpropergates with single batch
                BackPropergate(batch);
                AccumulateErrors(batch);



            });




            //Scales the weight changes accumulated to take in account the batch size and learn rate.
            ScaleWeightAndBiasChanges(learnRate, batchSize);

            //Finally changes the weight and bias.
            ChangeWeightsAndBias();


        }

        //Runs the network (feed forward)
        public double[] RunNetwork(double[] inputVector, int batchIndex)
        {
            if (PreviousValues == null)
            {
                PreviousValues = DataCollectionInitialiser.CreatePreviousValuesArray(Units, 1);

            }
            int layerCount = Units.Length;

            PreviousValues[batchIndex][0] = inputVector;



            //Loops for every layer not including the input layer as it works different from the other layers.
            for (int layer = 1; layer < layerCount; layer++)
            {
                int unitCount = Units[layer].Length;
                double[] outputVector = new double[unitCount];
                for (int unit = 0; unit < unitCount; unit++)
                {
                    outputVector[unit] = Units[layer][unit].CalculateOutput(inputVector);
                }
                PreviousValues[batchIndex][layer] = outputVector;
                //Input vector becomes the ouput from the previous layer when it loops again.
                inputVector = outputVector;
            }

           

            //The final version of the input vector will be the final layer's output. 
            return inputVector;

        }


        //This just changes the structure of the PreviousValue array so that it works the the new batch size. 

        #endregion

        #region Learning Region
        //Backpropergates a single input.
        private void BackPropergate(int batchIndex)
        {
            int startIndex = Units.Length - 1;
            int endIndex = 0;
            //Starts at the top layer ( output layer ) and goes back throught the network.
            for (int layer = startIndex; layer > endIndex; layer--)
            {
                int unitCount = Units[layer].Length;
                for (int unit = 0; unit < unitCount; unit++)
                {
                    BiasChanges[layer][unit] += CalculatedErrorDerivativeWRTWeightedSum(batchIndex, layer, unit);
                    int weightCount = Units[layer][unit].ReturnWeightCount();
                    for (int weight = 0; weight < weightCount; weight++)
                    {
                        WeightChanges[layer][unit][weight] += CalculateErrorDerivativeWRTWeight(batchIndex, layer, unit, weight);
                        //The bias change derivative is just the error derivative with respect to the weighted sum as the error derivative with respect to the bias is just 1.
                        
                    }
                }
            }
        }

        //Scales the weight changes so that they take in account the batch size and the learn rate. 
        private void ScaleWeightAndBiasChanges(double learnRate, int batchSize)
        {
  
            int layerCount = Units.Length;
            for (int layer = 1; layer < layerCount; layer++)
            {
                int unitCount = Units[layer].Length;
                for (int unit = 0; unit < unitCount; unit++)
                {
                    int weightCount = Units[layer][unit].ReturnWeightCount();
                    BiasChanges[layer][unit] /= batchSize;
                    BiasChanges[layer][unit] *= learnRate;
                    for (int weight = 0; weight < weightCount; weight++)
                    {
                        WeightChanges[layer][unit][weight] /= batchSize;
                        WeightChanges[layer][unit][weight] *= learnRate;
                    }
                }
            }
        }

        //Changes the weights and bias' of the network using the weight changes produced in backpropergation.
        private void ChangeWeightsAndBias()
        {
            int layerCounter = Units.Length;

            //Loops for every layer in the network apart from the first layer as it has no weights or bias.
            for (int layer = 1; layer < layerCounter; layer++)
            {
                int unitCount = Units[layer].Length;
                //Loops for every unit in the layer.
                for (int unit = 0; unit < unitCount; unit++)
                {
                    Units[layer][unit].ChangeWeights(WeightChanges[layer][unit]);
                    Units[layer][unit].ChangeBias(BiasChanges[layer][unit]);
                }
            }

        }

        #region Backpropergation Algorithm

        // dE / dZ
        private double CalculatedErrorDerivativeWRTWeightedSum(int batchIndex, int layerIndex, int unitIndex)
        {
            double outputDerivativeWRTWeightedSum = CalculateOutputDerivativeWRTWeightedSum(batchIndex, layerIndex, unitIndex);
            double errorDerivativeWRTOutput;
            double derivative;
            int ouputLayerIndex = Units.Length - 1;


            //The algorithm will be different for the ouput layer and therefore this needs to have a different error derivative with respect to the ouput compared to the hidden layer.
            if (layerIndex == ouputLayerIndex)
            {
                errorDerivativeWRTOutput = CalculateErrorDerivativeWRTOutput(batchIndex, layerIndex, unitIndex);
            }
            else
            {
                errorDerivativeWRTOutput = CalculateErrorDerivativeWRTOutputBelow(batchIndex, layerIndex, unitIndex);
            }

            derivative = outputDerivativeWRTWeightedSum * errorDerivativeWRTOutput;
            return derivative;

        }

        // dY / dZ
        private double CalculateOutputDerivativeWRTWeightedSum(int batchIndex, int layerIndex, int unitIndex)
        {
            double output = PreviousValues[batchIndex][layerIndex][unitIndex];
            //y *(1 -y) 
            double derivative = output * (1 - output);
            return derivative;
        }

        // dE / dy ( Output Layer)
        private double CalculateErrorDerivativeWRTOutput(int batchIndex, int layerIndex, int unitIndex)
        {
            double output = PreviousValues[batchIndex][layerIndex][unitIndex];
            double target = Targets[batchIndex][unitIndex];
            double derivative = output - target;

            //This make it so that the network prioritizes that the network gets the correct answer over the confidence of the other outputs. 
            if (target == 1)
            {

                //By making the changes 12 times more bigger it will mean that it will be 0.2 times more important to get the correct classification.
                derivative *= 12;
            }
            return derivative;
        }


        // dE / dW
        private double CalculateErrorDerivativeWRTWeight(int batchIndex, int layerIndex, int unitIndex, int weightIndex)
        {

            double weightedSumDerivativeWRTWeight = CalculateWeightedSumDerivativeWRTWeight(batchIndex, layerIndex, weightIndex);

            double errorDerivativeWRTWeightedSum = CalculatedErrorDerivativeWRTWeightedSum(batchIndex, layerIndex, unitIndex);

            double derivative = weightedSumDerivativeWRTWeight * errorDerivativeWRTWeightedSum;

            return derivative;
        }

        // dZ / dW
        private double CalculateWeightedSumDerivativeWRTWeight(int batchIndex, int layerIndex, int weightIndex)
        {
            double output = PreviousValues[batchIndex][layerIndex - 1][weightIndex];
            return output;
        }


        // dE / dy ( below Layer)
        private double CalculateErrorDerivativeWRTOutputBelow(int batchIndex, int layerIndex, int unitIndex)
        {

            double derivative = 0;
            int unitsInlayerAbove = Units[layerIndex + 1].Length;


            double unitsInLayerAbove = Units[layerIndex + 1].Length;
            for (int weight = 0; weight < unitsInLayerAbove; weight++)
            {
                double weightedSumDerivativeWRTOutput = Units[layerIndex + 1][weight].ReturnWeight(unitIndex);
                double errorDerivativeWRTWeightedSum = CalculatedErrorDerivativeWRTWeightedSum(batchIndex, layerIndex+1, weight);
                derivative += weightedSumDerivativeWRTOutput * errorDerivativeWRTWeightedSum;
            }


            return derivative;
        }

        #endregion

        #endregion






    }
}
