# ジョイスティック

[Joystick](xref:Altseed.Joystick) は ジョイスティックコントローラーについての機能を提供します。 コントローラーの検出やコントローラー名の取得、ボタンやスティックの入力の取得、振動といったことは[Joystick](xref:Altseed.Joystick)で行うことができます。

## 対応状況
JoyCon(R),  JoyCon(L)

## [Joystick](xref:Altseed.Joystick)

[Joystick](xref:Altseed.Joystick)では次の機能を提供します。
* ジョイスティックコントローラーの存在を確認
* ジョイスティックコントローラーのプロダクト名の取得
* ジョイスティックの種類を取得
* ジョイスティックコントローラーのボタン入力の取得
* ジョイスティックコントローラーのスティック入力の取得
* ジョイスティックコントローラーの振動

## 基本的な呼び出し手順

Altseed2の[Initialize](xref:Altseed.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed.Configuration))を呼び出した後、Engine.Joystick という形でJoystickの各種メソッドを呼び出してください。
> [!NOTE]
> [JoystickButtonType](xref:Altseed.JoystickButtonType)や[ButtonState](xref:Altseed.ButtonState)は
> Joystickには含まれていません。


## ボタン入力の取得

サンプル

[!code-csharp[Main](../../Src/Samples/Input/JoystickButton.cs)]

ボタンの取得は以下のメソッドを用いて行います。
* [GetButtonStateByType](xref:Altseed.Joystick.GetButtonStateByType(System.Int32,Altseed.JoystickButtonType))
* [GetButtonStateByIndex](xref:Altseed.Joystick.GetButtonStateByIndex(System.Int32,System.Int32))

### メソッド共通
第一引数に取得したいジョイスティックコントローラーのインデックスを指定します。
戻り値は[ButtonState](xref:Altseed.ButtonState)です。

### [GetButtonStateByType](xref:Altseed.Joystick.GetButtonStateByType(System.Int32,Altseed.JoystickButtonType))
第２引数に[JoystickButtonType](xref:Altseed.JoystickButtonType)を指定します。

### [GetButtonStateByIndex](xref:Altseed.Joystick.GetButtonStateByIndex(System.Int32,System.Int32))
第２引数にボタンのインデックスを指定します。
> [!IMPORTANT]
> ジョイスティックコントローラーのボタンとインデックスの対応はコントローラーごとに異なります。特定のボタンを取得したい場合は[GetAxisStateByIndex](xref:Altseed.Joystick.GetButtonStateByType(System.Int32,Altseed.JoystickButtonType))を使うことをおすすめします。



## スティック入力の取得

サンプル
[!code-csharp[Main](../../Src/Samples/Input/JoystickAxis.cs)]

スティックの取得には以下のメソッドを用います。
* [GetButtonStateByType](xref:Altseed.Joystick.GetButtonStateByType(System.Int32,Altseed.JoystickButtonType))
* [GetButtonStateByIndex](xref:Altseed.Joystick.GetButtonStateByIndex(System.Int32,System.Int32))

### メソッド共通
第一引数に取得したいジョイスティックコントローラーのインデックスを指定します。
戻り値は-1から1の間のfloatです。
取得できる値は、左右スティックの水平方向(LeftH,RightH), 垂直方向(LeftV,RightV)です。

[ButtonState](xref:Altseed.ButtonState)です。

### [GetButtonStateByType](xref:Altseed.Joystick.GetButtonStateByType(System.Int32,Altseed.JoystickButtonType))
第２引数に[JoystickButtonType](xref:Altseed.JoystickAxisType)を指定します。


### [GetButtonStateByIndex](xref:Altseed.Joystick.GetButtonStateByIndex(System.Int32,System.Int32))
第２引数にボタンのインデックスを指定します。




## 振動

サンプル
[!code-csharp[Main](../../Src/Samples/Input/JoystickVibrate.cs)]

ジョイスティックコントローラーを振動させるには以下のメソッドを使用します。
* [Vibrate](xref:Altseed.Joystick.Vibrate(System.Int32,System.Single,System.Single))

第1引数は振動させたいジョイスティックコントローラーのインデックスです。
第2引数では振動の周波数を指定します。(40.0 ~ 1252.0)
第3引数では振動の振幅を指定します。(0.0 ~ 1.0)

一度このメソッドを実行すると、5秒程度コントローラーが振動します。
> [!TIP]
> 振動をキャンセルしたい場合は、振幅に0を指定してこのメソッドを実行してください。

[!CAUTION] 
* 周波数は 40.0 から 1252.0 の間に収めてください。これを超える範囲の値は、前述の範囲内の一番近い値に書き換えられます。
* 振幅は 0.0 から 1.0 の範囲内に収めてください。これを超える範囲の値は、前述の範囲内に一番近い値に書き換えられます。




## ジョイスティックの種類を取得

ジョイスティックの種類を取得するには、以下のメソッドを使用します。
* [GetJoystickType](xref:Altseed.Joystick.GetJoystickType(System.Int32))

第一引数は取得したいジョイスティックコントローラーのインデックスを指定してください。
戻り値は [JoystickType](xref:Altseed.JoystickType) です。



## プロダクト名の取得

プロダクト名の取得を取得するには、以下のメソッドを使用します。
* [GetJoystickName](xref:Altseed.Joystick.GetJoystickName(System.Int32))

プロダクト名を取得したいコントローラーのインデックスを指定してください。
戻り値は System.String です。

## 存在を確認

ジョイスティックコントローラーがAltseedで認識されているか確認するには以下のメソッドを使用します。
* [GetJoystickName](xref:Altseed.Joystick.GetJoystickName(System.Int32))

認識されているか確認したいコントローラーのインデックスを指定してください。
戻り値は bool[xref:Sysytem.Boolean] です。