using Altseed;
using System;

namespace Tutorial
{
    // まっすぐな弾を発射する敵
    public class StraightShotEnemy : Enemy
    {
        // カウンタ
        private int count = 0;

+       // ショット時の効果音
+       private Sound shotSound;

        // コンストラクタ
        public StraightShotEnemy(Player player, Vector2F position) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

            // 半径を設定
            collider.Radius = Texture.Size.X / 2;

            // 倒された時に加算されるスコアを設定
            score = 20;

+           // ショット時の効果音を読み込む
+           shotSound = Sound.LoadStrict("Resources/shot2.wav", true);
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // カウントが150の倍数で実行
            if (count % 150 == 0)
            {
                // プレイヤーに対するベクトルの単位ベクトルを取得
                var velocity = (player.Position - Position).Normal;
                // ベクトルの長さを調整(弾速になる)
                velocity *= 5;

                // 弾を追加
                Shot(velocity);
            }

            // 座標を設定
            Position -= new Vector2F(MathF.Sin(MathHelper.DegreeToRadian(count)) * 3.0f, 0);

            // EnemyのOnUpdateを実行
            base.OnUpdate();

            // カウントを進める
            count++;
        }

        // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
            Parent.AddChildNode(new EnemyBullet(mainNode, Position, velocity));

+           // ショット音を再生
+           Engine.Sound.Play(shotSound);
        }
    }
}
