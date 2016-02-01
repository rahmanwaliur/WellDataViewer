using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WellDataViewerProject.DataAccess;

namespace WellDataViewerProject.ViewModel
{
    class WellDataListViewModel : ViewModelBase
    {
        WellDataRepository _dataRepository = new WellDataRepository();

        RelayCommand _browseCommand;

        public WellDataListViewModel()
        {
            
        }

        protected override void OnDispose()
        {
            AllWellData.Clear();
        }

        private ObservableCollection<Model.WellData> _wellData;
        public ObservableCollection<Model.WellData> AllWellData
        {
            get
            {
                return _wellData;
            }
            set 
            {
                _wellData = value;
                OnPropertyChanged("AllWellData");
            }
        }

        private String _wellDataPath;
        public String WellDataPath
        {
            get
            {
                return _wellDataPath;
            }
            set
            {
                _wellDataPath = value;
                OnPropertyChanged("WellDataPath");
            }
        }

        
        public ICommand BrowseCommand
        {
            get 
            {
                if (_browseCommand == null)
                {
                    _browseCommand = new RelayCommand(param => this.BrowseCommandExecute(), param => this.BrowseCommandCanExecute);
                }

                return _browseCommand;
            }
        }

        void BrowseCommandExecute()
        {
            WellDataRepository dataAccess = new WellDataRepository();

            AllWellData = new ObservableCollection<Model.WellData>(_dataRepository.GetXMLData());

            WellDataPath = AllWellData.ElementAt(0).FilePath;

          
        }
            
        bool BrowseCommandCanExecute
        {
           get
           {
               return true;
           }
        }
    }
}
