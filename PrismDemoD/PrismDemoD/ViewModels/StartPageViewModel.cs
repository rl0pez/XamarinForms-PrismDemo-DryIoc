using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemoD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismDemoD.ViewModels
{
    public class StartPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        public DelegateCommand NavToMainPageCommand { get; private set; }

        private ObservableCollection<Book> _booklist = new ObservableCollection<Book>();
        public ObservableCollection<Book> Booklist
        {
            get { return _booklist; }
            set { SetProperty(ref _booklist, value); }
        }

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }
        //public string _vorname = Person.FirstName;

        private string _maintext = "start...";
        public string MainText
        {
            get { return _maintext; }
            set { SetProperty(ref _maintext, value); }
        }

        public DelegateCommand AddItemCommand { get; set; }
        public DelegateCommand RemoveItemCommand { get; set; }
        public DelegateCommand ReloadTagsCommand { get; set; }
        public DelegateCommand<Book> BookSelectedCommand => new DelegateCommand<Book>(OnBookSelectedCommandExecuted);

        private void AddTag()
        {
            //_people.Add("zusätzlich");
            _booklist.Add(new Book() { Title = "Neues Buch", Year = 2015, Author = "Dolby", FirstName = "John" });
        }
        private void RemoveItem()
        {
            _booklist.RemoveAt(2);
            MainText = "Buch an dritter Position gelöscht...";
        }

        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavToMainPageCommand = new DelegateCommand(ToMain);
            MainText = "Noch nichts Besonderes...";
            AddItemCommand = new DelegateCommand(AddTag);
            RemoveItemCommand = new DelegateCommand(RemoveItem);
            //NewItemsCommand = new DelegateCommand(Starten);    //(LoadNewItems);
            ReloadTagsCommand = new DelegateCommand(ReloadTags);

            // _people = new ObservableCollection<Person>();  siehe oben
            _booklist.Add(new Book() { Title = "Narrenschicksal", FirstName = "Hamza", Author = "Anjum" });
            _booklist.Add(new Book() { Title = "Abenteuer unter Wasser", FirstName = "Shahzad", Author = "Sheikh" });
            _booklist.Add(new Book() { Title = "Emil und die Detektive", FirstName = "Usman", Author = "Irfan" });
            _booklist.Add(new Book() { Title = "Totentanz", FirstName = "Farooq", Author = "Kamran" });
        }

        private void ToMain()
        {
            _navigationService.NavigateAsync("MainPage");
        }

        void OnBookSelectedCommandExecuted(Book item)
        {
            //Debug.WriteLine("Hi " + name + "!");
            MainText = "Buch " + item.Title + " (gelöscht)";
            _booklist.Remove(item);
        }

        public void ReloadTags()
        {
            var tags = new ObservableCollection<string>();
            tags.Add("Im Westen nichts Neues");
            tags.Add("A Way with Words");
            tags.Add("Discourse & Cognition");
            tags.Add("Buch");
            tags.Add("Buch");
            tags.Add("Buch");
            tags.Add("Buch");
            tags.Add("Buch");

            _booklist.Clear();
            foreach (string t in tags)
            {
                // zu Person umwandeln
                _booklist.Add(new Book() { Title = t });
            }
            MainText = tags.Count.ToString() + " reloaded...";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
    
}
