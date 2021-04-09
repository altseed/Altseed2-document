# カーソル

[Cursor](xref:Altseed2.Cursor) は カーソルの画像を設定するためのクラスです。


## 基本的な使い方

Altseed2の[Create](xref:Altseed2.Cursor.Create(System.String,Altseed2.Vector2I))を呼び出し、カーソルインスタンスを生成します。
生成したカーソルインスタンスを、Mouseの[Create](xref:Altseed2.Cursor.Create(System.String,Altseed2.Vector2I))に入れてカーソルをセットすると、カーソル画像が変更されます。
> [!NOTE]
> ホットスポットとは、カーソルのクリック判定の出る座標のことです。
> 
> 座標は画像の中の相対座標で指定してください。
> 画像はホットスポットが中心となります。



## Create

サンプル

[!code-csharp[Main](../../Src/Samples/Input/Mouse.cs)]

カーソルインスタンスを生成するメソッドです。
第一引数にカーソルの画像、第二引数にホットスポットを指定します。



戻り値は[ButtonState](xref:Altseed2.Cursor)です。
画像のロードに失敗したときは null を返します。

