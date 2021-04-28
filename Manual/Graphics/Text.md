# 文字

文字を描画するには、
- フォントデータを格納する[Font](xref:Altseed2.Font)
- Fontを使って文字列を描画する[TextNode](xref:Altseed2.TextNode)
を使用します。

## [Font](xref:Altseed2)

フォント情報を格納するクラスです。
実行時にフォント情報を作成する動的フォントと、事前にフォント情報を作成する静的フォントの二種類があります。

- 動的フォント
  - メリット
    - 事前に使用する文字を指定せず、必要に応じて文字情報をフォントファイルから読み込んで追加できる。
  - デメリット
    - 新しい文字を読み込む際に負荷が発生する。
    - フォントの規約によってはゲームに直接フォントファイルを同梱できない場合が多い。
  
- 静的フォント
  - メリット
    - 文字を読み込む負荷が発生しない。
    - フォントファイルを事前に画像に変換するため、フォントファイルを直接同梱する必要がない。
  - デメリット
    - 事前に使用したい文字を指定して静的フォントファイルを生成する必要がある。

### フォントのサイズ

Altseed2 では、フォントの描画に
<a href="https://github.com/Chlumsky/msdfgen" target="_blank" rel="noopener noreferrer">MSDF</a>
を利用しています。

Altseed 初代では利用したいフォントサイズごとに `Font` クラスのインスタンスを作成する必要がありましたが、Altseed2 では読み込み時のサンプリングサイズをある程度大きく指定すれば、好きなサイズでの文字列の描画に利用することができます。

サンプリングサイズとしては、通常は `64` 程度、複雑な形状の文字を利用する場合にはそれ以上の値を指定すると良さそうです。

### 対応フォーマット

Freetypeが対応している以下のフォーマットを利用することができます。

> - TrueType fonts (TTF) and TrueType collections (TTC)
> - CFF fonts
> - WOFF fonts
> - OpenType fonts (OTF, both TrueType and CFF variants) and OpenType collections (OTC)
> - Type 1 fonts (PFA and PFB)
> - CID-keyed Type 1 fonts
> - SFNT-based bitmap fonts, including color Emoji
> - X11 PCF fonts
> - Windows FNT fonts
> - BDF fonts (including anti-aliased ones)
> - PFR fonts
> - Type 42 fonts (limited support)
> 
> https://www.freetype.org/freetype2/docs/index.html


### 動的フォント

[LoadDynamicFont](xref:Altseed2.Font.LoadDynamicFont(System.String,System.Int32))
静的メソッドを用いてフォントファイルを読み込み[Font](xref:Altseed2.Texture2D)インスタンスを作成します。

```csharp
// 動的フォントを読み込む (デフォルトのサンプリングサイズは64)
var font = Font.LoadDynamicFont("path/to/dynamicfont.ttf");

// サンプリングサイズを指定してフォントファイルを読み込む
var fontWithSamplingSize = Font.LoadDynamicFont("path/to/dynamicfont.otf", 96);
```

### 静的フォント

静的フォントを使用する場合は、事前にa2fファイルを作成する必要があります。

GUIを利用したい場合は、 FontGenerator を使って生成することができます。

Altseed2 から直接呼び出したい場合は、
[GenerateFontFile](xref:Altseed2.Font.GenerateFontFile(System.String,System.String,System.String,System.Int32))
静的メソッドを利用して、a2fファイルを生成することができます。

その後、
[LoadStaticFont](xref:Altseed2.Font.LoadStaticFont(System.String))
静的メソッドを用いてa2fファイルを読み込み[Font](xref:Altseed2.Texture2D)インスタンスを作成します。

```csharp
// 事前に生成したa2fファイルから静的フォントを読み込む
var font = Font.LoadStaticFont("path/to/staticfont.a2f");

// コード上から静的フォントを生成したい場合
Font.GenerateFontFile("font.ttf", "font.a2f", "使いたい文字を指定");


// コード上から静的フォントを生成したい場合（サンプリングサイズの指定）
Font.GenerateFontFile("font.ttf", "font96.a2f", "使いたい文字を指定", 96);
```

#### a2fファイル

`font.a2f`を出力先として指定した場合、以下のようなファイルとフォルダが生成されます。

```
font.a2f
font/
├── Texture0.png
├── Texture1.png
├── ...
└── TextureN.png
```

このa2fファイルを使いたい場合は、この相対位置を保って`font.a2f`ファイルと`font`フォルダを同じフォルダに配置する必要があります。

## [TextNode](xref:Altseed2.TextNode)

描画する文字列やそれに適用するオプションなどを設定可能にしたノードです。
描画する文字列、文字列の大きさなどを設定することができます。

## サンプル

### 文字の描画

[!code-csharp][Main](../../Src/Samples/Graphics/Text.cs)]
