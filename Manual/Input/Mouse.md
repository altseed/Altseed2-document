# マウス

[Mouse](xref:Altseed2.Mouse) は マウス入力に関する基本的な機能を提供します。


## [Mouse](xref:Altseed2.Mouse)

[Mouse](xref:Altseed2.Mouse)では次の機能を提供します。
* マウスカーソルの座標を取得・設定
* マウスボタンの状態を取得
* マウスホイールの回転量を取得を取得
* カーソルモードの取得または設定

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration))を呼び出した後、Engine.Mouse という形でMouseの各種メソッドを呼び出してください。
> [!NOTE]
> [MouseButtons](xref:Altseed2.MouseButtons)や[ButtonState](xref:Altseed2.ButtonState)は
> Mouseには含まれていません。



## カーソル座標

サンプル

[!code-csharp[Main](../../Src/Samples/Input/Mouse.cs)]


カーソルの座標の取得・設定は以下のプロパティを通して行います。
* [Position](xref:Altseed2.Mouse.Position

戻り値は[Vector2F](xref:Altseed2.Vector2F)です。



## マウスボタン

サンプル

[!code-csharp[Main](../../Src/Samples/Input/Mouse.cs)]

スティックの取得には以下のメソッドを用います。
* [GetMouseButtonState](xref:Altseed2.Mouse.GetMouseButtonState(Altseed2.MouseButtons))

戻り値は[ButtonState](xref:Altseed2.ButtonState)です。



### マウスホイール

サンプル

[!code-csharp[Main](../../Src/Samples/Input/Mouse.cs)]

マウスホイールの回転量を取得するには以下のプロパティを使用します。
* [Wheel](xref:Altseed2.Mouse.Wheel)

戻り値は-1~1の範囲の[float](xref:System.Single)です。


### カーソルモード

CursorModeを取得・設定するには、以下のプロパティを使用します。
* [CursorMode](xref:Altseed2.Mouse.CursorMode)

カーソルモードの設定は[CursorMode](xref:Altseed2.CursorMode)の中から行ってください。

#### CursorMode
* Normal  ...  デフォルト値
* Hidden  ...  カーソル非表示の状態
* Disable ...  カーソルの入力が無効の状態。カーソルがウィンドウ中央にロックされます。


## カーソル画像

カーソル画像を指定するには、以下のメソッドを使います。
* [SetCursorImage](xref:Altseed2.Mouse.SetCursorImage(Altseed2.Cursor))

第一引数に、設定したい画像を読み込んだ[カーソル](xref:Altseed2.Cursor)オブジェクトを渡します。
