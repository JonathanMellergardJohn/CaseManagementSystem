using System.Collections.Generic;

namespace CaseManagementSystem.Models.Entities
{
    internal class CaseEntity
    {
        // Key
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        // FK to Area table
        public int AreaId { get; set; }
        // FK to Staff table
        public int AgentId { get; set; }
        // FK to Staff table
        public int PrincipalId { get; set; }
        // FK to Status table
        public int StatusId { get; set; }
        // Should potentially be a List of strings, where a new comment
        // adds another item in the list?
        public List<string> Comments { get; set; } = new List<string>();
    }
}
