using Prism.Navigation;
using Prism.Mvvm;
using PrismDemoD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismDemoD.ViewModels
{
    public class BookPageViewModel : ViewModelBase
    {
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        public BookPageViewModel()
        {

        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("book"))
                Book = (Book)parameters["book"];
        }
    }
}
