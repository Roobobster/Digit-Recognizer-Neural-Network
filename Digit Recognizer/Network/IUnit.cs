using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    public interface IUnit
    {
        double CalculateOutput(double[] inputVector);
        int ReturnWeightCount();
        double ReturnWeight(int weightIndex);
        void ChangeWeights(double[] weightChanges);
        void ChangeBias(double bias);
        void SetWeights(double[] weights);
        double[] ReturnAllWeights();
    }
}
