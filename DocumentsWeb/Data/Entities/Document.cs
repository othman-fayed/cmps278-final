using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace DocumentsWeb.Data.Entities
{
    public enum DocumentStatus
    {
        Draft,
        PendingApproval,
        Approved
    }

    public class Document
    {
        public Document()
        {
            Created = DateTime.Now;
            Modified = Created;
        }

        public Document(string name, string content, Workflow workflow, User owner) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; }

        public DocumentStatus Status { get; set; } = DocumentStatus.Draft;

        public User Owner { get; set; }
        public string OwnerId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Approved { get; set; }
    }

    public class Workflow
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<WorkflowStep> Steps { get; set; } = new List<WorkflowStep>();
    }

    public class WorkflowStep
    {
        public int Id { get; set; }
        public int Order { get; set; }

        public WorkflowAction Action { get; set; }
        public string? Value { get; set; }

        public Workflow Workflow { get; set; }
        public int WorkflowId { get; set; }
    }


    public enum WorkflowAction
    {
        SendEmail,
        /// <summary>
        /// Value indicate filter or email
        /// </summary>
        AddReviewer,
        Approve
    }
}