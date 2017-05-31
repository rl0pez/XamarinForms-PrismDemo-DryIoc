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

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
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

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        private string _maintext = "start...";
        public string MainText
        {
            get { return _maintext; }
            set { SetProperty(ref _maintext, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private int _year;
        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }
        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        private string _author;
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        public DelegateCommand AddBookCommand { get; set; }
        public DelegateCommand RemoveItemCommand { get; set; }
        public DelegateCommand ReloadTagsCommand { get; set; }
        public DelegateCommand LoadJsonCommand { get; set; }
        public DelegateCommand<Book> BookSelectedCommand => new DelegateCommand<Book>(OnBookSelectedCommandExecuted);

        private void AddBook()
        {
            Books.Add(new Book() { Title = "Neues Buch", Year = 2015, Author = "Dolby", FirstName = "John" });
        }

        // private void RemoveItem()
        //{
        //    _booklist.RemoveAt(2);
        //    MainText = "Buch an dritter Position gelöscht...";
        //}

        public StartPageViewModel(INavigationService navigationService, IBookService bookService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            MainText = "Noch nichts Besonderes...";
            AddBookCommand = new DelegateCommand(AddBook);
            //RemoveItemCommand = new DelegateCommand(RemoveItem);
            //NewItemsCommand = new DelegateCommand(Starten);    //(LoadNewItems);
            //ReloadTagsCommand = new DelegateCommand(ReloadTags);
            LoadJsonCommand = new DelegateCommand(LoadJsonBooks);

            //// _people = new ObservableCollection<Person>();  siehe oben
            //_booklist.Add(new Book() { Title = "Narrenschicksal", FirstName = "Hamza", Author = "Anjum" });
            //_booklist.Add(new Book() { Title = "Abenteuer unter Wasser", FirstName = "Shahzad", Author = "Sheikh" });
            //_booklist.Add(new Book() { Title = "Emil und die Detektive", FirstName = "Usman", Author = "Irfan" });
            //_booklist.Add(new Book() { Title = "Totentanz", FirstName = "Farooq", Author = "Kamran" });
        }

        private async void LoadJsonBooks()
        {
            // Bücher  //// Achtung! fkt. nicht mit Null-Bedingung!!!!
            //if (Books == null)
            Books = new ObservableCollection<Book>(await _bookService.GetBooks());
            Books.Add(new Book() { Title = "Narrenschicksal", FirstName = "Hamza", Author = "Anjum" });
            MainText = Books[0].ToString();
        }

        void OnBookSelectedCommandExecuted(Book item)
        {
            //Debug.WriteLine("Hi " + name + "!");
            MainText = "Buch " + item.Title + " ( aus Liste entfernt (disabled)";
            //_booklist.Remove(item);
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            //// Achtung! fkt. nicht mit Null-Bedingung!!!! >> Dies war der Blocker !!!!
            //if (Books == null)
            //Books = new ObservableCollection<Book>(await _bookService.GetBooks());
        }

    }
    
}
