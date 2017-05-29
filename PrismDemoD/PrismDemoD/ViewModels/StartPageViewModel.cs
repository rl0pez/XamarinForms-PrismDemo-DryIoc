using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemoD.Models;
using System.Collections.ObjectModel;
using PrismDemoD.Services;

namespace PrismDemoD.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        IBookService _bookService;

        private ObservableCollection<BookGroup> _bookGroups;
        public ObservableCollection<BookGroup> BookGroups
        {
            get { return _bookGroups; }
            set { SetProperty(ref _bookGroups, value); }
        }

        // Passed parameter:
        private string paramstring;
        //public void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    if (parameters.ContainsKey("paramEntry"))
        //    {
        //        paramstring = (string)parameters["paramEntry"];
        //        //_lexitems = await _lexitemManager.GetTasksAsync(param_suchstring);
        //        // LexItems = await _lexitemManager.GetTasksAsync(param_suchstring);

        //        MainText = paramstring;
        //        //int num = _lexitems.Count;
        //        //string msg;
        //        //_dialogService.DisplayAlertAsync("Jak Prism", "Listcount: " + num.ToString(), "OK");
        //        //if (_lexitems.Count > 0)
        //        //{
        //        //    msg = num.ToString() + " items. ";
        //        //    msg += _lexitems[0].canform;
        //        //    ListStatus = msg;
        //        //}
        //    }
        //    else
        //    {
        //        MainText = "Kein Parameter";    // wird nicht angezeigt
        //    }
        //}

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
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
        public DelegateCommand LoadJsonCommand { get; set; }
        public DelegateCommand<Book> BookSelectedCommand => new DelegateCommand<Book>(OnBookSelectedCommandExecuted);

        //private void AddTag()
        //{
        //    //_people.Add("zusätzlich");
        //    _booklist.Add(new Book() { Title = "Neues Buch", Year = 2015, Author = "Dolby", FirstName = "John" });
        //}
        //private void RemoveItem()
        //{
        //    _booklist.RemoveAt(2);
        //    MainText = "Buch an dritter Position gelöscht...";
        //}

        public StartPageViewModel(INavigationService navigationService, IBookService bookService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            MainText = "Noch nichts Besonderes...";
            //AddItemCommand = new DelegateCommand(AddTag);
            //RemoveItemCommand = new DelegateCommand(RemoveItem);
            //NewItemsCommand = new DelegateCommand(Starten);    //(LoadNewItems);
            ReloadTagsCommand = new DelegateCommand(ReloadTags);
            LoadJsonCommand = new DelegateCommand(LoadJsonBooks);

            //// _people = new ObservableCollection<Person>();  siehe oben
            //_booklist.Add(new Book() { Title = "Narrenschicksal", FirstName = "Hamza", Author = "Anjum" });
            //_booklist.Add(new Book() { Title = "Abenteuer unter Wasser", FirstName = "Shahzad", Author = "Sheikh" });
            //_booklist.Add(new Book() { Title = "Emil und die Detektive", FirstName = "Usman", Author = "Irfan" });
            //_booklist.Add(new Book() { Title = "Totentanz", FirstName = "Farooq", Author = "Kamran" });
        }

        private async void LoadJsonBooks()
        {
            //if (BookGroups == null)
            //    BookGroups = new ObservableCollection<BookGroup>(await _bookService.GetBookGroups());
        }

        void OnBookSelectedCommandExecuted(Book item)
        {
            //Debug.WriteLine("Hi " + name + "!");
            MainText = "Buch " + item.Title + " ( aus Liste entfernt (disabled)";
            //_booklist.Remove(item);
        }

        public void ReloadTags()
        {
            //var tags = new ObservableCollection<string>();
            //tags.Add("Im Westen nichts Neues");
            //tags.Add("A Way with Words");
            //tags.Add("Discourse & Cognition");
            //tags.Add("Buch");
            //tags.Add("Buch");
            //tags.Add("Buch");
            //tags.Add("Buch");
            //tags.Add("Buch");

            //_booklist.Clear();
            //foreach (string t in tags)
            //{
            //    // zu Person umwandeln
            //    _booklist.Add(new Book() { Title = t });
            //}
            //MainText = tags.Count.ToString() + " reloaded...";
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (BookGroups == null)
                BookGroups = new ObservableCollection<BookGroup>(await _bookService.GetBookGroups());
        }
 
    }
    
}
