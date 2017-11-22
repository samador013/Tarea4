using Lab3.Model;
using Lab3.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab3.ViewModel
{
    public class PersonaViewModel: INotifyPropertyChanged
    {
        #region Singleton
        private static PersonaViewModel instance = null;

        private PersonaViewModel()
        {
            InitClass();
            InitCommand();            
        }
        public static PersonaViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonaViewModel();
            }
            return instance;
        }
        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion
        #region Instances

        private List<PersonaModel> lstOriginalPersonas = new List<PersonaModel>();

        private ObservableCollection<PersonaModel> _lstPersonas = new ObservableCollection<PersonaModel>();

        public ObservableCollection<PersonaModel> lstPersonas
        {
            get
            {
                return _lstPersonas;
            }
            set
            {
                _lstPersonas = value;
                OnPropertyChanged("lstPersonas");
            }
        }

        private string _TextoBuscar = string.Empty;

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }
            set
            {
                _TextoBuscar = value;
                OnPropertyChanged("TextoBuscar");
                FiltrarPersona(_TextoBuscar);
            }
        }

        private string _NuevaPersona = string.Empty;

        public string NuevaPersona
        {
            get
            {
                return _NuevaPersona;
            }
            set
            {
                _NuevaPersona = value;
                OnPropertyChanged("NuevaPersona");
            }
        }

        private PersonaModel _PersonaActual { get; set; }

        public PersonaModel PersonaActual
        {
            get
            {
                return _PersonaActual;
            }
            set
            {
                _PersonaActual = value;
                OnPropertyChanged("PersonaActual");
            }
        }

        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }

        public ICommand VerPersonaCommand { get; set; }

        #endregion

        private void AgregarPersona()
        {
            lstPersonas.Add(new PersonaModel { Nombre = NuevaPersona });
            lstOriginalPersonas.Add(new PersonaModel { Nombre = NuevaPersona });

            NuevaPersona = string.Empty;
        }

        private void FiltrarPersona(string textoBuscar)
        {
            lstPersonas.Clear();
            lstOriginalPersonas.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => lstPersonas.Add(x));

        }

        private void BorrarPersona(int id)
        {
            lstOriginalPersonas.RemoveAll(p => p.Id == id);
            lstPersonas = new ObservableCollection<PersonaModel>(lstOriginalPersonas);
            
        }

        private void VerPersona(int id)
        {
            PersonaActual = lstOriginalPersonas.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new UsuarioDetalle());

        }

        #region init
        private void InitClass()
        {

            lstPersonas = PersonaModel.ObtenerPersonas();

            lstOriginalPersonas = lstPersonas.ToList();
        }

        private void InitCommand()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
            VerPersonaCommand = new Command<int>(VerPersona);

        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
