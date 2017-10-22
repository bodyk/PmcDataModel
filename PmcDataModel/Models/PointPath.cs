namespace PmcDataModel.Models
{
    public class PointPath
    {
        public int? MatrixNumber { get; set; }
        public int PositionNumber { get; set; }

        public bool Equals(PointPath other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.MatrixNumber == null || MatrixNumber == null)
            {
                return other.PositionNumber == PositionNumber;
            }

            return other.MatrixNumber == MatrixNumber && other.PositionNumber == PositionNumber;
        }
    }
}
