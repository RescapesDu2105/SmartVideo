using DTOLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SmartVideo
{
    public class ListFilmsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ChangePageButtonCommand CPBC { get; set; } 
        public SmartWCFServiceReference.SmartWCFServiceClient ClientService { get; set; }

        public ListFilmsViewModel(ObservableCollection<FilmDTO> listFilmsDTO, SmartWCFServiceReference.SmartWCFServiceClient clientService)
        {
            ClientService = clientService;
            ListFilmsDTO = listFilmsDTO;
            //CPBC = new ChangePageButtonCommand(ClientService.GetFilmsPage, this);
        }

        public ObservableCollection<FilmDTO> ListFilmsDTO
        {
            get { return ListFilmsDTO; }
            set
            {
                ListFilmsDTO = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ListFilmsDTO"));
                }
            }
        }
       
    }
}
