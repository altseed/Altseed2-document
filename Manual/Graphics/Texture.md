# 画像

画像を描画するには、
- 画像を格納する[Texture2D](xref:Altseed.Texture2D)
- Texture2Dを描画する[SpriteNode](xref:SpriteNode)
を使用します。

## [Texture2D](xref:Altseed.Texture2D)

画像情報を格納するクラスです。
[Load](xref:Altseed.Texture2D.Load(System.String))メソッドを用いて画像ファイルを読み込み[Texture2D](xref:Altseed.Texture2D)インスタンスを作成します。
現在、読み込み可能なフォーマットは、以下の通りです。

- JPEG
- PNG
- TGA
- BMP
- PSD
- GIF
- HDR
- PIC
- PNM

> [!TIP]
> フォーマットによっては、アルファチャンネルに対応していない場合があります。

また、[LoadAsync](xref:Altseed.Texture2D.LoadAsync(System.String))メソッドを用いて、非同期的に画像を読み込むことができます。
非同期読み込みによって、読み込みを待たずに描画処理を行うことができます。

## [SpriteNode](xref:SpriteNode)

描画するテクスチャやそれに適用するオプションを設定可能にしたノードです。描画するテクスチャ、そのテクスチャの切り出し範囲、 ~~反転描画のフラグ~~ などを設定することができます。

## サンプル

### 画像の描画

[!code-csharp[Main](../../Src/Samples/Graphics/Sprite.cs)]