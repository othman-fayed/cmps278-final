using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace DocumentsWeb.Data.Entities
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public Workflow Workflow { get; set; }
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
    }


    public enum WorkflowAction
    {
        SendEmail,
        AddReviewer,
        Approve
    }
}