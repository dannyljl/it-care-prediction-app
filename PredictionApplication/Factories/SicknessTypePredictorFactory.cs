using PredictionApplication.Enums;
using PredictionApplication.Interfaces;

namespace PredictionApplication.Factories
{
    public static class SicknessTypePredictorFactory
    {
        public static ISicknessType PredictorFromType(SicknessType sicknessType)
        {
            switch (sicknessType)
            {
                case SicknessType.Physical:
                    return new PhysicalSicknessType();
                case SicknessType.Mental:
                    return new MentalSicknessType();
                default:
                    throw new Exception("Sickness type is not supported:" + sicknessType);
            }
        }
    }
}
