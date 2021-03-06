﻿using DryIoc;
using Prism.DryIoc;
using PrismDemoD.Services;
using PrismDemoD.Views;
using Xamarin.Forms;

namespace PrismDemoD
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/StartPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<StartPage>();
            Container.RegisterTypeForNavigation<BookPage>();

            Container.Register<IBookService, BookService>();
        }
    }
}
