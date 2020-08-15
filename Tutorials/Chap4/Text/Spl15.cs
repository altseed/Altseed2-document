using Altseed2;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
        // コンストラクタ
        public Player(Vector2F position)
        {
            // 座標を設定
            Position = position;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = ContentSize / 2;
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // 移動を実行
            Move();

            // ショットを実行
            Shot();
        }

        // 移動を行う
        void Move()
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
            var halfSize = ContentSize / 2;

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
-               // 発射される自機弾
-               var bullet = new Bullet(Position, new Vector2F(10f, 0f));
-
-               // 自機弾をエンジンに追加
-               Engine.AddNode(bullet);

+               // Zキーでショットを放つ
+               Parent.AddChildNode(new Bullet(Position , new Vector2F(10f, 0f)));
            }
        }
    }
}