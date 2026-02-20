using Prototype.Domain.Abstractions;

namespace Prototype.Domain.Documents.Entites
{
    public class DocumentTemplate : IPrototype<DocumentTemplate>
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<Section> Sections { get; set; } = [];
        public DocumentStyle? Style { get; set; }    
        public List<string> RequiredFields { get; set; } = [];
        public Dictionary<string, string> Metadata { get; set; } = [];
        public ApprovalWorkflow? Workflow { get; set; }
        public List<string> Tags { get; set; } = [];

        public DocumentTemplate Clone()
        {
            return new DocumentTemplate
            {
                Title = Title,
                Category = Category,
                Style = Style?.Clone(),
                Workflow = Workflow?.Clone(),
                Sections = Sections.Select(s => s.Clone()).ToList(),
                RequiredFields = [.. RequiredFields],
                Tags = [.. Tags],
                Metadata = new Dictionary<string, string>(Metadata)
            };
        }
    }
}
