using System;
namespace MerchApp.Models
{
	public class TicketsCount
	{
		public int IssueID { get; set; }
		public int Priority { get; set; }
		public int StatusID { get; set; }
		public string IssueDate { get; set; }
		public string Subject { get; set; }
		public string Status { get; set; }
		public bool UpdatedByUser { get; set; }
		public bool UpdatedByPerformer { get; set; }
		public int CategoryID { get; set; }
		public string UserName { get; set; }
		public string Technician { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public object DueDate { get; set; }
		public string TechFirstName { get; set; }
		public string TechLastName { get; set; }
		public string LastUpdated { get; set; }
		public bool UpdatedForTechView { get; set; }
		public int UserID { get; set; }
		public int CompanyID { get; set; }
		public string CompanyName { get; set; }
		public int AssignedToUserID { get; set; }
		public string ResolvedDate { get; set; }
		public int SectionID { get; set; }
		public string Category { get; set; }
		public string Origin { get; set; }
		public string Email { get; set; }
	}
}
