using Prototype.Domain.Abstractions;

namespace Prototype.Domain.Documents.Entites
{
    public class DocumentStyle : IPrototype<DocumentStyle>
    {
        public string FontFamily { get; set; } = string.Empty;
        public int FontSize { get; set; }
        public string HeaderColor { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public Margins? PageMargins { get; set; }

        public DocumentStyle Clone()
        {
            return new DocumentStyle
            {
                FontFamily = FontFamily,
                FontSize = FontSize,
                HeaderColor = HeaderColor,
                LogoUrl = LogoUrl,
                PageMargins = PageMargins?.Clone()
            };
        }
    }
}