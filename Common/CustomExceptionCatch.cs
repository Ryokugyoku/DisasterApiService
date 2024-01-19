using System.Net;
using DisasterApiService.Common;
public class CustomExceptionCatch{
    private readonly RequestDelegate _next;

    public CustomExceptionCatch(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // 例外が発生した場合に実行する処理
            await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"内部エラー発生："+ex);
        }
    }
}