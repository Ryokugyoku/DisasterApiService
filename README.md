# 必要な環境
 DOTNET8　　
 Docker Desktop　　
 任意のエディタ

# 起動前に必要な設定
　マイグレーション作業(下記のコードを実行)　　
　''' dotnet ef database update InitialCreate '''
  DiscordBotの作成・トークンの設定（CommonParameter.cs）
  Discordチャットの送信先チャットIDの設定

# バッチ処理の実行方法
  Hangifireのダッシュボード Recurring Jobsから　daily-job を選択して実行する

> [!CAUTION]
> 11万件近くの登録処理が走ります。途中で処理を中断した場合　DBの削除と再度マイグレーションをしてください