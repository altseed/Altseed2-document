------added start------

using Altseed;

namespace Tutorial
{
    // 放射ショットの敵
    public class RadialShotEnemy : Enemy
    {
        // カウンタ変数
        private int count = 0;

        // 撃ち出すショットの個数
        private int shotAmount;

        // フレーム毎の速度
        private Vector2F velocity;

        // コンストラクタ
        public RadialShotEnemy(Player player, Vector2F position, int shotAmount) : base(player, position)
        {
            // 撃ち出すショットの個数を設定
            this.shotAmount = shotAmount;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // スコアを設定
            score = 30;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // カウントが250の倍数だったら
            if (count % 250 == 0)
            {
                // 計算用のローカル変数
                var half = shotAmount / 2;

                for (int i = 0; i < shotAmount; i++)
                {
                    // 現時点の座標からプレイヤーに向かうベクトルの単位ベクトルを取得する
                    var vector = (player.Position - Position).Normal;

                    // ベクトルを速度分掛ける
                    vector *= 7.0f;

                    // ベクトルを傾ける
                    vector.Degree += 30 * (i - half);

                    // ショットを放つ
                    Shot(vector);
                }
            }

            // カウント÷100の余りが0～49だったら
            if (count % 100 < 50)
            {
                // カウント÷100の余りが0だったら
                if (count % 100 == 0)
                {
                    // 進むベクトルを設定
                    velocity = (player.Position - Position).Normal * 3.0f;
                }

                // 速度分ベクトルを設定
                Position += velocity;
            }

            // EnemyクラスのOnUpdateを呼び出す
            base.OnUpdate();

            // カウントを進める
            count++;
        }

        // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
            Parent.AddChildNode(new EnemyBullet(Position, velocity));
        }
    }
}

------added end------