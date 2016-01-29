using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellDataViewerProject.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        //readonly EmployeeRepository _employeeRepository;


        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            //_employeeRepository = new EmployeeRepository();
            //EmployeeListViewModel viewModel = new EmployeeListViewModel(_employeeRepository);
            //this.ViewModels.Add(viewModel);

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
