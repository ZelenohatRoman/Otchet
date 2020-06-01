using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using RPTSobj.ApplicationServices.Ports;
using RPTSobj.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace RPTSobj.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetRPTSobjListUseCase _getRPTSobjListUseCase;

        public MainViewModel(IGetRPTSobjListUseCase getRPTSobjListUseCase)
            => _getRPTSobjListUseCase = getRPTSobjListUseCase;

        private Task<bool> _loadingTask;
        private rptsobj _currentRPTSobj;
        private ObservableCollection<rptsobj> _rptsobjs;

        public event PropertyChangedEventHandler PropertyChanged;

        public rptsobj CurrentRPTSobj
        {
            get => _currentRPTSobj; 
            set
            {
                if (_currentRPTSobj != value)
                {
                    _currentRPTSobj = value;
                    OnPropertyChanged(nameof(CurrentRPTSobj));
                }
            }
        }

        private async Task<bool> LoadRPTSobjs()
        {
            var outputPort = new OutputPort();
            bool result = await _getRPTSobjListUseCase.Handle(GetRPTSobjListUseCaseRequest.CreateAllRPTSobjsRequest(), outputPort);
            if (result)
            {
                RPTSobjs = new ObservableCollection<rptsobj>(outputPort.RPTSobjs);
            }
            return result;
        }

        public ObservableCollection<rptsobj> RPTSobjs
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadRPTSobjs();
                }
                
                return _rptsobjs; 
            }
            set
            {
                if (_rptsobjs != value)
                {
                    _rptsobjs = value;
                    OnPropertyChanged(nameof(RPTSobjs));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetRPTSobjListUseCaseResponse>
        {
            public IEnumerable<rptsobj> RPTSobjs { get; private set; }

            public void Handle(GetRPTSobjListUseCaseResponse response)
            {
                if (response.Success)
                {
                    RPTSobjs = new ObservableCollection<rptsobj>(response.RPTSobjs);
                }
            }
        }
    }
}
