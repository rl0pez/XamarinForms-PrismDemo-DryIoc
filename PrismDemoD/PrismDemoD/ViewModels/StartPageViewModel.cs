using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemoD.Models;
using System;

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace PrismDemoD.ViewModels
{
    public class StartPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        // Passed parameter:
        private string paramstring;
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("paramEntry"))
            {
                paramstring = (string)parameters["paramEntry"];
                //_lexitems = await _lexitemManager.GetTasksAsync(param_suchstring);
                // LexItems = await _lexitemManager.GetTasksAsync(param_suchstring);

                MainText = paramstring;
                //int num = _lexitems.Count;
                //string msg;
                //_dialogService.DisplayAlertAsync("Jak Prism", "Listcount: " + num.ToString(), "OK");
                //if (_lexitems.Count > 0)
                //{
                //    msg = num.ToString() + " items. ";
                //    msg += _lexitems[0].canform;
                //    ListStatus = msg;
                //}
            }
            else
            {
                MainText = "Kein Parameter";    // wird nicht angezeigt
            }
        }

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
        public DelegateCommand LoadJsonCommand { get; set; }
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
            MainText = "Noch nichts Besonderes...";
            AddItemCommand = new DelegateCommand(AddTag);
            RemoveItemCommand = new DelegateCommand(RemoveItem);
            //NewItemsCommand = new DelegateCommand(Starten);    //(LoadNewItems);
            ReloadTagsCommand = new DelegateCommand(ReloadTags);
            LoadJsonCommand = new DelegateCommand(LoadJsonBooks);

            // _people = new ObservableCollection<Person>();  siehe oben
            _booklist.Add(new Book() { Title = "Narrenschicksal", FirstName = "Hamza", Author = "Anjum" });
            _booklist.Add(new Book() { Title = "Abenteuer unter Wasser", FirstName = "Shahzad", Author = "Sheikh" });
            _booklist.Add(new Book() { Title = "Emil und die Detektive", FirstName = "Usman", Author = "Irfan" });
            _booklist.Add(new Book() { Title = "Totentanz", FirstName = "Farooq", Author = "Kamran" });
        }

        private void LoadJsonBooks()
        {
            var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Data/PrismDemoD.Booklist1.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
        }

        void OnBookSelectedCommandExecuted(Book item)
        {
            //Debug.WriteLine("Hi " + name + "!");
            MainText = "Buch " + item.Title + " ( aus Liste entfernt)";
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
    
}
