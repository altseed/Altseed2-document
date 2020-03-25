
# ノード

Altseed2では、ゲームに登場する*キャラクター等のオブジェクト*、及び*オブジェクトが持つ機能*等をノードとして管理します。
例えばゲームに画像を表示する際には、描画機能を持ったノード([SpriteNode](xref:Altseed.SpriteNode))をエンジンに追加します。

ノードは親子関係の階層構造を持ちます。また、ノードはエンジンに実装されているものを使うだけでなく、独自に継承・拡張して利用することができます。

> [!NOTE]
> 初代Altseedにおけるシーンやレイヤーはノード機能にまとめられました。
> 同様の感覚で利用したい場合、Nodeクラスを継承したSceneクラスやLayerクラスを自作すると良いでしょう。  
> また、Unity等でも用いられているコンポーネントの機能もノードによって実現できます。

> [!TIP]
> 便宜上ノードの追加・削除という表現をしていますが、ノードインスタンスの作成・削除とは直接関係が有りません。
> 必要に応じて、登録・登録解除と読み替えてください。

## [Node](xref:Altseed.Node)

[Node](xref:Altseed.Node) は全てのノードの基本です。全てのノードはこのNodeを継承する必要があります（もちろん [SpriteNode](xref:Altseed.SpriteNode) 等のNodeを継承したクラスをさらに継承しても構いません）。  
使い道は主に以下の二つです。

- ノードを自作する場合に、継承して使う。
- 複数のノードをまとめて管理したい場合に、親ノードとして利用する。

エンジンへの追加は[Engine.AddNode](xref:Altseed.Engine.AddNode(Altseed.Node))メソッドを使います。逆に削除したい場合は、[Engine.RemoveNode](xref:Altseed.Engine.RemoveNode(Altseed.Node))メソッドを使います。  
親子関係の追加・削除も同様に、[AddChildNode](xref:Altseed.Node.AddChildNode(Altseed.Node))メソッド、[RemoveChildNode](xref:Altseed.Node.RemoveChildNode(Altseed.Node))メソッドを使います。

> [!IMPORTANT]
> ノードは作成だけしても、エンジンに登録されていなければ**更新されません**。  
> また、親ノードがエンジンに追加されている場合、子ノードも自動的に更新対象になります。

> [!NOTE]
> Nodeを新たに追加しても、親子構造が反映されるのは次の更新処理時（＝1フレーム後）になります。



## サンプル

### Nodeの作成と親子関係の構築

[!code-csharp[Main](../../Src/Samples/CreatingNode.cs)]