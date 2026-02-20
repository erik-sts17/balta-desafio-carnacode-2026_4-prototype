using Prototype.Domain.Documents.Entites;

namespace Prototype.Application.Interfaces
{
    public interface IDocumentTemplateFactory
    {
        DocumentTemplate Create(string templateKey);
    }
}