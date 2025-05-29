namespace MerhabaMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActifgvationState? activationState)
        {df
            return new Window(new AppShell());
        }
    }
}