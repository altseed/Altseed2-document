# シリアライズ

Altseed2では一部を除き，殆どのクラス・構造体がバイナリシリアライズに対応しています。  

> [!WARNING]
> XMLシリアライズやJsonシリアライズには対応していません。

> [!IMPORTANT]
> Altseed2のバージョンが変わってシリアライズ内容やフィールド情報が変わった場合，デシリアライズに失敗する可能性があります。  
> Altseed2のバージョンを差し替えるときはご注意ください。

## シリアライズ非対応のクラス

以下のクラスはシリアライズに対応していません。  
これらは[Engine](xref:Altseed2.Engine)クラスにてシングルトンとしてインスタンスが提供されているクラスです。

- [BuiltinShader](xref:Altseed2.BuiltinShader)
- [CommandList](xref:Altseed2.CommandList)
- [Easing](xref:Altseed2.Easing)
- [File](xref:Altseed2.File)
- [Glyph](xref:Altseed2.Glyph)
- [Graphics](xref:Altseed2.Graphics)
- [JoyStick](xref:Altseed2.Joystick)
- [JoyStickInfo](xref:Altseed2.JoystickInfo)
- [KeyBoard](xref:Altseed2.Keyboard)
- [Log](xref:Altseed2.Log)
- [Mouse](xref:Altseed2.Mouse)
- [SoundMixer](xref:Altseed2.SoundMixer)
- [Tool](xref:Altseed2.Tool)

## 使い道

- Altseed2を用いたアプリケーションを制作する際にデータの保存や読み込み
- UIのノードを予め作っておいて読み込む

等があります。


## サンプル(シリアライズの手順)

シリアライズには [`System.Runtime.Serialization.Formatters.Binary.BinaryFormatter`](https://docs.microsoft.com/ja-jp/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter?view=netstandard-2.1) を使用します。  
以下に，[StaticFile](xref:Altseed2.StaticFile)のシリアライズを例にシリアライズ/デシリアライズの手順を示します。


[!code-csharp[Sample](../../Src/Samples/Serialization/Serialization.cs)]

結果は以下のようになります。  

```
text1 : Test
text2 : Test
```