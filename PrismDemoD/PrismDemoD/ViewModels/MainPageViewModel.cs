using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemoD.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public DelegateCommand ToStartPageCommand { get; private set; }

        private string _paramEntry;
        public string ParamEntry
        {
            get { return _paramEntry; }
            set { SetProperty(ref _paramEntry, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToStartPageCommand = new DelegateCommand(ToStartPage);

        }

        // Zur Startpage mit Parameter
        private async void ToStartPage()
        {

            var p = new NavigationParameters();
            p.Add("paramEntry", _paramEntry);

            await _navigationService.NavigateAsync("StartPage", p);
            
        }

 

        public void OnNavigatedToAsync(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

    }
}
