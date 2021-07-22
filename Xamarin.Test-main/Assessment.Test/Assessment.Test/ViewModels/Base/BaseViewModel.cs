using Assessment.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Assessment.Test.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Constructors & initialisation

        public BaseViewModel(IErrorHandlingService pErrorHandlingService)
        {
            errorHandlingService = pErrorHandlingService;
        }
        public BaseViewModel()
        {
            errorHandlingService = DependencyService.Get<IErrorHandlingService>();
        }
        private void _constructor()
        {

        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Services

        public IErrorHandlingService errorHandlingService;

        #endregion


        #region Properties

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }

        #endregion

        #region Methods

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
