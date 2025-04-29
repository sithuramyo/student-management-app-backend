using Shares.Models.Communications;

namespace Cores.Features.Communications;

public interface IChatService
{
    Task<ApiResponse<List<UsersResponseModel>>> GetChatUsersAsync(string search, string currentUserId);
    Task<ApiResponse<List<ChatRoomResponseModel>>> GetChatRooms(string userId);
    Task<ApiResponse<List<ChatMessageResponseModel>>> GetChatMessages(string userId, string roomId, int page, int pageSize);
    Task<ApiResponse<CreateChatRoomResponseModel>> CreateChatRoom(CreateChatRoomRequestModel request, string creatorUserId);
    Task<ApiResponse<SendMessageResponse>> SendMessage(string senderId, SendMessageRequest request);
    Task<ApiResponse<UserPresenceResponseModel>> GetUserPresence(string userId);
    Task<ApiResponse<List<UserStatusResponseModel>>> GetParticipantsStatus(string roomId, string currentUserId);
}