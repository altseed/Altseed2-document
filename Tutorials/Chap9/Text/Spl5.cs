using Altseed2;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : CollidableObject
    {
        ...略...

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象が敵か敵の弾だったら
            if (obj is Enemy || obj is EnemyBullet)
            {
                // 死亡音を読み込む
                var deathSound = Sound.LoadStrict("Resources/Explosion.wav", true);

                // 死亡音を再生
                Engine.Sound.Play(deathSound);

                // 自身を親から削除
                Parent.RemoveChildNode(this);

+               // ゲームオーバーに遷移
+               mainNode.ToGameOver();
            }
        }

        ...略...