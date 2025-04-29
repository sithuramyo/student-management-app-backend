using Cores.Features.Communications;
using Shares.Models.Communications;

namespace Interfaces.Features.Communications;

public class ChatController(IChatService service) : BaseController
{
    [HttpGet("chat-users")]
    [ProducesResponseType(typeof(ApiResponse<List<UsersResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers([FromQuery] string search = "")
    {
        var currentUserId = GetCurrentUserId();
        var result = await service.GetChatUsersAsync(search, currentUserId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("rooms")]
    [ProducesResponseType(typeof(ApiResponse<List<ChatRoomResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetChatRooms()
    {
        var userId = GetCurrentUserId();
        var result = await service.GetChatRooms(userId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("room/{roomId}/messages")]
    [ProducesResponseType(typeof(ApiResponse<List<ChatMessageResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetChatRoom(string roomId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userId = GetCurrentUserId();
        var result = await service.GetChatMessages(userId, roomId, page, pageSize);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost("room")]
    [ProducesResponseType(typeof(ApiResponse<CreateChatRoomResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateChatRoom(ApiRequest<CreateChatRoomRequestModel> request)
    {
        var currentUserId = GetCurrentUserId();
        var result = await service.CreateChatRoom(request.Request, currentUserId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpPost("send")]
    [ProducesResponseType(typeof(ApiResponse<SendMessageResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendMessage(ApiRequest<SendMessageRequest> request)
    {
        var currentUserId = GetCurrentUserId();
        var result = await service.SendMessage(currentUserId, request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }

    [HttpGet("user-presence/{userId}")]
    [ProducesResponseType(typeof(ApiResponse<UserPresenceResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserPresence(string userId)
    {
        var result = await service.GetUserPresence(userId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }


    [HttpGet("room/{roomId}/participants-status")]
    [ProducesResponseType(typeof(ApiResponse<List<UserStatusResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetParticipantsStatus(string roomId)
    {
        var currentUserId = GetCurrentUserId();
        var result = await service.GetParticipantsStatus(roomId, currentUserId);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }


}