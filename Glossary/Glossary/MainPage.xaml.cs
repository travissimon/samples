namespace Glossary {
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Navigation;
	using Glossary.LoginUI;
	using Glossary.Web;

	/// <summary>
	/// <see cref="UserControl"/> class providing the main UI for the application.
	/// </summary>
	public partial class MainPage : UserControl {
		private MainPageViewModel ViewModel;

		/// <summary>
		/// Creates a new <see cref="MainPage"/> instance.
		/// </summary>
		public MainPage() {
			InitializeComponent();
			ViewModel = new MainPageViewModel();
			DataContext = ViewModel;
		}

		private void HyperlinkButton_Click(object sender, RoutedEventArgs e) {
			ViewModel.CreateNewEntry();
			SwivelToBackStoryboard.Begin();
		}

		private void EditButton_Click(object sender, RoutedEventArgs e) {
			Button editButton = (Button)sender;
			GlossaryEntry entry = (GlossaryEntry)editButton.DataContext;
			ViewModel.EditEntry(entry);
			SwivelToBackStoryboard.Begin();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e) {
			Button editButton = (Button)sender;
			GlossaryEntry entry = (GlossaryEntry)editButton.DataContext;
			ViewModel.DeleteEntry(entry);
		}

		private void Save_Click(object sender, RoutedEventArgs e) {
			if (ViewModel.SaveCurrentEntry())
				SwivelToFrontStoryboard.Begin();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e) {
			ViewModel.CancelChanges();
			SwivelToFrontStoryboard.Begin();
		}
	}
}