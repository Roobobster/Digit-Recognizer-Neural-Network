using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    class SigmoidUnit : IUnit
    {
        private double[] Weights { get; set; }
        private double Bias { get; set; }
        
        //When the sigmoid unit is created it's weight array is initialised with a random double which is then scaled to the limit.
        public SigmoidUnit(double maxWeight, int weightCount,int unitIndex, bool isOutput, ref Random rnd)
        {
            Weights = new double[weightCount];
            //Make the veritcalIndex 999 so that it doesn't affect any of the other code if it's not on that unit yet.
            int[] verticalIndexes = new int[28];
            int startIndex = 999;
            if (unitIndex >= 28)
            {
                startIndex = unitIndex - 28;
            }
            for (int i = 0; i < verticalIndexes.Length; i++)
            {
                verticalIndexes[i] = startIndex + (i * 28);
            }
            // By multiplying the number by 0.1 it limits it to a max Bias of 0.1 as NextDouble generates a decimal from 0 to 1.
            Bias = rnd.NextDouble() * 0.1;
            for (int i = 0; i < weightCount; i++)
            {
                int lowerIndex = unitIndex * 28;
                int upperIndex = (unitIndex + 1) *28;
                
              
         
                if (isOutput || (i >=  lowerIndex && i < upperIndex) || Weights.Length != (28*28))
                {

                    Weights[i] = rnd.NextDouble();
                    Weights[i] *= maxWeight;
                }
                else
                {
                    Weights[i] = 0;
                }
                
            }
            if (startIndex != 999 && Weights.Length == 28 * 28)
            {
                for (int i = 0; i < verticalIndexes.Length; i++)
                {
                    Weights[verticalIndexes[i]] = rnd.NextDouble();
                    Weights[verticalIndexes[i]] *= maxWeight;
                }
            }
            
        }

        //Calculates the weighted sum of the inputs.
        private double CalculateWeightedSum(double[] inputVector)
        {
            int inputCount = inputVector.Length;
            double weightedSum = 0;
            for (int i = 0; i < inputCount; i++)
            {
                weightedSum += Weights[i] * inputVector[i];
            }

            weightedSum += Bias;
            return weightedSum;
        }

        #region Public Functions

        public void SetWeights(double[] weights)
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }

        //Calculates an ouput based on the inputs provided to the unit.
        public double CalculateOutput(double[] inputVector)
        {
            double weightedSum = CalculateWeightedSum(inputVector);
            //Sigmoid Function
            double output = 1.0 / (1.0 + Math.Exp(-weightedSum));

            return output;
        }

        public int ReturnWeightCount()
        {
            return Weights.Length;
        }

        public double ReturnWeight(int weightIndex)
        {
            return Weights[weightIndex];
        }

        public double[] ReturnAllWeights()
        {
            return Weights;
        }

        public void ChangeWeights(double[] weightChanges)
        {
            int weightCount = Weights.Length;
            for (int weight = 0; weight < weightCount; weight++)
            {
                if (Weights[weight] != 0)
                {
                    Weights[weight] -= weightChanges[weight];

                }

            }
        }

        public void ChangeBias(double biasChange)
        {
            Bias -= biasChange; 
        }
        #endregion
    }
}
