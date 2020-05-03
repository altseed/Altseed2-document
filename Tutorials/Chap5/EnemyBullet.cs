using Altseed;

namespace Tutorial
{
    // 敵の弾のクラス
    public class EnemyBullet : Bullet
    {
        // コンストラクタ
        public EnemyBullet(Vector2F position, Vector2F velocity) : base(position, velocity)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Red.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;
        }
    }
}
