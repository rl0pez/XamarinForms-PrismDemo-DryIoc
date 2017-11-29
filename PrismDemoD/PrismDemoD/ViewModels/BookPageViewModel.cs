using Prism.Navigation;
using Prism.Commands;
using PrismDemoD.Models;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PrismDemoD.ViewModels
{
    public class BookPageViewModel : ViewModelBase
    {
        private IPageDialogService _dialogService;

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        public DelegateCommand ReadBookCommand { get; set; }

        public BookPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            ReadBookCommand = new DelegateCommand(showAlert);
        }

        private async void showAlert()
        {
            // show alert with response
            var answer = await _dialogService.DisplayAlertAsync("Prism: DisplayAlertAsync", "Did you read this book?", "Yes", "No");    
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("book"))
                Book = (Book)parameters["book"];
        }
    }
}
