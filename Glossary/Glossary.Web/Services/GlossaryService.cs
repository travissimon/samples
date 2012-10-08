
namespace Glossary.Web.Services {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Data;
	using System.Linq;
	using System.ServiceModel.DomainServices.EntityFramework;
	using System.ServiceModel.DomainServices.Hosting;
	using System.ServiceModel.DomainServices.Server;
	using Glossary.Web;


	// Implements application logic using the GlossaryEntities context.
	// TODO: Add your application logic to these methods or in additional methods.
	// TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
	// Also consider adding roles to restrict access as appropriate.
	// [RequiresAuthentication]
	[EnableClientAccess()]
	public class GlossaryService : LinqToEntitiesDomainService<GlossaryEntities> {

		// TODO:
		// Consider constraining the results of your query method.  If you need additional input you can
		// add parameters to this method or create additional query methods with different names.
		// To support paging you will need to add ordering to the 'GlossaryEntries' query.
		public IQueryable<GlossaryEntry> GetGlossaryEntries() {
			return this.ObjectContext.GlossaryEntries.OrderBy(g => g.Term);
		}

		public void InsertGlossaryEntry(GlossaryEntry glossaryEntry) {
			if ((glossaryEntry.EntityState != EntityState.Detached)) {
				this.ObjectContext.ObjectStateManager.ChangeObjectState(glossaryEntry, EntityState.Added);
			} else {
				this.ObjectContext.GlossaryEntries.AddObject(glossaryEntry);
			}
		}

		public void UpdateGlossaryEntry(GlossaryEntry currentGlossaryEntry) {
			this.ObjectContext.GlossaryEntries.AttachAsModified(currentGlossaryEntry, this.ChangeSet.GetOriginal(currentGlossaryEntry));
		}

		public void DeleteGlossaryEntry(GlossaryEntry glossaryEntry) {
			if ((glossaryEntry.EntityState == EntityState.Detached)) {
				this.ObjectContext.GlossaryEntries.Attach(glossaryEntry);
			}
			this.ObjectContext.GlossaryEntries.DeleteObject(glossaryEntry);
		}
	}
}


