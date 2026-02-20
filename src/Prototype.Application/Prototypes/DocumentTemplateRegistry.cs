using Prototype.Domain.Documents.Entites;

namespace Prototype.Application.Prototypes
{
    public class DocumentTemplateRegistry
    {
        private readonly Dictionary<string, DocumentTemplate> _templates = new();

        public void Register(string key, DocumentTemplate template)
        {
            _templates[key] = template;
        }

        public DocumentTemplate Create(string key)
        {
            return _templates[key].Clone();
        }
    }
}