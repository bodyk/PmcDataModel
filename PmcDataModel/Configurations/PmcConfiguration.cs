namespace PmcDataModel.Configurations
{
    public class PmcConfiguration<T>
    {
        public T DataValue { get; set; }
        public int CountContainers { get; set; }
        public int CountMatrices { get; set; }
        public int CountPositions { get; set; }
        public int CountPoints { get; set; }
        public MatrixConfiguration MatrixConfig { get; set; }
        public XyConfiguration XyConfig { get; set; }
        public XyzConfiguration XyzConfig { get; set; }
    }
}
