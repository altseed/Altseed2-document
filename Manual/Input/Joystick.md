# ジョイスティック

[Joystick](xref:Altseed2.Joystick)クラスはジョイスティックコントローラーについての機能を提供します。
コントローラーの検出やコントローラー情報の取得、ボタンやスティックの入力の取得が可能です。

[SDL GameControllerDB](https://github.com/gabomdq/SDL_GameControllerDB)に対応しているコントローラー（およそ数百種類）では、[JoystickButton](xref:Altseed2.JoystickButton)や[JoystickAxis](xref:Altseed2.JoystickAxis)を利用して抽象化されたコントローラーへのアクセスが可能です。

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration))を呼び出した後、`Engine.Joystick` という形でJoystickの各種メソッドを呼び出してください。

Joystickを接続・取り外しした際には、自動的にインデックスが更新されます。

## ジョイスティックの情報の取得
[Engine.Joystick.GetJoystickInfo(int joystickIndex)](xref:Altseed2.Joystick.GetJoystickInfo(System.Int32))を利用して、指定したインデックスのジョイスティックの情報を取得できます。
返り値は[JoystickInfo](xref:Altseed2.JoystickInfo)です。
ジョイスティックが接続されていない場合は`null`を返します。

[JoystickInfo](xref:Altseed2.JoystickInfo)を通して、ジョイスティックの情報を取得できます。

- [IsGamepad](xref:Altseed2.JoystickInfo.IsGamepad): ジョイスティックがGameControllerDBに登録された製品かどうかを取得できます。
- [GamepadName](xref:Altseed2.JoystickInfo.GamepadName): [IsGamepad](xref:Altseed2.JoystickInfo.IsGamepad)が`true`の場合にのみ使えます。GameControllerDBに登録された、わかりやすい名前を取得できます。
- [Name](xref:Altseed2.JoystickInfo.Name): [IsGamepad](xref:Altseed2.JoystickInfo.IsGamepad)が`false`の場合はこちらを利用してください。

また、[Engine.Joystick.IsPresent(int joystickIndex)](xref:Altseed2.Joystick.IsPresent(System.Int32))を利用しても、指定したインデックスにジョイスティックが接続されているかどうかを取得できます。


## ボタン入力の取得

ボタンの取得は以下のメソッドを用いて行います。
第一引数に取得したいジョイスティックコントローラーのインデックスを指定します。
戻り値は[ButtonState](xref:Altseed2.ButtonState)です。

### [GetButtonState(int joystickIndex, JoystickButton button)](xref:Altseed2.Joystick.GetButtonState(System.Int32,Altseed2.JoystickButton))
第2引数に[JoystickButton](xref:Altseed2.JoystickButton)を指定します。
[JoystickInfo](xref:Altseed2.JoystickInfo)の[IsGamepad](xref:Altseed2.JoystickInfo.IsGamepad)が`true`の時のみ利用できます。

### [GetButtonState(int joystickIndex, int buttonIndex)](xref:Altseed2.Joystick.GetButtonState(System.Int32,System.Int32))
第2引数にボタンのインデックスを指定します。

[!code-csharp[Main](../../Src/Samples/Input/JoystickButton.cs)]

## スティック入力の取得

スティックの取得には以下のメソッドを用います。

第一引数に取得したいジョイスティックコントローラーのインデックスを指定します。
戻り値は-1から1の間のfloatです。
取得できる値は、左右スティックの水平方向(LeftX, RightX), 垂直方向(LeftY, RightY)、左右のトリガー(LeftTrigger, RightTrigger)です。

### [GetAxisState(int joystickIndex, JoystickAxis axis)](xref:Altseed2.Joystick.GetAxisState(System.Int32,Altseed2.JoystickAxis))
第２引数に[JoystickAxis](xref:Altseed2.JoystickAxis)を指定します。
[JoystickInfo](xref:Altseed2.JoystickInfo)の[IsGamepad](xref:Altseed2.JoystickInfo.IsGamepad)が`true`の時のみ利用できます。

### [GetAxisState(int joystickIndex, int axisIndex)](xref:Altseed2.Joystick.GetAxisState(System.Int32,System.Int32))
第２引数にスティックのインデックスを指定します。

[!code-csharp[Main](../../Src/Samples/Input/JoystickAxis.cs)]

<!-- 

## 振動

サンプル
[!code-csharp[Main](../../Src/Samples/Input/JoystickVibrate.cs)]

ジョイスティックコントローラーを振動させるには以下のメソッドを使用します。
* [Vibrate](xref:Altseed2.Joystick.Vibrate(System.Int32,System.Single,System.Single))

第1引数は振動させたいジョイスティックコントローラーのインデックスです。
第2引数では振動の周波数を指定します。(40.0 ~ 1252.0)
第3引数では振動の振幅を指定します。(0.0 ~ 1.0)

一度このメソッドを実行すると、5秒程度コントローラーが振動します。
> [!TIP]
> 振動をキャンセルしたい場合は、振幅に0を指定してこのメソッドを実行してください。

[!CAUTION] 
* 周波数は 40.0 から 1252.0 の間に収めてください。これを超える範囲の値は、前述の範囲内の一番近い値に書き換えられます。
* 振幅は 0.0 から 1.0 の範囲内に収めてください。これを超える範囲の値は、前述の範囲内に一番近い値に書き換えられます。
 -->
