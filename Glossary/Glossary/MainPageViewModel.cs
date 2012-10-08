using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Glossary.Web.Services;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;
using Glossary.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Windows.Data;

namespace Glossary {
	public class MainPageViewModel : INotifyPropertyChanged {
		GlossaryContext ctx = new GlossaryContext();

		public MainPageViewModel() {
			LoadGlossaryEntries();
		}

		private GlossaryEntry currentEntry = new GlossaryEntry();
		public GlossaryEntry CurrentEntry {
			get { return currentEntry; }
			set {
				if (currentEntry != value) {
					currentEntry = value;
					NotifyPropertyChanged("CurrentEntry");
				}
			}
		}

		public void LoadGlossaryEntries() {
			ctx.Load(ctx.GetGlossaryEntriesQuery(), LoadBehavior.RefreshCurrent, LoadGlossaryEntriesCallback, null);
		}

		private void LoadGlossaryEntriesCallback(LoadOperation operation) {
			PagedCollectionView pcv = new PagedCollectionView(ctx.GlossaryEntries);
			pcv.SortDescriptions.Add(new SortDescription("Term", ListSortDirection.Ascending));
			Entries = pcv;
		}

		public void CreateNewEntry() {
			GlossaryEntry entry = new GlossaryEntry();
			ctx.GlossaryEntries.Add(entry);
			CurrentEntry = entry;
		}

		public void EditEntry(GlossaryEntry entry) {
			CurrentEntry = entry;
		}

		private bool hasErrors = false;
		public bool CurrentEntryHasValidationErrors {
			get { return hasErrors; }
			set {
				if (hasErrors != value) {
					hasErrors = value;
					NotifyPropertyChanged("CurrentEntryHasValidationErrors");
				}
			}
		}

		private List<ValidationResult> validationErrors = new List<ValidationResult>();
		public List<ValidationResult> ValidationErrors {
			get { return validationErrors; }
			set {
				if (validationErrors != value) {
					validationErrors = value;
					CurrentEntryHasValidationErrors = (validationErrors != null && validationErrors.Count > 0);
					NotifyPropertyChanged("ValidationErrors");
				}
			}
		}

		// returns true if Save is successful
		public bool SaveCurrentEntry() {
			bool successful = false;
			List<ValidationResult> results = new List<ValidationResult>();
			if (Validator.TryValidateObject(CurrentEntry, new ValidationContext(CurrentEntry, null, null), results)) {
				ctx.SubmitChanges(ChangeCallback, null);
				Entries.Refresh();
				NotifyPropertyChanged("Entries");
				successful = true;
			}
			ValidationErrors = results;
			return successful;
		}

		private void ChangeCallback(SubmitOperation operation) {
		}

		public void DeleteEntry(GlossaryEntry entry) {
			ctx.GlossaryEntries.Remove(entry);
			ctx.SubmitChanges(DeleteCallback, null);
		}

		private void DeleteCallback(SubmitOperation operation) {
		}

		public void CancelChanges() {
			ValidationErrors = new List<ValidationResult>();
			ctx.RejectChanges();
		}

		private PagedCollectionView entries = null;
		public PagedCollectionView Entries {
			get { return entries; }
			set {
				entries = value;
				NotifyPropertyChanged("Entries");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null)
				PropertyChanged(null, new PropertyChangedEventArgs(propertyName));
		}
	}
}
