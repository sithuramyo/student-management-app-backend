namespace Infrastructures.DataModels.Communications;

public class ChatRoom : BaseDataModel
{
    public string Name { get; set; } = string.Empty;         // Group name or blank for 1:1
    public bool IsGroup { get; set; } = false;               // Distinguish group vs direct
}