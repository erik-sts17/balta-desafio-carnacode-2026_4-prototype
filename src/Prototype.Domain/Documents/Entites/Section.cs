using Prototype.Domain.Abstractions;

namespace Prototype.Domain.Documents.Entites
{
    public class Section : IPrototype<Section>
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsEditable { get; set; }
        public List<string> Placeholders { get; set; } = new();

        public Section Clone()
        {
            return new Section
            {
                Name = Name,
                Content = Content,
                IsEditable = IsEditable,
                Placeholders = [.. Placeholders]
            };
        }
    }
}