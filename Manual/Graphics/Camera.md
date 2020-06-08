# カメラ

[CameraNode](xref:Altseed.CameraNode)は指定の領域の描画結果を写し撮るノードです。既定では写し撮った領域は画面に描画されます。描画結果を [RenderTexure](xref:Altseed.RenderTexture) として取り出して再利用することもできます。領域の左上座標は [Transform](xref:Altseed.CameraNode.Transform) プロパティで設定できます。

> [!IMPORTANT]
>　エンジンにカメラが一つも登録されていない場合は、暗黙的に存在するデフォルトカメラによって登録されている全ての [DrawnNode](xref:Altseed.DrawnNode) が描画されます。エンジンにカメラが一つでも登録した場合は、デフォルトカメラが無効化されるため、下記[CameraGroup](xref:Altseed.DrawnNode.CameraGroup) プロパティ を適切に設定していない [DrawnNode](xref:Altseed.DrawnNode) は描画されません。

## クリア

[IsColorCleared](xref:Altseed.CameraNode.IsColorCleared) プロパティを設定することで、[CameraNode](xref:Altseed.CameraNode)が描画を開始する前、描画領域をクリアすることができます。その際の色は [ClearColor](xref:Altseed.CameraNode.ClearColor) プロパティで設定できます。クリアを行わないと、前のフレームの描画結果に上書きして描画した結果が得られます。

> [!NOTE]
> 複数のカメラの描画結果を画面に出力する場合、透明な色でクリアすることによって、より下に（先に）出力されるカメラの描画結果も表示することができます。

## Group

各 [DrawnNode](xref:Altseed.DrawnNode) のもつ[CameraGroup](xref:Altseed.DrawnNode.CameraGroup) プロパティはどのカメラの描画対象となるかを指定するものです。
[CameraNode](xref:Altseed.CameraNode) の [Group](xref:Altseed.CameraNode.Group) プロパティが n であるとき、[CameraGroup](xref:Altseed.DrawnNode.CameraGroup) プロパティの下から n ビット目が [DrawnNode](xref:Altseed.DrawnNode) であるような [DrawnNode](xref:Altseed.DrawnNode) を写します。

> [!NOTE]
> [DrawnNode](xref:Altseed.DrawnNode) の値で複数のビットを立てることによって、複数のカメラに[DrawnNode](xref:Altseed.DrawnNode)を写すことができます。
> [CameraNode](xref:Altseed.CameraNode) は [Group](xref:Altseed.CameraNode.Group) プロパティの値に従い降順に描画結果を生成します。これはペイントソフトなどにおけるレイヤーの重ね順のように機能します。

> [!IMPORTANT]
>また[RenderTexure](xref:Altseed.RenderTexture) として取り出して再利用する際は、[Group](xref:Altseed.CameraNode.Group) プロパティの値がより大きいカメラによって写される[DrawnNode](xref:Altseed.DrawnNode)でのみ使用できます。
>[Group](xref:Altseed.CameraNode.Group) プロパティの値が同じかより小さいカメラによって写される[DrawnNode](xref:Altseed.DrawnNode)では、[RenderTexure](xref:Altseed.RenderTexture)への描画がその時点でまだ行われていないため、まだ何も描画されていないか1フレーム前の描画結果が使用されます。

## サンプル

### カメラ

[!code-csharp[Main](../../Src/Samples/Graphics/Camera.cs)]

### RenderTexture

[!code-csharp[Main](../../Src/Samples/Graphics/RenderTexture.cs)]