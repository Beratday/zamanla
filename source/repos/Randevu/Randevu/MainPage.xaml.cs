namespace Randevu
{
    using System.Collections.ObjectModel;

    namespace Randevu;

    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Appointment> _appointments = new();

        public MainPage()
        {
            InitializeComponent();
            AppointmentsView.ItemsSource = _appointments;
        }

        public object AppointmentsView { get; private set; }
        public object TitleEntry { get; private set; }

        private void OnAddAppointmentClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                DisplayAlert("Hata", "Lütfen randevu başlığını girin.", "Tamam");
                return;
            }

            var appointment = new Appointment
            {
                Title = TitleEntry.Text,
                Date = DatePicker.Date
            };

            _appointments.Add(appointment);
            TitleEntry.Text = string.Empty;
            DatePicker.Date = DateTime.Now;
        }
    }

    public class Appointment
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
