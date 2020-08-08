using Altseed2;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : CollidableObject
    {
+       // ショット時の効果音
+       private Sound shotSound;

        // コンストラクタ
        public Player(MainNode mainNode, Vector2F position) : base(mainNode, position)
        {
            // 衝突判定を行うように設定
            doSurvey = true;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;

            // コライダの半径を設定
            collider.Radius = Texture.Size.Y / 2;

+           // ショット音を読み込む
+           shotSound = Sound.LoadStrict("Resources/shot1.wav", true);
        }

        // 衝突時に実行
        protected override void OnCollision(CollidableObject obj)
        {
            // 衝突対象が敵か敵の弾だったら
            if (obj is Enemy || obj is EnemyBullet)
            {
                // 自身を親から削除
                Parent.RemoveChildNode(this);
            }
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 移動を実行
            Move();

            // ショットを実行
            Shot();

            // CollidableObjectのOnupdate呼び出し
            base.OnUpdate();
        }

        // 移動を行う
        private void Move()
        {
            // 現在のX座標を取得する
            var x = Position.X;
            // 現在のY座標を取得する
            var y = Position.Y;

            // ↑キーでY座標を減少
            if (Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold)
            {
                y -= 2.5f;
            }

            // ↓キーでY座標を増加
            if (Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold)
            {
                y += 2.5f;
            }

            // →キーでX座標を増加
            if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold)
            {
                x += 2.5f;
            }

            // ←キーでX座標を減少
            if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold)
            {
                x -= 2.5f;
            }

            // テクスチャのサイズの半分を取得する
            var halfSize = Texture.Size / 2;

            // X座標が画面外に行かないように調整
            x = MathHelper.Clamp(x, Engine.WindowSize.X - halfSize.X, halfSize.X);
            // Y座標が画面外に行かないように調整
            y = MathHelper.Clamp(y, Engine.WindowSize.Y - halfSize.Y, halfSize.Y);

            // 調整された座標を設定
            Position = new Vector2F(x, y);
        }

        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Push)
            {
                Parent.AddChildNode(new PlayerBullet(mainNode, Position));

+               // ショット音を鳴らす
+               Engine.Sound.Play(shotSound);
            }
        }
    }
}
