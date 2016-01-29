using System.Collections.ObjectModel;

namespace WellDataViewerProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        //readonly EmployeeRepository _employeeRepository;


        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            WellDataListViewModel wellDataViewModel = new WellDataListViewModel();
            this.ViewModels.Add(wellDataViewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }

                return _viewModels;
            }
        }
    }
}
