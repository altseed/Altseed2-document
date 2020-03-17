# マウス

[Mouse](xref:Altseed.Mouse) は マウス入力に関する基本的な機能を提供します。


## [Mouse](xref:Altseed.Mouse)

[Mouse](xref:Altseed.Mouse)では次の機能を提供します。
* マウスカーソルの座標を取得・設定([カーソル座標](#カーソル座標)を参照)
* マウスボタンの状態を取得([マウスボタン](#マウスボタン)を参照)
* マウスホイールの回転量を取得を取得([マウスホイール](#マウスホイール)を参照)
* カーソルモードの取得または設定([カーソルモード](#カーソルモード)を参照)

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed.Configuration))を呼び出した後、Engine.Mouse という形でMouseの各種メソッドを呼び出してください。
> [!NOTE]
> [MouseButtons](xref:Altseed.MouseButtons)や[ButtonState](xref:Altseed.ButtonState)は
> Mouseには含まれていません。



## カーソル座標

サンプル

[!code-csharp[Main](Mouse.cs)]


カーソルの座標の取得・設定は以下のプロパティを通して行います。
* [Position](xref:Altseed.Mouse.Position

戻り値は[Vector2F](xref:Altseed.Vector2F)です。



## マウスボタン

サンプル

[!code-csharp[Main](Mouse.cs)]

スティックの取得には以下のメソッドを用います。
* [GetMouseButtonState](xref:Altseed.Mouse.GetMouseButtonState(Altseed.MouseButtons))

戻り値は[ButtonState](xref:Altseed.ButtonState)です。



### マウスホイール

サンプル

[!code-csharp[Main](Mouse.cs)]

マウスホイールの回転量を取得するには以下のプロパティを使用します。
* [Wheel](xref:Altseed.Mouse.Wheel)

戻り値は-1~1の範囲の[float](xref:System.Float)です。


### カーソルモード

CursorModeを取得・設定するには、以下のプロパティを使用します。
* [CursorMode](xref:Altseed.Mouse.CursorMode)

カーソルモードの設定は[CursorMode](xref:Altseed.CursorMode)の中から行ってください。

#### CursorMode
* Normal  ...  デフォルト値
* Hidden  ...  カーソル非表示の状態
* Disable ...  カーソルの入力が無効の状態。カーソルがウィンドウ中央にロックされます。


