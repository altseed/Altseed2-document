using Altseed;

namespace Tutorial
{
    // 死亡時エフェクト
    public class DeathEffect : SpriteNode
    {
        // カウンタ
        private int count = 0;

        // コンストラクタ
        public DeathEffect(Vector2F position)
        {
            // 座標を設定
            Position = position;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Explosion.png");

            // 中心座標を設定
            CenterPosition = new Vector2F(32f, 32f);

            // 表示位置をプレイヤーや敵よりも手前に設定
            ZOrder++;

            // テクスチャの描画範囲を設定
            Src = new RectF(new Vector2F(), new Vector2F(Texture.Size.X / 9, Texture.Size.Y));
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
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
        }
    }
}