# カメラ

[CameraNode](xref:Altseed2.CameraNode)は指定の領域の描画結果を写し撮るノードです。既定では写し撮った領域は画面に描画されます。[CameraNode](xref:Altseed2.CameraNode)が撮影する領域は[Angle](xref:Altseed2.CameraNode.Angle)、[CenterPosition](xref:Altseed2.CameraNode.CenterPosition)、[Position](xref:Altseed2.CameraNode.Position)、[Scale](xref:Altseed2.CameraNode.Scale) プロパティを用いることで設定できます。

> [!NOTE]
> 既定では、[CameraNode](xref:Altseed2.CameraNode)が撮影する領域は、点 (0, 0) を左上とする、[ウインドウサイズ](xref:Altseed2.Engine.WindowSize)と同じ大きさ（[TargetTexture](xref:Altseed2.CameraNode.TargetTexture)を設定した場合はその[大きさ](xref:Altseed2.TextureBase.Size)）の長方形の領域です。上記の各種プロパティを設定することで、この長方形を変形することで撮影する領域を調整すると考えるとよいです。

描画結果を [RenderTexure](xref:Altseed2.RenderTexture) として取り出して再利用することもできます。[Material](xref:Altseed2.Material) などを付けて再描画することができます。

> [!IMPORTANT]
>　エンジンにカメラが一つも登録されていない場合は、暗黙的に存在するデフォルトカメラによって登録されている描画できる全てのノードが描画されます。しかし **エンジンにカメラが一つでも登録した場合は、デフォルトカメラが無効化されるため、下記の[CameraGroup](xref:Altseed2.SpriteNode.CameraGroup) プロパティを適切に設定していないノードは描画されません。**

## クリア

[IsColorCleared](xref:Altseed2.CameraNode.IsColorCleared) プロパティを設定することで、[CameraNode](xref:Altseed2.CameraNode)が描画を開始する前、描画領域をクリアすることができます。その際の色は [ClearColor](xref:Altseed2.CameraNode.ClearColor) プロパティで設定できます。クリアを行わないと、前のフレームの描画結果に上書きして描画した結果が得られます。

> [!NOTE]
> 複数のカメラの描画結果を画面に出力する場合、透明な色でクリアすることによって、より下に（先に）出力されるカメラの描画結果も表示することができます。

## グループ

[SpriteNode](xref:Altseed2.SpriteNode) や [PostEffectNode](xref:Altseed2.PostEffectNode) のような描画できるノードが持っている[CameraGroup](xref:Altseed2.SpriteNode.CameraGroup) プロパティは、どのカメラの描画によって描画されるかを指定するものです。
描画の対象となる[CameraGroup](xref:Altseed2.SpriteNode.CameraGroup)は、[CameraNode](xref:Altseed2.CameraNode)クラスが持つ[Group](xref:Altseed2.CameraNode.Group) プロパティと、 [CameraGroup](xref:Altseed2.SpriteNode.CameraGroup) プロパティの AND 演算の結果が 0 以外である場合、描画します。

> [!NOTE]
> [CameraNode](xref:Altseed2.CameraNode) は [Group](xref:Altseed2.CameraNode.Group) プロパティの値に従い **降順** に描画結果を生成します。これはペイントソフトなどにおけるレイヤーの重ね順のように機能します。

> [!IMPORTANT]
> 上記の通り、画面もしくは[RenderTexure](xref:Altseed2.RenderTexture) への描画は[Group](xref:Altseed2.CameraNode.Group) プロパティの値に従い **降順** に行われます。[RenderTexure](xref:Altseed2.RenderTexture)への描画結果を[SpriteNode](xref:Altseed2.SpriteNode)などで再利用する場合、その[SpriteNode](xref:Altseed2.SpriteNode)は[RenderTexure](xref:Altseed2.RenderTexture)への描画を行った[CameraGroup](xref:Altseed2.SpriteNode.CameraGroup)よりも[Group](xref:Altseed2.CameraNode.Group) プロパティの値がより大きい[CameraGroup](xref:Altseed2.SpriteNode.CameraGroup)によって撮影する場合のみ正常に描画されます。[Group](xref:Altseed2.CameraNode.Group) プロパティの値が同じか、より小さい[CameraNode](xref:Altseed2.CameraNode)によって撮影しようとした場合、[RenderTexure](xref:Altseed2.RenderTexture) への描画がその時点でまだ行われていないため、何も描画されていないか1フレーム前の描画結果を使用して描画が行われます。

## サンプル

### カメラ

[!code-csharp[Main](../../Src/Samples/Graphics/Camera.cs)]

### RenderTexture

[!code-csharp[Main](../../Src/Samples/Graphics/RenderTexture.cs)]