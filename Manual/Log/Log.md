# ログ
[Log](xref:Altseed2.Log)クラスは、コンソールやファイルにログを出力する機能です。
Altseedの内部で発生したエラーなどはこの機能でコンソールやファイルへ出力されます。

以下のように記述して使用します。

```csharp
Engine.Debug(LogCategory.User, "");
```

[LogLevel](xref:Altseed2.LogLevel)列挙体の名前に応じたメソッドが用意されています。
[Log](xref:Altseed2.Log)クラスの[SetLevel](xref:Altseed2.Log.SetLevel(Altseed2.LogCategory,Altseed2.LogLevel))メソッドを利用して、[LogCategory](xref:Altseed2.LogCategory)別にログを出力時の最低レベルを指定することができます。

コンソールへのログやファイルへのログを有効化するには、[Engine](xref:Altseed2.Engine)の初期化時に渡す[Configuration](xref:Altseed2.Configuration)のプロパティを指定します。

- [ConsoleLoggingEnabled](xref:Altseed2.Configuration.ConsoleLoggingEnabled): コンソールへのログ出力を有効にするかどうか
- [FileLoggingEnabled](xref:Altseed2.Configuration.FileLoggingEnabled): ファイルへのログ出力を有効にするかどうか
- [LogFileName](xref:Altseed2.Configuration.LogFileName): ログ出力する際のファイル名
