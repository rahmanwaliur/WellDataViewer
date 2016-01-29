
namespace WellDataViewerProject.Model
{
    public class WellData
    {
        private string recordDate;
        public string RecordDate
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        private string wellName;
        public string WellName
        {
            get { return wellName; }
            set { wellName = value; }
        }

        private int oilProduced;
        public int OilProduced
        {
            get { return oilProduced; }
            set { oilProduced = value; }
        }

        private int gasProduced;
        public int GasProduced
        {
            get { return gasProduced; }
            set { gasProduced = value; }
        }

        private int waterProduced;
        public int WaterProduced
        {
            get { return gasProduced; }
            set { gasProduced = value; }
        }

        private string wellStatus;
        public string WellStatus
        {
            get { return wellStatus; }
            set { wellStatus = value; }
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
    }
}
