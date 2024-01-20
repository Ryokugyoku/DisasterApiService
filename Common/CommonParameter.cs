namespace DisasterApiService.Common;

public static class CommonParameter{

    /// <summary>
    ///  指定緊急避難所
    /// </summary>
    public static String EmergencyShelterCsvUrl {get;set;}= "https://www.gsi.go.jp/common/000253846.zip";

    /// <summary>
    /// 任意のDiscordトークンを設定する
    /// </summary>
    public static String DiscordToken {get;}= "MTE5NTUyNDYyODU3NjIyNzQ0OA.Gphu_K.4rxKFp8pyoEIDyZpMj9z_E4ZUuuzoXIqRn6pjE";

    /// <summary>
    ///  DiscordのチャットID　
    ///  メッセージを送信したいチャットIDを設定する
    /// </summary>
    public static String TextId {get;}= "1195535329776635976";
}
