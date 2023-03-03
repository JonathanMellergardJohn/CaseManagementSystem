using System.Collections.Generic;

namespace CaseManagementSystem.Models.Entities
{
    public class CaseEntity
    {
        // Key
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        // FK to Area table
        public int AreaId { get; set; }
        public AreaEntity Area { get; set; } = null!;
        // FK to Staff table
        public int AgentId { get; set; }
        public StaffEntity Agent { get; set; } = null!;
        // FK to Staff table
        public int PrincipalId { get; set; }
        public StaffEntity Principal { get; set; } = null!;
        // FK to Status table
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;
        // Should potentially be a List of strings, where a new comment
        // adds another item in the list?
        public string Comments { get; set; } = string.Empty;
    }
}
