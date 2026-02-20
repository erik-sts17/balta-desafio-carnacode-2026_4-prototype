using Prototype.Application.Prototypes;
using Prototype.Domain.Documents.Entites;
using System.Diagnostics;

namespace Prototype.Application.Services
{
    public class DocumentService 
    {
        public void GenerateWithPrototype() 
        {
            var registry = new DocumentTemplateRegistry();

            Load(registry);

            Console.WriteLine("Gerando 5 contratos a partir do prototype...\n");

            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= 5; i++)
            {
                var contract = registry.Create("service-contract");

                contract.Title = $"Contrato #{i} - Cliente {i}";
                contract.Metadata["Cliente"] = $"Cliente {i}";
                Console.WriteLine($"Criado: {contract.Title}");
            }

            stopwatch.Stop();
            Console.WriteLine($"\nTempo total com Prototype: {stopwatch.ElapsedMilliseconds}ms\n");
        }

        public void GenerateWithoutPrototype()
        {
            Console.WriteLine("Gerando 5 contratos SEM Prototype...\n");

            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= 5; i++)
            {
                // simula uma chamada externa por contrato
                var registry = new DocumentTemplateRegistry();
                Load(registry);

                var contract = registry.Create("service-contract");

                contract.Title = $"Contrato #{i} - Cliente {i}";
                contract.Metadata["Cliente"] = $"Cliente {i}";

                Console.WriteLine($"Criado: {contract.Title}");
            }

            stopwatch.Stop();
            Console.WriteLine($"\nTempo total SEM Prototype: {stopwatch.ElapsedMilliseconds}ms\n");
        }

        //Simula retorno do objeto, pode ser chamada http, repository
        public static void Load(DocumentTemplateRegistry registry)
        {
            Console.WriteLine("Inicializando templates complexos\n");

            Thread.Sleep(100); 

            var template = new DocumentTemplate
            {
                Title = "Contrato de Prestação de Serviços",
                Category = "Contratos",
                Style = new DocumentStyle
                {
                    FontFamily = "Arial",
                    FontSize = 12,
                    HeaderColor = "#003366",
                    LogoUrl = "https://company.com/logo.png",
                    PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
                },
                Workflow = new ApprovalWorkflow
                {
                    RequiredApprovals = 2,
                    TimeoutDays = 5
                }
            };

            template.Workflow.Approvers.Add("gerente@empresa.com");
            template.Workflow.Approvers.Add("juridico@empresa.com");

            template.Sections.Add(new Section
            {
                Name = "Cláusula 1 - Objeto",
                Content = "O presente contrato tem por objeto...",
                IsEditable = true
            });

            template.Sections.Add(new Section
            {
                Name = "Cláusula 2 - Prazo",
                Content = "O prazo de vigência será de...",
                IsEditable = true
            });

            template.Sections.Add(new Section
            {
                Name = "Cláusula 3 - Valor",
                Content = "O valor total do contrato é de...",
                IsEditable = true
            });

            template.RequiredFields.Add("NomeCliente");
            template.RequiredFields.Add("CPF");
            template.RequiredFields.Add("Endereco");

            template.Tags.Add("contrato");
            template.Tags.Add("servicos");

            template.Metadata["Versao"] = "1.0";
            template.Metadata["Departamento"] = "Comercial";
            template.Metadata["UltimaRevisao"] = DateTime.Now.ToString();

            registry.Register("service-contract", template);
        }
    }
}