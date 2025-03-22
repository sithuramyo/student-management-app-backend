namespace Infrastructures.DataModels.Communications;

public class Notification : BaseDataModel
{
    public string UserId { get; set; }                 // Recipient user (Student or Faculty)
    public string Title { get; set; }                // e.g., "Enrollment Approved"
    public string Message { get; set; }              // Detailed content
    public string? Type { get; set; }                // Info, Warning, Alert, GradeUpdate, etc.
    public bool IsRead { get; set; } = false;        // Read status
    public DateTime SentAt { get; set; } = DateTime.Now;

    // Optionally link to a specific object (like a Course or GradeReport)
    public string? RelatedEntityId { get; set; }
    public string? RelatedEntityType { get; set; }   // e.g., "Course", "Enrollment", "GradeReport"
}