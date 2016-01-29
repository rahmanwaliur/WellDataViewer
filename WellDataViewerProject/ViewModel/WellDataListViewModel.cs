﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        private bool _wellStatus;
        public bool WellStatus
        {
            get
            {
                return _wellStatus;
            }
            set
            {
                _wellStatus = value;
                OnPropertyChanged("WellStatus");
            }
        }

        private bool _oilProducedShutIn;
        public bool OilProducedShutIn
        {
            get
            {
                return _oilProducedShutIn;
            }
            set
            {
                _oilProducedShutIn = value;
                OnPropertyChanged("OilProducedShutIn");
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

            foreach (var row in AllWellData)
            {
                if (row.WellStatus == "ShutIn")
                {
                    WellStatus = true;
                    if (row.OilProduced != 0)
                        OilProducedShutIn = false;
                }
                
                
            }
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