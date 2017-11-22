using Lab3.Model;
using Lab3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab3.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel() {
            LoginCommand = new Command(LoginUser);
        }
        private string _UsuarioStr = string.Empty;

        public string UsuarioStr
        {
            get
            {
                return _UsuarioStr;
            }
            set
            {
                _UsuarioStr = value;
                OnPropertyChanged("UsuarioStr");
            }
        }

        private string _PwdStr = string.Empty;

        public string PwdStr
        {
            get
            {
                return _PwdStr;
            }
            set
            {
                _PwdStr = value;
                OnPropertyChanged("PwdStr");
            }
        }

        private string _ErrorMsg = string.Empty;

        public string ErrorMsg
        {
            get
            {
                return _ErrorMsg;
            }
            set
            {
                _ErrorMsg = value;
                OnPropertyChanged("ErrorMsg");
            }
        }

        public ICommand LoginCommand { get; set; }

        private async void LoginUser()
        {
            LoginModel model = new LoginModel{ UserName=UsuarioStr, Pwd=PwdStr};
            if (model.Validate())
            {
                ErrorMsg = "";
                NavigationPage navigation = new NavigationPage(new MainPage());

                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new HomeMenu(),
                    Detail = navigation
                };
            }
            else{
                //  ErrorMsg = "Usuario o clave incorrecto";
                ClearLogin();
                await App.Current.MainPage.DisplayAlert("Error", "Usuario o clave incorrectos", "Aceptar");
            }
        }

        private void ClearLogin() {
            UsuarioStr = "";
            PwdStr = "";
        }

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
