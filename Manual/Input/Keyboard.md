# キーボード

[Keyboard](xref:Altseed2.Keyboard) は キーボード入力に関する機能を提供します。


## [Keyboard](xref:Altseed2.Keyboard)

[Keyboard](xref:Altseed2.Keyboard)では次の機能を提供します。
* キーボード入力の取得

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration))を呼び出した後、Engine.Keyboard という形でKeyboardの各種メソッドを呼び出してください。




## キー入力

サンプル

[!code-csharp[Main](../../Src/Samples/Input/Keyboard.cs)]


カーソルの座標の取得・設定は以下のプロパティを通して行います。
* [GetKeyState](xref:Altseed2.Keyboard.GetKeyState(Altseed2.Key))

戻り値は[ButtonState](xref:Altseed2.ButtonState)です。




#### CursorMode
* Normal  ...  デフォルト値
* Hidden  ...  カーソル非表示の状態
* Disable ...  カーソルの入力が無効の状態。カーソルがウィンドウ中央にロックされます。


