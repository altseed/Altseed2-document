// 表示されるテクスチャのサイズを取得
var size = new Vector2F(Texture.Size.X / 9, Texture.Size.Y);

// 表示されるテクスチャの左上の座標を計算する
var pos = new Vector2F(size.X * (count / 2 % 9), size.Y);

// 描画範囲を設定
Src = new RectF(pos, size);

// カウントを進める
count++;

// カウントが18以上で自身を削除
if (count >= 18)
{
    Parent.RemoveChildNode(this);
}