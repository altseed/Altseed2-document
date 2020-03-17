# ログ
[Log](xref:Altseed.Log)クラスは、コンソールやファイルにログを出力する機能です。
Altseedの内部で発生したエラーなどはこの機能でコンソールやファイルへ出力されます。

以下のように記述して使用します。

```csharp
Engine.Debug(LogCategory.User, "");
```

[LogLevel](xref:Altseed.LogLevel)列挙体の名前に応じたメソッドが用意されています。
[Log](xref:Altseed.Log)クラスの[SetLevel](xref:Altseed.Log.SetLevel(Altseed.LogCategory,Altseed.LogLevel))メソッドを利用して、[LogCategory](xref:Altseed.LogCategory)別にログを出力時の最低レベルを指定することができます。

コンソールへのログやファイルへのログを有効化するには、[Engine](xref:Altseed.Engine)の初期化時に渡す[Configuration](xref:Altseed.Configuration)のプロパティを指定します。

- [ConsoleLoggingEnabled](xref:Altseed.Configuration.ConsoleLoggingEnabled): コンソールへのログ出力を有効にするかどうか
- [FileLoggingEnabled](xref:Altseed.Configuration.FileLoggingEnabled): ファイルへのログ出力を有効にするかどうか
- [LogFileName](xref:Altseed.Configuration.LogFileName): ログ出力する際のファイル名
