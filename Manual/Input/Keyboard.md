# キーボード

[Keyboard](xref:Altseed.Keyboard) は キーボード入力に関する基本的な機能を提供します。


## [Keyboard](xref:Altseed.Keyboard)

[Keyboard](xref:Altseed.Keyboard)では次の機能を提供します。
* キーボード入力の取得([キー入力](#キー入力)を参照))

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed.Configuration))を呼び出した後、Engine.Keyboard という形でKeyboardの各種メソッドを呼び出してください。
> [!NOTE]
> [MouseButtons](xref:Altseed.MouseButtons)や[ButtonState](xref:Altseed.ButtonState)は
> Mouseには含まれていません。



## キー入力

サンプル

[!code-csharp[Main](Keyboard.cs)]


カーソルの座標の取得・設定は以下のプロパティを通して行います。
* [GetKeyState](xref:Altseed.Keyboard.GetKeyState

戻り値は[ButtonState](xref:Altseed.ButtonState)です。




#### CursorMode
* Normal  ...  デフォルト値
* Hidden  ...  カーソル非表示の状態
* Disable ...  カーソルの入力が無効の状態。カーソルがウィンドウ中央にロックされます。


