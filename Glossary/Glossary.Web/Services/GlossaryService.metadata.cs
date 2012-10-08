
namespace Glossary.Web {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.ServiceModel.DomainServices.Hosting;
	using System.ServiceModel.DomainServices.Server;


	// The MetadataTypeAttribute identifies GlossaryEntryMetadata as the class
	// that carries additional metadata for the GlossaryEntry class.
	[MetadataTypeAttribute(typeof(GlossaryEntry.GlossaryEntryMetadata))]
	public partial class GlossaryEntry {

		// This class allows you to attach custom attributes to properties
		// of the GlossaryEntry class.
		//
		// For example, the following marks the Xyz property as a
		// required property and specifies the format for valid values:
		//    [Required]
		//    [RegularExpression("[A-Z][A-Za-z0-9]*")]
		//    [StringLength(32)]
		//    public string Xyz { get; set; }
		internal sealed class GlossaryEntryMetadata {

			// Metadata classes are not meant to be instantiated.
			private GlossaryEntryMetadata() {
			}

			public string Definition { get; set; }

			public int Id { get; set; }

			public string Term { get; set; }
		}
	}
}
