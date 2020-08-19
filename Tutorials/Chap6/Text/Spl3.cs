using Altseed2;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : CollidableObject
    {
        // コンストラクタ
-       public Player(Vector2F position)
+       public Player(MainNode mainNode, Vector2F position) : base(mainNode, position)
        {
-           // 座標を設定
-           Position = position;

+           // 衝突判定を行うように設定
+           doSurvey = true;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

+           // コライダの半径を設定
+           collider.Radius = Texture.Size.Y / 2;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 移動を実行
            Move();

            // ショットを実行
            Shot();

+           // CollidableObjectのOnUpdate呼び出し
+           base.OnUpdate();
        }

        ...略...

    }
}