using Prototype.Domain.Abstractions;

namespace Prototype.Domain.Documents.Entites
{
    public class ApprovalWorkflow : IPrototype<ApprovalWorkflow>
    {
        public List<string> Approvers { get; set; } = [];
        public int RequiredApprovals { get; set; }
        public int TimeoutDays { get; set; }

        public ApprovalWorkflow Clone()
        {
            return new ApprovalWorkflow
            {
                RequiredApprovals = RequiredApprovals,
                TimeoutDays = TimeoutDays,
                Approvers = [.. Approvers]
            };
        }
    }
}